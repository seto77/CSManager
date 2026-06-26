# Import and export

CSManager can import crystals from CIF, AMC, and PDIndexer / ReciPro crystal lists, and can export the selected crystal as CIF.

## Import

- `Import CIF, AMC ...` in the `File` menu — reads a CIF file or AMC file and appends it to the end of the current database.
- `Import PDI Crystal data (*.xml)` in the `File` menu — reads a PDIndexer or ReciPro crystal list (`*.xml`) and appends it to the end of the current database.
- You can also load a crystal by dragging and dropping a CIF / AMC file onto the [Crystal information](4-crystal-information/index.md) area. You can also import by right-clicking the crystal information and choosing `Import from CIF or AMC...`.

CIF is the standard format of the International Union of Crystallography (IUCr), and AMC is the format adopted by the Mineralogical Society of America.

## Export

- Right-clicking the [Crystal information](4-crystal-information/index.md) and choosing `Export to CIF` writes out the current crystal in CIF format.
- To save the entire database, use `Save Database` in the `File` menu (see [Database loading](1-database-loading.md)).
