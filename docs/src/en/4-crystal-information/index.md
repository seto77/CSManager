---
title: Crystal information
---

# Crystal information

The crystal information area (the `Crystal Information` control) displays and edits the cell constants, symmetry, atomic positions, references, and so on of the selected crystal. You can also load any crystal by dragging and dropping a CIF file or an AMC file onto this area.

!!! warning "Confirm changes with `Add` / `Replace`"
    Whenever you make a change to a crystal, be sure to press the `Add` or `Replace` button. If you do not, the changes are not saved to the database table and are lost.

The top shows common information such as the crystal name (`Name`) and chemical composition (`Formula`), and `Reset` initializes all of the crystal's information. The bottom contains tabs for setting symmetry, atoms, references, and so on.

## Tabs

- [Basic information](1-basic-information.md) — cell constants, symmetry, volume, density, and so on (the `Basic Info.` tab)
- [Atoms](2-atoms.md) — atomic positions, occupancies, temperature factors, and scattering factors (the `Atom Info.` tab)
- [Bonds and polyhedra](3-bonds-polyhedra.md) — drawing settings for bonds and coordination polyhedra (the `Bonds & Polyhedra` tab)
- [References](4-references.md) — reference information (the `Ref.` tab)

## Right-click menu

Right-clicking a blank part of the control lets you perform the following operations.

- `Import from CIF or AMC...` — imports a crystal structure in CIF / AMC format.
- `Export to CIF` — writes out the current crystal in CIF format.
- `Send this crystal to other software` — sends the selected crystal to software such as PDIndexer or ReciPro.
- `Symmetry Information` — opens a detailed window about symmetry (space-group serial number, Laue group / point group, presence rules, Wyckoff positions, geometric calculations for crystal planes and zone axes, and so on).
- `Revert cell constants` — restores the cell constants to the values they had just after loading.
- `Convert to P1 Space Group` / `Convert to a superstructure` / `Change the axes/origin setting` — perform conversions of the space group or lattice.
