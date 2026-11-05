# データベースの読込・保存

本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

対象: CSManager master `e081e9d`（サブモジュール Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`）。
略記: CDC = `Crystallography.Controls/CrystalDatabase/CrystalDatabaseControl.cs`、FM = `CSManager/FormMain.cs`、C2 = `Crystallography/Crystal/CrystalMinimum.cs`（`Crystal2`）。

## データの置き場所

- `UserAppDataPath` = `Application.UserAppDataPath` の親フォルダ（版番号を含まない）（FM `UserAppDataPath`、CDC 同名プロパティ）。csproj に `Company`/`Product` 指定が無いため、SDK 既定なら `%APPDATA%\CSManager\CSManager\`（要確認）。
- 起動ごとに、実行フォルダの `AMCSD.cdb3` を `UserAppDataPath\AMCSD.cdb3` へ**上書きコピー**する（FM `FormMain_Load`）。続けて `UserAppDataPath` 直下の空フォルダを削除し、版番号付きの `Application.UserAppDataPath` フォルダを再帰削除する。
- AMCSD は `UserAppDataPath\AMCSD.cdb3`、COD は `UserAppDataPath\COD.cdb3`（ヘッダ）と `UserAppDataPath\COD\COD.000`… を読む（CDC `AMCSD_CheckedChanged` 相当のハンドラ、`ReadCOD`）。

## 結晶リスト上部の `AMCSD` / `COD` チェックボックス

結晶リストの上に `AMCSD` と `COD` のチェックボックスがある（`checkBoxAMCSD` / `checkBoxCOD`、CSManager では `DatabaseSelection = true`、既定は両方オフ）。`ファイル` メニューの `AMCSD データベースを読込` / `CODデータベースを読込` は、このチェックをオンにするだけである（FM `toolStripMenuItemReadDefault1_Click` / `…2_Click`）。チェックボックスには 2 つの役割がある。

1. **初回オンで読み込み**
    - AMCSD: 未読なら `ReadDatabase(AMCSD.cdb3)` を開始する（完了は待たない）。
    - COD: 未読なら `ReadCOD()`（下記）を呼び、完了まで待つ。失敗なら（`false` が返ると）チェックを外す。
2. **表示フィルタ**: チェック変更のたびに `DataBaseChanged` が発生し、検索パネルが再検索する。データ種別が AMCSD のレコードは `AMCSD` オフで、COD のレコードは `COD` オフで非表示になる。データ種別 None（ユーザーが追加した結晶、単一 CIF/AMC インポート、XML インポート）は常に表示（`SearchCrystalControl` の検索ワーカー）。オフにしてもメモリからは消えない。

データ種別（`Crystal2.datatype`）: 0 = None、1 = AMCSD、2 = COD。

## COD のダウンロードと更新確認（CDC `ReadCOD`）

1. ローカルの `COD.cdb3` ヘッダを読み、分割ファイル**全部**の MD5 をヘッダ記録値と照合する（`CheckDatabaseFiles(…, checkMD5: true)`）。COD をオンにするたびに約 885 MB をハッシュするので、時間がかかる。
2. 照合 OK なら、`https://github.com/seto77/CSManager/raw/master/COD/COD.cdb3`（585 バイトのヘッダ）を取得してローカルとバイト比較する。
    - 同一 → ローカルを読む。
    - 異なる → 「Now, new database is available. / Download and load the new database: YES / Use the current database: No / Cancel database loading: Cancel」。`Yes` で再ダウンロード、`No` で現行版を読む、`Cancel` で中止。
3. 通信例外（オフラインなど）→ ローカルを読む。
4. ローカルが無い・不正 → 「Local COD database is missing. Do you download the new database now ?」（Yes/No）。
5. ダウンロードでは `COD.cdb3` を保存した後、分割ファイル（現行 24 個、`COD.000`〜`COD.023`、各 35〜40 MB、計 885,018,299 バイト）を**全部並列**で取得する。`HttpClient` のタイムアウトは 600 秒。進捗は「Downloading COD database (x MB / y MB) ...」。
6. 失敗時は「Failed to download new COD database. Sorry.」。ダウンロード後の MD5 再照合は行わない。

