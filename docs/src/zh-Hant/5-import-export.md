# 匯入與匯出

CSManager 可從 CIF、AMC、PDIndexer / ReciPro 的晶體清單匯入晶體，並可將所選晶體輸出為 CIF。

## 匯入

- `檔案` 選單的 `匯入 CIF、AMC …` — 讀入 CIF 檔案或 AMC 檔案，並追加到目前資料庫的末尾。
- `檔案` 選單的 `匯入 PDI 晶體資料 (*.xml)` — 讀入 PDIndexer 或 ReciPro 的晶體清單 (`*.xml`)，並追加到目前資料庫的末尾。
- 將 CIF / AMC 檔案拖放到 [晶體資訊](4-crystal-information/index.md) 區域，也可讀入晶體。此外，在晶體資訊上按右鍵並選擇 `從 CIF 或 AMC 匯入...` 同樣可以匯入。

CIF 是國際結晶學聯合會 (IUCr) 的標準格式，AMC 是美國礦物學會採用的格式。

## 匯出

- 在 [晶體資訊](4-crystal-information/index.md) 上按右鍵並選擇 `匯出為 CIF`，即可將目前的晶體以 CIF 格式輸出。
- 若要儲存整個資料庫，請使用 `檔案` 選單的 `儲存資料庫`（請參閱 [資料庫讀取](1-database-loading.md)）。
