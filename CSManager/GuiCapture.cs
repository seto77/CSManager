using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CSManager;

// 260704Cl 追加: マニュアル用スクリーンショットの非対話生成 (兄弟アプリの --capture と同方式)。
//   使い方: CSManager.exe --capture <出力フォルダ> <カルチャ名 (en/ja/de/...)>
//   FormMain を指定カルチャで起動し、AMCSD データベースの読み込み完了 (または 90 秒) を待って
//   FormMain.png を保存して終了する。ユーザー設定 (レジストリ) は汚染しない (SuppressRegistrySave)。
//   キャプチャ中は無操作必須。
internal static class GuiCapture
{
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool PrintWindow(IntPtr hWnd, IntPtr hdc, uint nFlags);

    /// <summary>Program.Main の --capture 分岐から呼ぶ。戻り値は exit code。</summary>
    public static int Run(string[] args)
    {
        var outDir = args.Length >= 2 ? args[1] : "capture";
        var culture = args.Length >= 3 ? args[2] : "en";
        Directory.CreateDirectory(outDir);

        var ci = new CultureInfo(Crystallography.SupportedCultures.Resolve(culture).Name);
        Thread.CurrentThread.CurrentUICulture = ci;
        CultureInfo.DefaultThreadCurrentUICulture = ci;

        Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.SetDefaultFont(Crystallography.Controls.FontHelper.GetUIFont());

        int exitCode = 0;
        var f = new FormMain { SuppressRegistrySave = true };
        f.Shown += (s, e) =>
        {
            f.LoadDefaultDatabaseForCapture();
            var deadline = DateTime.Now.AddSeconds(90);
            int lastRows = -1;
            var timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timer.Tick += (s2, e2) =>
            {
                // 読み込み完了判定: Enabled かつ 行数 > 0 かつ 直前 tick から行数が増えていない (非同期読み込みの安定待ち)
                var rows = f.DatabaseRowCountForCapture;
                var ready = f.DatabaseEnabledForCapture && rows > 0 && rows == lastRows;
                lastRows = rows;
                if (!ready && DateTime.Now < deadline)
                    return; // まだ読み込み中
                timer.Stop();
                try
                {
                    Application.DoEvents(); // 最終レイアウトを反映させてから撮る
                    // FormMain は MDI コンテナのため DrawToBitmap では MdiClient がクライアント領域を塗り潰してしまう。
                    // PrintWindow (PW_RENDERFULLCONTENT=2) でウィンドウ自身に描画させる。
                    using var bmp = new Bitmap(f.Width, f.Height);
                    using (var g = Graphics.FromImage(bmp))
                    {
                        var hdc = g.GetHdc();
                        PrintWindow(f.Handle, hdc, 2);
                        g.ReleaseHdc(hdc);
                    }
                    bmp.Save(Path.Combine(outDir, "FormMain.png"), ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"capture failed: {ex}");
                    exitCode = 1;
                }
                finally
                {
                    f.Close();
                }
            };
            timer.Start();
        };
        Application.Run(f);
        return exitCode;
    }
}
