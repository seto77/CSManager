# Code signing policy

This document describes the code-signing policy for CSManager release artifacts.

## Current status

CSManager is preparing code signing for its Windows release artifacts.

Unless a GitHub Release explicitly states that an installer is digitally signed, users should not assume that it is signed. This applies to `CSManager-setup.msi`, `CSManager-setup_arm64.msi`, the legacy-named copy `CSManagerSetup.msi`, and the portable ZIP packages.

## Official downloads

Official release artifacts are published only from the CSManager GitHub Releases page:

- https://github.com/seto77/CSManager/releases/latest

Users should avoid downloading CSManager installers from unofficial mirrors or third-party redistribution sites.

## Intended signing model

The intended signing route for the Windows packages is the **SignPath Foundation** open-source code-signing program (SignPath.io). CSManager is currently adopting this program (application planned).

Once signing is enabled, CSManager will carry the following attribution:

> Free code signing provided by [SignPath.io](https://about.signpath.io), certificate by [SignPath Foundation](https://signpath.org).

Release artifacts will be signed using Windows Authenticode signing and then published from GitHub Releases. For SignPath Foundation signing, the signer shown by Windows may be `SignPath Foundation` rather than the personal name of the CSManager maintainer.

## Scope of signing

The intended signing scope is:

- `CSManager-setup.msi` and `CSManager-setup_arm64.msi` (including the legacy-named copy `CSManagerSetup.msi`, which is the byte-identical x64 installer kept for auto-update compatibility with older versions);
- `CSManager.exe` (and `apphost.exe`) built from this repository, including the `CSManager.exe` inside the portable ZIP packages (the portable packages are flat, non-single-file self-contained publishes, so the executable and the in-house libraries are separate files);
- the in-house libraries built from this repository (`Crystallography.dll`, `Crystallography.Controls.dll`, and their satellite resource DLLs).

CSManager does not bundle any native libraries (no `Crystallography.Native.dll`, no `libxrl-11.dll`; `glfw3.dll` is excluded because CSManager has no OpenGL 3D views). Third-party managed binaries (NuGet runtime DLLs and the .NET runtime) must not be re-signed as if they were maintained by CSManager. See `THIRD-PARTY-NOTICES.md` for bundled or referenced third-party components and data.

## Lightweight repository protection policy

CSManager is primarily a personal research-software project. The repository policy is intentionally lightweight: routine development should remain possible without mandatory pull requests, external approvals, required signed commits, or required status checks.

For release integrity, the intended minimum protection is limited to release-critical history:

- the default branch, `master`, should not be force-pushed or deleted;
- release tags matching `v*` should not be deleted or moved after creation;
- release builds should be produced from the public GitHub repository and published as GitHub Releases.

The release workflow's `force`-rebuild mode (which deleted and recreated an existing tag) has been removed so that this protection is never violated: to re-issue a release, bump the version in `CSManager/Version.cs` and publish a new tag.

## Maintainer and signing roles

CSManager is maintained by a single maintainer, Yusuke Seto, who is the sole committer and owner of the source repository. For code signing, the same person holds all roles:

- **Author** — Yusuke Seto: develops and maintains the source code.
- **Approver** — Yusuke Seto: reviews and approves each signing request before a release is signed.

## Privacy

CSManager is a local desktop application. It does not collect or transmit personal or usage data; the only network access is an optional update check against the public GitHub repository and the optional on-demand download of the COD database.

## Verifying an installer

### Digital-signature check after signing is enabled

After code signing is enabled for a release, users can inspect the installer from Windows Explorer:

1. Right-click `CSManager-setup.msi`.
2. Open **Properties**.
3. Open the **Digital Signatures** tab.
4. Confirm that the signature is valid and that the signer matches the signer documented for that release.

Advanced users can also verify the installer with the Windows SDK `signtool` utility:

```powershell
signtool verify /pa /all CSManager-setup.msi
```

## Reporting suspicious artifacts

If you find a suspicious CSManager installer or a download link that does not match the official GitHub Releases page, please report it through the GitHub issue tracker or contact the maintainer through the project website.
