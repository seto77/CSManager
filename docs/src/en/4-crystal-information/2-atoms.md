# Atoms

The `Atom Info.` tab displays and sets information about the atoms contained in the crystal. The list at the top shows the atoms, and clicking an atom shows its detailed information below.

!!! warning
    After editing an atom, press the `Add` or `Replace` button. If you do not, the atom information is not saved to the list.

## Working with the atom list

- `Add` — adds the configured atom to the list as a new entry.
- `Replace` — replaces the currently selected atom with the configured atom.
- `Up` / `Down` — moves the selected atom up or down in the order.
- `Delete` — deletes the selected atom from the list.

## Element and position

- `Label` — enter the label of the atom.
- `Element` — set the element.
- `X`, `Y`, `Z` — set the fractional coordinates of the atom. Enter real numbers from 0 to 1. Fractions such as 1/2 or 2/3 can also be entered.
- `Occ` — specify the occupancy as a real number from 0 to 1.

In **Origin shift**, you can shift the origin position using preset buttons or any value.

## Temperature factor (Debye-Waller factor)

- **Notation** — choose `U` or `B`.
- **Model** — choose isotropic (Isotropy) or anisotropic (Anisotropy).
- Enter each component of the temperature factor (`B##` or `U##`).

## Scattering factor

Set the valence and isotopic composition used when calculating the atomic scattering factor.

- **X-ray** — choose the valence used to calculate the elastic atomic scattering factor for X-rays. The parameters are based on *International Tables for Crystallography volume C*.
- **Electron** — choose the valence for the elastic atomic scattering factor for electron beams. The parameters are based on Peng (1998, *Acta Cryst.* A54, 481-485).
- **Neutron** — choose the isotopic composition for calculating the elastic neutron scattering length. You can choose `Natural isotope abundance` or `Custom isotope abundance`.
