# Third-party notices

This file summarizes third-party components, libraries, and data sources that are bundled with or referenced by CSManager. It is intended to support transparent redistribution and future code-signing review.

This file is not a substitute for the original license texts. For each dependency, refer to the upstream project or data provider for the authoritative license terms.

## Project license

CSManager itself is distributed under the MIT License. See `LICENSE.md`.

## Status of this document

Last reviewed: 2026-06-26 (WiX / arm64 / portable-ZIP release line, v.1.912). The inventory below is derived from the actual framework-dependent publish output of `CSManager.csproj` (the managed assemblies shipped in the MSI). **AMCSD bulk redistribution is permitted (permission obtained from one of the AMCSD maintainers); COD is public-domain.** The data-attribution and citation details are aligned with the sibling project ReciPro (same core library and same author-hosted COD mirror). Items still requiring external verification are marked **`TODO: confirm`**.

CSManager does **not** bundle any native libraries. Unlike its sibling ReciPro, CSManager has no OpenGL 3D views and does not call the in-house SIMD native library or xraylib, so `Crystallography.Native.dll`, `libxrl-11.dll`, and `glfw3.dll` are **not** shipped (`glfw3.dll`, pulled in transitively by OpenTK, is removed from the MSI and portable packages during the build).

## NuGet / managed libraries

These ship as managed assemblies inside the MSI (through the CSManager publish output) and in the portable ZIP packages, built from their respective upstream NuGet packages. Versions are pinned inline per project.

| Name | Version | Purpose | Bundled or downloaded | Upstream URL | License | Signed by CSManager? | Notes |
|------|---------|---------|-----------------------|--------------|---------|----------------------|-------|
| CsvHelper | 33.1.0 | CSV read/write (AMCSD CSV import / maintenance utilities) | Bundled (DLL) | https://github.com/JoshClose/CsvHelper | Dual: MS-PL OR Apache-2.0 (the consumer may choose either) | No (third-party) | CSManager-specific dependency (declared in `CSManager.csproj`). |
| MathNet.Numerics | 6.0.0-beta2 | Numerical / scientific computing | Bundled (DLL) | https://numerics.mathdotnet.com/ | MIT | No (third-party) | Pre-release (beta) version. From the shared Crystallography libraries. |
| MemoryPack(.Core) | 1.21.4 | Zero-encoding binary serializer (Cysharp) | Bundled (DLL) | https://github.com/Cysharp/MemoryPack | MIT | No (third-party) | Used by Crystallography (`.cdb3` crystal-database serialization). |
| PureHDF | 2.1.2 | Pure C# HDF5 reader/writer | Bundled (DLL) | https://github.com/Apollo3zehn/PureHDF | MIT | No (third-party) | From the shared Crystallography library. |
| DynamicExpresso.Core | 2.19.3 | Runtime C#-like expression interpreter (symmetry-operation parsing) | Bundled (DLL) | https://github.com/dynamicexpresso/DynamicExpresso | MIT | No (third-party) | From Crystallography. Replaced `System.Linq.Dynamic.Core`. |
| IronPython (+ .Modules / .SQLite / .Wpf) | 3.4.2 | Python implementation for .NET (macro engine) | Bundled (DLLs) | https://github.com/IronLanguages/ironpython3 | Apache-2.0 | No (third-party) | 3.x is Apache-2.0; include the `NOTICE` + Apache-2.0 text. Pulls in `Mono.Unix.dll` (MIT, from the Mono project). |
| Mono.Unix | (IronPython dependency) | POSIX interop (transitive via IronPython) | Bundled (DLL) | https://github.com/mono/mono | MIT | No (third-party) | `TODO: confirm` exact package/version. |
| OpenTK | 4.9.4 | OpenGL/OpenAL/OpenCL bindings (managed only) | Bundled (managed DLLs only) | https://github.com/opentk/opentk | MIT | No (third-party) | From the shared libraries. **CSManager ships the managed OpenTK assemblies only; the native `glfw3.dll` is excluded** because CSManager has no 3D views (structure rendering moved to ReciPro). |
| SimdLinq | 1.3.2 | SIMD-accelerated LINQ (Cysharp) | Bundled (DLL) | https://github.com/Cysharp/SimdLinq | MIT | No (third-party) | From the shared libraries. |
| ZLinq | 1.5.6 | Zero-allocation LINQ (Cysharp) | Bundled (DLL) | https://github.com/Cysharp/ZLinq | MIT | No (third-party) | From the shared libraries. |
| WpfMath | 2.1.0 | WPF LaTeX math rendering | Bundled (DLL) | https://github.com/ForNeVeR/wpf-math | MIT | No (third-party) | From Crystallography.Controls. Ships `XamlMath.Shared.dll` (its support library, MIT). |

