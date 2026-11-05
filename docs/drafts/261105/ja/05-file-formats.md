# 対応ファイル形式とインポート・エクスポート

本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

対象: CSManager master `e081e9d`（サブモジュール Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`）。各節の **[main]** は Crystallography origin/main（`876f5e4`・`9ffcf47` など）で変わる点。dotnet が無い環境で書いたため、実ファイルでの動作確認はしていない。
略記: C = `Crystallography/Crystal/ConvertCrystalData.cs`、M = `Crystallography/Crystal/CrystalMinimum.cs`（`Crystal2`）、FM = `CSManager/FormMain.cs`、CC = `Crystallography.Controls/Crystal/CrystalControl.cs`、CDC = `CrystalDatabaseControl.cs`。

## 一覧

| 形式 | 読込 | 書出 | 入口 | 制限・注意 |
|---|---|---|---|---|
| `.cdb3`（CSManager DB） | ○ | ○ | `ファイル` ▸ `データベースを読込` / `データベースを保存` | [データベース](02-database.md)。メインウィンドウへのドロップは不可 |
| `.cdb` / `.cdb2`（旧 DB） | × | × | ダイアログには出る | 黙って無視される（CDC `ReadDatabase`） |
| `.cif` | ○ | ○ | 単一インポート、結晶情報へのドロップ・右クリック、フォルダ一括取り込み / 結晶情報の右クリック `CIFファイルとして出力` | 拡張子は**小文字のみ**。CIF2 非対応。詳細は下記 |
| `.amc`（AMCSD） | ○ | × | 単一インポート、結晶情報へのドロップ・右クリック、フォルダ一括取り込み | 拡張子は小文字のみ |
| AMCSD CSV（`.csv`） | ○ | × | `Debug functions` ▸ `Import AMCSD_CSV` | 保守用 |
| `Crystal[]` XML（PDIndexer / ReciPro の結晶リスト） | ○ | × | `インポート (PDIndexer, ReciProの結晶リスト) (*.xml)`、メインウィンドウへのドロップ | メニュー経由は例外処理なし（壊れた XML でアプリが落ちる） |
| クリップボード | — | ○ | 結晶リストの選択 | [他ソフトとの連携](07-interoperation.md) |

形式は**中身を見ず、拡張子だけ**で決まる。`ConvertToCrystal2` / `ConvertToCrystal`（C）は `EndsWith("amc")` / `EndsWith("cif")`（Ordinal）で判定するので、`.CIF` や `.Cif` は読めない。単一インポートでは null に対する例外が `catch {}` で握りつぶされ、何も表示されない（FM `toolStripMenuItemImport_Click`）。

## 入口ごとの違い

| 入口 | 処理 | DB に入るレコード |
|---|---|---|
| `インポート (単一ファイル) (CIF, AMC)` | `ConvertToCrystal(file).ToCrystal2()`（Crystal2 → Crystal → `FromCrystal` を経由） | `datatype = 0`、**d リストなし**、数値文字列は `Compose` で作り直す |
| 結晶情報へのドロップ / 右クリック `CIFファイル又はAMCファイルから読み込み` | `ConvertToCrystal` で結晶情報に表示するだけ | DB には入らない（`↑ 追加 ↑` などで入れる。その場合は上と同じ） |
| `Import All File (CIF or AMC)`（フォルダ一括取り込み） | `ConvertToCrystal2`（文字列のまま） + d・化学式・密度を計算 | `.cif` は一律 `datatype = COD`、`.amc` は AMCSD |
| `Import AMCSD_CSV` | `ConvertFromAmc` + d・化学式・密度を計算 | `datatype = AMCSD` |
| XML | `XmlSerializer(Crystal[])` → `SetAxis` → `Crystal2.FromCrystal` | `datatype = 0`、d リストなし |

### 一括取り込み

`Debug functions` ▸ `Import All File (CIF or AMC)`（FM `GetAllImport` / `WorkerAllImport_DoWork`）:

- フォルダを選び（初期値 `Y:`）、「Also search subdirectory?」で `はい` ならサブフォルダも対象。
- フルパスが `amc` / `cif` で終わるファイル（大小区別）を逆順に、並列度 1 で変換する。
- 失敗したファイル名（拡張子なし）を `<選択フォルダ>_failed.txt` に書く。フォルダの**中ではなく、隣**にできる（パスに `\` を足していない）。
- 完了後、全件を DB 末尾に追加する。

### AMCSD CSV

`Debug functions` ▸ `Import AMCSD_CSV`（FM `importAMCSDCSVToolStripMenuItem_Click`）: 列 `database_code_amcsd`・`Mineral Name`・`Ideal IMA Formula`・`AMC File Contents`・`Volume`・`Pressure`・`Temperature`・`Chemistry`・`AMC File`・`CIF File`・`DIF File`・`File`・`Reference ID` を持つ CSV（CsvHelper、InvariantCulture）。使うのは `AMC File Contents` だけで、これを行に分けて `ConvertFromAmc` に渡す。失敗した行は CSV と同じフォルダの `_failed.txt` に `番号: AMCSD コード` で書く。CSV 経由では空行が残るため、著者欄に空行があるレコードは失敗する（C `ConvertFromAmc`）。

## CIF の読み込み（C `ConvertFromCIF`、行番号は 6eeb86a）

### 前処理

1. UTF-8（BOM 検出）で全文を読み、改行を揃え、HTML 実体参照（`&amp; &lt; &gt; &quot; &nbsp; &#39;`）を全文で戻す（`EscapeString`）。
2. `_shelx_hkl_file` などの後に続く `;…;` を消す。SHELX の file 行から checksum 行までを消す。
3. 行に分ける（空行はここで消える）。
4. `_refln*`・`_reflns*`・`_geom*`・`_platon*`・`_diffrn_refln*`（前方一致）: ループならループごと消す。単独項目なら**タグ行だけ**を消す。
5. `#` で始まる行を消す（最終行を除く）。この時点では Trim 前なので、インデントされたコメントや行の途中のコメントは残る。
6. セミコロン文字列: 次の `;` 行までを空白で 1 行につなぎ、`'…'` で囲む。**開きの `;` と同じ行の文字は捨てる。**
7. タブを空白にし、Trim、空行の削除。
8. 引用符: `''` を退避させたあと、`'` と `"` を**左から順に対にする**（CIF 1.1 の「閉じ引用符の直後は空白」の規則には従わない）。

