# メニュー・オプション・ヘルプ・言語

本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

対象: CSManager master `e081e9d`（サブモジュール Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`）。
根拠は特記しない限り `CSManager/FormMain.cs`・`FormMain.Designer.cs`・`FormMain.resx`（英語）・`FormMain.ja.resx`（日本語）。

## メニュー構成

メニューバーは `ファイル`・`オプション`・`ヘルプ`・`言語`（右寄せ）の 4 つ（`FormMain.Designer.cs` の `menuStrip.Items.AddRange`）。

### ファイル

| 日本語 UI | 英語 UI | 動作（ハンドラ） |
|---|---|---|
| `AMCSD データベースを読込 (データ数: ###)` | `Read AMSCD Database (including ### crystals)` | `crystalDatabaseControl.AMCSD_Checked = true`（`toolStripMenuItemReadDefault1_Click`）。`###` は起動時に `Version.AMCSD` の値で置換（`FormMain_Load`） |
| `CODデータベースを読込 (データ数: ###)` | `Read COD Database (including ### crystals)` | `crystalDatabaseControl.COD_Checked = true`（`toolStripMenuItemReadDefault2_Click`）。`###` は `Version.COD` |
| `データベースを読込` | `Read Database` | `*.cdb; *.cdb2; *.cdb3` を複数選択可で開き、順に `ReadDatabase`（`readDatabaseToolStripMenuItem_Click`） |
| `データベースを保存` | `Save Database` | `*.cdb3` で保存（`saveDatabaseToolStripMenuItem_Click` → `SaveDatabase`） |
| `データベースをクリア` | `Clear Database` | `crystalDatabaseControl.ClearAll()` |
| `インポート (単一ファイル) (CIF, AMC)` | `Import CIF, AMC ...` | 1 ファイルを読み、DB 末尾に追加（`toolStripMenuItemImport_Click`）。詳細は [ファイル形式](05-file-formats.md) |
| `インポート (PDIndexer, ReciProの結晶リスト) (*.xml)` | `Import PDI Crystal data (*.xml)` | `Crystal[]` の XML を読み、全結晶を DB 末尾に追加（`readXml`） |
| `閉じる` | `Close` | アプリ終了 |
| （日本語訳なし）`Debug functions` | `Debug functions` | 保守用サブメニュー。下表 |

`Debug functions` は Release ビルドでも表示される（`Visible` 指定なし）。中身:

| 英語 UI（日本語訳なし） | 動作 |
|---|---|
| `Compress and Split` | ハンドラ未接続（クリックしても何も起きない） |
| `Show the file name of the selected crystal` | 選択中レコードの `Crystal2.fileName` をメッセージボックスで表示（`toolStripMenuItemShowFileName_Click`） |
| `Check Duplicated File` | ハンドラ本体は全てコメントアウト（何も起きない） |
| `Import All File (CIF or AMC)` | フォルダ一括取り込み。[ファイル形式](05-file-formats.md#一括取り込み) を参照 |
| `Import AMCSD_CSV` | AMCSD 配布の CSV から DB を構築。[ファイル形式](05-file-formats.md#amcsd-csv) を参照 |
| `密度と化学式を再計算` / `Re-calculate density and formula` | `crystalDatabaseControl.RecalculateDensityAndFormula()` |
| `CODtype` | ハンドラ本体が空 |

### オプション

| 日本語 UI | 英語 UI | 既定 | 動作 |
|---|---|---|---|
| `ツールチップを表示` | `Tool Tip` | オン（Designer） | `FormMain`・結晶情報・検索・結晶リストの 4 つの `ToolTip.Active` を一括切替（`toolTipToolStripMenuItem_Click`）。レジストリには保存されない |
| `起動時にAMCSDデータベースを自動で読み込む` | `Read AMCSD Database on Next Boot` | 下記注意 | 起動時に AMCSD を読むかどうか |
| `Incremental Search`（訳なし） | `Incremental Search` | オフ・**無効化（灰色）** | 未実装。`Enabled = false`、`Checked` はどこからも参照されない（Designer の 260531Cl コメント） |
| `Font Size in Data Table` ▸ `Increase (Ctrl+Shift+.)` / `Decrease (Ctrl+Shift+,)` | 同左 | — | 結晶リストの `FontSize` を ×1.1 / ×0.9（`increaseToolStripMenuItem_Click` / `decreaseToolStripMenuItem_Click`） |

!!! warning "`起動時にAMCSDデータベースを自動で読み込む` の実際の挙動"
    `FormMain_Load` は、この項目の `Checked`（Designer 既定値 `true`）を見て AMCSD を読み込んだ**後に** `readRegistry()` でレジストリ値を反映する。そのため現行コードでは、保存値にかかわらず起動時には常に AMCSD が読み込まれる。また初回起動などレジストリ値が無い場合、`readRegistry` の既定値 `"False"` によってチェックは外れて表示される。[実装上の疑問点](90-implementation-questions.md) Q1。

### ヘルプ

| 日本語 UI | 英語 UI | 動作 |
|---|---|---|
| `アップデート` | `Program Updates` | 下記「アップデート確認」。Portable ZIP 版（実行フォルダに `README-PORTABLE.txt` がある場合）は非表示（`FormMain_Load`） |
| `ヒント` | `Hint` | 起動ダイアログ（`CommonDialog`）をヒント表示モードで開く |
| `バージョン履歴` | `Version History` | 同ダイアログを履歴モードで開く（`Version.History`） |
| `ライセンス` | `License` | 同ダイアログをライセンスモードで開く |
| `Github ページ` | （英語 resx に `Text` 無し） | https://github.com/seto77/CSManager を既定ブラウザで開く |
| `バグ、要望、コメントの送信` | `Repport bugs, request or comments` | https://github.com/seto77/CSManager/issues を開く |
| `マニュアル (PDF)` | `Help (PDF)` | オンラインマニュアルを開く。英語 UI 時は `https://seto77.github.io/CSManager/`、それ以外は `https://seto77.github.io/CSManager/<HelpCulture>/`（`helpwebToolStripMenuItem_Click`, `SupportedCultures.HelpCulture`）。PDF ではない |

#### アップデート確認（`programUpdatesToolStripMenuItem_Click` → `Crystallography/ProgramUpdates.cs: Check`）

1. `https://raw.githubusercontent.com/seto77/CSManager/master/CSManager/Version.cs` を取得し、最初に `" ver"` を含む行から版番号 5 文字を切り出す。
2. 実行中の版（`Version.VersionAndDate` の 4〜8 文字目）と `double` で比較。新しければ確認ダイアログ。
3. インストーラ名は実行アーキテクチャで切替（Arm64: `CSManager-setup_arm64.msi`、それ以外: `CSManager-setup.msi`）。`http://github.com/seto77/CSManager/releases/download/v.<版>/<名>` の存在をヘッダ取得で確認し、無ければ「このアーキテクチャのインストーラは未公開」と案内して終了。
4. `はい` で MSI を `%APPDATA%` 側のユーザーデータフォルダ（`UserAppDataPath`）へダウンロードし、起動して CSManager を閉じる。

### 言語

`言語` メニューの項目は起動時に `Crystallography.SupportedCultures.All` のうち `Released = true` のものから動的生成される（`PopulateLanguageMenu`）。現行は English / 日本語 / Deutsch / Français / Español / Português / Italiano / Русский / 简体中文 / 繁體中文 / 한국어 の 11 言語。

選択すると「表示言語を「…」に切り替えるには CSManager の再起動が必要です。保存していない作業は失われます。今すぐ再起動しますか？」と確認され、`はい` で設定を保存して新プロセスを起動し、現プロセスを閉じる（`languageToolStripMenuItem_Click` → `RestartApplicationForLanguageChange`）。`いいえ` なら何も変わらない。

!!! note
    コード内で生成されるメッセージ（`Localization.Loc(en:…, ja:…)`）は英語と日本語の 2 通りのみ。日本語以外の UI 言語ではこれらは英語で表示される（`FormMain.CurrentLanguage`）。

## 設定の保存場所

`HKEY_CURRENT_USER\Software\Crystallography\CSManager` に、終了時（`FormMain_FormClosing` → `saveRegistry`）次の値を書く。

| 値の名前 | 内容 |
|---|---|
| `Culture` | UI カルチャ名（起動時に `Program.Main` が読み、`SupportedCultures.Resolve` で解決。未知の値は英語） |
| `MainWidth` / `MainHeight` / `MainLocationX` / `MainLocationY` | ウィンドウの大きさと位置（`MainLocationY > 0` のときだけ復元） |
| `readDefaultDatabaseOnNextBootToolStripMenuItem.Checked` | `"True"` / `"False"` |
| `initialDialog.AutomaricallyClose` | 起動ダイアログを自動で閉じるか（綴りはコードのまま） |

`--capture` 起動時は保存しない（`SuppressRegistrySave`）。

## コマンドライン引数（`Program.Main`）

| 引数 | 動作 |
|---|---|
| `--smoke [出力ファイル]` | 実行アーキテクチャと実行フォルダを書き出して即終了（CI 用。既定出力 `smoke-result.txt`） |
| `--capture <出力フォルダ> <カルチャ>` | 指定カルチャでメインウィンドウを開き、AMCSD 読み込み完了（最長 90 秒）を待って `FormMain.png` を保存して終了（`GuiCapture.Run`）。マニュアル用スクリーンショットの生成用 |

<!-- screenshot: メニューバーの ファイル メニューを開いた状態（日本語 UI） -->

## 要確認事項

1. `Debug functions` を一般ユーザー向けマニュアルに載せるか（現状 Release でも表示される）。載せない場合は「保守用」とだけ記すか。
2. `Help (PDF)` / `マニュアル (PDF)` の表記は現状オンラインマニュアルを開くので、UI 文字列を変えるか、マニュアル側でこの表記のまま説明するか。
3. 英語 UI の `Github ページ` 項目に `Text` が無い（英語 UI で空欄表示になるはず）。実機での見え方の確認。
4. 設定保存先フォルダ（`UserAppDataPath` = `Application.UserAppDataPath` の親）の実パス。csproj に `Company` 指定が無いので SDK 既定（アセンブリ名）なら `%APPDATA%\CSManager\CSManager\` になるはずだが、実機未確認。
