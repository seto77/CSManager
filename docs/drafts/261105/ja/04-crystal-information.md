# 結晶情報（CrystalControl）

本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

対象: CSManager master `e081e9d`（サブモジュール Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`）。各節の **[main]** は Crystallography.Controls origin/main（`aadeb74` まで）で変わる点。
略記: CC = `Crystallography.Controls/Crystal/CrystalControl.cs`、SC = `SymmetryControl.cs`、AC = `AtomControl.cs`、BC = `BondControl.cs`、EC = `EOSControl.cs`、ElC = `ElasticityControl.cs`（いずれも同フォルダ）。

## 編集内容の保存は 2 段階

1. 各タブの入力は、値を変えるたびに結晶オブジェクトへ反映される（`ItemChanged` → `GenerateFromInterface`）。原子と結合は、そのタブの `追加` / `更新` を押した時点で一覧に入る。
2. DB に入るのは、メインウィンドウの `↑ 追加 ↑`（新規行）か `↑ 入れ替え ↑`（選択行を置換）を押したときだけ。

DB の 1 レコード（`Crystal2`）に入らないもの: **同位体組成、表示（Appearance）設定、結合・多面体、EOS、弾性定数**。DB の行を選び直すと、Appearance と結合は VESTA 既定に戻り、それ以外は消える（`Crystal2.ToCrystal`）。D（重水素）だけは元素番号 255 として保存される。

## 表示されるタブ

CSManager の設定（`FormMain.Designer.cs`）で表示されるのは次の 6 タブ（CC `setTabPages` の順）。Bounds・Lattice Plane・Strain・Stress・Polycrystalline Property は非表示。

| 日本語 UI | 英語 UI |
|---|---|
| `格子/対称性` | `Basic Info.` |
| `原子情報` | `Atom Info.` |
| `多面体/結合描画設定` | `Bonds & Polyhedra` |
| `引用文献` | `Ref.` |
| `状態方程式` | `EOS` |
| `弾性定数` | `Elasticity` |

## ヘッダ（全タブ共通）

| 日本語 UI | 英語 UI | 内容 |
|---|---|---|
| `結晶名` | `Name` | 自由入力 |
| `対称性詳細` | `Symmetry info.` | 対称性詳細ウィンドウの表示を切り替える |
| `ビーム相互作用` | `Beam interaction` | ビーム相互作用ウィンドウの表示を切り替える（`BeamInteractionVisible = false` は初期状態を閉じておくだけ） |
| `化学組成` | `Formula` | 読み取り専用。原子から計算 |
| `Z数` | `Z` | 読み取り専用。下記 |
| `描画色` | `Color` | クリックで色の選択。3D 表示と回折プロファイルの色。固定コミットでは次の再生成時に反映される。**[main]** 即時に反映 |

既存マニュアルにある `Reset` ボタンは存在しない。

## 格子/対称性

### 格子定数（`格子定数` / `Cell constants`）

- `長さの単位` / `Unit`: `Å`（既定）/ `nm`。切り替えると表示値を ×10 / ×0.1 する。内部は nm・rad（SC）。
- `誤差表示` / `Show Errors`（既定オフ）で ± 欄を出す。
- 結晶系に応じて拘束された欄は無効になり、値が上書きされる（SC `SetCellConstantsBySymmetry`）。
    - 単斜晶: 主軸に対応する角だけ自由、残りは 90°
    - 直方晶: 角はすべて 90°
    - 正方晶・六方晶: b = a、γ = 90° / 120°
    - 三方晶: 六方軸では b = a、γ = 120°。菱面体軸（内部名に `Rho`）では a = b = c、α = β = γ
    - 立方晶: a = b = c、角はすべて 90°
- 負の長さ・π を超える角では「Input valid cell constants」（英語のみ）。0 は通る。

### 対称性（`対称性` / `Symmetry`）

- `結晶系` → `点群` → `空間群` の順に選ぶ。上位を変えると下位は先頭に戻る。選択肢の日本語: 不明 / 三斜晶系 / 単斜晶系 / 直方晶系 / 正方晶系 / 三方晶系 / 六方晶系 / 立方晶系。
- 空間群は `番号:H-M` の形で、同じ番号の別設定（軸・原点・格子の取り方）は別の項目として並ぶ。
- `検索` / `Search`（SC）: 入力の各文字がその順に H-M 文字列に現れるか（**連続していなくてもよい部分列一致**）。大文字小文字を区別する。内部の H-M 文字列は空白を含まないため、空白を入れると何も一致しない。`P21/c` で `P2sub1/c` に一致するので、`sub` を打つ必要はない。`=`（例 `C2=C121`）や `Rho` / `Hex` でも絞り込める。候補は右のリストに入り、選ぶと 3 つのコンボに反映される。
- `Change axes/origin setting`（日本語訳なし）: 空間群番号 > 2 で、同じ番号に複数の設定があるときだけ有効。下記「別の設定への変換」と同じウィンドウを開く。

### 計算値（読み取り専用、CC `SetCellVolumeAndDensity` 付近、`Crystal.cs`）

n_i = Σ(多重度 × 占有率) として計算する。

| 日本語 UI | 英語 UI | 単位 | 定義 |
|---|---|---|---|
| `単位胞体積` | `Cell Volume` | Å³（隣に nm³） | |
| `単位胞質量` | `Cell Mass` | ×10⁻²⁴ g | ρV |
| `モル体積` | `Molar Volume` | cm³/mol | 組成式あたり |
| `モル質量` | `Molar Mass` | g/mol | 組成式あたり |
| `密度` | `Density` | g/cm³ | ΣA_i n_i / (V N_A) |
| `平均Z (個数)` | `Mean Z (number)` | – | Σn_iZ_i / Σn_i |
| `平均Z (質量)` | `Mean Z (mass)` | – | Σn_iA_iZ_i / Σn_iA_i |
| `平均A` | `Mean A` | g/mol | 原子あたり |
| `原子数密度` | `Atom density` | nm⁻³ | Σn_i / V |
| `電子数密度` | `Electron density` | nm⁻³ | Σn_iZ_i / V |

- Z（ヘッダ）は、元素ごとの単位胞内原子数の整数 GCD から求める。部分占有があると割り切れず、Z = 1 になりやすい。
- 原子が無い、または占有率の合計が 0 のときは密度などを計算しない。体積は表示される。
- **[main]** 体積の欄が 1 つになり、Å/nm の選択に追従する。原子数密度・電子数密度も Å⁻³ / nm⁻³ に追従する。

## 原子情報（AtomControl）

### 原子の一覧

列: 表示チェック（3D 表示用。CSManager では意味を持たず、保存もされない）、`ラベル`、`元素`（`26: Fe` の形）、`X`、`Y`、`Z`、`占有率`、`多重度`、`ワイコフ文字`、`サイト対称性`。座標は分母 2, 3, 4, 5, 6, 8, 9, 10, 11, 12, 16, 24 のいずれかと 1e-6 以内で一致すれば分数、それ以外は `g6` で表示する。

行の上で右クリック → `等価な原子位置を表示` / `Show equivalent atom positions`: 等価位置の一覧ウィンドウ（`原子位置` / `Atom Positions`）を開く。`コピー` で TSV をクリップボードに置く。

| ボタン（日本語 / 英語） | 動作 |
|---|---|
| `追加` / `Add` | 下の編集欄の原子を末尾に追加 |
| `更新` / `Replace` | 選択中の原子を置換 |
| `上へ移動` / `Up`、`下へ移動` / `Down` | 並べ替え |
| `削除` / `Delete` | 削除 |
| `同種の原子を更新` / `Apply to Same Element` | 表示タブ・デバイワラー因子タブのときだけ出る。選択原子を置換し、同じ元素の全原子に表示設定（表示タブ）または温度因子（デバイワラー因子タブ）をコピーする |
| `全ての原子を更新` / `Apply to all elements` | デバイワラー因子タブのときだけ出る。全原子に温度因子をコピーする |

### サブタブ

**`元素種と原子位置` / `Element & Position`**

- `ラベル`、`元素`（`1: H`〜`98: Cf`）。元素を変えると、X 線・電子線の散乱因子の選択、中性子の同位体（天然存在比に戻る）、半径・色（VESTA 既定）がリセットされる。
- `X`・`Y`・`Z`・`占有率`: **範囲の制限はない**。入力は打鍵ごとに式として評価されるので、`1/3+1/8` のような式も入る。Ctrl+Enter / Shift+Enter で評価結果に置き換える（`NumericBox`）。
- `誤差表示` で誤差欄を出す。
- 原子を選んでいないときの占有率の既定値は 0。

**`原点シフト` / `Origin Shift`**

- 「全ての原子を以下の値で平行移動」。符号 `+`（既定）/ `-` と、プリセット (⅛ ⅛ ⅛)、(¼ ¼ ¼)、(¼ −¼ ¼)、(¼ −¼ 0)、(¼ ¼ 0)、(0 ¼ ¼)、(¼ 0 ¼)、(0 ¼ ⅛)、(0 ¼ −⅛)。
- 任意値は X/Y/Z（−1〜1）を入れて `Apply custom shift`。このとき `+`/`-` の符号は使わない。
- シフト後に等価位置を作り直す。

**`デバイワラー因子` / `Debye-Waller Factor`**

- `形式`: `U` / `B`（既定 B）。`モデル`: `等方` / `非等方`。原子を選ぶ前の既定は `非等方`（CrystalControl が `UseIsotropy = false` を設定）。
- 等方値は Å²。異方性は U 形式なら U_ij（Å²）。**B 形式では無次元の β_ij をそのまま表示する**が、見出しは `B11`、ツールチップは「Å²」で、表示と実体が食い違う。`次元` の表示は Å²（異方性 B では None）。
- 固定コミットでは U ↔ B を切り替えても値は換算されず、ラベルが変わるだけ。**[main]** 切替時に換算し、見出しは `β11`、次元は「無次元」になる。

**`散乱因子` / `Scattering Factor`**（`BeamInteractionVisible = false` でも表示される）

- `X線`: 価数を選ぶ。係数は Waasmaier & Kirfel (1995) *Acta Cryst.* A51, 416-431（`AtomStatic.XrayScatteringWK` のコメント）。
- `電子線`: 価数を選ぶ。中性原子は Peng et al. (1996) *Acta Cryst.* A52, 257-276、イオンは Peng (1998) *Acta Cryst.* A54, 481-485（`AtomStatic.ElectronScatteringPeng` のコメント）。
- `中性子線`: `Natural isotope abundance` / `Custom isotope abundance`（訳なし）。Custom のとき `編集` で同位体組成のウィンドウ（題名が `FormIsotopeComposition` のまま）を開く。列は同位体・原子量・天然存在比 (%)・存在比を指定 (%)。
- CIF / AMC から読んだ原子は、電荷が書かれていても中性原子の係数になる（[ファイル形式](05-file-formats.md#元素の決め方)）。

**`表示` / `Appearance`**（`FormMain_Load` で表示に設定）

`半径`（Å、既定は VESTA 半径 × 0.4）、`原子の色`、`ラベル表示`、`環境`・`拡散`・`反射`・`放射`・`透明度`（0〜1）、`表面粗さ`（0〜20）。CSManager には 3D 表示が無く、DB にも保存されない。

## 多面体/結合描画設定（BondControl）

- 一覧の列: 有効チェック、`中心`、`頂点`、`下限`、`上限`（Å）、`結合の表示`、`多面体の表示`。
- `結合原子`: `(中心)` と `(頂点)` を選ぶ。
- `結合を表示`（既定オン）: `半径` 0.1〜9.9 Å（既定 0.1）、`透明度`（既定 0.7）、`結合長の範囲`（既定 0.1〜1.6 Å）。
- `多面体を表示`（既定オン）: `中心を表示`、`頂点を表示`、`Show Inner Bonds`（日本語 UI では `結合を表示` と表示され、上と同じ名前になる）、`透明度`（既定 0.7）、`辺を表示` → `線幅`（0〜1、既定 0.7）。
- 色の欄は非表示で、色は原子の色から決まる。
- `追加` / `更新` / `削除`。
- **DB に保存されない。** DB の行を選ぶたびに VESTA 既定で作り直される。既存マニュアルの「ReciPro などで使われる」は、CSManager から送る経路（右クリックの `Send this crystal to other software`）が非表示なので当てはまらない。

## 引用文献

| 日本語 UI | 英語 UI | 内容 |
|---|---|---|
| `Note`（訳なし） | `Note` | 自由記述のメモ |
| `著者` | `Authors` | |
| `雑誌名` | `Journal` | |
| `タイトル` | `Title` | |

いずれも DB に保存される。

## 状態方程式（EOS）

既存マニュアルに記載が無いタブ。ラベルの多くは英語のまま。DB には保存されない。

- `EOS を使用` / `Use EOS`（既定オフ）。
- `T₀ における等温圧力` / `Isothermal pressure at T₀`: `3rd BM`（既定）、`4th BM`、`Vinet`、`AP2`、`Keane`、`3rd Vinet`。
- `熱圧力` / `Thermal pressure`: `Mie-Grüneisen`（既定）または `K₀ と V₀ の温度依存性` / `T-dependence K₀ && V₀`（K(T,0) = K(T₀,0) + (∂K/∂T)(T−T₀)、V(T,0) = V₀ exp[∫(a+bT+c/T²)dT]）。

| パラメータ | 単位 | 既定 | 備考 |
|---|---|---|---|
| V₀ | Å³/cell または cm³/mol | 300 | クリックした側を編集できる。V₀[cm³/mol] = V₀[Å³]·N_A/Z |
| K₀ | GPa | | |
| K′₀ | – | 4 | `3rd Vinet` では非表示 |
| K″₀ | GPa⁻¹（ツールチップ） | | `4th BM` のみ |
| K′∞ | – | | `Keane` のみ |
| η, β, ψ | – | | `3rd Vinet` のみ |
| T₀ | K | 300 | |
| γ₀, q, θ₀ | θ₀ は K | θ₀ = 300 | Mie–Grüneisen。γ = γ₀(V/V₀)^q、θ = θ₀ exp[(γ₀−γ)/q] |
| ∂K/∂T | GPa/K | | 温度依存モデル |
| a, b, c | 10⁻⁵ K⁻¹, 10⁻⁹ K⁻², K | | 温度依存モデル |
| T | K | 300 | |
| P | GPa | | 読み取り専用。現在の格子体積での圧力 |

- Mie–Grüneisen: P = P_iso + (γ/V)[E_th(T) − E_th(T₀)]、E_th は Debye モデル（`Crystallography/EOS.cs`）。n は組成式あたりの原子数。
- AP2: p_FG = 2336.965 (Z_e/V₀)^{5/3}（Z_e は単位胞内の電子数、占有率込み）。
- 温度依存モデルと `3rd Vinet` の組み合わせでは 0 を返す。Z = 0 なら P = 0。
- 結晶を切り替えた直後に P と V₀(cm³/mol) が更新されないなど、表示の不具合がある（[実装上の疑問点](90-implementation-questions.md) Q20）。

## 弾性定数（Elasticity）

既存マニュアルに記載が無いタブ。DB には保存されない。

- `弾性スティフネス定数` / `Elastic stiffness constant`（既定）と `弾性コンプライアンス定数` / `Elastic compliance constant` を切り替える。
- Voigt 表記の c11〜c66（対称 6×6 の 21 成分）。単位はツールチップ上で C が GPa、S が GPa⁻¹。C と S は逆行列として相互に持つ。
- 結晶系による拘束のコードはあるが、CrystalControl が `elasticityControl1.SymmetrySeriesNumber` を設定しないため常に P1 扱いになり、**21 成分すべてが独立になる（拘束・自動補完は働かない）**。origin/main でも同じ（Q21）。

## 右クリックメニュー

コントロールの空白部分（テキストボックス・数値欄・一覧の上以外）で右クリックすると出る（CC Designer `contextMenuStrip1`）。

| 日本語 UI | 英語 UI | 動作 |
|---|---|---|
| `ビーム相互作用` | `Beam Interaction` | ウィンドウの表示を切り替える |
| `対称性詳細` | `Symmetry Information` | ウィンドウの表示を切り替える |
| `CIFファイル又はAMCファイルから読み込み` | `Import from CIF or AMC...` | `*.cif;*.amc` を結晶情報に読み込む（DB には入らない） |
| `CIFファイルとして出力` | `Export to CIF` | 既定ファイル名 `{Name}.cif`。**直前に `GenerateFromInterface` を呼ばない**ため、直前の名前・文献・色の変更が入らないことがある |
| `アプリ起動時の格子定数に戻す` | `Revert cell constants` | `RevertInitialCellConstants`。初期値はリスト読み込み（`ConvertToCrystalList`）でしか保存されないので、CSManager では実質働かない（要実機確認） |
| `P1に変換` | `Convert to P1 Space Group` | 全等価位置を独立の原子にし、ラベルを `{label}_{n}` とする |
| `超構造に変換` | `Convert to a superstructure` | `a ×`・`b ×`・`c ×`（1〜100、既定 1）を指定する |
| `異なる軸・原点セッティングの空間群に変換` | `Change the axes/origin setting` | 同じ番号の別設定へ変換。単斜晶は軸の取り替え、直方晶は軸の取り替えと原点移動、正方晶・立方晶は原点移動、三方晶は H ⇔ R |

非表示の項目: `Send this crystal to other software`、`格子ひずみ (invisible)` / `Strain Control`。

!!! danger "変換の不具合（固定コミット）"
    - 六方軸 → 菱面体軸の変換式が誤っている（CC `ChangeAxesOrigin` の `srcExtra == "H"` 分岐）。c_R = (−a−b+c)/3、z_R = y+z となっているが、正しくは c_R = (−a−2b+c)/3、z_R = −y+z（R → H 分岐の逆になっていない）。
    - P1 変換・超構造・軸変換で、異方性の温度因子を座標と一緒に変換しない。
    - いずれも **[main]** `41955ec` で修正（β′ = MβMᵀ）。

## ドラッグ＆ドロップ

結晶情報の上に 1 ファイルをドロップすると `ConvertToCrystal` で読み込み、結晶情報に表示する（DB には入らない）。拡張子 `amc` / `cif` は**小文字のみ**。それ以外や読み込みの失敗は、何も表示せずに無視する。

**[main]** 右クリックメニューの先頭に `化学組成の詳細` / `Details of the chemical composition` が加わる（wt%、at%、規格化原子数、酸化物などへの換算、価数の編集）。

<!-- screenshot: 結晶情報の 格子/対称性 タブ（日本語 UI、AMCSD の 1 件を選択した状態） -->
<!-- screenshot: 結晶情報の 原子情報 タブ ▸ デバイワラー因子（非等方を選択した状態） -->
<!-- screenshot: 状態方程式タブ / 弾性定数タブ -->

## 要確認事項

1. DB に保存されないタブ（Appearance・結合・EOS・弾性・同位体）を、マニュアルでどう扱うか（明記するか、CSManager では非表示にするか）。
2. `アプリ起動時の格子定数に戻す` の実機での挙動。
3. `Radius`（VESTA 半径 × 0.4）の意味づけ。
4. `対称性詳細`・`周期表` などのウィンドウ題名が日本語化されていない点を UI 側で直すか。
5. 原子を選ぶ前の温度因子の既定が `非等方` になっているのは意図どおりか。
