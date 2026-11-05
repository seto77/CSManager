# Existing manual versus current code

Draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

Compared:
- Existing manual: `docs/src/ja/*.md` and `docs/src/en/*.md` (MkDocs, 11 languages; the other nine are translations with the same structure, so the same findings apply)
- Code: CSManager master `e081e9d`, pinned submodules Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`
- Also: `README.md`, `README-PORTABLE.txt`, history in `CSManager/Version.cs`

Other documentation assets: the bundled PDF manuals (`doc\CSManager(en/ja).pdf`) were removed from the csproj and are not in the repository (260625Cl comment). The GitHub Wiki could not be cloned (authentication required, or it does not exist). `docs/src/assets/cap-*-auto/FormMain.png` are screenshots generated with `--capture`; no page references them.

## A. Statements that disagree with the code

| # | Page | Existing statement | Actual behaviour | Evidence |
|---|---|---|---|---|
| A1 | index, troubleshooting | requires **.NET Desktop Runtime 8** or later | .NET 10 (`net10.0-windows`), updated in ver1.904; README also says 10 | `CSManager.csproj`, `Version.History` |
| A2 | 1-database-loading | "Read Database — opens any `*.cdb3`" | the dialog offers `*.cdb; *.cdb2; *.cdb3`, but anything except `.cdb3` is silently ignored; with multi-select only the first is read | `FormMain.readDatabaseToolStripMenuItem_Click`, `CrystalDatabaseControl.ReadDatabase` |
| A3 | 1-database-loading | "COD is downloaded on first load, then the downloaded file is read" | every time, the MD5 of all parts is checked and the web header compared for updates (Yes/No/Cancel if newer); if missing, asks whether to download | `CrystalDatabaseControl.ReadCOD` |
| A4 | 1-database-loading / 7-options | `Read AMCSD Database on Next Boot` "enabled by default", disabling it prevents loading | always loads regardless; appears unchecked on first launch (Q1) | `FormMain.FormMain_Load` / `readRegistry` |
| A5 | 1-database-loading | the AMCSD menu shows the current number of entries | it shows `Version.AMCSD = 21,478`; the bundled database has 21,588 (e081e9d) | `Version.cs`, `AMCSD.cdb3` |
| A6 | 2-database-table | "if PDIndexer or ReciPro is running, the crystal is transferred via the clipboard on selection" | no check whether they run; **the clipboard is overwritten on every selection** | `FormMain.crystalDatabaseControl_CrystalChanged` |
| A7 | 3-search | "press the `Search` button or the Enter key" | Enter in Name/Reference/numeric boxes and `Search`; toggling `AMCSD` / `COD` also searches. All conditions are ANDed | `SearchCrystalControl` |
| A8 | 3-search | `Cell Params` — "items for which you enter zero as the tolerance are ignored" | fields whose **value** is 0 are ignored; tolerance 0 means exact match. Lengths relative %, angles absolute °. Effectively broken by a unit mismatch (Q7) | `SearchCrystalControl` search worker |
| A9 | 3-search | `d-spacing` — "only the top 20 crystal planes by intensity" | top **16** (`bestNum = 16` in `GetDspacingList`). Up to three d values, ANDed; relative % tolerance | `Crystal.GetDspacingList`, `SearchCrystalControl` |
| A10 | 3-search | `Name`, `Reference` only "search by …" | Name: substring, case-insensitive. Reference: substring of journal, authors or title | same |
| A11 | 3-search | three element states in the periodic table | correct. Add: any excluded element rejects, all included are required, crystals without atoms are rejected, `La`/`Ac` buttons do nothing | `FormPeriodicTable`, `SearchCrystalControl` |
| A12 | 5-import-export | "reads a CIF or AMC file and appends it to the database" | lower-case extensions only; failures show nothing; no d list is built, so it is not found by the d-spacing search (with scattering factor) | `FormMain.toolStripMenuItemImport_Click`, `ConvertCrystalData.ConvertToCrystal` |
| A13 | 5-import-export / 6-interoperation | context menu `Send this crystal to other software` | hidden (`Visible = False`) | `CrystalControl.resx` |
| A14 | 4-crystal-information/index | `Name` and `Formula` at the top, `Reset` initialises everything | no `Reset` button. Header: Name, Symmetry info., Beam interaction, Formula, Z, Color | `CrystalControl.Designer.cs` |
| A15 | 4-crystal-information/index | four tabs | **six**: `EOS` and `Elasticity` are also shown | `FormMain.Designer.cs` (`VisibleEOSTab = true`, `VisibleElasticityTab = true`) |
| A16 | 4-crystal-information/index | confirm changes with `Add` / `Replace` | correct, but omits that isotopes, appearance, bonds, EOS and elasticity are not stored | `Crystal2.FromCrystal` / `ToCrystal` |
| A17 | 4-crystal-information/index | `Revert cell constants` returns to the values right after loading | initial values are saved only by list reading, so it effectively does nothing in CSManager (to be confirmed) | `Crystal.RevertInitialCellConstants` |
| A18 | 4.1 basic-information | lengths in Å | `Unit` switches Å / nm (default Å) | `SymmetryControl` |
| A19 | 4.1 basic-information | space-group `Search` is case-sensitive | correct. Add: subsequence (not necessarily contiguous) match; spaces never match; `sub` not needed | `SymmetryControl` search |
| A20 | 4.1 basic-information | volume etc. computed "if atom information is entered" | volume is shown without atoms. Items: Cell Volume (Å³ and nm³), Cell Mass, Molar Volume, Molar Mass, Density, Mean Z (number, mass), Mean A, Atom density, Electron density. Z is in the header, computed by GCD | `CrystalControl`, `Crystal.cs` |
| A21 | 4.1 basic-information | **Color of Profile** | the actual label is `Color`, in the header | `CrystalControl.resx` |
| A22 | 4.1 basic-information (ja) | `Cell constants`, `Symmetry`, `Crystal system`… in English | Japanese UI shows `格子定数`, `対称性`, `結晶系`, `点群`, `空間群`, `検索` | `SymmetryControl.ja.resx` |
| A23 | 4.2 atoms | X, Y, Z "real numbers from 0 to 1", Occ "0 to 1" | no range limit; expressions such as `1/3+1/8` are accepted | `NumericBox` |
| A24 | 4.2 atoms | X-ray scattering factors from *International Tables for Crystallography volume C* | per the code comment: Waasmaier & Kirfel (1995) *Acta Cryst.* A51, 416-431 | `AtomStatic.XrayScatteringWK` |
| A25 | 4.2 atoms | electron scattering factors from Peng (1998) | neutral atoms Peng et al. (1996) A52, 257-276; ions Peng (1998) A54, 481-485 | `AtomStatic.ElectronScatteringPeng` |
| A26 | 4.2 atoms | only Notation `U` / `B` and Model | pinned commit: switching U ↔ B does not convert values; anisotropic B is the dimensionless β (header `B11` misleading); defaults B and anisotropic | `AtomControl` |
| A27 | 4.2 atoms (ja) | buttons written as `Add`, `Replace`, `Up`, `Down`, `Delete` | Japanese UI: `追加`, `更新`, `上へ移動`, `下へ移動`, `削除` | `AtomControl.ja.resx` |
| A28 | 4.3 bonds-polyhedra | "bonds/polyhedra defined here are used in viewers such as ReciPro" | not stored in the CSManager database, and the send menu is hidden; regenerated with VESTA defaults on selection | `Crystal2.ToCrystal` |
| A29 | 4.3 bonds-polyhedra | "fine settings such as polyhedron transparency can be adjusted" | defaults: bond radius 0.1 Å, bond length 0.1–1.6 Å, opacity 0.7, edge width 0.7; colours cannot be set (atom colours) | `BondControl.Designer.cs` |
| A30 | 4.4 references | `Note`, `Authors`, `Journal`, `Title` | correct. Japanese UI: `Note` (untranslated), `著者`, `雑誌名`, `タイトル` | `CrystalControl.ja.resx` |
| A31 | 7-options-language | `Incremental Search` updates results immediately | not implemented; the item is disabled | `FormMain.Designer.cs` (260531Cl comment) |
| A32 | 7-options-language | switching language requires a restart (performed automatically) | a confirmation "Restart now?" appears; `Yes` restarts and unsaved work is lost | `FormMain.languageToolStripMenuItem_Click` |
| A33 | 7-options-language | `Help (PDF)` opens the online manual | correct, but the UI still says "PDF". Non-English: `https://seto77.github.io/CSManager/<lang>/` | `FormMain.helpwebToolStripMenuItem_Click` |
| A34 | 7-options-language (en) | `Github page` | no `Text` in the English resx; should be blank in the English UI (Q33) | `FormMain.resx` |
| A35 | 0-main-window | crystal information (bottom), search panel (bottom right) | correct; missing: `AMCSD` / `COD` checkboxes and citation notice above the table, and the `↑ Add ↑` / `↑ Replace ↑` buttons | `FormMain.Designer.cs` |
| A36 | troubleshooting | "COD loading fails — over 800 MB" | 24 parts, about 885 MB in total, downloaded in parallel; the MD5 check every time takes a while | `ReadCOD`, `COD/` |

