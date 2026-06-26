# Troubleshooting

This page summarizes common problems and how to deal with them.

- **Cannot start / .NET runtime not found** — CSManager requires **.NET Desktop Runtime 8** or later to run. If it is not installed, get it from Microsoft's distribution page.
- **COD fails to load** — `Read COD Database (including ### crystals)` downloads a large file (over 800 MB) from the Internet on the first run. Check your network connection and free disk space, and try again later.
- **Cannot open the database file** — check whether the `*.cdb3` file has been corrupted, moved, or saved with a different version. If you use AMCSD / COD as-is, you can reload them from `Read AMSCD Database (including ### crystals)` / `Read COD Database (including ### crystals)`.
- **Slow operation with a large database** — with large databases such as COD, searching and loading can take time. Narrow down with the conditions you need before operating.
- **Cannot interoperate with PDIndexer / ReciPro** — check whether the target software is running. The automatic transfer on selection is done via the clipboard (see [Interoperation](6-interoperation.md)).

For problems not listed here, please report them to the GitHub [Issue](https://github.com/seto77/CSManager/issues) page.
