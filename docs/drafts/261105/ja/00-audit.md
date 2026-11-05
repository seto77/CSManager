# 既存マニュアルと現行コードの照合

本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

照合の対象:
- 既存マニュアル: `docs/src/ja/*.md`・`docs/src/en/*.md`（MkDocs、11 言語。en/ja 以外の 9 言語は en/ja と同じ構成の翻訳なので、同じ指摘があてはまる）
- コード: CSManager master `e081e9d`、サブモジュール固定コミット Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`
- そのほか: `README.md`、`README-PORTABLE.txt`、`CSManager/Version.cs` の履歴

ほかの文書資産: 同梱 PDF マニュアル（`doc\CSManager(en/ja).pdf`）は csproj から削除済みで、リポジトリにも無い（260625Cl のコメント）。GitHub Wiki は clone できなかった（認証が必要、または存在しない）。`docs/src/assets/cap-*-auto/FormMain.png` は `--capture` で生成した画面写真で、どのページからも参照されていない。

## A. 既存マニュアルの記述がコードと食い違う箇所

| # | ページ | 既存の記述 | コードの実際 | 根拠 |
|---|---|---|---|---|
| A1 | index・troubleshooting | 動作に **.NET Desktop Runtime 8** 以上 | .NET 10（`net10.0-windows`）。ver1.904 で 10.0 に更新。README も 10 | `CSManager.csproj`、`Version.History` |
| A2 | 1-database-loading | 「データベースを読込 — 任意の `*.cdb3` を開く」 | ダイアログは `*.cdb; *.cdb2; *.cdb3` を出すが、`.cdb3` 以外は黙って無視。複数選択しても最初の 1 つだけ | `FormMain.readDatabaseToolStripMenuItem_Click`、`CrystalDatabaseControl.ReadDatabase` |
| A3 | 1-database-loading | 「COD は初回に自動でダウンロードし、次回以降はダウンロード済みのファイルを読む」 | 毎回 MD5 で全分割ファイルを照合し、Web のヘッダと比べて更新を確認する（更新があれば Yes/No/Cancel）。無ければダウンロードするか確認する | `CrystalDatabaseControl.ReadCOD` |
| A4 | 1-database-loading / 7-options | `起動時にAMCSDデータベースを自動で読み込む` は「既定で有効」で、オフにすれば読まない | 設定にかかわらず常に読み込む。初回起動ではチェックが外れて見える（Q1） | `FormMain.FormMain_Load` / `readRegistry` |
| A5 | 1-database-loading | AMCSD のメニューには現在の件数が表示される | 表示されるのは `Version.AMCSD = 21,478`。同梱 DB は 21,588 件（e081e9d） | `Version.cs`、`AMCSD.cdb3` |
| A6 | 2-database-table | 「PDIndexer や ReciPro が起動している場合は、選択と同時に…クリップボード経由で転送」 | 起動の有無は確かめず、**選択のたびに必ずクリップボードを上書き**する | `FormMain.crystalDatabaseControl_CrystalChanged` |
| A7 | 3-search | 「`検索` ボタンを押すか Enter キーを押すと検索」 | 名前・文献・数値欄での Enter と `検索`。加えて `AMCSD` / `COD` チェックの切替でも再検索。条件はすべて AND | `SearchCrystalControl` |
| A8 | 3-search | `格子定数` — 格子定数と許容範囲を指定。「許容範囲にゼロを入力した項目は無視される」 | 無視されるのは**値が 0 の欄**。許容範囲 0 は完全一致。長さは相対 %、角度は絶対 °。さらに単位不一致のため実質機能しない（Q7） | `SearchCrystalControl` 検索ワーカー |
| A9 | 3-search | `d値` — 「散乱因子を無視が無効の場合は…強度上位 20 までの結晶面だけを対象」 | 上位 **16**（`GetDspacingList` の `bestNum = 16`）。d は最大 3 個まで AND で指定。許容範囲は相対 % | `Crystal.GetDspacingList`、`SearchCrystalControl` |
| A10 | 3-search | `名前`・`文献` の説明が「…で検索」のみ | 名前は部分一致・大小無視。文献は雑誌・著者・タイトルのいずれかに部分一致 | 同上 |
| A11 | 3-search | 周期表の各元素の状態（含んでもよい / 必ず含む / 必ず除外） | 記述は正しい。補足: 除外が 1 つでもあれば不合格、含むはすべて必要、原子が 0 の結晶は除外、`La`/`Ac` ボタンは働かない | `FormPeriodicTable`、`SearchCrystalControl` |
| A12 | 5-import-export | 「CIF ファイルや AMC ファイルを読み込み、現在のデータベースの末尾に追加」 | 拡張子は小文字のみ。失敗しても何も表示しない。d リストを作らないので、d 値検索（散乱因子を考慮）の対象外 | `FormMain.toolStripMenuItemImport_Click`、`ConvertCrystalData.ConvertToCrystal` |
| A13 | 5-import-export / 6-interoperation | 右クリック `Send this crystal to other software` で送れる | この項目は非表示（`Visible = False`） | `CrystalControl.resx` |
| A14 | 4-crystal-information/index | 最上部に `Name` と `Formula`、`Reset` で全情報を初期化 | `Reset` ボタンは無い。ヘッダには 結晶名・対称性詳細・ビーム相互作用・化学組成・Z数・描画色 がある | `CrystalControl.Designer.cs` |
| A15 | 4-crystal-information/index | タブは 4 つ（格子/対称性・原子情報・多面体/結合描画設定・引用文献） | **6 つ**。`状態方程式`（EOS）と `弾性定数`（Elasticity）も表示される | `FormMain.Designer.cs`（`VisibleEOSTab = true`、`VisibleElasticityTab = true`） |
| A16 | 4-crystal-information/index | 変更は `追加` / `入れ替え` で確定 | 正しいが、DB に保存されない項目（同位体・表示・結合・EOS・弾性）がある点が抜けている | `Crystal2.FromCrystal` / `ToCrystal` |
| A17 | 4-crystal-information/index | `アプリ起動時の格子定数に戻す` — 読み込み直後の値に戻す | 初期値が保存されるのはリスト読み込みのときだけで、CSManager では実質働かない（要実機確認） | `Crystal.RevertInitialCellConstants` |
| A18 | 4.1 basic-information | 長さの単位は Å | `長さの単位` で Å / nm を切り替えられる（既定 Å） | `SymmetryControl` |
| A19 | 4.1 basic-information | 空間群の `Search` は「大文字・小文字を区別」 | 正しい。補足: 連続していなくてもよい部分列一致。空白を入れると一致しない。`sub` は不要 | `SymmetryControl` 検索 |
| A20 | 4.1 basic-information | 「原子情報が入力されている場合」に体積なども計算 | 体積は原子が無くても出る。項目は Cell Volume（Å³ と nm³）・Cell Mass・Molar Volume・Molar Mass・Density・Mean Z（個数・質量）・Mean A・Atom density・Electron density。Z はヘッダにあり GCD で算出 | `CrystalControl`、`Crystal.cs` |
| A21 | 4.1 basic-information | **Color of Profile** | 実際のラベルは `描画色` / `Color` で、ヘッダにある | `CrystalControl.resx` |
| A22 | 4.1 basic-information（ja） | `Cell constants`・`Symmetry`・`Crystal system`… を英語で表記 | 日本語 UI では `格子定数`・`対称性`・`結晶系`・`点群`・`空間群`・`検索` | `SymmetryControl.ja.resx` |
| A23 | 4.2 atoms | X, Y, Z は「0 から 1 までの実数」、Occ は「0 から 1」 | 範囲の制限は無く、式（`1/3+1/8` など）も入る | `NumericBox` |
| A24 | 4.2 atoms | X 線散乱因子のパラメータは *International Tables for Crystallography volume C* | コードのコメントでは Waasmaier & Kirfel (1995) *Acta Cryst.* A51, 416-431 | `AtomStatic.XrayScatteringWK` |
| A25 | 4.2 atoms | 電子線散乱因子は Peng (1998) | 中性原子は Peng et al. (1996) A52, 257-276、イオンは Peng (1998) A54, 481-485 | `AtomStatic.ElectronScatteringPeng` |
| A26 | 4.2 atoms | Notation `U` / `B`、Model の説明のみ | 固定コミットでは U ↔ B の切替で値を換算しない。異方性 B は無次元の β（見出し `B11` は誤解を招く）。既定は B・非等方 | `AtomControl` |
| A27 | 4.2 atoms（ja） | ボタン名を `Add`・`Replace`・`Up`・`Down`・`Delete` と英語で表記 | 日本語 UI では `追加`・`更新`・`上へ移動`・`下へ移動`・`削除` | `AtomControl.ja.resx` |
| A28 | 4.3 bonds-polyhedra | 「ここで定義した結合・多面体は ReciPro などの構造ビューアでの表示に用いられる」 | CSManager では DB に保存されず、送信メニューも非表示。DB の行を選ぶと VESTA 既定で作り直される | `Crystal2.ToCrystal` |
| A29 | 4.3 bonds-polyhedra | 「多面体の透明度などの細かな描画設定もこのタブで調整」 | 既定値: 結合半径 0.1 Å、結合長 0.1〜1.6 Å、透明度 0.7、辺の線幅 0.7。色は設定できない（原子の色） | `BondControl.Designer.cs` |
| A30 | 4.4 references | `Note`・`Authors`・`Journal`・`Title` | 内容は正しい。日本語 UI では `Note`（訳なし）・`著者`・`雑誌名`・`タイトル` | `CrystalControl.ja.resx` |
| A31 | 7-options-language | `Incremental Search` — 有効にすると即座に反映 | 未実装で、項目は無効（灰色） | `FormMain.Designer.cs`（260531Cl コメント） |
| A32 | 7-options-language | 言語の切替には再起動が必要（再起動は自動） | 「今すぐ再起動しますか？」の確認があり、`はい` で再起動。保存していない作業は失われる | `FormMain.languageToolStripMenuItem_Click` |
| A33 | 7-options-language | `マニュアル (PDF)` — オンラインマニュアルを開く | 記述どおり。ただし UI 表記が「PDF」のまま。英語以外では `https://seto77.github.io/CSManager/<言語>/` | `FormMain.helpwebToolStripMenuItem_Click` |
| A34 | 7-options-language（en） | `Github page` | 英語 resx に `Text` が無く、英語 UI では空欄のはず（Q33） | `FormMain.resx` |
| A35 | 0-main-window | 結晶情報（下部）、検索パネル（下部右側） | 正しい。結晶リスト上部の `AMCSD` / `COD` チェックと引用文、`↑ 追加 ↑` / `↑ 入れ替え ↑` ボタンの記述が無い | `FormMain.Designer.cs` |
| A36 | troubleshooting | 「COD の読み込みに失敗する — 800 MB 超」 | 分割 24 ファイル、計約 885 MB を並列ダウンロード。毎回 MD5 照合するので時間がかかる | `ReadCOD`、`COD/` |

