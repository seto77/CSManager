using System;
using System.Collections.Generic;
using System.Text;

namespace CSManager
{
    static class Version
    {
        static public string Software =
           "CSManager"
           ;
        static public string VersionAndDate { get => History.Remove(0, 10).Remove(20); }

        static public int AMCSD = 21_026;
        static public int COD = 514_854;

        static public string History = 
            "History" +
                "\r\n ver1.896(2024/06/30) Renewed AMCSD database (contains 21,026) and COD database (514,854)." +
                "\r\n ver1.896(2024/01/04) Updated .Net Desktop Runtime to 8.0. Fixed a broken link to manual pages." +
                "\r\n ver1.895(2023/09/29) Renewed AMCSD database (contains 21,004) and COD database (506,047)." +
                "\r\n ver1.894(2022/11/16) Updated .Net Desktop Runtime to 7.0. Renewed COD database (494,508). Changed algorithm when saving and loading." +
                "\r\n ver1.893(2022/10/27) Improved search function." +
                "\r\n ver1.892(2022/10/26) Fixed minor bugs." +
                "\r\n ver1.891(2022/09/09) Renewed AMCSD database (contains 20,997) and COD database (490,180)." +
                "\r\n ver1.890(2021/11/12) Target framework is changed to .Net Desktop Runtime 6.0." +
                "\r\n ver1.888(2021/07/16) Renewed AMCSD database (contains 20,819)" +
                "\r\n ver1.887(2021/07/12) Changed the target framework to .Net 5.0. Improved loading speed of database. Renewed COD database (463,756)" +
                "\r\n ver1.886(2021/03/23) Renewed AMCSD database (contains 20,797). Fixed minor bugs." +
                "\r\n ver1.885(2020/12/10) Fixed an initializing bug." +
                "\r\n ver1.885(2020/12/10) Fixed an initializing bug." +
                "\r\n ver1.884(2020/11/18) Renewed COD database (463,756)." +
                "\r\n ver1.883(2020/07/28) Fixed minor GUI bugs." +
                "\r\n ver1.882(2020/07/14) Renewed AMCSD database (20,718)." +
                "\r\n ver1.881(2020/07/10) Renewed COD database (458,512)." +
                "\r\n ver1.880(2020/06/06) Renewed COD database (457,000)." +
                "\r\n ver1.879(2020/05/15) Minor bugs fixed." +
                "\r\n ver1.878(2020/05/14) Renewed AMCSD database (contains 20,698) and COD database (456,027)." +
                "\r\n ver1.877(2020/04/02) Fixed a minor bug." +
                "\r\n ver1.876(2020/03/22) Fixed a minor bug." +
                "\r\n ver1.875(2020/03/19) Fixed a minor bug." +
                "\r\n ver1.874(2020/03/18) Fixed a minor bug." +
                "\r\n ver1.873(2020/03/17) Changed: File format of database is changed (cdb2 => cdb3)." +
                "\r\n ver1.871(2020/03/14) Improved: Loading speed of database becomes faster." +
                "\r\n ver1.87 (2020/03/14) Renewed COD database (452,532)." +
                "\r\n ver1.861(2020/03/03) Fixed a minor bug on distribution problem." +
                "\r\n ver1.86 (2020/03/01) Changed: Download site is changed to GitHub." +
                "\r\n ver1.85 (2019/09/10) Renewed COD database (406,999). Changed .Net framework version to 4.8." +
                "\r\n ver1.841(2019/06/26) Renewed AMCSD database (contains 20,698 crystals) and COD database (404,015)." +
                "\r\n ver1.84 (2019/04/10) Changed the installer. ClickOnce version will be not maintained in the future." +
                "\r\n ver1.833(2019/02/20) Changed .Net framework version to 4.7.2." +
                "\r\n ver1.832(2018/12/20) Fixed minor bugs." +
                "\r\n ver1.831(2018/12/18) Fixed minor bugs." +
                "\r\n ver1.83 (2018/11/20) Renewed AMCSD database (contains 20,574 crystals) and COD database (396,244). Modified some incosistensies." +
                "\r\n ver1.82 (2018/02/20) Renewed AMCSD database (contains 20,537 crystals) and COD database (386,893)." +
                "\r\n ver1.811(2018/02/19) Minor bug fix." +
                "\r\n ver1.81 (2016/09/18) Renewed AMCSD database (contains 20,468 crystals) and COD database (361,953)." +
                "\r\n ver1.80 (2016/03/03) Renewed AMCSD database (contains 20,372 crystals) and COD database (353,229)." +
                "\r\n ver1.79 (2015/10/11) Renewed AMCSD database (contains 20,151 crystals) and COD database (334,870)." +
                "\r\n ver1.781(2015/07/13) Fixed a bug on loading database." +
                "\r\n ver1.78 (2015/07/13) Added a font size option." +
                "\r\n ver1.77 (2015/07/06) Fixed a bug on Loading COD database." +
                "\r\n ver1.76 (2015/03/19) Renewed AMCSD database (contains 20,143 crystals) and COD database (306,566). Fixed a bug on Debye-Waller factor calulations (thx Dr. Koga)." +
                "\r\n ver1.752(2015/01/15) Fixed a minor bug on loading a COD file." +
                "\r\n ver1.751(2014/11/06) Fixed a minor bug on UI in Japanese." +
                "\r\n ver1.75 (2014/10/30) Renewed AMCSD database (contains 20,121 crystals) and COD database (296,540), and improved UI." +
                "\r\n ver1.742(2014/10/27) Fixed a bug on scattering factor information." +
                "\r\n ver1.741(2014/05/16) Fixed: a bug on transport crystal data through clipboard." +
                "\r\n ver1.74 (2014/02/11) Renewed AMCSD database (contains 19,924 crystals) and COD database (250,274)." +
                "\r\n ver1.732(2013/10/27) Fixed small bugs on appearance" +
                "\r\n ver1.731(2013/08/17) Renewed AMCSD database(contains 38,581 crystals)." +
                "\r\n ver1.73 (2013/08/15) Renewed COD database(contains 234,989 crystals)." +
                "\r\n ver1.721(2013/02/26) Changed adress of help page." +
                "\r\n ver1.72 (2013/02/25) Added: Update check function." +
                "\r\n ver1.71 (2013/02/20) Added: CIF file export function." +
                "\r\n ver1.702(2012/12/19) Fixed a small bug." +
                "\r\n ver1.701(2012/12/05) Fixed a small bug." +
                "\r\n ver1.70 (2012/08/21) Renewed AMCSD database (contains 37,961 crystals) and COD database (204,657). Fixed a small bug." +
                "\r\n ver1.60 (2011/12/28) Database format was modified and got slim size. Renewed AMCSD database (contains 37,898 crystals) and COD database(150,294)." +
                "\r\n ver1.54 (2011/10/21) Added language option (en/ja). " +
                "\r\n ver1.53 (2011/04/09) AMCSDとCODのデータをコンパイルしたものをHPに配布。データベース読み込みさらに高速化。" +
                "\r\n ver1.52 (2011/04/05) データベース読み込みを高速化。データベース形式を変更(cdb->cdb2)しました。前の形式は読み込みのみ可能です。" +
                "\r\n ver1.51 (2011/04/05) 標準データベース更新。データ数: 37658 " +
                "\r\n ver1.51 (2010/05/09) 開発環境をVS2010に変更 && 標準データベース更新。データ数: 34786 " +
                "\r\n ver1.50 (2009/10/15) 標準データベース更新。データ数: 34329 && アプリ間の通信がうまくいかないバグを更新しました。" +
                "\r\n ver1.49 (2009/09/03) 64bit OSに対応しました。 メモリさえ積んであれば快適に動くはずです。" +
                "\r\n ver1.48 (2008/06/20) メールアドレス等を変更しました。" +
                "\r\n ver1.47 (2008/06/19) 標準データベース更新。 データ数: 33073" +
                "\r\n ver1.46 (2008/04/20) 標準データベース更新。 データ数: 32807" +
                "\r\n ver1.45 (2008/02/24) 標準データベース更新。 データ数: 32661" +
                "\r\n ver1.44 (2008/02/11) 他ソフトとの連携を強化" +
                "\r\n ver1.43 (2008/01/27) 標準データベース更新。このバージョンからデータベースをまとめて一つにしました。" +
                "\r\n ver1.42 (2008/01/26) 起動時にヒントを表示できるようにしました。" +
                "\r\n ver1.41 (2008/01/21) 発行元を変更" +
                "\r\n ver1.40 (2008/01/07) 内部形式変更 + 標準データベースを更新" +
                "\r\n ver1.39 (2007/11/12) 標準データベースを更新。" +
                "\r\n ver1.38 (2007/10/27) 共通フォーム&コントロールの部分を分離しDLL化した" +
                "\r\n ver1.37 (2007/10/10) 標準データベースを更新。" +
                "\r\n ver1.36 (2007/09/03) 標準データベースを修正。重複を消したので見かけ上、数が減っています。" +
                "\r\n ver1.35 (2007/08/16) 標準データベースを修正。" +
                "\r\n ver1.34 (2007/07/31) 標準データベースを修正。" +
                "\r\n ver1.34 (2007/07/14) d値で検索できるようにしました。これに伴いデータベースが若干大きくなりました。" +
                "\r\n ver1.33 (2007/07/05) 結晶軸の計算のところでバグを修正" +
                "\r\n ver1.32 (2007/06/27) ドラッグドロップ関連を修正" +
                "\r\n ver1.31 (2007/06/21) ホームページアドレス変更" +
                "\r\n ver1.30 (2007/06/19) CIF, AMCファイルをインポートできるようにしました。PDIndexerの結晶データも読み込み可能に。" +
                "\r\n ver1.29 (2007/06/18) デフォルトの構造データベースをソフトと同梱しました。起動時に自動読み込み機能を追加" +
                "\r\n ver1.28 (2007/06/18) 構造描画機能は別ソフト「ReciPro」に移行しました。" +
                "\r\n ver1.27 (2007/05/14) 画像が保存できなかったバグを修正 + メモリ使用量が増大するバグ修正" +
                "\r\n ver1.26 (2007/04/23) 検索機能を強化 周期表をつけました。 & バグ修正" +
                "\r\n ver1.25 (2007/04/11) 検索機能を完全実装 & バグ修正" +
                "\r\n ver1.24 (2007/02/20) 原子位置の計算のところを若干修正" +
                "\r\n ver1.23 (2007/02/20) データベースファイルの読み込みを若干高速化" +
                "\r\n ver1.22 (2007/02/16) 対称性･結晶構造の計算を若干高速化" +
                "\r\n ver1.21 (2007/02/15) 原子位置が正常に表示されないバグを修正" +
                "\r\n ver1.20 (2007/02/08) StructureViewerのデザインを変更" +
                "\r\n ver1.19 (2007/02/07) マウスホイールで拡大/縮小 && 回転を若干高速化" +
                "\r\n ver1.18 (2007/02/04) 格子面の表示が可能になりました。" +
                "\r\n ver1.17 (2007/02/03) 選択した複数の原子間の長さ・角度などが表示できるようにしました。" +
                "\r\n ver1.16 (2007/02/02) 原子の選択が可能になりました。" +
                "\r\n ver1.15 (2007/01/29) カメラ回転を廃止 && 軸･面での回転機能をつけました。" +
                "\r\n ver1.14 (2007/01/28) 透明なオブジェクトを正しく描画できるようにしました。(完全ではないんですが..まいいか)" +
                "\r\n ver1.13 (2007/01/26) UnitCellの表示を出来るようにしました。" +
                "\r\n ver1.12 (2007/01/24) Polyhedraの表示を正しくおこなえるようにしました。" +
                "\r\n ver1.11 (2007/01/24) Bonds, Polyhedraをとりあえず描画できるようにしました。細かい設定はまだです。" +
                "\r\n ver1.10 (2007/01/21) 結晶構造の描画機能をつけました。まだまだ発展途上です。" +
                "\r\n ver1.00 (2007/01/19) PDIndexerから分離"
                ;

        

