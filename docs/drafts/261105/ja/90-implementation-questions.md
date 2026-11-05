# 実装上の疑問点

本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

マニュアル作成のためにコードを読んでいて見つけた、不具合と思われる点の一覧。**コードは一切変更していない**。dotnet の無い Linux 環境で読んだだけで、実行による再現はしていない。
対象: CSManager master `e081e9d`、サブモジュール固定コミット Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`（2026-07-12）。「main」は各ライブラリの origin/main（Crystallography `9ffcf47`、Controls `aadeb74`、2026-11-05 時点）を指す。

重要度: ★★★ = 結果が誤る・データが失われる、★★ = 機能が働かない、★ = 表示・軽微。

## 結果が誤る・データが失われる

| # | 重要度 | 内容 | 根拠 | main |
|---|---|---|---|---|
| Q7 | ★★★ | **格子定数検索の単位不一致**。入力の Å・° をそのまま、DB 側の nm・rad（`CellOnlyValue_nm_radian`）と比べる。d 値は `/10` しているのに格子定数はしていない。長さは一致せず、角度を 0 以外にすると全件が除外される | `SearchCrystalControl.cs` `buttonSearch_Click`（`SearchParameters` の生成）と検索ワーカーの「格子定数」ブロック、`CrystalMinimum.cs` `CellOnlyValue_nm_radian` | 未修正 |
| Q9 | ★★★ | **CIF の空間群が IT 番号で上書きされる**。`if (symmetrySeriesNumber >= 1 \|\| …)` が H-M が一致した場合でも真になり、`_symmetry_Int_Tables_number` があると、その番号の最初の設定に置き換わる。例: `P 1 21/n 1` → `P 1 21/c 1`。菱面体・第 2 原点の補正も無効になる。Hall が無い CIF（ICSD 形式など）が影響を受ける。おそらく `< 1 \|\|` の意図 | `ConvertCrystalData.cs` `SearchSGseriesNumberForCIF` 末尾（6eeb86a の 1757-1764 行） | 未修正 |
| Q10 | ★★★ | **`Crystal2.FromCrystal` を通った誤差付きの値が 0 になる**。`Compose` は |値| < 1 または ≥ 10 のとき `1.2340(50)E-1` の形で書くが、`Decompose` / `DecomposeOnlyValue` は指数を `NumberStyles.Number`（指数を許さない）で読むため `expValue = 0` になる。単一インポート・XML・`↑ 追加 ↑` / `↑ 入れ替え ↑` で入れた結晶が影響を受ける | `CrystalMinimum.cs` `Compose` / `Decompose` / `DecomposeOnlyValue`、`style = NumberStyles.Number` | `876f5e4` で修正 |
| Q2 | ★★★ | **絞り込み中に保存すると空ファイルになる**。`total = Table.Count` まで回しながら `bindingSource[j]`（絞り込み後のビュー）を参照するため範囲外になる。例外は `Parallel.For` 内で起き、`e.Error` を誰も見ないので、状態表示は「Total saving time」と出る。`AMCSD` / `COD` のどちらかがオフでも絞り込み扱いになる | `CrystalDatabaseControl.cs` `SaveDatabaseWorker_DoWork` | 未修正 |
| Q15 | ★★★ | AMC の異方性 U13 と U23 の入れ替わり。AMC の列順 (12, 13, 23) を内部の (12, 23, 31) に並べ替えていない。同梱 AMCSD は e081e9d で修正版から作り直し済みだが、固定コミットのままでは、単一インポート・一括取り込みの AMC は今も入れ替わる | `ConvertCrystalData.cs` `ConvertFromAmc` | 修正済み（`876f5e4` 付近。e081e9d のコミットメッセージによる） |
| Q14 | ★★★ | CIF の B 型の扱い。`_atom_site_B_iso_or_equiv` があるだけで B 型とみなし、`_atom_site_aniso_U_ij` を捨てる。`_atom_site_aniso_B_ij`（Å²）を無次元の β としてそのまま格納する | `ConvertCrystalData.cs` `ConvertFromCIF`（6eeb86a の 1376-1393 行） | `876f5e4` で修正 |
| Q17 | ★★★ | 六方軸 → 菱面体軸の変換式の誤り。c_R = (−a−b+c)/3、z_R = y+z になっている。正しくは c_R = (−a−2b+c)/3、z_R = −y+z | `CrystalControl.cs` 軸変換（`srcExtra == "H"` 分岐） | `41955ec` で修正 |
| Q18 | ★★★ | P1 変換・超構造・軸変換で、異方性の温度因子を変換しない（元の原子と共有したまま） | `CrystalControl.cs` P1 変換・超構造・軸変換 | `41955ec` で修正 |
| Q11 | ★★ | CIF に原点シフトがあると、su 付きの座標が NaN になる。生の `0.1234(5)` を `|5|` 形式しか読めない `Decompose` に渡している | `ConvertCrystalData.cs` 原点シフトの適用部（6eeb86a の 1313-1320 行） | 未修正 |
| Q12 | ★★ | 三方晶・六方晶の座標の丸めが `Contains(".333")` などの部分文字列判定で行われる。`-0.3333` が +1/3 になり、`0.3337(4)` や誤差の数字にも反応する | `CrystalMinimum.cs` `Decompose`（`IsHex`） | 未修正 |
| Q13 | ★★ | 菱面体軸設定の R 群を CIF に書き出すと、`_symmetry_equiv_pos_as_xyz` が 0 行になる | `ConvertCrystalData.cs` `ConvertToCIF`（中心化の分岐に R が無い） | 未修正 |
| Q8 | ★★ | `FromCrystal` は `d` を設定しない。d リストの無いレコードで、`散乱因子を無視` オフの d 値検索が例外になり、途中までの結果が警告なしに表示される。名前・文献が null のレコードでも同様の例外がありうる | `CrystalMinimum.cs` `FromCrystal`、`SearchCrystalControl.cs` 検索ワーカー | 未修正 |
| Q4 | ★★ | COD の更新確認で `No`（現行版を使う）を選ぶと、読み込みを始めたうえで `false` を返すため、チェックが外れて行が隠れる。再度オンにすると二重に読み込まれる | `CrystalDatabaseControl.cs` `ReadCOD` / `COD_CheckedChanged` 相当 | 未修正 |
| Q16 | ★★ | メニューからの XML 読み込み（`readXml`）に例外処理が無く、壊れた XML でアプリが落ちる。`FileStream` も `using` されていない | `FormMain.cs` `readXml` | – |

## 機能が働かない

| # | 重要度 | 内容 | 根拠 | main |
|---|---|---|---|---|
| Q1 | ★★ | `起動時にAMCSDデータベースを自動で読み込む` が効かない。`FormMain_Load` が Designer 既定値（true）で読み込みを判定した**後に** `readRegistry()` を呼ぶ。レジストリ値が無いときの既定は `"False"` なので、初回起動ではチェックが外れて見える | `FormMain.cs` `FormMain_Load` / `readRegistry` | – |
| Q3 | ★★ | `データベースをクリア` 後、読み込み済みフラグとチェックボックスが戻らず、同じセッションで AMCSD / COD を読み直せない | `CrystalDatabaseControl.cs` `ClearAll` | 未修正 |
| Q5 | ★★ | `データベースを読込` で複数ファイルを選んでも、最初の 1 つしか読まれない（ワーカーが動いている間の呼び出しは捨てられる） | `FormMain.cs` `readDatabaseToolStripMenuItem_Click`、`CrystalDatabaseControl.cs` `ReadDatabase` | – |
| Q6 | ★★ | メインウィンドウへの `.cdb3` のドロップが効かない（`EndsWith("cdb")`）。`.cdb` は一致するが `ReadDatabase` が無視する。ファイルダイアログも `.cdb` / `.cdb2` を出すが読めない（表示文字列も `*.cdb2` が重複） | `FormMain.cs` `FormMain_DragDrop` / `readDatabaseToolStripMenuItem_Click`、`CrystalDatabaseControl.cs` `ReadDatabase` | – |
| Q21 | ★★ | 弾性定数タブの結晶系による拘束が働かない。`elasticityControl1.SymmetrySeriesNumber` がどこからも設定されず、常に P1 扱い。また拘束が働いた場合、コンプライアンス表示でもスティフネスの関係式（S66 = 2(S11−S12) などを使わない）で補完する | `CrystalControl.cs`（設定箇所なし）、`ElasticityControl.cs` | 未修正 |
| Q20 | ★★ | EOS タブの `setParameters`: `SkipEvent` 中に `CalculatePressure` を呼ぶため、結晶を切り替えた直後に P と V₀(cm³/mol) が更新されない。η, β, ψ を読み戻さない。パラメータ欄の表示・非表示を EOS の種類に合わせて更新しない。そのほか、原子数 n を int どうしの割り算で求めており、占有率も反映しない | `EOSControl.cs` `setParameters`、`Crystallography/EOS.cs` | 未修正 |
| Q19 | ★★ | 温度因子の U ↔ B を切り替えても値を換算しない。異方性 B の見出し `B11` とツールチップの「Å²」が、実体（無次元の β）と食い違う | `AtomControl.cs` | `aadeb74` で修正 |
| Q22 | ★ | `CIFファイルとして出力` の前に `GenerateFromInterface` を呼ばないため、直前の名前・文献・色の変更が CIF に入らないことがある | `CrystalControl.cs` Export 処理 | – |
| Q37 | ★ | `アプリ起動時の格子定数に戻す` が実質働かない。初期値は `ConvertToCrystalList` でしか保存されない | `Crystal.cs` `RevertInitialCellConstants` / `SaveInitialCellConstants` | 未修正 |
| Q31 | ★ | `密度と化学式を再計算` は表示列だけを書き換え、保存されるレコードは更新しない。d リストも計算し直さない | `CrystalDatabaseControl.cs` `RecalculateDensityAndFormula` | – |
| Q32 | ★ | COD のダウンロードに失敗しても読み込み済み扱いになり、同じセッションで再試行できない。ダウンロード後に MD5 を照合しない | `CrystalDatabaseControl.cs` `ReadCOD` | 未修正 |
| Q40 | ★ | Release ビルドでも `Debug functions` が表示され、`Compress and Split`（ハンドラなし）・`Check Duplicated File`（本体がコメントアウト）・`CODtype`（空）が押せる | `FormMain.Designer.cs` | – |

## CIF / AMC の読み書きの細部

| # | 内容 | 根拠 |
|---|---|---|
| Q23 | 拡張子の判定が大小区別（`.CIF` は読めない）。単一インポートでは null に対する例外を `catch {}` で握りつぶし、何も表示しない | `ConvertCrystalData.cs` `ConvertToCrystal` / `ConvertToCrystal2`、`FormMain.cs` `toolStripMenuItemImport_Click`、`GetAllImport` |
| Q24 | 引用符を左から順に対にするだけで、CIF の「閉じ引用符の直後は空白」の規則に従わない。`'O'Brien, J.'` は単独項目なら値が空、ループ内ならループ全体が捨てられる | `ConvertFromCIF` 引用符処理 |
| Q25 | H-M も Hall も無い CIF は警告なしに P1 になる（IT 番号や対称操作があっても）。Hall が一致せず H-M が空なら例外でファイル全体が null。固定コミットでは H-M が一致しないときも例外 | `ConvertFromCIF`、`SearchSGseriesNumberForCIF` |
| Q26 | 書き出しで非標準のタグ `_chemical_name`・`_journal_name` を使う。読み込みは `_journal_name_full` を見るので、CSManager で書いて読み直すと雑誌名が消える。H-M も内部名（`P2sub1/c=P12sub1/n1` など）のまま出す | `ConvertToCIF` |
| Q27 | H-M の短縮名の置換で `P422` → P4₂22、`P622` → P6₂22、`P4212` → P4₂2₁2 になる（空白区切りなら問題なし） | `SearchSGseriesNumberForCIF` の文字列置換 |
| Q28 | `_space_group_IT_number` を読まない（`Contains("_Int_Tables_number")` に一致しない） | `ConvertFromCIF` |
| Q29 | タグ照合が大小区別。CIF2 非対応。`data_` ブロックを区別しない。ループのトークン数が合わないと黙ってループごと捨てる | `ConvertFromCIF` |
| Q30 | 元素をラベルから判定するとき大小無視の最長一致のため、type_symbol が無く `CA1` / `NA1` のようなラベルだと Ca / Na になる。電荷は捨てる | `ConvertFromCIF` 元素判定 |
| Q36 | 書き出しの数値（`f6`）と `Compose` が CurrentCulture 依存で、小数点がカンマの環境では壊れる | `ConvertToCIF`、`CrystalMinimum.cs` `Compose` |