### 構文

- 単独項目: 空白で区切ったトークンが 2 個ならそれが値、1 個なら次の行全体が値、**3 個以上なら値は空**。
- `loop_`: タグを集めたあと、続くトークンをデータとする。**トークン数がタグ数で割り切れなければ、ループ全体を黙って捨てる。**
- タグの照合は**大文字小文字を区別する**（CIF の規格では区別しない）。
- **CIF2 非対応**: `#\#CIF_2.0`、三重引用符、リスト `[]`、テーブル `{}`、DDLm のドット区切りのタグ（`_cell.length_a`）は扱えない。
- **`data_` ブロックを区別しない**。全ブロックの項目が 1 つのリストにまとまる。原子は `_atom_site_label` を含む最初のループ、格子定数は原子ループより前で最後に出た値、空間群名は候補を集めて先頭から試す。複数ブロックの CIF では結果が予測しにくい（要確認事項 1）。

### 読むタグ

| タグ | 照合 | 用途 |
|---|---|---|
| `_chemical_name*`（`_mineral`・`_common`・`_systematic`・`_structure_type` など、前方一致） | StartsWith | 出現順に空白でつないで結晶名にする（末尾に空白が残る） |
| `_chemical_formula_sum` | 完全一致 | 結晶名が空か `?` のときの代わり。化学式欄には使わない（化学式は原子から計算） |
| `_cell_length_a/b/c`、`_cell_angle_alpha/beta/gamma` | 完全一致 | 格子定数（文字列のまま、su 付き） |
| `_publ_author_name` | 完全一致 | 著者。各名前の `,` を消して `", "` でつなぎ、**全体から `.` を消す**（"Smith, J.A." → "Smith JA"） |
| `_publ_section_title` | 完全一致 | タイトル |
| `_journal_name_full`・`_journal_coden_ASTM`・`_journal_year`・`_journal_volume`・`_journal_page_first`・`_journal_page_last`・`_journal_issue` | 完全一致 | `"{full} {coden}, {issue}, {volume}({year}), {first}-{last}"` にまとめて雑誌欄へ |
| `_symmetry_space_group_name_H-M`、`_space_group_name_H-M_alt`、`_H-M_full` など | `Contains("_space_group_name_H-M")` | H-M 候補 |
| `_symmetry_space_group_name_Hall`、`_space_group_name_Hall` | Contains | Hall 候補 |
| `_symmetry_Int_Tables_number` | `Contains("_Int_Tables_number")` | 空間群番号。**`_space_group_IT_number` はこの照合に一致しないので読まれない** |
| `_space_group_symop_operation_xyz`、`_symmetry_equiv_pos_as_xyz` | 完全一致 | 原点シフトの検出だけに使う（空間群の決定には使わない） |
| `_atom_site_label`、`_atom_site_type_symbol` | 完全一致 | ラベルと元素 |
| `_atom_site_fract_x/y/z` | 完全一致 | 座標。`?` / `.` は空 → NaN |
| `_atom_site_occupancy` | 完全一致 | 占有率。無ければ 1 |
| `_atom_site_U_iso_or_equiv`、`_atom_site_B_iso_or_equiv` | 完全一致 | 等方性の温度因子 |
| `_atom_site_aniso_label` | 原子ラベルと完全一致 | 異方性ループと原子の対応 |
| `_atom_site_aniso_U_11/22/33/12/13/23` | 完全一致 | 異方性 U（Å²） |
| `_atom_site_aniso_B_11/…/23` | 完全一致 | 異方性 B（下記の注意） |