        /// <summary>
        /// はじめに
        /// </summary>
        static public string Introduction = 
            "はじめに:\r\n"
            + "　このソフトは結晶構造のデータベースを取り扱うソフトです。主な特徴は"
            + "\r\n ・3万件以上の構造データを同梱"
            + "\r\n ・CIF、AMCデータをインポート可能"
            + "\r\n ・組成、文献、対称性などから検索"
            + "\r\n ・拙作ソフト｢PDIndexer｣、｢ReciPro｣と連携"
            + "\r\nなどです。"
            ;

        /// <summary>
        /// 謝辞
        /// </summary>
        static public string Acknowledge = 
            "謝辞:\r\n"
            + "　本ソフトのエラーの報告、改良の助言にあたっては東京大学物性研究所の浜根様を中心に"
            + "多くの方の協力を頂いております。この場を借りて御礼申し上げます。"
            ;

        /// <summary>
        /// 使い方
        /// </summary>
        static public string Manual = 
            "使い方:\r\n"
            + "　このソフトは「CSManager.exe」を実行することで起動します。"
            + "より詳しい使い方は下記ホームページをご覧ください。"
            ;

        /// <summary>
        /// 著作権
        /// </summary>
        static public string CopyRight = "著作権:\r\n "
            + "　本プログラムの著作権は、作者である瀬戸雄介、"
            + "およびその所属機関である神戸大学理学研究科が保有しています。"
            ;

