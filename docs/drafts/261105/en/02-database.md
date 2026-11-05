# Reading and saving databases

Draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

Target: CSManager master `e081e9d` (submodules Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`).
Abbreviations: CDC = `Crystallography.Controls/CrystalDatabase/CrystalDatabaseControl.cs`, FM = `CSManager/FormMain.cs`, C2 = `Crystallography/Crystal/CrystalMinimum.cs` (`Crystal2`).

## Where the data live

- `UserAppDataPath` = parent of `Application.UserAppDataPath` (no version number) (FM and CDC `UserAppDataPath`). With no `Company`/`Product` in the csproj, the SDK default should give `%APPDATA%\CSManager\CSManager\` (to be confirmed).
- At every start the `AMCSD.cdb3` next to the executable is **copied over** `UserAppDataPath\AMCSD.cdb3` (FM `FormMain_Load`). Empty subfolders of `UserAppDataPath` are then deleted, and the versioned `Application.UserAppDataPath` folder is deleted recursively.
- AMCSD is read from `UserAppDataPath\AMCSD.cdb3`; COD from `UserAppDataPath\COD.cdb3` (header) plus `UserAppDataPath\COD\COD.000`… (CDC, `ReadCOD`).

## The `AMCSD` / `COD` checkboxes above the table

Two checkboxes, `AMCSD` and `COD`, sit above the database table (`checkBoxAMCSD` / `checkBoxCOD`; CSManager sets `DatabaseSelection = true`, both unchecked by default). The `File` menu items `Read AMSCD Database …` / `Read COD Database …` just tick them (FM `toolStripMenuItemReadDefault1_Click` / `…2_Click`). They have two roles.

1. **First tick loads the data**
    - AMCSD: if not yet read, starts `ReadDatabase(AMCSD.cdb3)` without waiting for it to finish.
    - COD: if not yet read, calls `ReadCOD()` (below) and waits. If it returns `false`, the box is unticked again.
2. **Display filter**: every change raises `DataBaseChanged` and the search panel searches again. Records of data type AMCSD are hidden while `AMCSD` is unticked, COD records while `COD` is unticked. Records of data type None (user-added crystals, single CIF/AMC import, XML import) are always shown (`SearchCrystalControl` search worker). Unticking does not remove the data from memory.

Data types (`Crystal2.datatype`): 0 = None, 1 = AMCSD, 2 = COD.

## COD download and update check (CDC `ReadCOD`)

1. Reads the local `COD.cdb3` header and checks the MD5 of **every** split file against it (`CheckDatabaseFiles(…, checkMD5: true)`). This hashes about 885 MB every time COD is ticked, so it takes a while.
2. If valid, downloads `https://github.com/seto77/CSManager/raw/master/COD/COD.cdb3` (the 585-byte header) and compares it byte by byte with the local one.
    - Identical: reads the local copy.
    - Different: "Now, new database is available. / Download and load the new database: YES / Use the current database: No / Cancel database loading: Cancel". `Yes` downloads again, `No` reads the current copy, `Cancel` stops.
3. On a network exception (e.g. offline): reads the local copy.
4. Local copy missing or invalid: "Local COD database is missing. Do you download the new database now ?" (Yes/No).
5. The download saves `COD.cdb3`, then fetches **all split files in parallel** (currently 24 files, `COD.000`–`COD.023`, 35–40 MB each, 885,018,299 bytes in total). The `HttpClient` timeout is 600 s. Progress: "Downloading COD database (x MB / y MB) ...".
6. On failure: "Failed to download new COD database. Sorry.". The MD5 is not checked again after downloading.

!!! warning
    With the current code, choosing `No` in step 2 starts loading but unticks the box, so the COD rows are hidden. Ticking it again loads them a second time. See [Implementation questions](90-implementation-questions.md) Q4.

## `Read Database` / `Save Database` / `Clear Database`

- **Read** (CDC `ReadDatabase`): reads only files whose name ends in `cdb3` and **appends** them to the table (no replacement, no duplicate check). The file dialog offers `*.cdb; *.cdb2; *.cdb3`, but `.cdb` / `.cdb2` files are silently ignored. Multi-select is allowed, but calls made while the loading worker is busy are dropped, so only the first file is actually read (Q5).
- **Save** (CDC `SaveDatabase`): writes `*.cdb3` in the current display (sort) order. Above 35,000,000 bytes it switches to the split format (below).
    - With the current code, saving while a search filter is active, or while `AMCSD` or `COD` is unticked, produces an empty file (Q2). Clear the conditions and tick both boxes before saving.
- **Clear** (CDC `ClearAll`): empties the table only; files are not deleted. The "already read" flags and the checkboxes are not reset, so AMCSD/COD cannot be read again in the same session (Q3). Restart if needed.

## cdb3 file format (CDC `ReadDatabaseWorker` / `SaveDatabaseWorker`)

| Position | Content |
|---|---|
| 1 byte | format flag: 100 = single file, 200 = split |
| int32 | total number of records |

- **Single (100)**: a sequence of `[int32 length L][L bytes]` chunks. Each chunk is `Crystal2[]` (up to 2500 records) serialized with MemoryPack and compressed with Brotli (`SmallestSize`, window 24). The bundled `AMCSD.cdb3` (5,620,522 bytes) holds 21,588 records in 9 chunks.
- **Split (200)**: the main file holds only `[200][int32 total][int32 N][int64×N sizes][16 bytes×N MD5]`. The data are in a subfolder named after the file without its extension, as `name.000`… (same chunk sequence as the single format). The current `COD.cdb3` is 585 bytes = 1+4+4+24×8+24×16, with 533,220 records in 24 parts.
- The legacy `.cdb` (up to ver1.51) and `.cdb2` (ver1.52–1.871) formats cannot be read (`ReadDatabase` ignores anything not ending in `cdb3`).

The database stores `Crystal2` (a compact record), not the full `Crystal`. See [File formats](05-file-formats.md#crystal2-record) for what is kept.

## Using and citing the databases

The notice above the table (`textBox1`, English only) asks users to cite Downs & Hall-Wallace (2003) *American Mineralogist* 88, 247-250 for AMCSD, and https://wiki.crystallography.net/cod/citing/ for COD (same citation as the existing manual).

<!-- screenshot: AMCSD / COD checkboxes and citation notice above the table -->

## Open questions

1. Actual path of `UserAppDataPath`.
2. Were the d lists of the bundled COD built with the old `GetDspacingList`? (e081e9d rebuilt AMCSD only.)
3. The `File` menu shows `Version.AMCSD = 21_478`, but the bundled `AMCSD.cdb3` has 21,588 records. Should `Version.cs` be updated?
4. Is it intended to keep serving the 35–40 MB COD parts from GitHub raw?
