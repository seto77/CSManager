# 画面（フォーム）一覧と機能概要

本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

対象: CSManager master `e081e9d`（サブモジュール Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`）。

CSManager の画面は、メインウィンドウ 1 枚（`FormMain`）と、そこから開く補助ウィンドウで構成される。補助ウィンドウのうち CSManager 本体にあるのは `FormMain` だけで、残りは共通ライブラリ Crystallography.Controls のもの。

## メインウィンドウ（`FormMain`）

題名は `CSManager   ver1.912 (2026/06/25)`（`Version.VersionAndDate`）。`splitContainer1` / `splitContainer2` で次の領域に分かれる（`FormMain.Designer.cs`）。

| 領域 | コントロール | 章 |
|---|---|---|
| メニューバー（`ファイル`・`オプション`・`ヘルプ`・`言語`） | `menuStrip` | [メニュー](06-menus-options.md) |
| 上段: `AMCSD` / `COD` チェック、引用の注意書き、結晶リスト、ナビゲータ | `CrystalDatabaseControl` | [データベース](02-database.md)、[結晶リストと検索](03-table-search.md) |
| 下段左: 結晶情報と `↑ 追加 ↑` / `↑ 入れ替え ↑` ボタン | `CrystalControl` | [結晶情報](04-crystal-information.md) |
| 下段右: 検索パネル | `SearchCrystalControl` | [結晶リストと検索](03-table-search.md) |
| 最下部: 進捗バーと状態表示 | `statusStrip` | 下記 |

状態表示には読み込み・保存・検索の進捗（「… Completed: x %. Elapsed time: y sec. Remaining time: z sec.」）が出る（`FormMain.reportProgress`、`CrystalDatabaseControl.report`）。

<!-- screenshot: メインウィンドウ全体（AMCSD 読み込み後、日本語 UI）。docs/src/assets/cap-ja-auto/FormMain.png が --capture で生成済み -->

## 補助ウィンドウ

| ウィンドウ（英語題名 / 日本語題名） | クラス | 開き方 | 種類 |
|---|---|---|---|
| 起動ダイアログ `Calculating...` | `CommonDialog`（Initialize） | 起動時。`起動後にこのウィンドウを自動で閉じる` / `Close this window automatically after startup` | モードレス |
| `Hint`（英語のみ） | `CommonDialog`（Hint） | `ヘルプ` ▸ `ヒント`。`Next` で次のヒント | 同上 |
| `Version history`（英語のみ） | `CommonDialog`（History） | `ヘルプ` ▸ `バージョン履歴` | 同上 |
| `CSManager License (MIT)`（英語のみ） | `CommonDialog`（License） | `ヘルプ` ▸ `ライセンス` | 同上 |
| `Periodic Table`（訳なし） | `FormPeriodicTable` | 検索パネル ▸ `元素` ▸ `周期表` | 閉じても隠れるだけ |
| `Symmetry Information`（訳なし） | `FormSymmetryInformation` | 結晶情報のヘッダ `対称性詳細`、または右クリック | モードレス、閉じても隠れるだけ |
| `Group Relations` / `群の関係` | `FormGroupRelations` | 対称性詳細ウィンドウの `群の関係...` | |
| `Beam Interaction` / `ビーム相互作用` | `FormBeamInteraction` | 結晶情報のヘッダ `ビーム相互作用`、または右クリック | モードレス |
| `Convert to another spacegroup` / `別の空間群へ変換` | `FormAnotherSpaceGroup` | 右クリック `異なる軸・原点セッティングの空間群に変換`、`Change axes/origin setting` ボタン | モーダル |
| `Set superstructure size`（訳なし） | `FormSuperStructure` | 右クリック `超構造に変換` | モーダル |
| `Atom Positions` / `原子位置` | `FormAtomDetailedInfo` | 原子一覧の行を右クリック `等価な原子位置を表示` | モードレス |
| `FormIsotopeComposition`（題名未設定） | `FormIsotopeComposition` | 原子情報 ▸ `散乱因子` ▸ 中性子 Custom ▸ `編集` | モーダル |
| `Strain Control` | `FormStrain` | 到達できない（メニュー項目が非表示） | – |

対称性詳細ウィンドウのタブ: `幾何計算` / `Geometrics Calculation`、`ワイコフ位置` / `Wyckoff Positions`、`反射条件` / `Conditions`、`対称操作` / `Operations`、`群の性質` / `Properties`、`設定一覧` / `Settings`。

ビーム相互作用ウィンドウのタブ: `反射` / `Reflections`、`散乱因子` / `Scattering factors`、`減衰・輸送` / `Attenuations && Transport`、`蛍光` / `Fluorescence`。

これら 2 つのウィンドウの中身は ReciPro・PDIndexer と共通で、本稿では扱わない（要確認事項 1）。

**[main]** 右クリックの `化学組成の詳細` から `FormChemicalComposition` が開けるようになる。

## 要確認事項

1. 対称性詳細ウィンドウとビーム相互作用ウィンドウを、CSManager のマニュアルで詳しく説明するか、ReciPro のマニュアルへのリンクにするか。
2. `CommonDialog` の各モードの題名と、`Periodic Table`・`Symmetry Information`・`Set superstructure size`・`FormIsotopeComposition` の題名が日本語化されていない（UI 側の課題）。
