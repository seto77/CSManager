# Database table and search

Draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

Target: CSManager master `e081e9d` (submodules Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`).
Abbreviations: CDC = `CrystalDatabaseControl.cs`, SCC = `SearchCrystalControl.cs`, FPT = `FormPeriodicTable.cs` (all in `Crystallography.Controls/CrystalDatabase/`), DS = `Crystallography.Controls/DataSet.cs`.

## Database table

| Column (English UI) | Format | Content |
|---|---|---|
| Name | – | `name` |
| Density | N4 | g/cm³ |
| Formula | – | chemical formula |
| a, b, c | `#.#####` | Å |
| α, β, γ | `#.#####` | ° |
| Crystal System | – | |
| Point Group | – | |
| Space Group | – | H-M symbol (subscripts as `_`, ` H` / ` R` appended for hexagonal/rhombohedral settings, text after `=` dropped) (DS) |
| Authors | – | with two or more commas: first author + `, et al.` (DS) |
| Title | – | paper title (`sect`) |
| Journal | – | `jour` (journal, volume, issue, year and pages in one string) |

- Because of the `#.#####` format, a value of 0 is shown as a blank cell.
- Read-only, single-row selection. Click a header to sort (default `SortMode` Automatic). No context menu.
- The navigator at the bottom (first / previous / position / count / next / last) counts the **filtered** rows. Its tooltips are always Japanese (hard-coded in the Designer).
- Font size: `Option` ▸ `Font Size in Data Table` (default 9.75 pt, ×1.1 / ×0.9).
- Selecting a row (`bindingSource.CurrentChanged` → `CrystalChanged`) shows the crystal below and also **overwrites the clipboard** (see [Interoperation](07-interoperation.md)).

### Adding, replacing and deleting (`FormMain`)

| Button | Action |
|---|---|
| `↑ Add ↑` | builds a crystal from the crystal-information fields (`GenerateFromInterface`) and appends it as a new row |
| `↑ Replace ↑` | replaces the selected row with it; adds a new row if none is selected (CDC `ChangeCrystal`) |

The selected row is deleted by `DeleteCurrentCrystal` (no confirmation). Records added or replaced here have no d list (see the warning below).

## Search panel

### Running a search

- Runs on the `Search` button, on Enter in the `Name` / `Reference` text boxes, and on Enter in any numeric box (SCC `KeyDown`).
- Toggling the `AMCSD` / `COD` checkboxes also searches again.
- Toggling a condition checkbox or clicking in the periodic table does not search; the checkboxes only show or enable their inputs.
- **All enabled conditions are combined with AND.** Rows that fail get `Flag = false`, and the view is filtered on `Flag = true`.
- `Incremental Search` in the `Option` menu is not implemented (greyed out).
- Status: "Searching... x sec." → "Completion of search. x sec.".

### Meaning of each condition

| Condition | Test (SCC search worker) |
|---|---|
| `Name` | the crystal name contains the whole input string (substring, case-insensitive, `CurrentCultureIgnoreCase`). Spaces are literal; no AND/OR, no wildcards |
| `Reference` | substring (case-insensitive) of the journal (`jour`), authors (`auth`, full list) or title (`sect`) |
| `Crystal System` | choices Unknown, triclinic, monoclinic, orthorhombic, tetragonal, trigonal, hexagonal, cubic. Unknown and no selection mean "no condition" |
| `Elements` | see "Periodic table" below |
| `Cell Params` | a, b, c (Å) with a relative tolerance `±%`, α, β, γ (°) with an absolute tolerance `±°`. A field with value 0 is ignored. A tolerance of 0 means exact match, not "ignored". **In the current code this condition effectively does not work because of a unit bug (below)** |
| `d-spacing` | up to three values (d1–d3, Å), relative tolerance `±%` (open interval). Each enabled non-zero d must fall on one of the crystal's d values; the three are ANDed |
| `Ignore scattering factor` | off: compares with the d list stored in the database (16 strongest reflections). on: computes every d from the cell alone (no extinction, symmetry or intensity) and compares with those (`calcDlist`, at most 8000 values, down to `dMin = min(d_i(1−2ε_i))`) |
| `Density` | relative `±%`, g/cm³. A value of 0 is ignored |

Defaults (SCC Designer): all condition checkboxes off (except the checkbox of the `d1` row). a–γ, d1–d3 and density are 0. All tolerances are 3 (%, °, %, %), max. 50, step 0.5.

!!! danger "Unit mismatch in the cell-parameter search"
    The input is passed on in Å and degrees, but compared with `Crystal2.CellOnlyValue_nm_radian` (nm and rad) (SCC: the `SearchParameters` built in `buttonSearch_Click` and the cell block of the search worker). The d values are converted with `/10`, the cell parameters are not. As a result a = 5 Å ± 3 % never matches a 0.5 nm crystal, and any non-zero angle excludes every crystal. Still present in origin/main. See [Implementation questions](90-implementation-questions.md) Q7.

!!! note "How the d list is built, and the "top 20" in the existing manual"
    The database d list comes from `Crystal.GetDspacingList(0.154, 200)` (FM `GetPlanesFormulaDensity`). `0.154` is the wavelength in nm (≈ Cu Kα). `200` means |g| is expanded until 200 symmetry-unique (point group), non-extinct planes have been collected. The intensity is I = |F|² (X-ray) × multiplicity × (1+cos²2θ)/(sin2θ sinθ), and the d (nm) of the `bestNum = 16` strongest are returned. The "top 20" in the existing manual is wrong, and the comment "up to the 8th strongest" on `Crystal2.d` is out of date.
    In origin/main (Crystallography `9ffcf47`) there is a 2θ ≤ 150° cap, Friedel pairs are merged by Laue group, and d values within a relative 1e-6 are merged with their intensities summed. The bundled AMCSD (e081e9d) was rebuilt with this version. Only the AMCSD CSV import and the folder batch import compute d lists.

!!! warning "Records without a d list"
    `Crystal2.FromCrystal` does not set `d`. Records entered with `↑ Add ↑` / `↑ Replace ↑`, the single CIF/AMC import or the XML import have `d == null`. A d-spacing search with `Ignore scattering factor` off then throws, and the partial result is shown without a warning (Q8).

### Periodic table (`Periodic Table` button, FPT)

- Each click on an element cycles neutral (light yellow) → must include (light blue) → must exclude (light red) → neutral.
- The test uses the elements of all atom sites (occupancy is not considered). A crystal is rejected if it contains **any** excluded element, and it must contain **all** included elements. Neutral elements do not matter.
- With `Elements` enabled, crystals without atoms are rejected even when no element is specified.
- Selectable range: H–Rg (1–111). The `La` / `Ac` buttons only mark the positions of the lanthanide/actinide rows and do nothing.
- Buttons at the top: `must include` (all elements to "include"), `must exclude` (all to "exclude"), `may or not include` (reset all to neutral).
- Closing the window only hides it, so the selection is kept.
- Startup hint: "Select 'must exclude' to exclude all elements first, then pick the elements that are contained" (`Version.Hint`).

<!-- screenshot: search panel with Elements and d-spacing enabled, periodic table window open -->

## Open questions

1. Is the unit mismatch in the cell search (Q7) unintended? After a fix, the manual should state "a, b, c in Å, relative tolerance %".
2. Does `Font Size in Data Table` actually reach the cells (the Designer sets `DefaultCellStyle.Font` explicitly)?
3. Is it acceptable that the crystal-system choices stay in English in the Japanese UI?
