# Supported file formats, import and export

Draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

Target: CSManager master `e081e9d` (submodules Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`). **[main]** marks what changes in Crystallography origin/main (`876f5e4`, `9ffcf47`, etc.). Written without dotnet; nothing was tested on real files.
Abbreviations: C = `Crystallography/Crystal/ConvertCrystalData.cs`, M = `Crystallography/Crystal/CrystalMinimum.cs` (`Crystal2`), FM = `CSManager/FormMain.cs`, CC = `Crystallography.Controls/Crystal/CrystalControl.cs`, CDC = `CrystalDatabaseControl.cs`.

## Overview

| Format | Read | Write | Entry point | Limits / notes |
|---|---|---|---|---|
| `.cdb3` (CSManager database) | ✓ | ✓ | `File` ▸ `Read Database` / `Save Database` | see [Databases](02-database.md). Cannot be dropped on the main window |
| `.cdb` / `.cdb2` (legacy) | – | – | shown in the dialog | silently ignored (CDC `ReadDatabase`) |
| `.cif` | ✓ | ✓ | single import, drop / context menu on crystal information, folder batch import / context menu `Export to CIF` | **lower-case extension only**. No CIF2. Details below |
| `.amc` (AMCSD) | ✓ | – | single import, drop / context menu on crystal information, folder batch import | lower-case extension only |
| AMCSD CSV (`.csv`) | ✓ | – | `Debug functions` ▸ `Import AMCSD_CSV` | maintenance |
| `Crystal[]` XML (PDIndexer / ReciPro crystal list) | ✓ | – | `Import PDI Crystal data (*.xml)`, drop on main window | no exception handling via the menu (a broken XML crashes the app) |
| Clipboard | – | ✓ | selecting a table row | see [Interoperation](07-interoperation.md) |

The format is decided **by the extension only, not by content**. `ConvertToCrystal2` / `ConvertToCrystal` (C) test `EndsWith("amc")` / `EndsWith("cif")` (Ordinal), so `.CIF` or `.Cif` are not read. In the single import the resulting null-reference exception is swallowed by `catch {}` and nothing is shown (FM `toolStripMenuItemImport_Click`).

## Differences between entry points

| Entry point | Processing | Record stored in the database |
|---|---|---|
| `Import CIF, AMC ...` | `ConvertToCrystal(file).ToCrystal2()` (via Crystal2 → Crystal → `FromCrystal`) | `datatype = 0`, **no d list**, number strings rebuilt by `Compose` |
| Drop on / context menu `Import from CIF or AMC...` of crystal information | `ConvertToCrystal`, shown in the editor only | not stored (use `↑ Add ↑` etc.; then as above) |
| `Import All File (CIF or AMC)` (folder batch import) | `ConvertToCrystal2` (strings kept) + d list, formula and density computed | `.cif` always `datatype = COD`, `.amc` AMCSD |
| `Import AMCSD_CSV` | `ConvertFromAmc` + d list, formula and density | `datatype = AMCSD` |
| XML | `XmlSerializer(Crystal[])` → `SetAxis` → `Crystal2.FromCrystal` | `datatype = 0`, no d list |

### Batch import

`Debug functions` ▸ `Import All File (CIF or AMC)` (FM `GetAllImport` / `WorkerAllImport_DoWork`):

- Choose a folder (initial path `Y:`); answering `Yes` to "Also search subdirectory?" includes subfolders.
- Files whose full path ends in `amc` / `cif` (case-sensitive) are converted in reverse order with parallelism 1.
- Names (without extension) of failed files are written to `<selected folder>_failed.txt`, i.e. **next to** the folder, not inside it (no `\` is added).
- When finished, all records are appended to the database.

### AMCSD CSV

`Debug functions` ▸ `Import AMCSD_CSV` (FM `importAMCSDCSVToolStripMenuItem_Click`): a CSV (CsvHelper, InvariantCulture) with the columns `database_code_amcsd`, `Mineral Name`, `Ideal IMA Formula`, `AMC File Contents`, `Volume`, `Pressure`, `Temperature`, `Chemistry`, `AMC File`, `CIF File`, `DIF File`, `File`, `Reference ID`. Only `AMC File Contents` is used: it is split into lines and passed to `ConvertFromAmc`. Failed rows are written as `index: AMCSD code` to `_failed.txt` in the CSV's folder. Empty lines are kept on this path, so records with an empty line in the author block fail (C `ConvertFromAmc`).

## Reading CIF (C `ConvertFromCIF`, line numbers of 6eeb86a)

### Pre-processing

1. Reads the whole text as UTF-8 (BOM detected), normalises line breaks and decodes HTML entities (`&amp; &lt; &gt; &quot; &nbsp; &#39;`) in the whole text (`EscapeString`).
2. Removes the `;…;` text after `_shelx_hkl_file` and similar, and the lines from SHELX file lines to their checksum lines.
3. Splits into lines (empty lines disappear here).
4. `_refln*`, `_reflns*`, `_geom*`, `_platon*`, `_diffrn_refln*` (prefix match): a loop is removed entirely; for a single item **only the tag line** is removed.
5. Removes lines starting with `#` (except the last line). This happens before trimming, so indented comments and trailing comments survive.
6. Semicolon text fields are joined with spaces into one line up to the next `;` line and wrapped in `'…'`. **Text on the same line as the opening `;` is discarded.**
7. Tabs to spaces, trim, remove empty lines.
8. Quotes: after protecting `''`, `'` and `"` are **paired from left to right** (the CIF 1.1 rule "a closing quote must be followed by white space" is not followed).

### Syntax

- Single item: if the line has 2 tokens the second is the value; with 1 token the whole next line is the value; **with 3 or more tokens the value is empty**.
- `loop_`: tags are collected, then the following tokens are data. **If the number of tokens is not a multiple of the number of tags, the whole loop is silently discarded.**
- Tag matching is **case-sensitive** (CIF itself is case-insensitive).
- **No CIF2**: `#\#CIF_2.0`, triple quotes, lists `[]`, tables `{}` and DDLm dotted tags (`_cell.length_a`) are not handled.
- **`data_` blocks are not distinguished.** The items of all blocks end up in one list. Atoms come from the first loop containing `_atom_site_label`, cell parameters from the last value before the atom loop, and space-group names are collected and tried in order. Results for multi-block CIFs are hard to predict (open question 1).

### Tags that are read

| Tag | Match | Use |
|---|---|---|
| `_chemical_name*` (`_mineral`, `_common`, `_systematic`, `_structure_type`, …; prefix) | StartsWith | joined with spaces in file order into the crystal name (a trailing space remains) |
| `_chemical_formula_sum` | exact | substitute when the name is empty or `?`. Not used as the formula (the formula is computed from the atoms) |
| `_cell_length_a/b/c`, `_cell_angle_alpha/beta/gamma` | exact | cell parameters (kept as strings, with su) |
| `_publ_author_name` | exact | authors. `,` removed from each name, joined with `", "`, then **every `.` removed** ("Smith, J.A." → "Smith JA") |
| `_publ_section_title` | exact | title |
| `_journal_name_full`, `_journal_coden_ASTM`, `_journal_year`, `_journal_volume`, `_journal_page_first`, `_journal_page_last`, `_journal_issue` | exact | combined as `"{full} {coden}, {issue}, {volume}({year}), {first}-{last}"` into the journal field |
| `_symmetry_space_group_name_H-M`, `_space_group_name_H-M_alt`, `_H-M_full`, … | `Contains("_space_group_name_H-M")` | H-M candidates |
| `_symmetry_space_group_name_Hall`, `_space_group_name_Hall` | Contains | Hall candidates |
| `_symmetry_Int_Tables_number` | `Contains("_Int_Tables_number")` | space-group number. **`_space_group_IT_number` does not match and is not read** |
| `_space_group_symop_operation_xyz`, `_symmetry_equiv_pos_as_xyz` | exact | used only to detect an origin shift (not to determine the space group) |
| `_atom_site_label`, `_atom_site_type_symbol` | exact | label and element |
| `_atom_site_fract_x/y/z` | exact | coordinates; `?` / `.` → empty → NaN |
| `_atom_site_occupancy` | exact | occupancy; 1 if absent |
| `_atom_site_U_iso_or_equiv`, `_atom_site_B_iso_or_equiv` | exact | isotropic displacement |
| `_atom_site_aniso_label` | exact match with the atom label | links the anisotropic loop to the atoms |
| `_atom_site_aniso_U_11/22/33/12/13/23` | exact | anisotropic U (Å²) |
| `_atom_site_aniso_B_11/…/23` | exact | anisotropic B (see the note below) |

`_atom_site_thermal_displace_type` and `_chemical_formula_structural` are read but not used.

### Tags that are ignored (main examples)

- Atom sites: `_atom_site_calc_flag`, `_atom_site_refinement_flags*`, `_atom_site_disorder_assembly/group`, `_atom_site_symmetry_multiplicity`, `_atom_site_Wyckoff_symbol`, `_atom_site_attached_hydrogens`, `_atom_site_adp_type`, `_atom_site_Cartn_x/y/z` (a CIF with Cartesian coordinates only gives NaN coordinates), `_atom_site_aniso_type_symbol`, `_atom_site_aniso_beta_*`, `_atom_type_*` (including `_atom_type_oxidation_number`).
- Symmetry: `_space_group_IT_number`, `_space_group_crystal_system`, `_symmetry_cell_setting`, `_space_group_symop_id`.
- Cell / experiment: `_cell_volume`, `_cell_formula_units_Z`, `_cell_measurement_temperature/pressure`, `_diffrn_ambient_*`, `_diffrn_radiation_wavelength`, `_exptl_*` (including `_exptl_crystal_density_diffrn`; density is computed), `_refine_*`.
- Bibliography: `_database_code_*`, `_cod_database_code`, `_journal_name_abbrev`, `_publ_section_abstract`, `_audit_*`, `_computing_*`, `_chemical_formula_weight`.

### Numbers (M `ToBytes` / `Decompose`)

- Values are stored **as strings**: the 13 characters `0-9 . / - ( ) E` are packed into 4 bits. `0.1234(5)` is read as value 0.1234, error 0.0005.
- Fractions (`1/3`) are accepted. `?`, `NaN` and empty give NaN.
- Characters outside the table (`+`, space, `,`, letters) turn into `0` (e.g. `+.25` → `0025`).
- **Exponent notation (`1.2E-3`) becomes 0** (`NumberStyles.Number` cannot read the exponent, so `expValue = 0`). **[main]** fixed to `NumberStyles.Float`.
- For trigonal/hexagonal groups (No. 143–194), a coordinate string that **contains** `.333`, `.667`, `.167`, `.0833`, … as a substring is replaced by 1/3, 2/3, …. `-0.3333` also becomes +1/3 (Q12).

### U or B, isotropic or anisotropic

- If `_atom_site_B_iso_or_equiv` or any B_ij is present the atom is B type, otherwise U type. **The mere presence of B_iso discards U_ij.**
- If all six components of the chosen type are empty the atom is isotropic; an empty isotropic value becomes 0.
- Anisotropic B is stored as the dimensionless β, so `_atom_site_aniso_B_ij` (Å²) ends up wrong by orders of magnitude.
- **[main]** Anisotropic values always give U type; B_ij are divided by 8π² (su with the same factor); B_iso is converted when U_iso is missing.

### Determining the element

- Uses `_atom_site_type_symbol` if present, otherwise the label; the leading part of the string is shortened from the longest and compared with element symbols (**case-insensitive longest match**, up to Z = 96). `Fe3+` → Fe, `O2-` → O.
- **Charges/valences are discarded** (X-ray and electron scattering factors stay those of neutral atoms).
- Being case-insensitive, labels such as `CA1` or `NA1` without a type symbol give Ca or Na.
- `OH` becomes two atoms H and O at the same position. `D` becomes H with ²H at 100 %.
- Atoms that cannot be identified and atoms with Z ≥ 97 are **silently dropped**.

### Determining the space group (C `SearchSGseriesNumberForCIF`)

1. If there is neither H-M nor Hall: **P1**, even if an IT number or symmetry operators exist, without warning.
2. **Hall**: if it matches a Hall symbol of the internal table exactly (spaces removed) it is used (not overridden by the IT number). Hall symbols with an origin shift or written differently do not match.
3. **H-M**: normalised (`_` subscripts, suffixes `:H` `:R` `:1` `:2`, detection of origin choice 2, expansion of short symbols); then the **shortest** internal name that contains the space-free name as a substring is chosen. e-glides are also matched with a/b/c substitutes.
4. If the cell strings give a=b=c and α=β=γ and the internal name is a hexagonal setting, the rhombohedral (R) setting is used; with origin choice 2 the second-origin setting is used.
5. **If `_symmetry_Int_Tables_number` is 1–230, the setting chosen from H-M is replaced by the first setting of that number** (`symmetrySeriesNumber >= 1 || …` is always true). Example: `P 1 21/n 1` → `P 1 21/c 1`. CIFs without (or with a non-matching) Hall symbol are affected (Q9).
6. Origin-shift detection: only when the number of operators equals the number of internal general positions (with centring), shifts from {0, ±1/8, ±1/4}³ are tried; if the operator sets match, the shift is added to all coordinates. No warning when nothing matches. On this path coordinates with su become NaN (Q11).

## Reading AMC (C `ConvertFromAmc`)

Lines are interpreted in this order (empty lines removed first when reading from a file).

1. Crystal name
2. Authors. Following lines are appended with `", "` as long as their last character is not `.`, `/` or a digit and they do not contain `doi.org`, `DOI: ` or `Mineralogy`
3. Journal
4. Title, up to the cell line. `_database_code_amcsd` is replaced by `AMCSD:`, `_cod_database_code` by `COD:` and put into the title field
5. Cell line (7 tokens, the first six numeric); the seventh is the space group
6. Origin-shift line (if any; three tokens, not starting with `atom`); added to the coordinates
7. Atom header (looks for `occ`, `Uiso`, `Biso`, `U(1,1)`, `B(1,1)`)
8. Atom lines. If the token count differs from the header, switches to fixed-width reading at the header positions. Missing occ = 1

- Space group: `*` or `:2` means origin choice 2. Non-standard centrings such as C2₁, C2/a, F2/m, B2₁, B2₁/m, Imab and F4/mmm are replaced by the P-lattice group, and the atoms are duplicated by the centring translations (coordinates not reduced mod 1).
- Elements: **case-sensitive** longest match. `OH` → H + O, `D` → ²H, `Wat`/`WAT`/`wat` → H, H, O.
- **[main]** fixes the **swap of anisotropic U13 and U23** (AMC column order 12, 13, 23 → internal 12, 23, 31). In the pinned commit they are swapped. The bundled AMCSD (e081e9d) was rebuilt with the fixed reader; AMC files imported with the pinned library are still swapped.

## Writing CIF (C `ConvertToCIF`, CC context menu → `Crystal.ExportCIF`)

Written as UTF-8 without BOM:

| Output | Notes |
|---|---|
| `# exported from…`, `data_global` | |
| `_chemical_name '…'` | **non-standard tag**; `'` is not escaped |
| `loop_ _publ_author_name` | the author field split at `,` |
| `_journal_name '…'` | **non-standard tag**. Reading looks for `_journal_name_full`, so the journal is lost on re-import |
| `_publ_section_title` | `;…;`, wrapped at 80 columns |
| `_chemical_formula_sum` | |
| `_cell_length_*`, `_cell_angle_*`, `_cell_volume`, `_exptl_crystal_density_diffrn` | `f6`, **CurrentCulture**, no su (commas as decimal separator in such locales). **[main]** InvariantCulture |
| `_space_group_IT_number`, `_symmetry_Int_Tables_number`, `_symmetry_cell_setting` | |
| `_symmetry_space_group_name_H-M` | the internal name with `Hex`/`Rho` removed, so strings like `P2sub1/c=P12sub1/n1` or `Fd-3m(2)` appear as they are |
| `_symmetry_space_group_name_Hall` | internal notation without spaces |
| `loop_ _symmetry_equiv_pos_as_xyz` | general positions + centring translations. **Zero lines for R groups in the rhombohedral setting** (Q13) |
| `_atom_site_label`, `_type_symbol`, `_fract_x/y/z`, `_occupancy`, `_U_iso_or_equiv` | no charge. For anisotropic atoms the stored isotropic value is written and can be 0. **[main]** writes U_eq |
| `_atom_site_aniso_label`, `_U_11/22/33/23/13/12` | anisotropic atoms only |

**Lost**: all su, the note, journal details, isotopes (D becomes H), valences, bonds/polyhedra, EOS, elasticity, colour, Z, measurement conditions. A CIF written and re-read by CSManager recovers the space group because the Hall symbol matches exactly.

## Crystal2 record

The compact record carried in the database (cdb3) and on the clipboard (M; `Atoms2` in `Crystallography/Atom/AtomMinimum.cs`).

| Kept | Type / notes |
|---|---|
| a, b, c (Å), α, β, γ (°) | **strings** (with su, packed 4-bit) |
| space group | `sym` (short, internal setting number 0–540) |
| name, note, journal, authors, title, formula | string |
| density | float |
| atoms: label, x/y/z/occ/iso/aniso strings, atomic number, `SubXray`, `SubElectron`, U/B, iso/aniso | aniso order 11, 22, 33, 12, 23, 31; Å² for U, β for B |
| d list | float[], 16 strongest reflections (nm) |
| source file name, data type, display colour | |

**Lost** in `Crystal2.FromCrystal` (the path from the editor or XML into the database): bonds/polyhedra, EOS, elasticity, strain/stress, lattice planes, journal details, isotopes (D stored as H), atom colour and radius, d list (not set).

!!! danger "Numbers become 0 after FromCrystal (pinned commit)"
    `FromCrystal` writes numbers back to strings with `Compose`. Values with an error and |value| < 1 or ≥ 10 get an exponent, such as `1.2340(50)E-1`, but `Decompose` cannot read the exponent and returns 0. For crystals entered by single import, XML, `↑ Add ↑` or `↑ Replace ↑`, cell parameters, coordinates and U with errors can therefore read as 0 when opened from the database (Q10). **[main]** fixed in `876f5e4`.

## Open questions

1. Actual behaviour with multi-block CIFs (some COD entries, multi-phase powder CIFs).
2. Confirm the space-group override (Q9) with an ICSD-style CIF (no Hall, with `_symmetry_Int_Tables_number`).
3. Sign of the origin shift: the code adds +s, a strict solution gives −s. Groups where 2s is a normalizer translation cannot tell the difference; check with Pn-3:2, P4/nmm:2 and Fd-3m:2.
4. Purpose of decoding HTML entities in the whole text (COD web output?).
5. Is it intended that the batch import always marks `.cif` as COD (one's own CIFs are then hidden by the `COD` checkbox)?
