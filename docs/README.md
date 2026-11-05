# docs/

| Path | Content |
|---|---|
| `mkdocs.yml`, `src/` | Published user manual (MkDocs Material, 11 languages): https://seto77.github.io/CSManager/ |
| `drafts/261105/` | Code-derived drafts (2026-11-05), **not published, not yet reviewed by the author**. See below |

## drafts/261105/ — コードから起こした下書き / Code-derived drafts

本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。
Draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

`docs/src/` の外に置いたのは、マージしても MkDocs（`docs_dir: src`）で公開されないようにするため。査読後に `docs/src/{ja,en}/` の各ページへ統合し、ほかの 9 言語へ展開する想定。
They are kept outside `docs/src/` so that merging does not publish them (`docs_dir: src`). After review they are meant to be merged into the `docs/src/{ja,en}/` pages and then propagated to the other nine languages.

対象 / Target: CSManager master `e081e9d`, submodules Crystallography `6eeb86a` / Crystallography.Controls `6582a2f` (pinned). Rebased onto master `3d1cd39` (PR #3: warning fixes and removal of an unused class only, no behavioural change). `[main]` notes describe the libraries' origin/main (Crystallography `9ffcf47`, Controls `aadeb74`).

| # | 日本語 | English | 内容 / Content |
|---|---|---|---|
| 00 | [00-audit](drafts/261105/ja/00-audit.md) | [00-audit](drafts/261105/en/00-audit.md) | 既存マニュアルとコードの食い違い（A1–A36）、未記載機能（B1–B22）、履歴・README との差 / Existing manual vs code |
| 01 | [01-forms](drafts/261105/ja/01-forms.md) | [01-forms](drafts/261105/en/01-forms.md) | 画面（フォーム）一覧 / List of windows |
| 02 | [02-database](drafts/261105/ja/02-database.md) | [02-database](drafts/261105/en/02-database.md) | DB の読込・保存、COD ダウンロード、cdb3 形式 / Reading and saving databases |
| 03 | [03-table-search](drafts/261105/ja/03-table-search.md) | [03-table-search](drafts/261105/en/03-table-search.md) | 結晶リストと検索条件の意味 / Table and search semantics |
| 04 | [04-crystal-information](drafts/261105/ja/04-crystal-information.md) | [04-crystal-information](drafts/261105/en/04-crystal-information.md) | 結晶情報の全タブ（EOS・弾性を含む）/ Crystal information incl. EOS and elasticity |
| 05 | [05-file-formats](drafts/261105/ja/05-file-formats.md) | [05-file-formats](drafts/261105/en/05-file-formats.md) | 対応形式一覧、CIF の読むタグ・無視するタグ、空間群の決め方、CIF 書き出し / Formats, CIF tags read/ignored |
| 06 | [06-menus-options](drafts/261105/ja/06-menus-options.md) | [06-menus-options](drafts/261105/en/06-menus-options.md) | メニュー・オプション・ヘルプ・言語・レジストリ・コマンドライン / Menus, options, registry, CLI |
| 07 | [07-interoperation](drafts/261105/ja/07-interoperation.md) | [07-interoperation](drafts/261105/en/07-interoperation.md) | クリップボード・XML / Clipboard and XML |
| 90 | [90-implementation-questions](drafts/261105/ja/90-implementation-questions.md) | [90-implementation-questions](drafts/261105/en/90-implementation-questions.md) | 実装上の疑問点（Q1–Q45、コード未変更）/ Suspected bugs (no code changed) |

約束事 / Conventions:
- 根拠はファイル名・メソッド名で示す。行番号は固定コミットのもの。/ Evidence is given as file and method names; line numbers refer to the pinned commits.
- UI の文字列は Designer.cs / .resx の実際の文字列（日本語版は `*.ja.resx`）。/ UI strings are taken from Designer.cs / .resx.
- スクリーンショットは `<!-- screenshot: … -->` のプレースホルダ。`CSManager.exe --capture <dir> <culture>` で生成できる。/ Screenshots are placeholders; `--capture` can generate them.
- 確信の持てない点は各文書末尾の「要確認事項」（計 33 件）。/ Uncertain points are listed at the end of each document (33 in total).
