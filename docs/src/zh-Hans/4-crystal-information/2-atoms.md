# 原子

在 `原子信息` 标签页中，显示和设置晶体中包含的原子信息。上部列表会显示原子一览，点击各个原子后，下部会显示其详细信息。

!!! warning
    编辑原子后，请按 `Add` 或 `Replace` 按钮。若未按下，原子信息将不会保存到列表中。

## 原子列表的操作

- `Add` — 将设置好的原子新增到列表中。
- `Replace` — 用设置好的原子替换当前选中的原子。
- `Up` / `Down` — 将选中的原子在顺序中上移或下移。
- `Delete` — 从列表中删除选中的原子。

## 元素与位置

- `Label` — 输入原子的标签。
- `Element` — 设置元素。
- `X`, `Y`, `Z` — 设置原子的分数坐标。输入 0 到 1 之间的实数。也可输入 1/2 或 2/3 这样的分数。
- `Occ` — 以 0 到 1 之间的实数指定占有率。

在 **Origin shift** 中，可通过预设按钮或任意数值平移原点位置。

## 温度因子（Debye-Waller factor）

- **Notation** — 选择 `U` 或 `B`。
- **Model** — 选择各向同性 (Isotropy) 或各向异性 (Anisotropy)。
- 输入温度因子的各个分量（`B##` 或 `U##`）。

## 散射因子（Scattering factor）

设置计算原子散射因子时所用的价态和同位素组成。

- **X-ray** — 选择计算 X 射线弹性原子散射因子时所用的价态。参数基于 *International Tables for Crystallography volume C*。
- **Electron** — 选择电子束弹性原子散射因子的价态。参数基于 Peng (1998, *Acta Cryst.* A54, 481-485)。
- **Neutron** — 选择计算中子弹性散射长度的同位素组成。可选择 `Natural isotope abundance`（天然丰度）或 `Custom isotope abundance`（自定义设置）。