## B. Features and information missing from the manual

| # | Item | Evidence | Draft |
|---|---|---|---|
| B1 | `AMCSD` / `COD` checkboxes (loading and display filter) | `CrystalDatabaseControl` | [02](02-database.md) |
| B2 | where data live (`%APPDATA%`, AMCSD copied over at every start), registry keys | `FormMain_Load`, `saveRegistry` | [02](02-database.md), [06](06-menus-options.md) |
| B3 | cdb3 format (single/split, MemoryPack + Brotli, MD5) | `CrystalDatabaseControl` | [02](02-database.md) |
| B4 | `Save Database` saves in display order; empty file while filtered (Q2) | same | [02](02-database.md) |
| B5 | table columns, units, navigator | `DataSet.cs` | [03](03-table-search.md) |
| B6 | difference between `↑ Add ↑` and `↑ Replace ↑` (Replace without selection adds) | `FormMain`, `ChangeCrystal` | [03](03-table-search.md) |
| B7 | search defaults (tolerance 3, d1 row checked) | `SearchCrystalControl.Designer.cs` | [03](03-table-search.md) |
| B8 | `Hint` (Help menu) | `hintToolStripMenuItem_Click` | [06](06-menus-options.md) |
| B9 | `Font Size in Data Table` ▸ `Increase (Ctrl+Shift+.)` / `Decrease (Ctrl+Shift+,)` (×1.1 / ×0.9) | `FormMain` | [06](06-menus-options.md) |
| B10 | `Debug functions` submenu (batch import, AMCSD CSV, recalculation, …) | `FormMain.Designer.cs` | [05](05-file-formats.md), [06](06-menus-options.md) |
| B11 | dropping `.xml` on the main window imports a crystal list | `FormMain_DragDrop` | [05](05-file-formats.md) |
| B12 | `Program Updates` hidden in the portable ZIP; per-architecture MSI (arm64, ver1.912) | `FormMain_Load`, `programUpdatesToolStripMenuItem_Click` | [06](06-menus-options.md) |
| B13 | 11 UI languages (ver1.912); in-code messages English/Japanese only | `SupportedCultures`, `Localization.Loc` | [06](06-menus-options.md) |
| B14 | command line `--smoke` / `--capture` | `Program.Main`, `GuiCapture` | [06](06-menus-options.md) |
| B15 | `EOS` tab (six isothermal EOS, Mie–Grüneisen / T-dependence models) | `EOSControl`, `EOS.cs` | [04](04-crystal-information.md) |
| B16 | `Elasticity` tab (C / S, 21 Voigt components) | `ElasticityControl` | [04](04-crystal-information.md) |
| B17 | header button and context-menu item `Beam interaction` | `CrystalControl` | [04](04-crystal-information.md) |
| B18 | `Origin Shift` presets, `Appearance` sub-tab, `Apply to Same Element` / `Apply to all elements`, `Show equivalent atom positions` | `AtomControl` | [04](04-crystal-information.md) |
| B19 | `Change axes/origin setting` button, superstructure multipliers | `CrystalControl`, `FormSuperStructure` | [04](04-crystal-information.md) |
| B20 | neutron `Custom isotope abundance` and the isotope window | `FormIsotopeComposition` | [04](04-crystal-information.md) |
| B21 | which CIF tags are read or ignored, how the space group is determined, what export writes and loses | `ConvertCrystalData` | [05](05-file-formats.md) |
| B22 | list of windows (forms) | each form | [01](01-forms.md) |