`_atom_site_thermal_displace_type` と `_chemical_formula_structural` は読むが使わない。

### 読まないタグ（代表）

- 原子サイト: `_atom_site_calc_flag`、`_atom_site_refinement_flags*`、`_atom_site_disorder_assembly/group`、`_atom_site_symmetry_multiplicity`、`_atom_site_Wyckoff_symbol`、`_atom_site_attached_hydrogens`、`_atom_site_adp_type`、`_atom_site_Cartn_x/y/z`（直交座標だけの CIF は座標が NaN になる）、`_atom_site_aniso_type_symbol`、`_atom_site_aniso_beta_*`、`_atom_type_*`（`_atom_type_oxidation_number` を含む）。
- 対称: `_space_group_IT_number`、`_space_group_crystal_system`、`_symmetry_cell_setting`、`_space_group_symop_id`。
- 格子・実験: `_cell_volume`、`_cell_formula_units_Z`、`_cell_measurement_temperature/pressure`、`_diffrn_ambient_*`、`_diffrn_radiation_wavelength`、`_exptl_*`（`_exptl_crystal_density_diffrn` を含む。密度は計算値）、`_refine_*`。
- 書誌: `_database_code_*`、`_cod_database_code`、`_journal_name_abbrev`、`_publ_section_abstract`、`_audit_*`、`_computing_*`、`_chemical_formula_weight`。

### 数値の扱い（M `ToBytes` / `Decompose`）

- 値は**文字列のまま**保存する。`0-9 . / - ( ) E` の 13 種を 4 bit に詰める。`0.1234(5)` は値 0.1234、誤差 0.0005 として読む。
- 分数（`1/3`）は読める。`?`・`NaN`・空は NaN。
- 表に無い文字（`+`、空白、`,`、英字）は `0` に化ける（例: `+.25` → `0025`）。
- **指数表記（`1.2E-3`）は 0 になる**（`NumberStyles.Number` で指数部を読めず、`expValue = 0`）。**[main]** `NumberStyles.Float` に直った。
- 三方晶・六方晶（No.143〜194）では、座標の文字列が `.333`・`.667`・`.167`・`.0833` などを**部分文字列として含めば** 1/3, 2/3… に置き換える。`-0.3333` も +1/3 になる（Q12）。

### U か B か、等方か異方か

- `_atom_site_B_iso_or_equiv` か B_ij が 1 つでもあれば B 型、なければ U 型。**B_iso があるだけで U_ij は捨てられる。**
- 選ばれた型の 6 成分がすべて空なら等方。等方値が空なら 0。
- B 型の異方性は β（無次元）として格納されるため、`_atom_site_aniso_B_ij`（Å²）を入れると桁違いになる。
- **[main]** 異方性があれば必ず U 型。B_ij は 8π² で割って U に換算（su も同じ係数）。U_iso が無ければ B_iso を換算。

### 元素の決め方

