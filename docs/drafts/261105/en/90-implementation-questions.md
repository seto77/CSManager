# Implementation questions

Draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

Points that look like bugs, found while reading the code for the manual. **No code was changed.** Everything was read on Linux without dotnet; nothing was reproduced by running the program.
Target: CSManager master `e081e9d`, pinned submodules Crystallography `6eeb86a` / Crystallography.Controls `6582a2f` (2026-07-12). "main" means each library's origin/main (Crystallography `9ffcf47`, Controls `aadeb74`, as of 2026-11-05).

Severity: ★★★ = wrong results or data loss, ★★ = feature does not work, ★ = display/minor.

## Wrong results or data loss

| # | Sev. | Description | Evidence | main |
|---|---|---|---|---|
| Q7 | ★★★ | **Unit mismatch in the cell-parameter search.** The Å/° input is compared as is with the database nm/rad (`CellOnlyValue_nm_radian`). d values are divided by 10, cell parameters are not. Lengths never match, and any non-zero angle excludes every crystal | `SearchCrystalControl.cs` `buttonSearch_Click` (building `SearchParameters`) and the cell block of the search worker; `CrystalMinimum.cs` `CellOnlyValue_nm_radian` | not fixed |
| Q9 | ★★★ | **CIF space group overridden by the IT number.** `if (symmetrySeriesNumber >= 1 \|\| …)` is true even when H-M matched, so with `_symmetry_Int_Tables_number` the first setting of that number replaces it. Example: `P 1 21/n 1` → `P 1 21/c 1`; rhombohedral/second-origin corrections are lost too. Affects CIFs without a Hall symbol (e.g. ICSD style). Probably meant `< 1 \|\|` | `ConvertCrystalData.cs` end of `SearchSGseriesNumberForCIF` (lines 1757-1764 at 6eeb86a) | not fixed |
| Q10 | ★★★ | **Values with errors become 0 after `Crystal2.FromCrystal`.** `Compose` writes `1.2340(50)E-1` for \|value\| < 1 or ≥ 10, but `Decompose` / `DecomposeOnlyValue` parse the exponent with `NumberStyles.Number` (no exponent allowed), giving `expValue = 0`. Affects crystals entered by single import, XML, `↑ Add ↑` / `↑ Replace ↑` | `CrystalMinimum.cs` `Compose` / `Decompose` / `DecomposeOnlyValue`, `style = NumberStyles.Number` | fixed in `876f5e4` |
| Q2 | ★★★ | **Saving while filtered writes an empty file.** The loop runs to `Table.Count` but indexes `bindingSource[j]` (the filtered view) and goes out of range. The exception occurs inside `Parallel.For`; nobody checks `e.Error`, so the status still says "Total saving time". Unticking `AMCSD` or `COD` also counts as filtering | `CrystalDatabaseControl.cs` `SaveDatabaseWorker_DoWork` | not fixed |
| Q15 | ★★★ | AMC anisotropic U13 and U23 are swapped (AMC column order 12, 13, 23 not reordered to the internal 12, 23, 31). The bundled AMCSD was rebuilt with the fix in e081e9d, but with the pinned library AMC files imported singly or in batch are still swapped | `ConvertCrystalData.cs` `ConvertFromAmc` | fixed (around `876f5e4`, per the e081e9d commit message) |
| Q14 | ★★★ | CIF B type: the mere presence of `_atom_site_B_iso_or_equiv` makes the atom B type and discards `_atom_site_aniso_U_ij`. `_atom_site_aniso_B_ij` (Å²) is stored as the dimensionless β | `ConvertCrystalData.cs` `ConvertFromCIF` (lines 1376-1393 at 6eeb86a) | fixed in `876f5e4` |
| Q17 | ★★★ | Wrong hexagonal → rhombohedral transformation: c_R = (−a−b+c)/3, z_R = y+z; should be c_R = (−a−2b+c)/3, z_R = −y+z | `CrystalControl.cs` axis conversion (branch `srcExtra == "H"`) | fixed in `41955ec` |
| Q18 | ★★★ | P1 conversion, superstructure and axis conversion do not transform anisotropic displacement parameters (shared with the original atoms) | `CrystalControl.cs` | fixed in `41955ec` |
| Q11 | ★★ | When a CIF has an origin shift, coordinates with su become NaN: the raw `0.1234(5)` is passed to `Decompose`, which only reads the `|5|` form | `ConvertCrystalData.cs` origin-shift block (lines 1313-1320 at 6eeb86a) | not fixed |
| Q12 | ★★ | Trigonal/hexagonal coordinate rounding by substring tests such as `Contains(".333")`: `-0.3333` becomes +1/3, and `0.3337(4)` or digits of the error also trigger it | `CrystalMinimum.cs` `Decompose` (`IsHex`) | not fixed |
| Q13 | ★★ | Exporting an R group in the rhombohedral setting writes zero `_symmetry_equiv_pos_as_xyz` lines | `ConvertCrystalData.cs` `ConvertToCIF` (no R case in the centring branch) | not fixed |
| Q8 | ★★ | `FromCrystal` does not set `d`. For records without a d list, a d-spacing search with `Ignore scattering factor` off throws and shows a partial result without warning. Records with a null name/reference can throw similarly | `CrystalMinimum.cs` `FromCrystal`, `SearchCrystalControl.cs` search worker | not fixed |
| Q4 | ★★ | Choosing `No` (use the current copy) in the COD update dialog starts loading but returns `false`, so the box is unticked and the rows hidden; ticking again loads them twice | `CrystalDatabaseControl.cs` `ReadCOD` and the COD checkbox handler | not fixed |
| Q16 | ★★ | XML import from the menu (`readXml`) has no exception handling; a broken XML crashes the app. The `FileStream` is not disposed | `FormMain.cs` `readXml` | – |

