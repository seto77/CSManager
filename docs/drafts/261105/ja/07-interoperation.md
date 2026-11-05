# 他ソフトとの連携

本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

対象: CSManager master `e081e9d`（サブモジュール Crystallography `6eeb86a` / Crystallography.Controls `6582a2f`）。

## 選択時のクリップボード送信

結晶リストで行を選ぶたびに（`crystalDatabaseControl_CrystalChanged`）、CSManager は次の処理をする。

1. 結晶情報にその結晶を表示する。
2. `Clipboard.SetDataObject(MemoryPackEx.Serialize(Crystal2.ID, crystal2))` でクリップボードを**上書き**する。

- 中身は `byte[]`。先頭 1 バイトが型 ID（`Crystal2.ID = 0`）、続きが Brotli で圧縮した MemoryPack の `Crystal2`（`Crystallography/ExtensionMethods.cs`）。運ばれる情報は [ファイル形式](05-file-formats.md#crystal2-レコード) の `Crystal2` と同じ（結合・EOS・弾性・同位体は含まない）。
- 相手のソフトが起動しているかどうかは確かめない。**選択のたびに必ずクリップボードが置き換わる**ので、CSManager で行を選ぶと、それまでコピーしていた内容は消える。
- `SetDataObject` の `copy` 引数は既定の false なので、CSManager を終了するとこのデータはクリップボードから消える。
- 受け手は ReciPro・PDIndexer（起動時のヒントには IPAnalyzer も挙がっている、`Version.Hint`）。受け手がどの時点でクリップボードを読むかは、各ソフトの実装による（要確認事項 1）。

既存マニュアルにある右クリックの `Send this crystal to other software` は、現行では非表示（`Visible = False`）。

## 結晶リストの取り込み

`ファイル` ▸ `インポート (PDIndexer, ReciProの結晶リスト) (*.xml)` で、PDIndexer / ReciPro が書き出した `Crystal[]` の XML を読み、全結晶を DB に追加する（`FormMain.readXml`）。メインウィンドウへの `.xml` ファイルのドロップでも同じ処理をする。

- 取り込んだ結晶は `Crystal2.FromCrystal` を通るので、XML にある結合・EOS・弾性・歪み・同位体などは DB に残らない。d リストも作られない（d 値検索の対象外）。
- メニューからの読み込みには例外処理が無いため、壊れた XML を選ぶとアプリが終了する（[実装上の疑問点](90-implementation-questions.md) Q16）。

## CIF での受け渡し

結晶情報を右クリック ▸ `CIFファイルとして出力` で CIF を書き出せる。出力の内容と、読み直したときに失われる情報は [ファイル形式](05-file-formats.md#cif-の書き出し) を参照。

## 要確認事項

1. ReciPro・PDIndexer・IPAnalyzer の受け手側が、CSManager の `Crystal2` 形式（ID 0 + MemoryPack）を現在も読むか、どの時点で読むか（クリップボード監視か、フォーカス取得時か）。
2. 選択のたびにクリップボードを上書きする挙動を、マニュアルで注意として目立たせるか、オプション化するか。