        /// <summary>
        /// 使用条件
        /// </summary>
        static public string Condition =
            "使用条件:\r\n " +
            "本プログラムは学術目的で作成されたフリーソフトウェアです。" +
            "\r\n  ・商用/非商用を問わず、誰でもご自由にお使いいただけます。" +
            "\r\n  ・ただし、軍事目的あるいは違法な目的での使用は固く禁じます。" +
            "\r\n  ・如何なる商用目的の販売、あるいは有償のサポートを行いません。"
             ;

        /// <summary>
        /// 免責事項
        /// </summary>
        static public string Exemption =
            "免責:"
            + "\r\n　作者は本プログラムの"
            + "\r\n　 ・動作保証を致しません。"
            + "\r\n　 ・使用によって直接的あるいは間接的に生じた障害、損害についての責任を負いません。"
            + "\r\n　 ・修正、及びバージョンアップの義務を負いません。"
            ;

        /// <summary>
        /// 連絡先
        /// </summary>
        static public string Adress =
            "連絡先:\r\n"
            + "　プログラムの不具合、改善要望などがありましたらメールにてご連絡ください。"
            + "また詳しい使い方についてはホームページでも解説しています。"
            + "\r\n mail: seto@crystal.kobe-u.ac.jp"
            + "\r\n Home Page: http://pmsl.planet.sci.kobe-u.ac.jp/~seto/"
            + "\r\nできるだけご要望にお応えしたいと思います。"
            ;

        static public string[] Hint = new string[]{
            "特定の元素で検索するときはPeriodicTableを開き、赤字ボタン'must exclude'を選択して元素すべてを一旦排除したのち、含まれている元素を選ぶと便利です。",
            "拙作ソフトReciPro, PDIndexer, IPAnalyzerのいずれかが同時に起動しているとき、結晶を選択するとクリップボードで各ソフトに結晶情報が送信されます。",
            "'File'メニューから'Read Default Database' をクリックすることで、酸化物を中心とした数万種の結晶構造を読み込むことができます。"

        };
    }
}