!!! warning
    現行コードでは、手順 2 で `No` を選ぶと読み込みは始まるのにチェックが外れ、COD の行が非表示になる。もう一度オンにすると二重に読み込まれる。[実装上の疑問点](90-implementation-questions.md) Q4。

## `データベースを読込` / `データベースを保存` / `データベースをクリア`

- **読込**（CDC `ReadDatabase`）: 拡張子が `cdb3` で終わるファイルだけを読み、現在の表の末尾に**追加**する（置換・重複チェックはしない）。ファイルダイアログは `*.cdb; *.cdb2; *.cdb3` を表示するが、`.cdb` / `.cdb2` は何もせず無視される。複数選択はできるが、読み込みワーカーが動いている間の呼び出しは捨てられるため、実際に読まれるのは最初の 1 ファイルだけ（Q5）。
- **保存**（CDC `SaveDatabase`）: `*.cdb3` で書く。保存順は現在の表示順（ソート順）。35,000,000 バイトを超えると分割形式（下記）になる。
    - 検索で絞り込んでいる、または `AMCSD` / `COD` のどちらかがオフの状態で保存すると、現行コードでは中身が空のファイルになる（Q2）。保存前に条件を解除し、両方オンにしておくこと。
- **クリア**（CDC `ClearAll`）: 表を空にするだけ。ファイルは消えない。読み込み済みフラグとチェックボックスは戻らないので、同じセッションで `AMCSD` / `COD` を読み直すことはできない（Q3）。必要なら再起動する。

## cdb3 ファイル形式（CDC `ReadDatabaseWorker` / `SaveDatabaseWorker`）

| 位置 | 内容 |
|---|---|
| 1 バイト | 形式フラグ。100 = 単一ファイル、200 = 分割 |
| int32 | レコード総数 |

- **単一（100）**: `[int32 長さ L][L バイト]` のチャンクが続く。各チャンクは `Crystal2[]`（最大 2500 件）を MemoryPack でシリアライズし、Brotli（`SmallestSize`、window 24）で圧縮したもの。同梱 `AMCSD.cdb3`（5,620,522 バイト）は 21,588 件・9 チャンク。
- **分割（200）**: 本体には `[200][int32 総数][int32 N][int64×N サイズ][16 バイト×N MD5]` だけを置く。データは拡張子を除いた名前のサブフォルダに `名前.000`… として置く（中身は単一形式と同じチャンク列）。現行 `COD.cdb3` は 585 バイト = 1+4+4+24×8+24×16、533,220 件、24 分割。
- 旧形式 `.cdb`（〜ver1.51）/ `.cdb2`（ver1.52〜1.871）は読めない（`ReadDatabase` が拡張子 `cdb3` 以外を無視する）。

DB に入るのは `Crystal2`（縮約レコード）であり、`Crystal` の全情報ではない。何が保持されるかは [ファイル形式](05-file-formats.md#crystal2-レコード) を参照。

## データベースの利用と引用

結晶リスト上部の注意書き（`textBox1`、英語のみ）: AMCSD は Downs & Hall-Wallace (2003) *American Mineralogist* 88, 247-250、COD は https://wiki.crystallography.net/cod/citing/ を引用するよう求めている（既存マニュアルの引用文と同じ）。

<!-- screenshot: 結晶リスト上部の AMCSD / COD チェックボックスと引用注意書き -->

## 要確認事項

1. `UserAppDataPath` の実パス。
2. 同梱 COD の d 値リストが旧 `GetDspacingList` で作られているか（e081e9d で作り直したのは AMCSD のみ）。
3. `ファイル` メニューの件数表示は `Version.AMCSD = 21_478` だが、同梱 `AMCSD.cdb3` は 21,588 件。`Version.cs` を更新するか。
4. COD の分割ファイル（35〜40 MB）を GitHub raw から配信し続ける前提でよいか。
