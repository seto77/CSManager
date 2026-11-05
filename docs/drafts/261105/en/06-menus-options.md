# Menus, options, help and language

Draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

Target: CSManager master `e081e9d` (submodules Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`).
Unless stated otherwise, the evidence is `CSManager/FormMain.cs`, `FormMain.Designer.cs`, `FormMain.resx` (English) and `FormMain.ja.resx` (Japanese).

## Menu structure

The menu bar has four menus: `File`, `Option`, `Help` and `Language` (right-aligned) (`menuStrip.Items.AddRange` in `FormMain.Designer.cs`).

### File

| English UI | Action (handler) |
|---|---|
| `Read AMSCD Database (including ### crystals)` | sets `crystalDatabaseControl.AMCSD_Checked = true` (`toolStripMenuItemReadDefault1_Click`). `###` is replaced at startup by `Version.AMCSD` (`FormMain_Load`) |
| `Read COD Database (including ### crystals)` | sets `crystalDatabaseControl.COD_Checked = true` (`toolStripMenuItemReadDefault2_Click`). `###` is `Version.COD` |
| `Read Database` | opens `*.cdb; *.cdb2; *.cdb3` (multi-select) and calls `ReadDatabase` for each (`readDatabaseToolStripMenuItem_Click`) |
| `Save Database` | saves as `*.cdb3` (`saveDatabaseToolStripMenuItem_Click` → `SaveDatabase`) |
| `Clear Database` | `crystalDatabaseControl.ClearAll()` |
| `Import CIF, AMC ...` | reads one file and appends it to the database (`toolStripMenuItemImport_Click`). See [File formats](05-file-formats.md) |
| `Import PDI Crystal data (*.xml)` | reads a `Crystal[]` XML and appends all crystals (`readXml`) |
| `Close` | exits |
| `Debug functions` | maintenance submenu, see below |

`Debug functions` is visible in Release builds as well (no `Visible` setting). Items:

| English UI | Action |
|---|---|
| `Compress and Split` | no handler attached (does nothing) |
| `Show the file name of the selected crystal` | shows `Crystal2.fileName` of the selected record (`toolStripMenuItemShowFileName_Click`) |
| `Check Duplicated File` | handler body is entirely commented out (does nothing) |
| `Import All File (CIF or AMC)` | folder batch import, see [File formats](05-file-formats.md#batch-import) |
| `Import AMCSD_CSV` | builds a database from the AMCSD CSV, see [File formats](05-file-formats.md#amcsd-csv) |
| `Re-calculate density and formula` | `crystalDatabaseControl.RecalculateDensityAndFormula()` |
| `CODtype` | empty handler |

### Option

| English UI | Default | Action |
|---|---|---|
| `Tool Tip` | on (Designer) | toggles `ToolTip.Active` of the main form, crystal information, search panel and database table at once (`toolTipToolStripMenuItem_Click`). Not saved in the registry |
| `Read AMCSD Database on Next Boot` | see warning | whether AMCSD is read at startup |
| `Incremental Search` | off, **disabled (greyed out)** | not implemented: `Enabled = false`, and `Checked` is never read (260531Cl comment in Designer) |
| `Font Size in Data Table` ▸ `Increase (Ctrl+Shift+.)` / `Decrease (Ctrl+Shift+,)` | — | multiplies the table `FontSize` by 1.1 / 0.9 |

!!! warning "Actual behaviour of `Read AMCSD Database on Next Boot`"
    `FormMain_Load` checks this item's `Checked` (Designer default `true`) and reads AMCSD **before** `readRegistry()` applies the saved value. With the current code AMCSD is therefore always read at startup, whatever was saved. When no registry value exists (e.g. first launch), the `"False"` default in `readRegistry` leaves the item unchecked. See [Implementation questions](90-implementation-questions.md) Q1.

### Help

| English UI | Action |
|---|---|
| `Program Updates` | update check (below). Hidden in the portable ZIP edition (when `README-PORTABLE.txt` is next to the executable; `FormMain_Load`) |
| `Hint` | opens the startup dialog (`CommonDialog`) in hint mode |
| `Version History` | same dialog in history mode (`Version.History`) |
| `License` | same dialog in license mode |
| (no `Text` in the English resx; Japanese: `Github ページ`) | opens https://github.com/seto77/CSManager |
| `Repport bugs, request or comments` | opens https://github.com/seto77/CSManager/issues |
| `Help (PDF)` | opens the online manual: `https://seto77.github.io/CSManager/` for English, otherwise `https://seto77.github.io/CSManager/<HelpCulture>/` (`helpwebToolStripMenuItem_Click`, `SupportedCultures.HelpCulture`). It is not a PDF |

#### Update check (`programUpdatesToolStripMenuItem_Click` → `Crystallography/ProgramUpdates.cs: Check`)

1. Downloads `https://raw.githubusercontent.com/seto77/CSManager/master/CSManager/Version.cs` and takes five characters of the version number from the first line containing `" ver"`.
2. Compares it as `double` with the running version (characters 4–8 of `Version.VersionAndDate`). If newer, asks for confirmation.
3. The installer name depends on the process architecture (Arm64: `CSManager-setup_arm64.msi`, otherwise `CSManager-setup.msi`). The existence of `http://github.com/seto77/CSManager/releases/download/v.<version>/<name>` is checked with a header-only request; if missing, the user is told the installer for this architecture has not been published yet.
4. `Yes` downloads the MSI into the per-user data folder (`UserAppDataPath`), launches it and closes CSManager.

### Language

The items of the `Language` menu are generated at startup from the entries of `Crystallography.SupportedCultures.All` with `Released = true` (`PopulateLanguageMenu`): currently English, 日本語, Deutsch, Français, Español, Português, Italiano, Русский, 简体中文, 繁體中文 and 한국어.

Selecting one asks "Switching the display language to "…" requires restarting CSManager. Unsaved work will be lost. Restart now?". `Yes` saves the settings, starts a new process and closes the current one (`languageToolStripMenuItem_Click` → `RestartApplicationForLanguageChange`); `No` changes nothing.

!!! note
    Messages generated in code (`Localization.Loc(en:…, ja:…)`) exist only in English and Japanese; for other UI languages they appear in English (`FormMain.CurrentLanguage`).

## Where settings are stored

On exit (`FormMain_FormClosing` → `saveRegistry`) the following values are written to `HKEY_CURRENT_USER\Software\Crystallography\CSManager`.

| Value name | Content |
|---|---|
| `Culture` | UI culture name (read by `Program.Main` at startup and resolved by `SupportedCultures.Resolve`; unknown values fall back to English) |
| `MainWidth` / `MainHeight` / `MainLocationX` / `MainLocationY` | window size and position (restored only when `MainLocationY > 0`) |
| `readDefaultDatabaseOnNextBootToolStripMenuItem.Checked` | `"True"` / `"False"` |
| `initialDialog.AutomaricallyClose` | whether the startup dialog closes automatically (spelling as in the code) |

Nothing is saved when started with `--capture` (`SuppressRegistrySave`).

## Command-line arguments (`Program.Main`)

| Argument | Action |
|---|---|
| `--smoke [output file]` | writes the process architecture and base directory and exits (for CI; default output `smoke-result.txt`) |
| `--capture <output folder> <culture>` | opens the main window in the given culture, waits for AMCSD to finish loading (max. 90 s), saves `FormMain.png` and exits (`GuiCapture.Run`). Used to generate manual screenshots |

<!-- screenshot: File menu opened (English UI) -->

## Open questions

1. Should `Debug functions` be documented in the user manual (it is visible in Release builds)? If not, mention it only as "maintenance".
2. `Help (PDF)` opens the online manual; change the UI string, or keep it and explain in the manual?
3. The `Github page` item has no `Text` in the English resx (it should appear blank in the English UI). Check on a real machine.
4. Actual path of the settings folder (`UserAppDataPath` = parent of `Application.UserAppDataPath`). With no `Company` in the csproj the SDK default (assembly name) would give `%APPDATA%\CSManager\CSManager\`, not verified on a real machine.