Target framework: `net10.0-windows`. The .NET runtime itself is framework-dependent in the MSI (requires the .NET Desktop Runtime 10) and self-contained in the portable ZIP packages (the runtime files are bundled, under the .NET Library license / MIT, and are not re-signed by CSManager).

## Bundled and downloaded crystallographic data

### AMCSD (bundled)

| Item | Detail |
|------|--------|
| Name | American Mineralogist Crystal Structure Database (AMCSD) |
| Bundled or downloaded | **Bundled** — `AMCSD.cdb3` (~5.4 MB; Brotli + MemoryPack compressed `.cdb3` format). Shipped via `CSManager.csproj` `<Content Include="AMCSD.cdb3">` and copied to the user app-data folder at startup. |
| Content | ~21,478 crystal structures (per `Version.cs`). |
| Upstream URL | http://rruff.geo.arizona.edu/AMS/amcsd.php |
| Required citation | Downs, R. T. & Hall-Wallace, M. (2003). The American Mineralogist Crystal Structure Database. *American Mineralogist*, **88**, 247-250. |
| Signed by CSManager? | N/A (data file, not code) — ships inside the signed installer. |
| Redistribution status | **Permitted.** Redistribution permission was obtained from one of the AMCSD maintainers. The underlying crystal-structure data are scientific facts published in peer-reviewed journals and are openly distributed by AMCSD/RRUFF (e.g. https://www.rruff.net/). Attribution is provided via the Downs & Hall-Wallace (2003) citation. The `.cdb3` carries no embedded attribution; attribution is satisfied via this file (an in-app citation on the database window would further strengthen it). |

### COD (downloaded on first use)

| Item | Detail |
|------|--------|
| Name | Crystallography Open Database (COD) |
| Bundled or downloaded | **Downloaded on first use**, NOT bundled (~533,220 structures). Same `.cdb3` format as AMCSD, re-packaged by the author. |
| Download source | **This repository's own mirror**: `https://github.com/seto77/CSManager/raw/master/COD/` (CSManager is the COD mirror that its sibling apps also use). |
| Upstream URL | https://www.crystallography.net/cod/ |
| License | COD data are released to the **public domain** / open terms; redistribution is **permitted**. This repository (`seto77/CSManager`) hosts the COD mirror that CSManager and its sibling apps (ReciPro, PDIndexer) download from. |
| Required citation | Gražulis et al. (2009) *J. Appl. Cryst.* **42**, 726-729 (https://doi.org/10.1107/S0021889809016690); Gražulis et al. (2012) *Nucleic Acids Research* **40**, D420-D427 (https://doi.org/10.1093/nar/gkr900). COD lists further papers (e.g. Vaitkus et al. 2021) on its citation page. |
| Signed by CSManager? | N/A (downloaded data, not part of the signed installer). |
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

## Code-signing note

The intended code-signing scope is limited to CSManager release artifacts and binaries **built from this repository**: `CSManager.exe`, `apphost.exe`, and the in-house managed assemblies `Crystallography.dll` / `Crystallography.Controls.dll` (and their satellite resource DLLs). CSManager bundles no native libraries.

Third-party managed binaries (the NuGet runtime DLLs listed above and the bundled .NET runtime files in the portable ZIP) keep their own upstream provenance and licenses and must **not** be re-signed or relicensed as CSManager's MIT code. See `CODE_SIGNING.md` for the release-artifact signing policy. This notice is not a substitute for the upstream license texts.
