# 原子

在 `原子資訊` 分頁中，可顯示與設定晶體所含原子的資訊。上方的清單會顯示原子的一覽，點選各原子後詳細資訊會顯示於下方。

!!! warning
    編輯原子後，請按下 `Add` 或 `Replace` 按鈕。若未按下，原子資訊不會儲存至清單。

## 原子清單的操作

- `Add` — 將設定的原子新增至清單。
- `Replace` — 將設定的原子與目前所選的原子互換。
- `Up` / `Down` — 將所選原子的順序上下移動。
- `Delete` — 將所選原子從清單刪除。

## 元素與位置

- `Label` — 輸入原子的標籤。
- `Element` — 設定元素。
- `X`, `Y`, `Z` — 設定原子的分數座標。輸入 0 到 1 之間的實數。也可輸入如 1/2 或 2/3 的分數。
- `Occ` — 以 0 到 1 之間的實數指定佔有率。

在 **Origin shift** 中，可用預設按鈕或任意值平移原點位置。

## 溫度因子（Debye-Waller factor）

- **Notation** — 選擇 `U` 或 `B`。
- **Model** — 選擇等向性 (Isotropy) 或非等向性 (Anisotropy)。
- 輸入溫度因子的各分量（`B##` 或 `U##`）。

## 散射因子（Scattering factor）

設定計算原子散射因子時的價數與同位素組成。

- **X-ray** — 選擇計算 X 光彈性原子散射因子時所用的價數。參數依據 *International Tables for Crystallography volume C*。
- **Electron** — 選擇電子束彈性原子散射因子的價數。參數依據 Peng (1998, *Acta Cryst.* A54, 481-485)。
- **Neutron** — 選擇計算中子彈性散射長度的同位素組成。可選擇 `Natural isotope abundance`（天然存在比）或 `Custom isotope abundance`（自訂設定）。