## B. マニュアルに無い機能・情報

| # | 内容 | 根拠 | 下書き |
|---|---|---|---|
| B1 | `AMCSD` / `COD` チェックボックス（読み込みと表示フィルタの 2 役） | `CrystalDatabaseControl` | [02](02-database.md) |
| B2 | データの置き場所（`%APPDATA%` 側、起動ごとの AMCSD 上書きコピー）、レジストリのキー | `FormMain_Load`、`saveRegistry` | [02](02-database.md)、[06](06-menus-options.md) |
| B3 | cdb3 の形式（単一 / 分割、MemoryPack + Brotli、MD5） | `CrystalDatabaseControl` | [02](02-database.md) |
| B4 | `データベースを保存` は表示順で保存、絞り込み中は空になる（Q2） | 同上 | [02](02-database.md) |
| B5 | 結晶リストの列と単位、ナビゲータ | `DataSet.cs` | [03](03-table-search.md) |
| B6 | `↑ 追加 ↑` / `↑ 入れ替え ↑` の違い（未選択時の入れ替えは追加） | `FormMain`、`ChangeCrystal` | [03](03-table-search.md) |
| B7 | 検索条件の既定値（許容範囲 3、d1 行のチェック） | `SearchCrystalControl.Designer.cs` | [03](03-table-search.md) |
| B8 | `ヒント`（ヘルプメニュー） | `hintToolStripMenuItem_Click` | [06](06-menus-options.md) |
| B9 | `Font Size in Data Table` の `Increase (Ctrl+Shift+.)` / `Decrease (Ctrl+Shift+,)`（×1.1 / ×0.9） | `FormMain` | [06](06-menus-options.md) |
| B10 | `Debug functions` サブメニュー（一括取り込み、AMCSD CSV、密度と化学式の再計算など） | `FormMain.Designer.cs` | [05](05-file-formats.md)、[06](06-menus-options.md) |
| B11 | メインウィンドウへの `.xml` ドロップで結晶リストを取り込める | `FormMain_DragDrop` | [05](05-file-formats.md) |
| B12 | Portable ZIP 版では `アップデート` が非表示。アップデートはアーキテクチャ別 MSI（arm64 対応、ver1.912） | `FormMain_Load`、`programUpdatesToolStripMenuItem_Click` | [06](06-menus-options.md) |
| B13 | 11 言語の UI（ver1.912）。コード内メッセージは英語・日本語のみ | `SupportedCultures`、`Localization.Loc` | [06](06-menus-options.md) |
| B14 | コマンドライン `--smoke` / `--capture` | `Program.Main`、`GuiCapture` | [06](06-menus-options.md) |
| B15 | `状態方程式` タブ（6 種の等温 EOS、Mie–Grüneisen / 温度依存モデル） | `EOSControl`、`EOS.cs` | [04](04-crystal-information.md) |
| B16 | `弾性定数` タブ（C / S、Voigt 21 成分） | `ElasticityControl` | [04](04-crystal-information.md) |
| B17 | ヘッダの `ビーム相互作用`、右クリックの `ビーム相互作用` | `CrystalControl` | [04](04-crystal-information.md) |
| B18 | `原点シフト` のプリセット、`表示`（Appearance）サブタブ、`同種の原子を更新` / `全ての原子を更新`、`等価な原子位置を表示` | `AtomControl` | [04](04-crystal-information.md) |
| B19 | `Change axes/origin setting` ボタン、`超構造に変換` の倍率指定 | `CrystalControl`、`FormSuperStructure` | [04](04-crystal-information.md) |
| B20 | 中性子の `Custom isotope abundance` と同位体組成ウィンドウ | `FormIsotopeComposition` | [04](04-crystal-information.md) |
| B21 | CIF のどのタグを読み、何を無視するか。空間群の決め方。書き出す内容と失われる情報 | `ConvertCrystalData` | [05](05-file-formats.md) |
| B22 | 画面（フォーム）の一覧 | 各フォーム | [01](01-forms.md) |

