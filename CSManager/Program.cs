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
        [STAThread]
        static void Main()
        {
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
