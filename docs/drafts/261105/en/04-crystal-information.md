# Crystal information (CrystalControl)

Draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

Target: CSManager master `e081e9d` (submodules Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`). **[main]** marks what changes in Crystallography.Controls origin/main (up to `aadeb74`).
Abbreviations: CC = `Crystallography.Controls/Crystal/CrystalControl.cs`, SC = `SymmetryControl.cs`, AC = `AtomControl.cs`, BC = `BondControl.cs`, EC = `EOSControl.cs`, ElC = `ElasticityControl.cs` (same folder).

## Edits are stored in two steps

1. Every input on the tabs is applied to the crystal object when the value changes (`ItemChanged` → `GenerateFromInterface`). Atoms and bonds enter their lists when that tab's `Add` / `Replace` is pressed.
2. The database is changed only by the main window's `↑ Add ↑` (new row) or `↑ Replace ↑` (replace the selected row).

Not stored in a database record (`Crystal2`): **isotope composition, appearance settings, bonds/polyhedra, EOS, elastic constants**. When the row is selected again, appearance and bonds return to the VESTA defaults and the rest is gone (`Crystal2.ToCrystal`). Only D (deuterium) survives, stored as atomic number 255.

## Visible tabs

With the CSManager settings (`FormMain.Designer.cs`) these six tabs are shown (in the order of CC `setTabPages`). Bounds, Lattice Plane, Strain, Stress and Polycrystalline Property are hidden.

| English UI | Japanese UI |
|---|---|
| `Basic Info.` | `格子/対称性` |
| `Atom Info.` | `原子情報` |
| `Bonds & Polyhedra` | `多面体/結合描画設定` |
| `Ref.` | `引用文献` |
| `EOS` | `状態方程式` |
| `Elasticity` | `弾性定数` |

## Header (common to all tabs)

| English UI | Content |
|---|---|
| `Name` | free text |
| `Symmetry info.` | toggles the symmetry information window |
| `Beam interaction` | toggles the beam interaction window (`BeamInteractionVisible = false` only means it starts closed) |
| `Formula` | read-only, computed from the atoms |
| `Z` | read-only, see below |
| `Color` | click to choose; the colour of the 3D view and the diffraction profile. In the pinned commit it is applied at the next regeneration. **[main]** applied immediately |

The `Reset` button mentioned in the existing manual does not exist.

## Basic Info.

### Cell constants (`Cell constants`)

- `Unit`: `Å` (default) / `nm`. Switching multiplies the displayed values by 10 / 0.1; internally nm and rad are used (SC).
- `Show Errors` (default off) shows the ± fields.
- Fields constrained by the crystal system are disabled and overwritten (SC `SetCellConstantsBySymmetry`):
    - monoclinic: only the angle of the unique axis is free, the others 90°
    - orthorhombic: all angles 90°
    - tetragonal / hexagonal: b = a, γ = 90° / 120°
    - trigonal: hexagonal axes b = a, γ = 120°; rhombohedral axes (internal name with `Rho`) a = b = c, α = β = γ
    - cubic: a = b = c, all angles 90°
- Negative lengths or angles above π give "Input valid cell constants" (English only). 0 is accepted.

### Symmetry (`Symmetry`)

- Choose `Crystal System` → `Point Group` → `Space Group`. Changing a higher level resets the lower ones to their first item.
- Space groups are listed as `number:H-M`; different settings of the same number (axes, origin, cell choice) are separate items.
- `Search` (SC): each character of the input must appear in the H-M string in that order (**subsequence match, not necessarily contiguous**), case-sensitive. The internal H-M strings contain no spaces, so typing a space matches nothing. `P21/c` matches `P2sub1/c`, so typing `sub` is unnecessary. `=` (e.g. `C2=C121`) and `Rho` / `Hex` also work. Candidates appear in the list on the right; choosing one sets the three combo boxes.
- `Change axes/origin setting`: enabled only when the space-group number is > 2 and the number has several settings. Opens the same window as "Change the axes/origin setting" below.

### Computed values (read-only; CC around `SetCellVolumeAndDensity`, `Crystal.cs`)

n_i = Σ(multiplicity × occupancy).

| English UI | Unit | Definition |
|---|---|---|
| `Cell Volume` | Å³ (nm³ next to it) | |
| `Cell Mass` | ×10⁻²⁴ g | ρV |
| `Molar Volume` | cm³/mol | per formula unit |
| `Molar Mass` | g/mol | per formula unit |
| `Density` | g/cm³ | ΣA_i n_i / (V N_A) |
| `Mean Z (number)` | – | Σn_iZ_i / Σn_i |
| `Mean Z (mass)` | – | Σn_iA_iZ_i / Σn_iA_i |
| `Mean A` | g/mol | per atom |
| `Atom density` | nm⁻³ | Σn_i / V |
| `Electron density` | nm⁻³ | Σn_iZ_i / V |

- Z (header) comes from the integer GCD of the per-element atom counts in the cell. With partial occupancy it often does not divide and Z becomes 1.
- Without atoms, or with a total occupancy of 0, density etc. are not computed; the volume is still shown.
- **[main]** a single volume field that follows the Å/nm choice; atom and electron densities follow it too (Å⁻³ / nm⁻³).

## Atom Info. (AtomControl)

### Atom list

Columns: a display checkbox (for 3D display; meaningless in CSManager and not saved), `Label`, `Element` (as `26: Fe`), `X`, `Y`, `Z`, `Occ.`, `Multi.`, `Wyck. Let.`, `Site Sym.`. Coordinates are shown as fractions when they match a denominator of 2, 3, 4, 5, 6, 8, 9, 10, 11, 12, 16 or 24 within 1e-6, otherwise with `g6`.

Right-click a row → `Show equivalent atom positions`: opens the list of equivalent positions (`Atom Positions`). `Copy` puts it on the clipboard as TSV.

| Button | Action |
|---|---|
| `Add` | appends the atom of the edit fields below |
| `Replace` | replaces the selected atom |
| `Up`, `Down` | reorder |
| `Delete` | delete |
| `Apply to Same Element` | shown on the Appearance and Debye-Waller tabs only. Replaces the selected atom and copies the appearance (Appearance tab) or displacement parameters (Debye-Waller tab) to all atoms of the same element |
| `Apply to all elements` | Debye-Waller tab only. Copies the displacement parameters to all atoms |

### Sub-tabs

**`Element & Position`**

- `Label`, `Element` (`1: H`–`98: Cf`). Changing the element resets the X-ray/electron scattering-factor choice, the neutron isotopes (back to natural abundance), and radius/colour (VESTA defaults).
- `X`, `Y`, `Z`, `Occ`: **no range limit**. The input is evaluated as an expression on every keystroke, so expressions like `1/3+1/8` work. Ctrl+Enter / Shift+Enter replace the text with the evaluated value (`NumericBox`).
- `Show Error` shows the error fields.
- When no atom is selected the default occupancy is 0.

**`Origin Shift`**

- "Shift coordinates of all atoms by:" with sign `+` (default) / `-` and presets (⅛ ⅛ ⅛), (¼ ¼ ¼), (¼ −¼ ¼), (¼ −¼ 0), (¼ ¼ 0), (0 ¼ ¼), (¼ 0 ¼), (0 ¼ ⅛), (0 ¼ −⅛).
- For an arbitrary shift enter X/Y/Z (−1 to 1) and press `Apply custom shift`; the `+`/`-` sign is not used then.
- The equivalent positions are regenerated after the shift.

**`Debye-Waller Factor`**

- `Notation`: `U` / `B` (default B). `Model`: `Isotropy` / `Anisotropy`. Before an atom is selected the default is `Anisotropy` (CrystalControl sets `UseIsotropy = false`).
- Isotropic values in Å². Anisotropic: U_ij (Å²) in U notation. **In B notation the dimensionless β_ij is shown as is**, while the header says `B11` and the tooltip says "Å²". `Dimension` shows Å² (None for anisotropic B).
- In the pinned commit switching U ↔ B does not convert the values; only the labels change. **[main]** values are converted, the header becomes `β11` and the dimension "dimensionless".

**`Scattering Factor`** (shown even with `BeamInteractionVisible = false`)

- `X-ray`: choose the valence. Coefficients from Waasmaier & Kirfel (1995) *Acta Cryst.* A51, 416-431 (comment of `AtomStatic.XrayScatteringWK`).
- `Electron`: choose the valence. Neutral atoms from Peng et al. (1996) *Acta Cryst.* A52, 257-276, ions from Peng (1998) *Acta Cryst.* A54, 481-485 (comment of `AtomStatic.ElectronScatteringPeng`).
- `Neutron`: `Natural isotope abundance` / `Custom isotope abundance`. With Custom, `Edit` opens the isotope composition window (title still `FormIsotopeComposition`), with columns isotope, `Atomic Weight`, `Natural Abundance (%)`, `Custom Abundance (%)`.
- Atoms read from CIF/AMC use neutral-atom coefficients even if a charge is given (see [File formats](05-file-formats.md#determining-the-element)).

**`Appearance`** (made visible in `FormMain_Load`)

`Radius` (Å, default VESTA radius × 0.4), `Color`, `Show Labels`, `Ambient`, `Diffusion`, `Specular`, `Emission`, `Alpha` (0–1), `Shininess` (0–20). CSManager has no 3D view, and these are not stored in the database.

## Bonds & Polyhedra (BondControl)

- List columns: enabled checkbox, `Center`, `Vertex`, `Min len.`, `Max len.` (Å), `Bonds`, `Polyhedron`.
- `Bonding Atoms`: choose `(center)` and `(vertex)`.
- `Show Bonds` (default on): `Radius` 0.1–9.9 Å (default 0.1), `Opacity` (default 0.7), `Length between` (default 0.1–1.6 Å).
- `Show Polyhedron` (default on): `Show Center Atom`, `Show Vertex Atoms`, `Show Inner Bonds` (in the Japanese UI shown as `結合を表示`, the same as Show Bonds), `Opacity` (default 0.7), `Show Edges` → `Width` (0–1, default 0.7).
- The colour boxes are hidden; colours come from the atoms.
- `Add` / `Replace` / `Delete`.
- **Not stored in the database.** Regenerated with VESTA defaults every time a row is selected. The existing manual's "used for display in ReciPro and other viewers" does not apply, because the way to send from CSManager (context menu `Send this crystal to other software`) is hidden.

## Ref.

| English UI | Content |
|---|---|
| `Note` | free-form memo |
| `Authors` | |
| `Journal` | |
| `Title` | |

All of these are stored in the database.

## EOS

Not described in the existing manual. Most labels stay in English. Not stored in the database.

- `Use EOS` (default off).
- `Isothermal pressure at T₀`: `3rd BM` (default), `4th BM`, `Vinet`, `AP2`, `Keane`, `3rd Vinet`.
- `Thermal pressure`: `Mie-Grüneisen` (default) or `T-dependence K₀ && V₀` (K(T,0) = K(T₀,0) + (∂K/∂T)(T−T₀), V(T,0) = V₀ exp[∫(a+bT+c/T²)dT]).

| Parameter | Unit | Default | Notes |
|---|---|---|---|
| V₀ | Å³/cell or cm³/mol | 300 | the clicked one becomes editable; V₀[cm³/mol] = V₀[Å³]·N_A/Z |
| K₀ | GPa | | |
| K′₀ | – | 4 | hidden for `3rd Vinet` |
| K″₀ | GPa⁻¹ (tooltip) | | `4th BM` only |
| K′∞ | – | | `Keane` only |
| η, β, ψ | – | | `3rd Vinet` only |
| T₀ | K | 300 | |
| γ₀, q, θ₀ | θ₀ in K | θ₀ = 300 | Mie–Grüneisen; γ = γ₀(V/V₀)^q, θ = θ₀ exp[(γ₀−γ)/q] |
| ∂K/∂T | GPa/K | | T-dependence model |
| a, b, c | 10⁻⁵ K⁻¹, 10⁻⁹ K⁻², K | | T-dependence model |
| T | K | 300 | |
| P | GPa | | read-only; the pressure at the current cell volume |

- Mie–Grüneisen: P = P_iso + (γ/V)[E_th(T) − E_th(T₀)], with a Debye model for E_th (`Crystallography/EOS.cs`); n is the number of atoms per formula unit.
- AP2: p_FG = 2336.965 (Z_e/V₀)^{5/3} (Z_e = electrons per cell, occupancy included).
- The T-dependence model combined with `3rd Vinet` returns 0. Z = 0 gives P = 0.
- There are display problems, e.g. P and V₀(cm³/mol) are not updated right after switching crystals ([Implementation questions](90-implementation-questions.md) Q20).

## Elasticity

Not described in the existing manual. Not stored in the database.

- Switch between `Elastic stiffness constant` (default) and `Elastic compliance constant`.
- Voigt notation c11–c66 (21 components of a symmetric 6×6 matrix). Units per tooltip: GPa for C, GPa⁻¹ for S. C and S are kept as mutual inverses.
- Code for crystal-system constraints exists, but CrystalControl never sets `elasticityControl1.SymmetrySeriesNumber`, so P1 is always assumed and **all 21 components are independent (no constraints or auto-completion)**. Same in origin/main (Q21).

## Context menu

Shown when right-clicking an empty part of the control (not on text boxes, numeric boxes or lists) (CC Designer `contextMenuStrip1`).

| English UI | Action |
|---|---|
| `Beam Interaction` | toggles the window |
| `Symmetry Information` | toggles the window |
| `Import from CIF or AMC...` | reads `*.cif;*.amc` into the editor (not into the database) |
| `Export to CIF` | default file name `{Name}.cif`. **`GenerateFromInterface` is not called first**, so the latest changes to name, references or colour may be missing |
| `Revert cell constants` | `RevertInitialCellConstants`. Initial values are saved only by list reading (`ConvertToCrystalList`), so it effectively does nothing in CSManager (to be confirmed) |
| `Convert to P1 Space Group` | turns all equivalent positions into independent atoms labelled `{label}_{n}` |
| `Convert to a superstructure` | asks for `a ×`, `b ×`, `c ×` (1–100, default 1) |
| `Change the axes/origin setting` | converts to another setting of the same number: axis exchange for monoclinic, axis exchange and origin shift for orthorhombic, origin shift for tetragonal/cubic, H ⇔ R for trigonal |

Hidden items: `Send this crystal to other software`, `Strain Control`.

!!! danger "Conversion bugs (pinned commit)"
    - The hexagonal → rhombohedral transformation is wrong (CC axis conversion, branch `srcExtra == "H"`): it uses c_R = (−a−b+c)/3 and z_R = y+z, whereas the correct ones are c_R = (−a−2b+c)/3 and z_R = −y+z (it is not the inverse of the R → H branch).
    - P1 conversion, superstructure and axis conversion do not transform the anisotropic displacement parameters together with the coordinates.
    - Both fixed in **[main]** `41955ec` (β′ = MβMᵀ).

## Drag and drop

Dropping one file on the crystal information reads it with `ConvertToCrystal` and shows it in the editor (not in the database). Extensions `amc` / `cif` must be **lower case**. Other files and read failures are silently ignored.

**[main]** adds `Details of the chemical composition` at the top of the context menu (wt%, at%, normalised atom numbers, conversion to oxides etc., valence editing).

<!-- screenshot: Basic Info. tab (English UI, one AMCSD entry selected) -->
<!-- screenshot: Atom Info. ▸ Debye-Waller Factor with Anisotropy -->
<!-- screenshot: EOS tab / Elasticity tab -->

## Open questions

1. How should the manual treat the tabs that are not stored in the database (appearance, bonds, EOS, elasticity, isotopes): state it clearly, or hide them in CSManager?
2. Actual behaviour of `Revert cell constants`.
3. Meaning of `Radius` (VESTA radius × 0.4).
4. Should the untranslated window titles (`Symmetry Information`, `Periodic Table`, …) be fixed on the UI side?
5. Is the default displacement model `Anisotropy` before an atom is selected intended?