## C. 履歴（`Version.cs`）から見た、マニュアル未反映の変更

| 版 | 履歴の記述 | マニュアルの状態 |
|---|---|---|
| ver1.912 (2026/06/25) | arm64・portable ZIP の配布、多言語対応 | 言語は 7-options に記載済み。arm64・portable は未記載 |
| ver1.911 (2026/04/27) | COD 更新（533,220） | 件数の記載なし（「50 万件超」のみ） |
| ver1.910 (2026/04/06) | インストーラの小型化 | 該当なし |
| ver1.909 / 1.906 (2025/12) | AMCSD 更新（21,478 / 21,477） | 件数の記載なし（「約 2 万件」）。同梱 DB は e081e9d で 21,588 件 |
| ver1.904 (2025/11/14) | .NET 10 へ更新 | **未反映**（A1） |
| ver1.900 (2025/01/16) | メモリ使用量の削減 | 該当なし |
| ver1.894 (2022/11/16) | 保存・読込のアルゴリズム変更 | cdb3 の形式は未記載（B3） |
| ver1.893 (2022/10/27) | 検索機能の改良 | 検索の詳細は未記載 |
| ver1.873 (2020/03/17) | DB 形式を cdb2 → cdb3 に変更 | 旧形式を読めないことが未記載（A2） |
| ver1.78 (2015/07/13) | フォントサイズのオプション | 記載あり |
| ver1.72 / 1.71 (2013/02) | 更新確認、CIF 書き出し | 記載あり |

