# Search

The search panel lets you narrow down the loaded crystal database using various conditions. Enable the checkbox of the condition you want to use, enter a value, and then press the `Search` button or the Enter key to run the search. You can specify multiple conditions at the same time.

## Search conditions

- `Name` — searches by the name of the crystal.
- `Elements` — pressing the `Periodic Table` button opens a separate window where you can select the elements to search for. Each element button cycles through its state (may or may not include / must include / must exclude) every time it is pressed. The "may or not include" / "must include" / "must exclude" buttons at the top of the window switch the state of all elements at once.
- `Reference` — searches by reference information such as paper title, journal name, and author name.
- `Crystal System` — narrows down by crystal system.
- `Cell Params` — specifies cell constants and a tolerance range. Items for which you enter zero as the tolerance are ignored.
- `d-spacing` — specifies the d-spacing (interplanar spacing) of a crystal plane and a tolerance range, and searches for crystals that have a d-spacing within that range. When `Ignore scattering factor` is enabled, the diffraction intensity (crystal structure factor) is not taken into account, and the search includes crystal planes that violate the extinction rules. When it is disabled, the crystal structure factor is taken into account and only the top 20 crystal planes by intensity are searched.
- `Density` — specifies density and a tolerance range.
