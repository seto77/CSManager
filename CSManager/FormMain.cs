#region using
using Crystallography;
using Crystallography.Controls;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IronPython.Modules._ast;
#endregion

namespace CSManager;

public partial class FormMain : Form
{
    #region フィールド、プロパティ
    public static string UserAppDataPath => new DirectoryInfo(Application.UserAppDataPath).Parent.FullName + @"\";

    Lock lockObj = new();
    private Stopwatch stopwatch { get; set; } = new Stopwatch();
    bool skipProgressEvent { get; set; } = false;

    private Crystallography.Controls.CommonDialog initialDialog;

    private IProgress<(long, long, long, string)> ip;//IReport
    public static Languages CurrentLanguage => Thread.CurrentThread.CurrentUICulture.Name == "en" ? Languages.English : Languages.Japanese;

    #endregion

    #region 起動、終了

    public FormMain()
    {
        ip = new Progress<(long, long, long, string)>(o => reportProgress(o));//IReport
        var regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\CSManager");
        try
        {
            var culture = (string)regKey.GetValue("Culture", Thread.CurrentThread.CurrentUICulture.Name);
            if (culture.ToLower().StartsWith("ja"))
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ja");
            else
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
        }
        catch { }

        InitializeComponent();

        recalculateDensityFormulaAndDvaluesToolStripMenuItem.Click += RecalculateDensityFormulaAndDvaluesToolStripMenuItem_Click;

        ReadMeGenerator.WriteReadMeFile(
         "CSManager   " + Version.VersionAndDate,
         Version.Introduction,
         Version.Manual,
         Version.CopyRight,
         Version.Condition,
         Version.Exemption,
         Version.Adress,
         Version.Acknowledge,
         Version.History);

        searchCrystalControl.CrystalDatabaseControl = crystalDatabaseControl;
        this.AcceptButton = searchCrystalControl.buttonSearch;

        workerAllImport.ProgressChanged += WorkerAllImport_ProgressChanged;
        workerAllImport.DoWork += WorkerAllImport_DoWork;
        workerAllImport.RunWorkerCompleted += WorkerAllImport_RunWorkerCompleted;
    }


    private void FormMain_Load(object sender, EventArgs e)
    {
        //#if !DEBUG
        //           Ngen.Compile(new string[] { "Crystallography.dll", "Crystallography.Control.dll", "CSManager.exe" });
        //#endif

        //ユーザーパスにxmlファイルをコピー
        var appPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\";
        if (File.Exists(appPath + "AMCSD.cdb3"))
            File.Copy(appPath + "AMCSD.cdb3", UserAppDataPath + "AMCSD.cdb3", true);

        //UserAppDataPathに空フォルダがあったら削除
        foreach (var dir in Directory.GetDirectories(UserAppDataPath))
            if (!Directory.EnumerateFileSystemEntries(dir).Any())
                Directory.Delete(dir);

        initialDialog = new Crystallography.Controls.CommonDialog
        {
            Owner = this,
            DialogMode = Crystallography.Controls.CommonDialog.DialogModeEnum.Initialize,
            Software = Version.Software,
            VersionAndDate = Version.VersionAndDate,
            History = Version.History,
            Hint = Version.Hint,
        };

        englishToolStripMenuItem.Checked = Thread.CurrentThread.CurrentUICulture.Name != "ja";
        japaneseToolStripMenuItem.Checked = !englishToolStripMenuItem.Checked;

        initialDialog.Show();
        Application.DoEvents();
        initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.1);

        initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.4);

        this.Text = "CSManager   " + Version.VersionAndDate;

        initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.7);

        //AMCSDデータベースを読み込む
        if (readDefaultDatabaseOnNextBootToolStripMenuItem.Checked)
            toolStripMenuItemReadDefault1_Click(new object(), new EventArgs());

        initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 1.0);

        if (initialDialog.AutomaticallyClose)
            initialDialog.Visible = false;

        readRegistry();

        toolStripMenuItemReadDefault1.Text = toolStripMenuItemReadDefault1.Text.Replace("###", Version.AMCSD.ToString("N0"));
        toolStripMenuItemReadDefault2.Text = toolStripMenuItemReadDefault2.Text.Replace("###", Version.COD.ToString("N0"));

        if (!File.Exists(UserAppDataPath + "CSManagerSetup.msi"))
            File.Delete(UserAppDataPath + "CSManagerSetup.msi");
        Directory.Delete(Application.UserAppDataPath, true);

        crystalControl.atomControl.AppearanceTabVisible = true;
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        saveRegistry();
        e.Cancel = false;
    }
    private void readRegistry()
    {
        var regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\CSManager");
        if (regKey == null) return;
        if ((int)regKey.GetValue("MainLocationY", this.Location.Y) > 0)
        {
            this.Width = (int)regKey.GetValue("MainWidth", this.Width);
            this.Height = (int)regKey.GetValue("MainHeight", this.Height);
            this.Location = new Point((int)regKey.GetValue("MainLocationX", this.Location.X),
                (int)regKey.GetValue("MainLocationY", this.Location.Y));
        }
        if (initialDialog != null)
        {
            initialDialog.Location = new Point(Location.X + Width / 2 - initialDialog.Width / 2, Location.Y + Height / 2 - initialDialog.Height / 2);
            initialDialog.AutomaticallyClose = (string)regKey.GetValue("initialDialog.AutomaricallyClose", "False") == "True";
        }
        readDefaultDatabaseOnNextBootToolStripMenuItem.Checked = (string)regKey.GetValue("readDefaultDatabaseOnNextBootToolStripMenuItem.Checked", "False") == "True";
        regKey.Close();
    }
    private void saveRegistry()
    {
        var regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\CSManager");
        if (regKey == null) return;

        regKey.SetValue("Culture", Thread.CurrentThread.CurrentUICulture.Name);
        regKey.SetValue("MainWidth", this.Width);
        regKey.SetValue("MainHeight", this.Height);
        regKey.SetValue("MainLocationX", this.Location.X);
        regKey.SetValue("MainLocationY", this.Location.Y);
        regKey.SetValue("readDefaultDatabaseOnNextBootToolStripMenuItem.Checked", readDefaultDatabaseOnNextBootToolStripMenuItem.Checked);
        regKey.SetValue("initialDialog.AutomaricallyClose", initialDialog.AutomaticallyClose);
        regKey.Close();
    }

    #endregion

    #region 進捗状況報告
    private void reportProgress((long current, long total, long elapsedMilliseconds, string message) o)
       => reportProgress(o.current, o.total, o.elapsedMilliseconds, o.message);

    /// <summary>
    /// 進捗状況を更新
    /// </summary>
    /// <param name="current"></param>
    /// <param name="total"></param>
    /// <param name="elapsedMilliseconds">経過時間</param>
    /// <param name="message">メッセージ</param>
    /// <param name="interval">何回に一回更新するか</param>
    /// <param name="sleep"></param>
    /// <param name="showPercentage"></param>
    /// <param name="showEllapsedTime"></param>
    /// <param name="showRemainTime"></param>
    /// <param name="digit"></param>
    private void reportProgress(long current, long total, long elapsedMilliseconds, string message,
        int sleep = 0, bool showPercentage = true, bool showEllapsedTime = true, bool showRemainTime = true, int digit = 1)
    {
        if (skipProgressEvent || current > total)
            return;

        try
        {
            skipProgressEvent = true;
            toolStripProgressBar.Maximum = 100000;
            var ratio = (double)current / total;
            toolStripProgressBar.Value = (int)(ratio * 100000);
            var ellapsedSec = elapsedMilliseconds / 1E3;
            var format = $"f{digit}";

            if (showPercentage) message += $" Completed: {(ratio * 100).ToString(format)} %.";
            if (showEllapsedTime) message += $" Elapsed time: {ellapsedSec.ToString(format)} sec.";
            if (showRemainTime) message += $" Remaining time: {(ellapsedSec / current * (total - current)).ToString(format)} sec.";

            toolStripStatusLabel.Text = message;

            Application.DoEvents();

            if (sleep != 0) Thread.Sleep(sleep);
        }
        catch (Exception e)
        {
#if DEBUG
            MessageBox.Show(e.ToString());
#endif
        }
        finally { skipProgressEvent = false; }
    }

    /// <summary>
    /// crystalDatabaseControlからの進捗イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="progress"></param>
    /// <param name="message"></param>
    private void crystalDatabaseControl_ProgressChanged(object sender, double progress, string message)
    {
        if (skipProgressEvent) return;
        try
        {
            skipProgressEvent = true;
            toolStripProgressBar.Value = (int)(progress * toolStripProgressBar.Maximum);
            toolStripStatusLabel.Text = message;
            Application.DoEvents();
        }
        catch { }
        finally { skipProgressEvent = false; }
    }

    private void SearchCrystalControl_ProgressChanged(object sender, double progress, string message)
    {
        if (skipProgressEvent) return;
        try
        {
            skipProgressEvent = true;
            toolStripProgressBar.Value = (int)(progress * toolStripProgressBar.Maximum);
            toolStripStatusLabel.Text = message;
            Application.DoEvents();
        }
        catch { }
        finally { skipProgressEvent = false; }
    }

    #endregion

    #region データベース読み込み/書き込み関連

    /// <summary>
    /// データベース読み込み
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void readDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Database File[*.cdb;*.cdb2;*.cdb2]|*.cdb;*.cdb2;*.cdb3",
            Multiselect = true
        };
        if (dialog.ShowDialog() == DialogResult.OK)
            for (int i = 0; i < dialog.FileNames.Length; i++)
                crystalDatabaseControl.ReadDatabase(dialog.FileNames[i]);
    }

    /// <summary>
    /// データベース書き込み
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void saveDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var dlg = new SaveFileDialog() { Filter = "Database File[*.cdb3]|*.cdb3" };
        if (dlg.ShowDialog() == DialogResult.OK)
            crystalDatabaseControl.SaveDatabase(dlg.FileName);
    }

    /// <summary>
    /// AMCSDデータベース読み込み
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void toolStripMenuItemReadDefault1_Click(object sender, EventArgs e)
    {
        crystalDatabaseControl.AMCSD_Checked = true;
        //if (File.Exists(UserAppDataPath + "AMCSD.cdb3"))
        //    //readDatabase(UserAppDataPath + "AMCSD.cdb3");
        //    crystalDatabaseControl.ReadDatabase(UserAppDataPath + "AMCSD.cdb3");
    }
    #endregion

    #region CODデータベースのダウンロードや読み込み. 

    /// <summary>
    /// CODデータベースのダウンロードや読み込み. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void toolStripMenuItemReadDefault2_Click(object sender, EventArgs e)
    {
        crystalDatabaseControl.COD_Checked = true;
        //crystalDatabaseControl.ReadCOD();


        //var (Valid, DataNum, FileNum, FileSizes, CheckSums) = crystalDatabaseControl.CheckDatabaseFiles(UserAppDataPath + "COD.cdb3", true);
        //string urlHeader = "https://github.com/seto77/CSManager/raw/master/COD/";
        //if (Valid)
        //{//適切にダウンロードされている場合
        //    try//web上に新しいデータがあるかどうかをチェック
        //    {
        //        if (new WebClient().DownloadData(new Uri(urlHeader + "COD.cdb3")).SequenceEqual(File.ReadAllBytes(UserAppDataPath + "COD.cdb3")))
        //        {//ローカルのCODが最新版の場合
        //            crystalDatabaseControl.ReadDatabase(UserAppDataPath + "COD.cdb3");
        //            return;
        //        }
        //        else
        //        {//更新版が存在する場合
        //            var result = MessageBox.Show("Now, new database is available.\r\n  Download and load the new database: YES\r\n" +
        //                "  Use the current database: No\r\n  Cancel database loading: Cancel", "  New database is available", MessageBoxButtons.YesNoCancel);

        //            if (result == DialogResult.No) //Noの場合 (更新せずに現状を読み込む場合)
        //                crystalDatabaseControl.ReadDatabase(UserAppDataPath + "COD.cdb3");

        //            if (result == DialogResult.No || result == DialogResult.Cancel)//NoかCancelの場合
        //                return;
        //        }

        //    }
        //    catch //WEBが落ちている場合は、現状のCODを読み込む 
        //    {
        //        crystalDatabaseControl.ReadDatabase(UserAppDataPath + "COD.cdb3");
        //        return;
        //    }
        //}
        //else//CODデータが存在しないか、適切でない場合
        //{
        //    if (MessageBox.Show("Local COD database is missing.\r\n  Do you download the new database now ?", "Local COD database is missing.",
        //        MessageBoxButtons.YesNo) == DialogResult.No)
        //        return;
        //}

        ////ここからCODをダウンロード
        //try
        //{
        //    stopwatch.Restart();
        //    new WebClient().DownloadFile(new Uri(urlHeader + "COD.cdb3"), UserAppDataPath + "COD.cdb3");

        //    Directory.CreateDirectory(UserAppDataPath + "COD");

        //    (_, DataNum, FileNum, FileSizes, CheckSums) = crystalDatabaseControl.CheckDatabaseFiles(UserAppDataPath + "COD.cdb3", false);

        //    var wc = new MyWebClient[FileNum];
        //    var total = FileSizes.Sum();
        //    var current = new long[FileNum];
        //    var completedCount = 0;
        //    long n = 1;
        //    for (int i = 0; i < wc.Length; i++)
        //    {
        //        wc[i] = new MyWebClient();
        //        var _i = i;//このインスタンスで作成する必要あり
        //        wc[i].DownloadProgressChanged += (s, ev) =>
        //        {
        //            current[_i] = ev.BytesReceived;
        //            if (n++ % 100 == 0)
        //                ip.Report((current.Sum(), total, stopwatch.ElapsedMilliseconds,
        //               $"Dowonloading database.  {current.Sum() / 1E6:f0} MB / {total / 1E6:f0} MB.  "));
        //        };
        //        wc[i].DownloadFileCompleted += (s, ev) =>
        //        {
        //            if (!ev.Cancelled)
        //                completedCount++;
        //            if (completedCount == FileNum)
        //                crystalDatabaseControl.ReadDatabase(UserAppDataPath + "COD.cdb3");//読み込む
        //        };
        //    }

        //    for (int i = 0; i < wc.Length; i++)
        //        wc[i].DownloadFileAsync(new Uri($"{urlHeader}COD/COD.{i:000}"), $"{UserAppDataPath}COD\\COD.{i:000}");
        //}
        //catch
        //{
        //    MessageBox.Show("Failed to download new COD database. Sorry.", "Error", MessageBoxButtons.OK);
        //}
    }

    private class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = 600 * 1000;
            return w;
        }
    }
    #endregion

    #region 新しいAMCSDのデータベース (csv形式) の読み込み
    private void importAMCSDCSVToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var dlg = new OpenFileDialog { Filter = "AMCSD CSV file | *.csv", };
        if (dlg.ShowDialog() != DialogResult.OK) return;
        stopwatch.Restart();

        using var reader = new StreamReader(dlg.FileName);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<amcsd>().ToArray();

        c2Array = new Crystal2[records.Length];

        var failedFile = new List<(int Index, string code)>();

        Parallel.For(0, records.Length, i =>//foreach (var record in records)
        {
            try
            {
                var lines = records[i].AMC_File_Contents.Split(["\r\n", "\n"], StringSplitOptions.None);
                c2Array[i] = ConvertCrystalData.ConvertFromAmc(lines);
                if (c2Array[i] != null)
                {
                    (c2Array[i].d, c2Array[i].formula, c2Array[i].density) = GetPlanesFormulaDensity(c2Array[i]);
                    c2Array[i].datatype = (byte)Crystal2.DataType.AMCSD;
                }
                else
                    throw new Exception("Failed to convert AMC data to Crystal2 object.");
            }
            catch { lock (lockObj) failedFile.Add((i, records[i].database_code_amcsd)); }
        });

        //失敗ファイルを書き込む
        using var writer = new StreamWriter(Path.GetDirectoryName(dlg.FileName) + "\\_failed.txt");
        failedFile.ForEach(e => writer.WriteLine($"{e.Index}: {e.code}"));

        #region デバッグコード
        if (AssemblyState.IsDebug)
            foreach (var i in failedFile.Select(e => e.Index))
            {
                try
                {
                    var lines = records[i].AMC_File_Contents.Split(["\r\n", "\n"], StringSplitOptions.None);
                    c2Array[i] = ConvertCrystalData.ConvertFromAmc(lines);

                }
                catch { }
            }
        #endregion

        crystalDatabaseControl.AddCrystals(c2Array);
        toolStripStatusLabel.Text = $"Completed! {stopwatch.ElapsedMilliseconds / 1000.0:f1} sec elapsed. ({records.Length} total, {100.0 * failedFile.Count / records.Length:f2} % failed)...";
    }
    #region AMCSDデータを読み込むためのテンポラリなクラス
    class amcsd
    {
        [Name("database_code_amcsd")] public string database_code_amcsd { get; set; }
        [Name("Mineral Name")] public string Mineral_Name { get; set; }
        [Name("Ideal IMA Formula")] public string Ideal_IMA_Formula { get; set; }
        [Name("AMC File Contents")] public string AMC_File_Contents { get; set; }
        [Name("Volume")] public string Volume { get; set; }
        [Name("Pressure")] public string Pressure { get; set; }
        [Name("Temperature")] public string Temperature { get; set; }
        [Name("Chemistry")] public string Chemistry { get; set; }
        [Name("AMC File")] public string AMC_File { get; set; }
        [Name("CIF File")] public string CIF_File { get; set; }
        [Name("DIF File")] public string DIF_File { get; set; }
        [Name("File")] public string File { get; set; }
        [Name("Reference ID")] public string Reference_ID { get; set; }
    }
    #endregion
    #endregion

    /// <summary>
    /// Crystal2からdspacing, formula, densityを取得する
    /// </summary>
    /// <param name="c2"></param>
    /// <returns></returns>
    private static (float[] Dspacings, string Formula, float Density) GetPlanesFormulaDensity(Crystal2 c2)
    {
        if (c2.atoms.Count != 0)
        {
            var c = c2.ToCrystal();
            return (c.GetDspacingList(0.154, 200), c.ChemicalFormulaSum, (float)c.Density);
        }
        else
            return (null, "", 0);
    }

    #region ImportAll フォルダ内に存在する全てのCIF,AMCファイルを取得し、データベースに書き込む


    private void importAllCrystalsMenuItem_Click(object sender, EventArgs e) => GetAllImport();

    private BackgroundWorker workerAllImport = new() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
    private Crystal2[] c2Array = [];
    /// <summary>
    /// フォルダ内に存在する全てのCIF,AMCファイルを取得し、データベースに書き込む
    /// </summary>
    private void GetAllImport()
    {
        var dlg = new FolderBrowserDialog() { SelectedPath = "Y:" };
        if (dlg.ShowDialog() != DialogResult.OK) return;

        var current = new DirectoryInfo(dlg.SelectedPath);
        var fn = new List<string>();
        var dr = MessageBox.Show("Also search subdirectory?", "Serch option", MessageBoxButtons.YesNoCancel);
        if (dr == DialogResult.Cancel)
            return;
        foreach (var file in current.GetFiles("*", dr == DialogResult.Yes ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))  // ファイルの一覧表示
            if (file.FullName.EndsWith("amc") || file.FullName.EndsWith("cif"))
                fn.Add(file.FullName);

        fn.Reverse();
        c2Array = new Crystal2[fn.Count];
        stopwatch.Restart();
        workerAllImport.RunWorkerAsync((fn, dlg.SelectedPath));
    }


    private void WorkerAllImport_DoWork(object sender, DoWorkEventArgs e)
    {
        var failedFile = new List<string>();
        var (fn, selectedPath) = ((List<string>, string))e.Argument;
        int count = 0;
        Parallel.For(0, fn.Count, new ParallelOptions { MaxDegreeOfParallelism = 8 }, j =>
        {
            try
            {
                c2Array[j] = ConvertCrystalData.ConvertToCrystal2(fn[j]);
                if (c2Array[j] != null)
                {
                    (c2Array[j].d, c2Array[j].formula, c2Array[j].density) = GetPlanesFormulaDensity(c2Array[j]);
                    c2Array[j].datatype = (byte)Crystal2.DataType.COD;
                }
            }
            catch { c2Array[j] = null; }

            if (c2Array[j] == null)
                lock (lockObj)
                    failedFile.Add(Path.GetFileNameWithoutExtension(fn[j]));

            if (Interlocked.Increment(ref count) % 200 == 0)
                workerAllImport.ReportProgress(0, (count, failedFile.Count, fn.Count));
        }
        );
        workerAllImport.ReportProgress(0, (fn.Count, failedFile.Count, fn.Count));

        //失敗ファイルを書き込む
        using var writer = new StreamWriter(selectedPath + "_failed.txt");
        foreach (var s in failedFile)
            writer.WriteLine(s);
    }

    private void WorkerAllImport_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        var (i, fails, total) = ((int, int, int))e.UserState;
        if (i != total)
            ip.Report((i, total, stopwatch.ElapsedMilliseconds, $"Converting ({i}/{total}, {100.0 * fails / i:f2} % failed)..."));
        else
            ip.Report((i, total, stopwatch.ElapsedMilliseconds, $"Completed!  ({total} total, {100.0 * fails / i:f2} % failed)..."));
        Application.DoEvents();
    }

    private void WorkerAllImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        crystalDatabaseControl.AddCrystals(c2Array);
    }
    #endregion

    #region その他のインポート系
    private void toolStripMenuItemImport_Click(object sender, EventArgs e)
    {
        var dlg = new OpenFileDialog { Filter = "*.cif, *.amc file | *.amc;*.cif" };
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            try
            {
                Crystal2 c = ConvertCrystalData.ConvertToCrystal(dlg.FileName).ToCrystal2();
                if (c != null)
                    crystalDatabaseControl.AddCrystal(c);
            }
            catch { }
        }
    }

    private void toolStripMenuItemImportPDI_Click(object sender, EventArgs e)
    {
        var dlg = new OpenFileDialog { Filter = "PDIndexer Crystal data *.xml | *.xml" };
        if (dlg.ShowDialog() == DialogResult.OK)
            readXml(dlg.FileName);
    }

    private void readXml(string filename)
    {
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Crystal[]));
        var fs = new System.IO.FileStream(filename, System.IO.FileMode.Open);
        var cry = (Crystal[])serializer.Deserialize(fs);
        fs.Close();
        for (int i = 0; i < cry.Length; i++)
        {
            cry[i].SetAxis();
            crystalDatabaseControl.AddCrystal(Crystal2.FromCrystal(cry[i]));
        }
    }
    #endregion

    #region crystalDatabaseControlからの結晶変更イベント
    private void crystalDatabaseControl_CrystalChanged(object sender, EventArgs e)
    {
        var c = crystalDatabaseControl.Crystal;
        if (c != null)
        {
            crystalControl.Crystal = crystalDatabaseControl.Crystal;
            Clipboard.SetDataObject(crystalDatabaseControl.Crystal2.Serialize());
        }
    }
    #endregion

    #region 

    //重複ファイルを削除
    private void checkDuplicatedFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        /*  //重複があるかどうかチェック
          List<Crystal2> list = new List<Crystal2>();
          for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
              list.Add((Crystal2)((DataRowView)(bindingSourceMain.List[i])).Row[0]);
          for (int i = 0; i < list.Count; i++)
          {
              Crystal2 src = list[i];//(Crystal2)((DataRowView)(bindingSourceMain.List[i])).Row[0];
              for (int k = i + 1; k < list.Count; k++)
              {
                  Crystal2 target = list[k];// (Crystal2)((DataRowView)(bindingSourceMain.List[k])).Row[0];
                  bool flag = false;
                  if (src.name == target.name && src.a == target.a && src.atoms.Count == target.atoms.Count)
                  {
                      flag = true;
                      if (src.b != target.b || src.c != target.c || src.alpha != target.alpha || src.beta != target.beta || src.gamma != target.gamma ||
                          src.sym != target.sym || src.atoms.Count != target.atoms.Count)
                          flag = false;
                      else
                          for (int l = 0; l < src.atoms.Count; l++)
                              if (src.atoms[l].Position[0] != target.atoms[l].Position[0] || src.atoms[l].Position[1] != target.atoms[l].Position[1] || src.atoms[l].Position[2] != target.atoms[l].Position[2])
                                  flag = false;
                  }
                  if (flag)
                  {
                      list.RemoveAt(k);
                      //bindingSourceMain.RemoveAt(k);
                      k--;
                  }
              }
          }

          dataSet.Tables[0].Clear();


          bindingNavigator1.Visible = dataGridViewMain.Visible = false;
          foreach (Crystal2 crystal in list)
          {
              dataSet.DataTable.Add(crystal);
              Application.DoEvents();
          }
          bindingNavigator1.Visible = dataGridViewMain.Visible = true;
        */
    }


    #endregion

    #region ドラッグドロップ
    private void FormMain_DragDrop(object sender, DragEventArgs e)
    {
        string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
        try
        {
            if (fileName.Length == 1)
            {
                if (fileName[0].EndsWith("cdb"))
                    crystalDatabaseControl.ReadDatabase(fileName[0]);
                if (fileName[0].EndsWith("xml"))
                    readXml(fileName[0]);
            }
        }
        catch { return; }
    }


    private void FormMain_DragEnter(object sender, DragEventArgs e)
        => e.Effect = (e.Data.GetData(DataFormats.FileDrop) != null) ? DragDropEffects.Copy : DragDropEffects.None;

    #endregion 

    #region データベースへの追加/削除など

    private void clearDatabaseToolStripMenuItem_Click(object sender, EventArgs e) => crystalDatabaseControl.ClearAll();
    private void buttonAddCrystal_Click(object sender, EventArgs e)
    {
        crystalControl.GenerateFromInterface();
        if (crystalControl.Crystal != null)
        {
            Crystal2 crystal2 = Crystal2.FromCrystal(crystalControl.Crystal);
            crystalDatabaseControl.AddCrystal(crystal2);
        }
    }

    private void buttonChangeCrystal_Click(object sender, EventArgs e)
    {
        crystalControl.GenerateFromInterface();
        Crystal2 crystal2;
        if (crystalControl.Crystal != null)
        {

            crystal2 = Crystal2.FromCrystal(crystalControl.Crystal);
            crystalDatabaseControl.ChangeCrystal(crystal2);
        }
    }

    private void buttonDeleteCrystal_Click(object sender, EventArgs e) => crystalDatabaseControl.DeleteCurrentCrystal();

    private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        => crystalDatabaseControl.DeleteCurrentCrystal();

    #endregion

    #region プログラムアップデート
    private void programUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        (var Title, var Message, var NeedUpdate, var URL, var Path) = ProgramUpdates.Check(Version.Software, Version.VersionAndDate);

        if (!NeedUpdate)
            MessageBox.Show(Message, Title, MessageBoxButtons.OK);
        else if (MessageBox.Show(Message, Title, MessageBoxButtons.YesNo) == DialogResult.Yes)
            using (var wc = new WebClient())
            {
                long counter = 1;
                wc.DownloadProgressChanged += (s, ev) =>
                {
                    if (counter++ % 10 == 0)
                        ip.Report(ProgramUpdates.ProgressMessage(ev, stopwatch));
                };

                wc.DownloadFileCompleted += (s, ev) =>
                {
                    if (ProgramUpdates.Execute(Path))
                        Close();
                    else
                        MessageBox.Show($"Failed to downlod {Path}. \r\nSorry!", "Error!");
                };
                stopwatch.Restart();
                try { wc.DownloadFileAsync(new Uri(URL), Path); }
                catch { MessageBox.Show("Failed update check. \r\nServer may be down. \r\nAccess https://github.com/seto77/CSManager/releases/latest", " Error"); }
            }
    }
    #endregion

    #region その他ファイルメニュー
    private void RecalculateDensityFormulaAndDvaluesToolStripMenuItem_Click(object sender, EventArgs e)
        => crystalDatabaseControl.RecalculateDensityAndFormula();
    private void closeToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();
    private void toolTipToolStripMenuItem_Click(object sender, EventArgs e)
            => toolTip.Active = crystalControl.toolTip.Active = toolTipToolStripMenuItem.Checked;
    private void helpwebToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var fn = "\\doc\\CSManager(" + (CurrentLanguage == Languages.English ? "en" : "ja") + ").pdf";
        var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var f = new FormPDF(appPath + fn) { Text = "CSManager manual" };
        f.Show();
    }

    private void toolStripMenuItemGithubPage_Click(object sender, EventArgs e)
    => Process.Start(new ProcessStartInfo("https://github.com/seto77/CSManager") { UseShellExecute = true });

    private void repportBugsToolStripMenuItem_Click(object sender, EventArgs e)
        => Process.Start(new ProcessStartInfo("https://github.com/seto77/CSManager/issues") { UseShellExecute = true });

    private void hintToolStripMenuItem_Click(object sender, EventArgs e)
    {
        initialDialog.DialogMode = Crystallography.Controls.CommonDialog.DialogModeEnum.Hint;
        initialDialog.Visible = true;
    }
    private void languageToolStripMenuItem_Click(object sender, EventArgs e)
    {
        englishToolStripMenuItem.Checked = ((ToolStripMenuItem)sender).Name.Contains("english");
        japaneseToolStripMenuItem.Checked = !englishToolStripMenuItem.Checked;
        Thread.CurrentThread.CurrentUICulture = englishToolStripMenuItem.Checked ? new System.Globalization.CultureInfo("en") : new System.Globalization.CultureInfo("ja");
        Language.Change(this);
    }

    private void versionHistoryToolStripMenuItem_Click(object sender, EventArgs e)
    {
        initialDialog.DialogMode = Crystallography.Controls.CommonDialog.DialogModeEnum.History;
        initialDialog.Visible = true;
    }

    private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
    {
        initialDialog.DialogMode = Crystallography.Controls.CommonDialog.DialogModeEnum.License;
        initialDialog.Visible = true;
    }

    private void increaseToolStripMenuItem_Click(object sender, EventArgs e) => crystalDatabaseControl.FontSize *= 1.1f;

    private void decreaseToolStripMenuItem_Click(object sender, EventArgs e) => crystalDatabaseControl.FontSize *= 0.9f;

    private void toolStripMenuItemShowFileName_Click(object sender, EventArgs e)
    {
        MessageBox.Show(crystalDatabaseControl.Crystal2.fileName);
    }
    #endregion

    private void FormMain_ResizeBegin(object sender, EventArgs e)
    {
        //SuspendLayout();
    }

    private void FormMain_ResizeEnd(object sender, EventArgs e)
    {
        // ResumeLayout();
    }

    private void testToolStripMenuItem_Click(object sender, EventArgs e)
    {
        
    }
}