`Version.cs` のそのほかの文字列（`Introduction`・`Address` など。README 生成用）は、連絡先が神戸大学時代のもの（`seto@crystal.kobe-u.ac.jp`、旧 HP）で、既存マニュアルの連絡先（`seto.y@omu.ac.jp`）と一致しない。`Introduction` の「3万件以上の構造データを同梱」も現状と異なる。

## D. README との食い違い

| README の記述 | 実際 |
|---|---|
| 「source code references `21,478` AMCSD entries and `529,139` COD entries」 | `Version.COD = 533,220`。同梱 AMCSD は 21,588 件 |
| 「open legacy database files such as `.cdb` and `.cdb2`」 | 読めない（A2） |
| 「Database input: `.cdb`, `.cdb2`, `.cdb3`」 | `.cdb3` のみ |

## 要確認事項

1. 下書き（`docs/drafts/261105/`）を `docs/src/{ja,en}/` の各ページに統合するときの構成（既存の 9 ページ構成を維持するか、EOS・弾性・ファイル形式のページを新設するか）。
2. 不具合（Q1〜Q45）を直してからマニュアルを確定するか、現状の挙動をそのまま書くか。とくに Q7（格子定数検索）と Q9（CIF の空間群）。
3. サブモジュールを origin/main に上げる時期（[main] の記述をどちらに寄せるか）。
4. ほかの 9 言語のページへの反映方針。
