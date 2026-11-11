# Third-party notices

This file summarizes third-party components, libraries, and data sources that are bundled with or referenced by CSManager. It is intended to support transparent redistribution and future code-signing review.

This file is not a substitute for the original license texts. For each dependency, refer to the upstream project or data provider for the authoritative license terms.

## Project license

CSManager itself is distributed under the MIT License. See `LICENSE.md`.

## Status of this document

Last reviewed: 2026-11-06 (WiX / arm64 / portable-ZIP release line, v.1.913). The inventory below has been checked against the current project files, resolved NuGet dependencies, and release packaging workflow for `CSManager.csproj`. **AMCSD bulk redistribution is permitted (permission obtained from one of the AMCSD maintainers); COD is public-domain.** The data-attribution and citation details are aligned with the sibling project ReciPro (same core library and same author-hosted COD mirror). Items still requiring external verification are marked **`TODO: confirm`**.

CSManager does **not** bundle any native libraries. Unlike its sibling ReciPro, CSManager has no OpenGL 3D views and does not call the in-house SIMD native library or xraylib, so `Crystallography.Native.dll`, `libxrl-11.dll`, and `glfw3.dll` are **not** shipped (`glfw3.dll`, pulled in transitively by OpenTK, is removed from the MSI and portable packages during the build).

## NuGet / managed libraries

These ship as managed assemblies inside the MSI (through the CSManager publish output) and in the portable ZIP packages, built from their respective upstream NuGet packages. Versions are pinned inline per project.

| Name | Version | Purpose | Bundled or downloaded | Upstream URL | License | Signed by CSManager? | Notes |
|------|---------|---------|-----------------------|--------------|---------|----------------------|-------|
| CsvHelper | 34.0.0 | CSV read/write (AMCSD CSV import / maintenance utilities) | Bundled (DLL) | https://github.com/JoshClose/CsvHelper | Dual: MS-PL OR Apache-2.0 (the consumer may choose either) | No (third-party) | CSManager-specific dependency (declared in `CSManager.csproj`). |
| MathNet.Numerics | 6.0.0-beta2 | Numerical / scientific computing | Bundled (DLL) | https://numerics.mathdotnet.com/ | MIT | No (third-party) | Pre-release (beta) version. From the shared Crystallography libraries. |
| MemoryPack(.Core) | 1.21.4 | Zero-encoding binary serializer (Cysharp) | Bundled (DLL) | https://github.com/Cysharp/MemoryPack | MIT | No (third-party) | Used by Crystallography (`.cdb3` crystal-database serialization). |
| PureHDF | 2.2.0 | Pure C# HDF5 reader/writer | Bundled (DLL) | https://github.com/Apollo3zehn/PureHDF | MIT | No (third-party) | From the shared Crystallography library. |
| IronPython (+ .Modules / .SQLite / .Wpf) | 3.4.2 | Python implementation for .NET (macro engine) | Bundled (DLLs) | https://github.com/IronLanguages/ironpython3 | Apache-2.0 | No (third-party) | 3.x is Apache-2.0; include the `NOTICE` + Apache-2.0 text. Pulls in `Mono.Unix.dll` (MIT, from the Mono project). |
| Mono.Unix | 7.1.0-final.1.21458.1 | POSIX interop (transitive via IronPython) | Bundled (DLL) | https://github.com/mono/mono | MIT | No (third-party) | Version from the resolved NuGet dependency graph. |
| OpenTK | 4.9.4 | OpenGL/OpenAL/OpenCL bindings (managed only) | Bundled (managed DLLs only) | https://github.com/opentk/opentk | MIT | No (third-party) | From the shared libraries. **CSManager ships the managed OpenTK assemblies only; the native `glfw3.dll` is excluded** because CSManager has no 3D views (structure rendering moved to ReciPro). |
| WpfMath | 2.1.0 | WPF LaTeX math rendering | Bundled (DLL) | https://github.com/ForNeVeR/wpf-math | MIT | No (third-party) | From Crystallography.Controls. Ships `XamlMath.Shared.dll` (its support library, MIT). |
| System.Numerics.Tensors | 11.0.0 | SIMD-accelerated span math (`TensorPrimitives`) | Bundled (DLL) | https://github.com/dotnet/runtime | MIT | No (third-party) | Microsoft official package. From the shared Crystallography library (replaced SimdLinq / ZLinq, 261111Cl). |

Target framework: `net10.0-windows`. The .NET runtime itself is framework-dependent in the MSI (requires the .NET Desktop Runtime 10) and self-contained in the portable ZIP packages (the runtime files are bundled, under the .NET Library license / MIT, and are not re-signed by CSManager).

## Bundled and downloaded crystallographic data

### AMCSD (bundled)

