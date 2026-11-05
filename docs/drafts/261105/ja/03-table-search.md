# 結晶リストと検索

本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

対象: CSManager master `e081e9d`（サブモジュール Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`）。
略記: CDC = `CrystalDatabaseControl.cs`、SCC = `SearchCrystalControl.cs`、FPT = `FormPeriodicTable.cs`（いずれも `Crystallography.Controls/CrystalDatabase/`）、DS = `Crystallography.Controls/DataSet.cs`。

## 結晶リスト

| 列（日本語 UI） | 英語 UI | 書式 | 内容 |
|---|---|---|---|
| 結晶名 | Name | – | `name` |
| 密度 | Density | N4 | g/cm³ |
| Formula（訳なし） | Formula | – | 化学式 |
| a, b, c | 同 | `#.#####` | Å |
| α, β, γ | 同 | `#.#####` | ° |
| 結晶系 | Crystal System | – | |
| 点群 | Point Group | – | |
| 空間群 | Space Group | – | H-M 記号（下付きは `_`、六方/菱面体設定は ` H` / ` R` を付記、`=` 以降は省略）（DS） |
| 著者 | Authors | – | カンマが 2 つ以上なら第 1 著者 + `, et al.`（DS） |
| タイトル | Title | – | 論文タイトル（`sect`） |
| 雑誌名 | Journal | – | `jour`（雑誌名・巻・号・年・頁をまとめた文字列） |

- `#.#####` 書式のため、値 0 は空欄になる。
- 読み取り専用・単一行選択。列見出しクリックで並べ替え（`SortMode` 既定の Automatic）。右クリックメニューは無い。
- 下部のナビゲータ（先頭／前／位置／総数／次／末尾）の件数・位置は**絞り込み後**の表示行が対象。ツールチップは UI 言語にかかわらず日本語（Designer に直書き）。
- 文字サイズ: `オプション` ▸ `Font Size in Data Table`（既定 9.75 pt、×1.1 / ×0.9）。
- 行を選ぶと（`bindingSource.CurrentChanged` → `CrystalChanged`）下部の結晶情報に表示され、同時に**クリップボードが上書きされる**（[他ソフトとの連携](07-interoperation.md)）。

### 結晶の追加・入れ替え・削除（`FormMain`）

| ボタン | 動作 |
|---|---|
| `↑ 追加 ↑` / `↑ Add ↑` | 結晶情報の入力内容から結晶を作り（`GenerateFromInterface`）、新規行として末尾に追加 |
| `↑ 入れ替え ↑` / `↑ Replace ↑` | 選択行をその内容で置換。行が未選択なら新規追加（CDC `ChangeCrystal`） |

選択行の削除は `DeleteCurrentCrystal`（確認なし）。ここで追加・置換したレコードは d 値リストを持たない（下記の注意）。

## 検索パネル

### 検索の実行

- `検索` ボタン、`名前`・`文献` のテキストボックスでの Enter、各数値ボックスでの Enter で実行（SCC `KeyDown`）。
- `AMCSD` / `COD` チェックの切替でも再検索される。
- 条件のチェックボックスの切替や周期表の操作だけでは実行されない。チェックボックスは入力欄の表示・有効化を切り替える。
- **有効な条件はすべて AND**。条件を満たさない行に `Flag = false` を立て、`Flag = true` でフィルタする。
- `オプション` の `Incremental Search` は未実装（灰色）。
- 状態表示: 「Searching... x sec.」→「Completion of search. x sec.」。

### 条件ごとの意味

| 条件（日本語 / 英語） | 判定（SCC 検索ワーカー） |
|---|---|
| `名前` / `Name` | 結晶名に入力文字列全体が含まれるか（部分一致・大小無視、`CurrentCultureIgnoreCase`）。空白も文字として扱い、AND/OR やワイルドカードは無い |
| `文献` / `Reference` | 雑誌（`jour`）・著者（`auth`、全著者）・タイトル（`sect`）のいずれかに部分一致（大小無視） |
| `結晶系` / `Crystal System` | 選択肢 Unknown, triclinic, monoclinic, orthorhombic, tetragonal, trigonal, hexagonal, cubic（日本語訳なし）。Unknown と未選択は「条件なし」 |
| `元素` / `Elements` | 下記「周期表」 |
| `格子定数` / `Cell Params` | a, b, c（Å）は相対誤差 `±%`、α, β, γ（°）は絶対誤差 `±°`。値 0 の欄は無視。誤差 0 は「完全一致」で、無視ではない。**現行コードでは単位変換の不具合のため実質的に機能しない（下記）** |
| `d値` / `d-spacing` | 最大 3 個（d1〜d3、Å）。誤差は相対 `±%`（開区間）。有効で値が 0 でない各 d が、その結晶の d リストのどれかに入れば合格。3 個は AND |
| `散乱因子を無視` / `Ignore scattering factor` | オフ: DB に保存された d リスト（強度上位 16 本）と照合。オン: 格子定数だけから全ての d（消滅則・対称性・強度を無視）を計算して照合（`calcDlist`、上限 8000 個、`dMin = min(d_i(1−2ε_i))` まで） |
| `密度` / `Density` | 相対 `±%`、g/cm³。値 0 は無視 |