## Features that do not work

| # | Sev. | Description | Evidence | main |
|---|---|---|---|---|
| Q1 | ★★ | `Read AMCSD Database on Next Boot` has no effect. `FormMain_Load` decides on loading with the Designer default (true) **before** calling `readRegistry()`. The registry default is `"False"`, so on first launch the item appears unchecked | `FormMain.cs` `FormMain_Load` / `readRegistry` | – |
| Q3 | ★★ | After `Clear Database` the "already read" flags and checkboxes stay, so AMCSD/COD cannot be read again in the same session | `CrystalDatabaseControl.cs` `ClearAll` | not fixed |
| Q5 | ★★ | `Read Database` with several files reads only the first (calls made while the worker is busy are dropped) | `FormMain.cs` `readDatabaseToolStripMenuItem_Click`, `CrystalDatabaseControl.cs` `ReadDatabase` | – |
| Q6 | ★★ | Dropping a `.cdb3` on the main window does nothing (`EndsWith("cdb")`); `.cdb` matches but `ReadDatabase` ignores it. The file dialog offers `.cdb` / `.cdb2` that cannot be read (its label also repeats `*.cdb2`) | `FormMain.cs` `FormMain_DragDrop` / `readDatabaseToolStripMenuItem_Click`, `CrystalDatabaseControl.cs` `ReadDatabase` | – |
| Q21 | ★★ | Crystal-system constraints on the Elasticity tab never apply: `elasticityControl1.SymmetrySeriesNumber` is never set, so P1 is always assumed. If they did apply, the compliance view would be completed with the stiffness relations (not S66 = 2(S11−S12) etc.) | `CrystalControl.cs` (no assignment), `ElasticityControl.cs` | not fixed |
| Q20 | ★★ | EOS tab `setParameters`: calls `CalculatePressure` while `SkipEvent` is set, so P and V₀(cm³/mol) are not updated right after switching crystals; η, β, ψ are not read back; parameter fields are not shown/hidden for the selected EOS. Also, the atom count n is an integer division and ignores occupancy | `EOSControl.cs` `setParameters`, `Crystallography/EOS.cs` | not fixed |
| Q19 | ★★ | Switching U ↔ B does not convert values; the anisotropic-B header `B11` and tooltip "Å²" contradict the stored dimensionless β | `AtomControl.cs` | fixed in `aadeb74` |
| Q22 | ★ | `Export to CIF` does not call `GenerateFromInterface` first, so the latest changes to name, references or colour may be missing | `CrystalControl.cs` export | – |
| Q37 | ★ | `Revert cell constants` effectively does nothing; initial values are saved only by `ConvertToCrystalList` | `Crystal.cs` `RevertInitialCellConstants` / `SaveInitialCellConstants` | not fixed |
| Q31 | ★ | `Re-calculate density and formula` rewrites only the displayed columns, not the stored records, and does not recompute d lists | `CrystalDatabaseControl.cs` `RecalculateDensityAndFormula` | – |
| Q32 | ★ | After a failed COD download the database counts as read, so no retry in the same session; no MD5 check after download | `CrystalDatabaseControl.cs` `ReadCOD` | not fixed |
| Q40 | ★ | `Debug functions` is visible in Release builds, with `Compress and Split` (no handler), `Check Duplicated File` (body commented out) and `CODtype` (empty) | `FormMain.Designer.cs` | – |

## Details of CIF/AMC reading and writing