| Item | Detail |
|------|--------|
| Name | American Mineralogist Crystal Structure Database (AMCSD) |
| Bundled or downloaded | **Bundled** — `AMCSD.cdb3` (~5.6 MB; Brotli + MemoryPack compressed `.cdb3` format). Shipped via `CSManager.csproj` `<Content Include="AMCSD.cdb3">` and copied to the user app-data folder at startup. |
| Content | 21,588 crystal structures (2026-11-05 database update; matches `Version.cs`). |
| Upstream URL | http://rruff.geo.arizona.edu/AMS/amcsd.php |
| Required citation | Downs, R. T. & Hall-Wallace, M. (2003). The American Mineralogist Crystal Structure Database. *American Mineralogist*, **88**, 247-250. |
| Signed by CSManager? | N/A (data file, not code) — ships inside the installer. |
| Redistribution status | **Permitted.** Redistribution permission was obtained from one of the AMCSD maintainers. The underlying crystal-structure data are scientific facts published in peer-reviewed journals and are openly distributed by AMCSD/RRUFF (e.g. https://www.rruff.net/). Attribution is provided via the Downs & Hall-Wallace (2003) citation. The `.cdb3` carries no embedded attribution; attribution is satisfied via this file (an in-app citation on the database window would further strengthen it). |

### COD (downloaded on first use)

| Item | Detail |
|------|--------|
| Name | Crystallography Open Database (COD) |
| Bundled or downloaded | **Downloaded on first use**, NOT bundled (534,898 structures; 2026-11-05 database update, ~889.6 MB across 24 data files). Same `.cdb3` format as AMCSD, re-packaged by the author. |
| Download source | **This repository's own mirror**: `https://github.com/seto77/CSManager/raw/master/COD/` (CSManager is the COD mirror that its sibling apps also use). |
| Upstream URL | https://www.crystallography.net/cod/ |
| License | COD data are released to the **public domain** / open terms; redistribution is **permitted**. This repository (`seto77/CSManager`) hosts the COD mirror that CSManager and its sibling apps (ReciPro, PDIndexer) download from. |
| Required citation | Gražulis et al. (2009) *J. Appl. Cryst.* **42**, 726-729 (https://doi.org/10.1107/S0021889809016690); Gražulis et al. (2012) *Nucleic Acids Research* **40**, D420-D427 (https://doi.org/10.1093/nar/gkr900). COD lists further papers (e.g. Vaitkus et al. 2021) on its citation page. |
| Signed by CSManager? | N/A (downloaded data, not part of the installer). |
| Redistribution status | **Permitted (public domain).** The mirror is a re-packaged snapshot of public-domain COD data and preserves that status. |

### Hardcoded scientific data (compiled into the shared Crystallography core)

Factual/public-domain reference data are compiled into the shared `Crystallography` library source (the same core library used by ReciPro) and attributed by citation:

- X-ray atomic scattering factors — Waasmaier & Kirfel (1995) *Acta Cryst.* **A51**, 416-431 (plus analytic RHF/HF forms).
- Electron scattering factors — Peng et al. (1996, 1998).
- Neutron coherent scattering lengths — `periodictable` neutron table, reproduced from Rauch, H. & Waschkowski, W. (2003), "Neutron Scattering Lengths" in *ILL Neutron Data Booklet* (2nd ed.).
- X-ray mass / linear absorption coefficients — NIST FFAST (Chantler), public-domain US-government data.
- Elastic electron-scattering sampler — NIST Electron Elastic-Scattering Cross-Section Database (SRD 64). `TODO: confirm` exact SRD citation.
- Space-group / symmetry tables — derived from International Tables for Crystallography (ITA); factual data, attribution to ITA recommended. `TODO: confirm`.

These are scientific facts; no runtime dependency on the source packages is shipped. See ReciPro's `THIRD-PARTY-NOTICES.md` for the same list with additional detail.

### Embedded scientific datasets

The following resources are embedded in the shared `Crystallography.dll` shipped with CSManager. The two Temari datasets are © 2026 Yusuke Seto, licensed under [CC BY 4.0](https://creativecommons.org/licenses/by/4.0/), and provided as-is without warranties. Their data license is separate from the software's MIT license.

- **Atomic scattering factors f_x(s) and f_e(s) for 86 neutral atoms (Z = 1–86) computed with Temari**, dataset-factors **v2.0.0** (2026), [DOI: 10.5281/zenodo.22820415](https://doi.org/10.5281/zenodo.22820415). Embedded as `Crystallography.TemariFactors.bin`. **Modified:** the published values were requantized to steps of 1e-10 electrons (f_x) and 1e-11 Å (f_e), delta-coded, and Brotli-compressed; no values were recomputed.
- **Inner-shell ionization form factors F(s, E₀) for STEM-EDX: 525 channels (K, L1–L3, M1–M5) computed with Temari**, dataset **v7.0.0** (2026), [DOI: 10.5281/zenodo.22643468](https://doi.org/10.5281/zenodo.22643468). Embedded as `Crystallography.IonizationFsE0.bin`. **Modified:** the published tables were repacked using 1e-6 quantization, s-direction delta coding, and byte-plane shuffle; no values were recomputed.
- **Bote–Salvat absolute ionization cross-section coefficients**, embedded as `Crystallography.BoteSalvat.bin`. Extracted from `xione.jl` in [usnistgov/BoteSalvatICX.jl](https://github.com/usnistgov/BoteSalvatICX.jl), under **The Unlicense**. Sources: Bote & Salvat, *Phys. Rev. A* **77** (2008) 042701, [DOI: 10.1103/PhysRevA.77.042701](https://doi.org/10.1103/PhysRevA.77.042701); Bote, Salvat, Jablonski & Powell, *At. Data Nucl. Data Tables* **95** (2009) 871–909, [DOI: 10.1016/j.adt.2009.08.001](https://doi.org/10.1016/j.adt.2009.08.001).

## Code-signing note

The intended code-signing scope is limited to CSManager release artifacts and binaries **built from this repository**: `CSManager.exe`, `apphost.exe`, and the in-house managed assemblies `Crystallography.dll` / `Crystallography.Controls.dll` (and their satellite resource DLLs). CSManager bundles no native libraries.

Third-party managed binaries (the NuGet runtime DLLs listed above and the bundled .NET runtime files in the portable ZIP) keep their own upstream provenance and licenses and must **not** be re-signed or relicensed as CSManager's MIT code. See `CODE_SIGNING.md` for the release-artifact signing policy. This notice is not a substitute for the upstream license texts.