- `_atom_site_type_symbol` があればそれ、なければラベルの文字列から、先頭部分を長い順に短くしながら元素記号と比べる（**大小無視の最長一致**、Z ≤ 96 まで）。`Fe3+` → Fe、`O2-` → O。
- **電荷・価数は捨てる**（X 線・電子線の散乱因子は中性原子のまま）。
- 大小無視のため、type_symbol が無く、ラベルが `CA1`・`NA1` だと Ca・Na になる。
- `OH` は同じ座標の H と O の 2 原子にする。`D` は H（同位体 ²H 100 %）にする。
- 判定できない原子と Z ≥ 97 の原子は**黙って捨てる**。

### 空間群の決め方（C `SearchSGseriesNumberForCIF`）

1. H-M も Hall も無ければ **P1**。IT 番号や対称操作があっても P1 になり、警告も出ない。
2. **Hall**: 空白を除いて内部表の Hall 記号と完全一致すれば採用する（IT 番号による上書きもしない）。原点シフト付きの Hall や別の書き方の Hall は一致しない。
3. **H-M**: 正規化する（`_` の下付き、`:H` `:R` `:1` `:2` などの接尾辞、原点選択 2 の検出、短縮名から完全名への展開）。その後、空白を除いた名前を部分文字列として含む内部名のうち**最短**のものを選ぶ。e グライドは a/b/c に置き換えた名前とも照合する。
4. 格子定数が文字列として a=b=c かつ α=β=γ で、内部名が六方軸なら菱面体軸（R）にする。原点選択 2 なら第 2 原点の設定にする。
5. **`_symmetry_Int_Tables_number` が 1〜230 なら、H-M で決めた設定を、その番号の最初の設定で上書きする**（`symmetrySeriesNumber >= 1 || …` が常に真になる）。例: `P 1 21/n 1` → `P 1 21/c 1`。Hall が無い（または一致しない）CIF が影響を受ける（Q9）。
6. 原点シフトの検出: 対称操作の数が内部の一般位置の数（中心化を含む）と一致するときだけ、{0, ±1/8, ±1/4}³ のシフトを試す。操作の集合が一致すれば全座標にそのシフトを足す。一致しなくても警告は出ない。この経路では su 付き座標が NaN になる（Q11）。

## AMC の読み込み（C `ConvertFromAmc`）

行の並びを次のように解釈する（ファイルからの場合は空行を除いてから）。

1. 結晶名
2. 著者。続く行は、最後の文字が `.`・`/`・数字でなく、`doi.org`・`DOI: `・`Mineralogy` を含まなければ、著者の続きとして `", "` でつなぐ
3. 雑誌
4. タイトル。格子定数の行までを足す。`_database_code_amcsd` は `AMCSD:`、`_cod_database_code` は `COD:` に置き換えてタイトル欄に入れる
5. 格子定数の行（トークンが 7 個で、最初の 6 個が数値）。7 個目が空間群
6. 原点シフトの行（あれば。`atom` で始まらないトークン 3 個の行）。座標に加える
7. 原子の見出し（`occ`・`Uiso`・`Biso`・`U(1,1)`・`B(1,1)` を探す）
8. 原子の行。トークン数が見出しと違えば、見出しの位置で切る固定幅読みに切り替える。occ が無ければ 1

- 空間群: `*` か `:2` があれば第 2 原点。C2₁・C2/a・F2/m・B2₁・B2₁/m・Imab・F4/mmm などの非標準の中心化は、P 格子の群に置き換え、中心化の並進で原子を複製する（座標は mod 1 にしない）。
- 元素は**大小区別**の最長一致。`OH` → H+O、`D` → ²H、`Wat`/`WAT`/`wat` → H, H, O。
- **[main]** 異方性の **U13 と U23 の入れ替わりを修正**（AMC の列順 12, 13, 23 を内部の 12, 23, 31 に並べ替える）。固定コミットでは入れ替わっている。同梱 AMCSD（e081e9d）は修正版で作り直してある。単一インポートで入れた AMC は、固定コミットのままなら入れ替わる。

## CIF の書き出し（C `ConvertToCIF`、CC 右クリック → `Crystal.ExportCIF`）

UTF-8（BOM なし）で次を書く。