## 表示・軽微

| # | 内容 | 根拠 |
|---|---|---|
| Q33 | 英語 resx に `toolStripMenuItemGithubPage.Text` が無く、英語 UI では `ヘルプ` の GitHub 項目が空欄になるはず | `FormMain.resx` |
| Q34 | メニュー件数 `Version.AMCSD = 21_478` に対し、同梱 `AMCSD.cdb3` は 21,588 件。README の COD 件数（529,139）も `Version.COD`（533,220）と食い違う | `Version.cs`、`README.md` |
| Q35 | 英語メニューの綴り `Read AMSCD Database`、`Repport bugs`。`Help (PDF)` / `マニュアル (PDF)` だが PDF ではなく Web を開く | `FormMain.resx` / `FormMain.ja.resx` |
| Q38 | `FormMain_Load` の `if (!File.Exists(UserAppDataPath + "CSManagerSetup.msi")) File.Delete(…)` は条件が逆。しかも現在のダウンロード名は `CSManager-setup.msi` / `CSManager-setup_arm64.msi` なので、ダウンロードしたインストーラは残り続ける | `FormMain.cs` `FormMain_Load`、`ProgramUpdates.cs` `Check` |
| Q39 | フォルダ一括取り込みの `_failed.txt` が選択フォルダの中ではなく隣（`<フォルダ>_failed.txt`）にできる。初期フォルダが `Y:`。`.cif` は一律 COD 扱い | `FormMain.cs` `GetAllImport` / `WorkerAllImport_DoWork` |
| Q41 | 結晶リストのナビゲータのツールチップが日本語の直書きで、UI 言語に従わない | `CrystalDatabaseControl.Designer.cs` |
| Q42 | 日本語 UI で、多面体の `Show Inner Bonds` と `Show Bonds` がどちらも `結合を表示` | `BondControl.ja.resx` |
| Q43 | 同位体組成ウィンドウの題名が `FormIsotopeComposition` のまま。入力検査は 100 超だけで、負値や合計 ≠ 100 % を通す | `FormIsotopeComposition` |
| Q44 | 新規原子の占有率の既定値が 0。原子を選ぶ前の温度因子モデルの既定が非等方 | `NumericBox`、`CrystalControl.Designer.cs`（`UseIsotropy = false`） |
| Q45 | `Increase (Ctrl+Shift+.)` などに日本語訳が無い。結晶系コンボ（検索パネル）も日本語訳が無い | `FormMain.ja.resx`、`SearchCrystalControl.ja.resx` |

## 要確認事項

1. Q9 を実ファイル（Hall なし・`_symmetry_Int_Tables_number` ありの単斜晶 `P 1 21/n 1`）で確認する。
2. CIF の原点シフト検出で、コードは +s を足すが、厳密には −s のはず。2s が normalizer の並進に含まれる群では区別がつかない。Pn-3:2、P4/nmm:2、Fd-3m:2 で確認が必要。
3. Q2・Q4・Q5 は Windows 実機で再現を確認する。
4. サブモジュールを origin/main に上げる予定があるか。上げる場合、[main] の修正（Q10・Q14・Q15・Q17・Q18・Q19 など）を前提にマニュアルを書き直す。
