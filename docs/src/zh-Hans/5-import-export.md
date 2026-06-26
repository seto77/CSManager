# 导入与导出

CSManager 可从 CIF、AMC 以及 PDIndexer / ReciPro 的晶体列表导入晶体，并可将选中的晶体导出为 CIF。

## 导入

- `文件` 菜单的 `导入 CIF、AMC …` — 读取 CIF 文件或 AMC 文件，并追加到当前数据库的末尾。
- `文件` 菜单的 `导入 PDI 晶体数据 (*.xml)` — 读取 PDIndexer 或 ReciPro 的晶体列表 (`*.xml`)，并追加到当前数据库的末尾。
- 将 CIF / AMC 文件拖放到 [晶体信息](4-crystal-information/index.md) 区域也可读入晶体。此外，右键点击晶体信息并选择 `从 CIF 或 AMC 导入...` 也可导入。

CIF 是国际晶体学联合会 (IUCr) 的标准格式，AMC 是美国矿物学会采用的格式。

## 导出

- 右键点击 [晶体信息](4-crystal-information/index.md) 并选择 `导出为 CIF`，即可将当前晶体以 CIF 格式导出。
- 若要保存整个数据库，请使用 `文件` 菜单的 `保存数据库`（参见 [数据库读取](1-database-loading.md)）。