| # | Description | Evidence |
|---|---|---|
| Q23 | Extension test is case-sensitive (`.CIF` not read). The single import swallows the null-reference exception with `catch {}` and shows nothing | `ConvertCrystalData.cs` `ConvertToCrystal` / `ConvertToCrystal2`, `FormMain.cs` `toolStripMenuItemImport_Click`, `GetAllImport` |
| Q24 | Quotes are paired left to right, ignoring the CIF rule "closing quote followed by white space". `'O'Brien, J.'` gives an empty value as a single item and discards the whole loop inside a loop | `ConvertFromCIF` quote handling |
| Q25 | A CIF with neither H-M nor Hall becomes P1 without warning (even with an IT number or operators). If Hall does not match and H-M is empty, an exception makes the whole file null. In the pinned commit a non-matching H-M also throws | `ConvertFromCIF`, `SearchSGseriesNumberForCIF` |
| Q26 | Export uses the non-standard tags `_chemical_name` and `_journal_name`; reading looks for `_journal_name_full`, so the journal disappears on re-import. H-M is written in internal form (`P2sub1/c=P12sub1/n1` etc.) | `ConvertToCIF` |
| Q27 | Short-symbol replacement turns `P422` into P4₂22, `P622` into P6₂22 and `P4212` into P4₂2₁2 (fine with spaces) | string replacement in `SearchSGseriesNumberForCIF` |
| Q28 | `_space_group_IT_number` is not read (does not match `Contains("_Int_Tables_number")`) | `ConvertFromCIF` |
| Q29 | Case-sensitive tag matching; no CIF2; `data_` blocks not distinguished; loops with a token count that doesn't fit are silently discarded | `ConvertFromCIF` |
| Q30 | The element is taken from the label by a case-insensitive longest match, so labels such as `CA1` / `NA1` without a type symbol give Ca / Na. Charges are discarded | element detection in `ConvertFromCIF` |
| Q36 | Exported numbers (`f6`) and `Compose` depend on CurrentCulture and break in locales with a decimal comma | `ConvertToCIF`, `CrystalMinimum.cs` `Compose` |

## Display / minor

| # | Description | Evidence |
|---|---|---|
| Q33 | No `toolStripMenuItemGithubPage.Text` in the English resx; the GitHub item of `Help` should be blank in the English UI | `FormMain.resx` |
| Q34 | Menu count `Version.AMCSD = 21_478`, but the bundled `AMCSD.cdb3` holds 21,588 records. README's COD count (529,139) differs from `Version.COD` (533,220) | `Version.cs`, `README.md` |
| Q35 | English menu spellings `Read AMSCD Database`, `Repport bugs`. `Help (PDF)` / `マニュアル (PDF)` opens a web page, not a PDF | `FormMain.resx` / `FormMain.ja.resx` |
| Q38 | `if (!File.Exists(UserAppDataPath + "CSManagerSetup.msi")) File.Delete(…)` in `FormMain_Load` has the condition inverted, and the downloaded installer is now named `CSManager-setup.msi` / `CSManager-setup_arm64.msi`, so it is never removed | `FormMain.cs` `FormMain_Load`, `ProgramUpdates.cs` `Check` |
| Q39 | The batch import's `_failed.txt` is created next to the selected folder (`<folder>_failed.txt`), not inside; initial folder `Y:`; `.cif` always marked COD | `FormMain.cs` `GetAllImport` / `WorkerAllImport_DoWork` |
| Q41 | Navigator tooltips of the database table are hard-coded Japanese, regardless of the UI language | `CrystalDatabaseControl.Designer.cs` |
| Q42 | In the Japanese UI, `Show Inner Bonds` and `Show Bonds` are both `結合を表示` | `BondControl.ja.resx` |
| Q43 | The isotope window title is still `FormIsotopeComposition`; validation only rejects > 100, accepting negative values or totals ≠ 100 % | `FormIsotopeComposition` |
| Q44 | Default occupancy of a new atom is 0; default displacement model before selecting an atom is anisotropic | `NumericBox`, `CrystalControl.Designer.cs` (`UseIsotropy = false`) |
| Q45 | No Japanese for `Increase (Ctrl+Shift+.)` etc., nor for the crystal-system combo of the search panel | `FormMain.ja.resx`, `SearchCrystalControl.ja.resx` |

## Open questions

1. Confirm Q9 with a real file (no Hall, with `_symmetry_Int_Tables_number`, monoclinic `P 1 21/n 1`).
2. The CIF origin-shift detection adds +s, but strictly it should be −s. Groups where 2s is a normalizer translation cannot tell the difference; check Pn-3:2, P4/nmm:2 and Fd-3m:2.
3. Reproduce Q2, Q4 and Q5 on Windows.
4. Is there a plan to move the submodules to origin/main? If so, the manual should be rewritten assuming the [main] fixes (Q10, Q14, Q15, Q17, Q18, Q19, …).