| 出力 | 備考 |
|---|---|
| `# exported from…`、`data_global` | |
| `_chemical_name '…'` | **非標準のタグ**。`'` はエスケープしない |
| `loop_ _publ_author_name` | 著者欄を `,` で分けて書く |
| `_journal_name '…'` | **非標準のタグ**。読み込みは `_journal_name_full` を見るため、読み直すと雑誌名が消える |
| `_publ_section_title` | `;…;`、80 桁で折り返す |
| `_chemical_formula_sum` | |
| `_cell_length_*`、`_cell_angle_*`、`_cell_volume`、`_exptl_crystal_density_diffrn` | `f6`、**CurrentCulture**、su なし（小数点がカンマの環境ではカンマで出る）。**[main]** InvariantCulture |
| `_space_group_IT_number`、`_symmetry_Int_Tables_number`、`_symmetry_cell_setting` | |
| `_symmetry_space_group_name_H-M` | 内部名から `Hex`/`Rho` を消しただけ。`P2sub1/c=P12sub1/n1` や `Fd-3m(2)` のような文字列がそのまま出る |
| `_symmetry_space_group_name_Hall` | 空白なしの内部表記 |
| `loop_ _symmetry_equiv_pos_as_xyz` | 一般位置 + 中心化の並進。**菱面体軸設定の R 群では 0 行になる**（Q13） |
| `_atom_site_label`・`_type_symbol`・`_fract_x/y/z`・`_occupancy`・`_U_iso_or_equiv` | 電荷は書かない。異方性の原子では保存されている等方値が出るため、0 になることがある。**[main]** U_eq を出す |
| `_atom_site_aniso_label`、`_U_11/22/33/23/13/12` | 異方性の原子だけ |

**失われるもの**: すべての su、メモ（Note）、雑誌の細目、同位体（D は H になる）、価数、結合・多面体、EOS、弾性、色、Z、測定条件。CSManager どうしで書いて読み直す場合は、Hall が完全一致するので空間群は戻る。

## Crystal2 レコード

DB（cdb3）とクリップボードで運ばれる縮約レコード（M、`Atoms2` は `Crystallography/Atom/AtomMinimum.cs`）。

| 保持されるもの | 型・備考 |
|---|---|
| 格子定数 a, b, c（Å）、α, β, γ（°） | **文字列のまま**（su 付き、4 bit 詰め） |
| 空間群 | `sym`（short、内部の設定番号 0〜540） |
| 結晶名、メモ、雑誌、著者、タイトル、化学式 | string |
| 密度 | float |
| 原子: ラベル、x/y/z/occ/iso/aniso の文字列、元素番号、`SubXray`・`SubElectron`、U/B、等方/異方 | aniso の順は 11, 22, 33, 12, 23, 31。U なら Å²、B なら β |
| d リスト | float[]、強度上位 16 本（nm） |
| 元ファイル名、データ種別、表示色 | |

`Crystal2.FromCrystal`（結晶情報や XML から DB に入れる経路）で**失われるもの**: 結合・多面体、EOS、弾性、歪み・応力、格子面、雑誌の細目、同位体（D は H として保存）、原子の色・半径、d リスト（設定されない）。

!!! danger "FromCrystal を通った数値が 0 になる（固定コミット）"
    `FromCrystal` は数値を `Compose` で文字列に戻す。誤差付きで |値| < 1 または ≥ 10 の値は `1.2340(50)E-1` のような指数付きになるが、読み戻しの `Decompose` は指数を読めず 0 になる。単一インポート・XML・`↑ 追加 ↑` / `↑ 入れ替え ↑` で入れた結晶では、DB から開くと誤差付きの格子定数・座標・U が 0 になりうる（Q10）。**[main]** `876f5e4` で修正。

## 要確認事項

1. 複数 `data_` ブロックの CIF（COD の一部、粉末の多相 CIF）の実際の挙動。
2. 空間群の上書き（Q9）を、ICSD 形式の CIF（Hall なし・`_symmetry_Int_Tables_number` あり）で確認する。
3. 原点シフトの符号: コードは +s を足すが、厳密に解くと −s になる。2s が normalizer の並進に入る群では一致してしまう。Pn-3:2、P4/nmm:2、Fd-3m:2 で確認が必要。
4. HTML 実体参照を全文で戻す処理の意図（COD の Web 出力対策か）。
5. 一括取り込みで `.cif` を一律 COD 扱いにするのは意図どおりか（自前の CIF も `COD` チェックで隠れる）。
