# Database loading

Databases are read and saved from the `File` menu.

## Standard databases

- `Read AMSCD Database (including ### crystals)` — reads the AMCSD database provided by the Mineralogical Society of America (MSA). It contains about 20,000 crystal structures, and since it is bundled with the installation file, no separate download is required. The menu shows the current number of entries. If "Read AMCSD Database on Next Boot" is enabled in `Option`, it is read automatically at startup.
- `Read COD Database (including ### crystals)` — reads the crystal database provided by the Crystallography Open Database (COD). It contains more than 500,000 crystal structures and, because of its large file size (over 800 MB), it is not bundled. On the first load it is downloaded automatically from the Internet, and from then on the already downloaded file is read.

## Custom databases

- `Read Database` — opens any CSManager database file (`*.cdb3`).
- `Save Database` — saves the current database in `*.cdb3` format.
- `Clear Database` — clears the loaded data. The database file itself is not deleted.

If you use AMCSD or COD as-is, you will rarely need to use `Read Database` / `Save Database`.

## Using and citing the database

When you publish academic papers or the like using the crystal structure data contained in AMCSD, whether online or offline, you must always cite the following paper.

> Downs, R.T. and Hall-Wallace, M. (2003) The American Mineralogist Crystal Structure Database. *American Mineralogist* 88, 247-250.
