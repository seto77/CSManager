# 他ソフトとの連携

CSManager は、PDIndexer や ReciPro といった関連ソフトと結晶データをやり取りできます。

## 選択時の自動転送

[結晶リスト](2-database-table.md) で結晶を選択したとき、PDIndexer や ReciPro が起動していれば、その結晶の情報がクリップボード経由で自動的に転送されます。CSManager で結晶を選ぶだけで、対象ソフトに同じ結晶を読み込めます。

[結晶情報](4-crystal-information/index.md) を右クリックして `Send this crystal to other software` を選んでも、現在の結晶を送れます。

## 結晶リストのインポート

`ファイル` メニューの `インポート (PDIndexer, ReciProの結晶リスト) (*.xml)` から、PDIndexer や ReciPro の結晶リスト (`*.xml`) を読み込めます（[インポートとエクスポート](5-import-export.md) を参照）。
