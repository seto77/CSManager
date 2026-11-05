# Windows (forms) and overview

Draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

Target: CSManager master `e081e9d` (submodules Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`).

CSManager consists of one main window (`FormMain`) and auxiliary windows opened from it. Only `FormMain` belongs to CSManager itself; the others come from the shared library Crystallography.Controls.

## Main window (`FormMain`)

The title is `CSManager   ver1.912 (2026/06/25)` (`Version.VersionAndDate`). `splitContainer1` / `splitContainer2` divide it into these areas (`FormMain.Designer.cs`).

| Area | Control | Chapter |
|---|---|---|
| Menu bar (`File`, `Option`, `Help`, `Language`) | `menuStrip` | [Menus](06-menus-options.md) |
| Top: `AMCSD` / `COD` checkboxes, citation notice, database table, navigator | `CrystalDatabaseControl` | [Databases](02-database.md), [Table and search](03-table-search.md) |
| Bottom left: crystal information and the `↑ Add ↑` / `↑ Replace ↑` buttons | `CrystalControl` | [Crystal information](04-crystal-information.md) |
| Bottom right: search panel | `SearchCrystalControl` | [Table and search](03-table-search.md) |
| Very bottom: progress bar and status | `statusStrip` | below |

The status line shows the progress of loading, saving and searching ("… Completed: x %. Elapsed time: y sec. Remaining time: z sec.") (`FormMain.reportProgress`, `CrystalDatabaseControl.report`).

<!-- screenshot: whole main window after loading AMCSD (English UI). docs/src/assets/cap-en-auto/FormMain.png already generated with --capture -->

## Auxiliary windows

| Window (English title / Japanese title) | Class | How to open | Kind |
|---|---|---|---|
| Startup dialog `Calculating...` | `CommonDialog` (Initialize) | at startup; `Close this window automatically after startup` | modeless |
| `Hint` (English only) | `CommonDialog` (Hint) | `Help` ▸ `Hint`; `Next` for the next hint | same |
| `Version history` (English only) | `CommonDialog` (History) | `Help` ▸ `Version History` | same |
| `CSManager License (MIT)` (English only) | `CommonDialog` (License) | `Help` ▸ `License` | same |
| `Periodic Table` (not translated) | `FormPeriodicTable` | search panel ▸ `Elements` ▸ `Periodic Table` | closing only hides it |
| `Symmetry Information` (not translated) | `FormSymmetryInformation` | header button `Symmetry info.` or context menu | modeless, closing only hides it |
| `Group Relations` / `群の関係` | `FormGroupRelations` | `Group Relations...` in the symmetry information window | |
| `Beam Interaction` / `ビーム相互作用` | `FormBeamInteraction` | header button `Beam interaction` or context menu | modeless |
| `Convert to another spacegroup` / `別の空間群へ変換` | `FormAnotherSpaceGroup` | context menu `Change the axes/origin setting`, button `Change axes/origin setting` | modal |
| `Set superstructure size` (not translated) | `FormSuperStructure` | context menu `Convert to a superstructure` | modal |
| `Atom Positions` / `原子位置` | `FormAtomDetailedInfo` | right-click a row of the atom list ▸ `Show equivalent atom positions` | modeless |
| `FormIsotopeComposition` (title not set) | `FormIsotopeComposition` | Atom Info. ▸ `Scattering Factor` ▸ neutron Custom ▸ `Edit` | modal |
| `Strain Control` | `FormStrain` | not reachable (menu item hidden) | – |

Tabs of the symmetry information window: `Geometrics Calculation`, `Wyckoff Positions`, `Conditions`, `Operations`, `Properties`, `Settings`.

Tabs of the beam interaction window: `Reflections`, `Scattering factors`, `Attenuations && Transport`, `Fluorescence`.

These two windows are shared with ReciPro and PDIndexer and are not covered here (open question 1).

**[main]** `FormChemicalComposition` can be opened from the context menu item `Details of the chemical composition`.

## Open questions

1. Should the symmetry information and beam interaction windows be documented in detail in the CSManager manual, or linked to the ReciPro manual?
2. The titles of the `CommonDialog` modes and of `Periodic Table`, `Symmetry Information`, `Set superstructure size` and `FormIsotopeComposition` are not localised (a UI issue).