既定値（SCC Designer）: 条件のチェックは全てオフ（ただし d 値の `d1` 行のチェックだけオン）。a〜γ・d1〜d3・密度の値は 0。誤差は全て 3（%・°・%・%）、最大 50、刻み 0.5。

!!! danger "格子定数検索の単位不一致"
    入力は Å・° のまま渡されるが、比較対象は `Crystal2.CellOnlyValue_nm_radian`（nm・rad）である（SCC `buttonSearch_Click` の `SearchParameters` 生成と検索ワーカーの「格子定数」ブロック）。d 値は `/10` で nm に換算しているのに、格子定数は換算していない。このため a = 5 Å ± 3 % は 0.5 nm の結晶に一致せず、0 以外の角度を入れると全結晶が除外される。origin/main でも同じ。[実装上の疑問点](90-implementation-questions.md) Q7。

!!! note "d 値リストの作り方と、既存マニュアルの「強度上位 20」"
    DB の d リストは `Crystal.GetDspacingList(0.154, 200)` で作る（FM `GetPlanesFormulaDensity`）。`0.154` は波長（nm、Cu Kα 相当）。`200` は点群で対称等価を除いた、消滅しない面を 200 個集めるまで |g| を広げるという意味。強度 I = |F|²（X 線）× 多重度 × (1+cos²2θ)/(sin2θ sinθ) で、上位 `bestNum = 16` 本の d（nm）を返す。既存マニュアルの「上位 20」は誤りで、`Crystal2.d` のコメント「強度8位まで」も古い。
    origin/main（Crystallography `9ffcf47`）では、2θ ≤ 150° の上限、Laue 群によるフリーデル対の統合、相対差 1e-6 以内の d の統合（強度は合算）が入った。同梱 AMCSD（e081e9d）はこの新版で作り直してある。d リストを計算するのは AMCSD CSV 取り込みとフォルダ一括取り込みだけ。

!!! warning "d リストを持たないレコード"
    `Crystal2.FromCrystal` は `d` を設定しない。`↑ 追加 ↑` / `↑ 入れ替え ↑`、単一 CIF/AMC インポート、XML インポートで入ったレコードは `d == null` になる。`散乱因子を無視` オフの d 値検索で例外になり、警告なしに途中までの結果が表示される（Q8）。

### 周期表（`周期表` / `Periodic Table` ボタン、FPT）

- 元素ボタンはクリックごとに 中立（薄黄）→ 必ず含む（薄青）→ 必ず除外（薄赤）→ 中立 と変わる。
- 判定は全原子サイトの元素（占有率は問わない）。除外元素を**1つでも**含めば不合格。「含む」元素は**すべて**含む必要がある。中立元素の有無は問わない。
- `元素` 条件をオンにすると、元素の指定が無くても原子を 1 つも持たない結晶は除外される。
- 選択できるのは H〜Rg（1〜111）。`La` / `Ac` ボタンはランタノイド・アクチノイド行の位置を示すだけで、押しても何も起きない。
- 上部ボタン: `含める`（must include、全元素を「含む」）、`除外する`（must exclude、全元素を「除外」）、`含んでも含まなくてもよい`（may or not include、全元素を中立に戻す）。
- ウィンドウは閉じても隠れるだけなので、指定は保持される。ウィンドウ題名「Periodic Table」は翻訳されない。
- 起動時ヒント: 「must exclude で全元素を排除してから、含む元素を選ぶと便利」（`Version.Hint`）。

<!-- screenshot: 検索パネルで 元素・d値 を有効にし、周期表ウィンドウを開いた状態 -->

## 要確認事項

1. 格子定数検索の単位不一致（Q7）は意図しないものか。修正後はマニュアルの記述を「a, b, c は Å、相対誤差 %」に確定する。
2. `Font Size in Data Table` の変更がセルに反映されるか（Designer が `DefaultCellStyle.Font` を明示しているため）。
3. 結晶系の選択肢が日本語 UI でも英語のままでよいか。