## C. Changes in the history (`Version.cs`) not reflected in the manual

| Version | History entry | Manual |
|---|---|---|
| ver1.912 (2026/06/25) | arm64 and portable ZIP packages, multilingual UI | languages in 7-options; arm64/portable not mentioned |
| ver1.911 (2026/04/27) | COD renewed (533,220) | no count (only "more than 500,000") |
| ver1.910 (2026/04/06) | smaller installer | n/a |
| ver1.909 / 1.906 (2025/12) | AMCSD renewed (21,478 / 21,477) | no count ("about 20,000"); bundled database 21,588 since e081e9d |
| ver1.904 (2025/11/14) | .NET 10 | **not reflected** (A1) |
| ver1.900 (2025/01/16) | lower memory use | n/a |
| ver1.894 (2022/11/16) | saving/loading algorithm changed | cdb3 format not described (B3) |
| ver1.893 (2022/10/27) | improved search | search details not described |
| ver1.873 (2020/03/17) | database format cdb2 → cdb3 | that legacy formats cannot be read is not mentioned (A2) |
| ver1.78 (2015/07/13) | font-size option | described |
| ver1.72 / 1.71 (2013/02) | update check, CIF export | described |

Other strings in `Version.cs` (`Introduction`, `Address`, …, used to generate a README) still carry the Kobe University contact (`seto@crystal.kobe-u.ac.jp`, old home page), which differs from the manual's contact (`seto.y@omu.ac.jp`). `Introduction`'s "over 30,000 structures bundled" is also out of date.

## D. Disagreements with the README

| README | Actual |
|---|---|
| "source code references `21,478` AMCSD entries and `529,139` COD entries" | `Version.COD = 533,220`; bundled AMCSD has 21,588 |
| "open legacy database files such as `.cdb` and `.cdb2`" | cannot be read (A2) |
| "Database input: `.cdb`, `.cdb2`, `.cdb3`" | `.cdb3` only |

## Open questions

1. How to merge these drafts (`docs/drafts/261105/`) into the `docs/src/{ja,en}/` pages: keep the existing nine-page structure, or add pages for EOS, elasticity and file formats?
2. Fix the bugs (Q1–Q45) before finalising the manual, or describe the current behaviour as is? Especially Q7 (cell search) and Q9 (CIF space group).
3. When will the submodules move to origin/main (which way should the [main] notes lean)?
4. Policy for the other nine languages.
