# Interoperation with other software

Draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

Target: CSManager master `e081e9d` (submodules Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`).

## Clipboard transfer on selection

Every time a row of the database table is selected (`crystalDatabaseControl_CrystalChanged`), CSManager:

1. shows the crystal in the crystal-information area;
2. **overwrites** the clipboard with `Clipboard.SetDataObject(MemoryPackEx.Serialize(Crystal2.ID, crystal2))`.

- The content is a `byte[]`: one byte of type ID (`Crystal2.ID = 0`) followed by a Brotli-compressed MemoryPack `Crystal2` (`Crystallography/ExtensionMethods.cs`). It carries the same information as the `Crystal2` record in [File formats](05-file-formats.md#crystal2-record) (no bonds, EOS, elasticity or isotopes).
- CSManager does not check whether the other software is running. **The clipboard is replaced on every selection**, so whatever you had copied before is lost when you select a row.
- `SetDataObject` is called with the default `copy = false`, so the data disappear from the clipboard when CSManager exits.
- Receivers are ReciPro and PDIndexer (the startup hint also mentions IPAnalyzer, `Version.Hint`). When a receiver reads the clipboard depends on its own implementation (open question 1).

The context-menu item `Send this crystal to other software` mentioned in the existing manual is currently hidden (`Visible = False`).

## Importing crystal lists

`File` ▸ `Import PDI Crystal data (*.xml)` reads a `Crystal[]` XML written by PDIndexer / ReciPro and appends all crystals (`FormMain.readXml`). Dropping an `.xml` file on the main window does the same.

- Imported crystals go through `Crystal2.FromCrystal`, so bonds, EOS, elasticity, strain, isotopes, etc. in the XML are not kept. No d list is built (not found by the d-spacing search).
- Reading from the menu has no exception handling: a broken XML crashes the application ([Implementation questions](90-implementation-questions.md) Q16).

## Exchanging CIF files

Right-click the crystal information ▸ `Export to CIF` writes a CIF. For its content and what is lost on re-import, see [File formats](05-file-formats.md).

## Open questions

1. Do ReciPro, PDIndexer and IPAnalyzer still read CSManager's `Crystal2` format (ID 0 + MemoryPack), and when (clipboard monitoring or on focus)?
2. Should the clipboard overwrite on every selection be highlighted as a warning in the manual, or made optional?
