using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSManager
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        // private static void Main() // 260625Cl 旧シグネチャ (--smoke 引数対応のため string[] args を追加)
        [STAThread]
        static void Main(string[] args)
        {
            // 260625Cl 追加: 軽量 smoke テスト (WiX移行 Phase C / D-CS-6)。arm64 の「ビルド緑・実行時死亡」型故障を CI で検出する。
            //   CSManager は native (xraylib/Crystallography.Native) を UI から使わない (D-CS-2) ため arch 記録のみ。引数なし通常起動には一切影響しない。
            if (args.Length >= 1 && args[0] == "--smoke")
            {
                System.IO.File.WriteAllLines(args.Length >= 2 ? args[1] : "smoke-result.txt",
                [
                    $"arch={System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture}",
                    $"baseDir={AppContext.BaseDirectory}",
                ]);
                Environment.Exit(0);
            }

            // 260704Cl 追加: マニュアル用スクリーンショットの非対話生成 (--capture <出力先> <カルチャ>)。GuiCapture.cs 参照。
            if (args.Length >= 1 && args[0] == "--capture")
            {
                Environment.Exit(GuiCapture.Run(args));
                return;
            }

            // 260625Cl 追加: 多言語化。言語別 UI フォント (FontHelper.GetUIFont) と各フォームの resx ローカライズが
            //   CurrentUICulture を参照するため、フォーム生成 (SetDefaultFont/Application.Run) より前に、
            //   レジストリ保存値からカルチャを確定させる。未知カルチャは SupportedCultures.Resolve が既定 (英語) へ解決。
            //   旧: カルチャ復元は FormMain コンストラクタ内 (InitializeComponent 前) で en/ja 二値に丸めていた。
            try
            {
                using var regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\CSManager");
                var culture = (string)regKey?.GetValue("Culture", System.Threading.Thread.CurrentThread.CurrentUICulture.Name);
                var ci = new System.Globalization.CultureInfo(Crystallography.SupportedCultures.Resolve(culture).Name);
                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
                System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = ci;
            }
            catch { }

            Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetDefaultFont(Crystallography.Controls.FontHelper.GetUIFont());// 260625Cl 追加: 言語別 UI フォント (Designer 未指定コントロールの既定)
            Application.Run(new FormMain());
        }
    }
}
