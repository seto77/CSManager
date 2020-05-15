using Crystallography;
using Crystallography.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using MessagePack;
using MessagePack.Resolvers;
using System.Security.Cryptography;
using System.ServiceModel.Channels;
using System.Reflection;
using Microsoft.Scripting.Utils;

namespace CSManager
{
    public partial class FormMain : Form
    {
        #region クリップボード関連
        //private IntPtr NextHandle;
        //private const int WM_DRAWCLIPBOARD = 0x0308;
        //private const int WM_CHANGECBCHAIN = 0x030D;


        //[DllImport("user32")]
        //public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
        //[DllImport("user32")]
        //public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
        //[DllImport("user32", CharSet = CharSet.Auto)]
        //public extern static int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        //public bool EnableClipboard = false;
        //protected override void WndProc(ref System.Windows.Forms.Message msg)
        //{
        //    switch (msg.Msg)
        //    {
        //        case WM_DRAWCLIPBOARD:

        //            if (EnableClipboard && ((IDataObject)Clipboard.GetDataObject()).GetDataPresent(typeof(Crystal2)))
        //            {
        //                IDataObject data = Clipboard.GetDataObject();
        //                var c2 = (Crystal2)data.GetData(typeof(Crystal2));
        //                crystalControl.Crystal = Crystal2.GetCrystal(c2);
        //            }
        //            if ((int)NextHandle != 0)
        //                SendMessage(NextHandle, msg.Msg, msg.WParam, msg.LParam);
        //            break;
        //        case WM_CHANGECBCHAIN:
        //            if (msg.WParam == NextHandle)
        //                NextHandle = (IntPtr)msg.LParam;
        //            else if ((int)NextHandle != 0)
        //                SendMessage(NextHandle, msg.Msg, msg.WParam, msg.LParam);
        //            break;
        //    }
        //    base.WndProc(ref msg);
        //}
        #endregion

        public FormPeriodicTable formPeriodicTable;

        public string UserAppDataPath = new DirectoryInfo(Application.UserAppDataPath).Parent.FullName + @"\";

        Stopwatch stopwatch { get; set; } = new Stopwatch();
        bool skipProgressEvent { get; set; } = false;


        Crystallography.Controls.CommonDialog initialDialog;

        readonly ReaderWriterLockSlim rwlock = new ReaderWriterLockSlim();

        readonly MessagePackSerializerOptions msgOptions = StandardResolverAllowPrivate.Options.WithCompression(MessagePackCompression.Lz4BlockArray);

        IProgress<(long, long, long, string)> ip;//IReport

        byte[] serialize<T>(T c) => MessagePackSerializer.Serialize(c, msgOptions);

        T deserialize<T>(byte[] bytes) => MessagePackSerializer.Deserialize<T>(bytes, msgOptions);
        T deserialize<T>(Stream stream) => MessagePackSerializer.Deserialize<T>(stream, msgOptions);
        T deserialize<T>(object obj) => MessagePackSerializer.Deserialize<T>((byte[])obj, msgOptions);



        #region 起動、終了

        public FormMain()
        {
            ip = new Progress<(long, long, long, string)>(o => reportProgress(o));//IReport
            var regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\CSManager");
            try
            {
                string culture = (string)regKey.GetValue("Culture", Thread.CurrentThread.CurrentUICulture.Name);
                if (culture.ToLower().StartsWith("ja"))
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ja");
                else
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }
            catch { }

            InitializeComponent();

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
        }
        ~FormMain()
        {
            rwlock.Dispose();
        }



        private void FormMain_Load(object sender, EventArgs e)
        {
            //#if !DEBUG
            //           Ngen.Compile(new string[] { "Crystallography.dll", "Crystallography.Control.dll", "CSManager.exe" });
            //#endif

            //ユーザーパスにxmlファイルをコピー
            var appPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\";
            if (File.Exists(appPath + "StdDB.cdb3"))
                File.Copy(appPath + "StdDB.cdb3", UserAppDataPath + "StdDB.cdb3", true);

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
            japaneseToolStripMenuItem.Checked = Thread.CurrentThread.CurrentUICulture.Name == "ja";

            initialDialog.Show();
            Application.DoEvents();
            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.1);

            formPeriodicTable = new FormPeriodicTable();
            formPeriodicTable.Owner = this;

            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.4);

            this.Text = "CSManager   " + Version.VersionAndDate;

            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.7);

            if (readDefaultDatabaseOnNextBootToolStripMenuItem.Checked)
                toolStripMenuItemReadDefault1_Click(new object(), new EventArgs());

            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 1.0);

            if (initialDialog.AutomaricallyClose)
                initialDialog.Visible = false;

            readRegistry();

            //NextHandle = SetClipboardViewer(this.Handle);

            //EnableClipboard = true;

            toolStripMenuItemReadDefault1.Text = toolStripMenuItemReadDefault1.Text.Replace("###", Version.AMCSD.ToString());
            toolStripMenuItemReadDefault2.Text = toolStripMenuItemReadDefault2.Text.Replace("###", Version.COD.ToString());

            if (!File.Exists(UserAppDataPath + "CSManagerSetup.msi"))
                File.Delete(UserAppDataPath + "CSManagerSetup.msi");
            Directory.Delete(Application.UserAppDataPath, true);

            crystalControl.atomControl.AppearanceTabVisible = true;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveRegistry();
            formPeriodicTable.Close();
            e.Cancel = false;

            //ChangeClipboardChain(this.Handle, NextHandle);

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
                initialDialog.AutomaricallyClose = (string)regKey.GetValue("initialDialog.AutomaricallyClose", "False") == "True";
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
            regKey.SetValue("initialDialog.AutomaricallyClose", initialDialog.AutomaricallyClose);
            regKey.Close();
        }

        #endregion


        private void buttonSearch_Click(object sender, EventArgs e)
        {

            var filter = new List<string>();

            //名前
            if (checkBoxSearchName.Checked && textBoxSearchName.Text != "")
                filter.Add(string.Join(" AND ", textBoxSearchName.Text.Split().Select(s => $"Name LIKE '*{s}*'")));

            //Reference
            if (checkBoxSearchRefference.Checked && textBoxSearchRefference.Text != "")
                filter.Add(string.Join(" AND ", textBoxSearchRefference.Text.Split().Select(s => $"(Authors LIKE '*{s}*' OR Title LIKE '*{s}*' OR Journal LIKE '*{s}*')")));

            if (checkBoxSearchCrystalSystem.Checked && comboBoxSearchCrystalSystem.SelectedIndex >= 0)
                filter.Add($" CrystalSystem = '{comboBoxSearchCrystalSystem.Text}'");

            //元素のためのフィルター文字列
            if (checkBoxSearchElements.Checked && formPeriodicTable.IncludesStr.Length != 0)
                filter.Add(string.Join(" AND ", formPeriodicTable.IncludesStr.Select(s => $"Elements Like '*{s}*'")));

            if (checkBoxSearchElements.Checked && formPeriodicTable.ExcludesStr.Length != 0)
                filter.Add("NOT(" + string.Join(" OR ", formPeriodicTable.ExcludesStr.Select(s => $"Elements Like '*{s}*'")) + ")");//NOT句をつける

            //格子定数のフィルター
            if (checkBoxSearchCellParameter.Checked)
            {
                var lenErr = numericBoxCellLengthErr.Value / 100;
                var angErr = numericBoxCellAngleErr.Value / 100;
                var func = new Func<string, double, double, string>((symbol, val, err) => val != 0 ? $"{symbol} >{val * (1 - err)} AND {symbol} < {val * (1 + err)}" : "");

                filter.Add(func("A", numericBoxCellA.Value, lenErr));
                filter.Add(func("B", numericBoxCellB.Value, lenErr));
                filter.Add(func("C", numericBoxCellC.Value, lenErr));
                filter.Add(func("Alpha", numericBoxCellAlpha.Value, angErr));
                filter.Add(func("Beta", numericBoxCellBeta.Value, angErr));
                filter.Add(func("Gamma", numericBoxCellGamma.Value, angErr));
            }

            if (checkBoxDspacing.Checked)
            {
                var func = new Func<double, double, string>((val, err) =>
                {
                    if (val == 0) return "";
                    var temp = new List<string>();
                    for (int j = 1; j < 9; j++)
                        temp.Add($"( D{j} > {val * (1 - err)} AND D{j} < {val * (1 + err)} )");
                    return string.Join(" OR ", temp);
                });

                if (checkBoxD1.Checked)
                    filter.Add(func(numericBoxD1.Value, numericBoxD1Err.Value / 100));
                if (checkBoxD2.Checked)
                    filter.Add(func(numericBoxD2.Value, numericBoxD2Err.Value / 100));
                if (checkBoxD3.Checked)
                    filter.Add(func(numericBoxD3.Value, numericBoxD3Err.Value / 100));
            }

            //格子定数のフィルター
            if (checkBoxDensity.Checked && numericBoxDensity.Value != 0)
            {
                double val = numericBoxDensity.Value, err = numericBoxDensityErr.Value / 100;
                filter.Add($"Density >{val * (1 - err)} AND Density < {val * (1 + err)}");
            }

            bindingSourceMain.Filter = string.Join(" AND ", filter.Where(f => f != "").Select(f => "(" + f + ")"));

        }

        private void checkBoxSearch_CheckedChanged(object sender, EventArgs e)
        {
            buttonPeriodicTable.Visible = checkBoxSearchElements.Checked;
            if (formPeriodicTable.Visible && !checkBoxSearchElements.Checked)
                formPeriodicTable.Visible = false;

            textBoxSearchRefference.Visible = checkBoxSearchRefference.Checked;
            textBoxSearchName.Visible = checkBoxSearchName.Checked;
            comboBoxSearchCrystalSystem.Visible = checkBoxSearchCrystalSystem.Checked;
            groupBoxCellParameter.Visible = checkBoxSearchCellParameter.Checked;
            groupBoxDspacing.Visible = checkBoxDspacing.Checked;
            groupBoxDensity.Visible = checkBoxDensity.Checked;
        }


        private void readDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Database File[*.cdb;*.cdb2;*.cdb2]|*.cdb;*.cdb2;*.cdb3";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
                for (int i = 0; i < dialog.FileNames.Length; i++)
                    readDatabase(dialog.FileNames[i]);
        }

        #region データベース読み込み/書き込み関連
        private int readInt(Stream s) => BitConverter.ToInt32(readBytes(s, 4), 0);
        private int readByte(Stream s) => s.ReadByte();
        private long readLong(Stream s) => BitConverter.ToInt64(readBytes(s, 8), 0);

        private byte[] readAll(Stream s)
        {
            s.Position = 0;
            var bytes = new byte[s.Length];
            s.Read(bytes, 0, bytes.Length);
            return bytes;
        }

        private byte[] readBytes(Stream s, int length)
        {
            var bytes = new byte[length];
            s.Read(bytes, 0, bytes.Length);
            return bytes;
        }

        private void writeInt(Stream s, int v) => s.Write(BitConverter.GetBytes(v), 0, 4);
        private void writeLong(Stream s, long v) => s.Write(BitConverter.GetBytes(v), 0, 8);
        private void writeByte(Stream s, byte v) => s.WriteByte(v);
        private void writeBytes(Stream s, byte[] v) => s.Write(v, 0, v.Length);

        /// <summary>
        /// MD5を取得する。ファイルが存在しない場合はnullを返す。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private byte[] getMD5(string path)
        {
            if (!File.Exists(path))
                return null;
            using (var fs = new FileStream(path, FileMode.Open))
                return MD5.Create().ComputeHash(fs);
        }

        /// <summary>
        /// MD5とファイルが一致するかどうか調べる。
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="md5"></param>
        /// <returns></returns>
        private bool checkMD5(string path, byte[] md5)
        {
            var _md5 = getMD5(path);
            return _md5 != null && md5.Length == _md5.Length && md5.SequenceEqual(_md5);
        }
     
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
            skipProgressEvent = true;
            try
            {
                toolStripProgressBar.Maximum = int.MaxValue;
                var ratio = (double)current / total;
                toolStripProgressBar.Value = (int)(ratio * toolStripProgressBar.Maximum);
                var ellapsedSec = elapsedMilliseconds / 1E3;
                var format = $"f{digit}";

                if (showPercentage) message += $" Completed: {(ratio * 100).ToString(format)} %.";
                if (showEllapsedTime) message += $" Elappsed time: {ellapsedSec.ToString(format)} sec.";
                if (showRemainTime) message += $" Remaining time: {(ellapsedSec / current * (total - current)).ToString(format)} sec.";

                toolStripStatusLabel.Text = message;

                Application.DoEvents();

                if (sleep != 0) Thread.Sleep(sleep);
            }
            catch (Exception e){ 
            
            }
            skipProgressEvent = false;
        }

        /// <summary>
        /// データベース読み込み
        /// </summary>
        /// <param name="filename"></param>
        async private void readDatabase(string filename)
        {
            try
            {
                stopwatch.Restart();
                var progressStep = 500;
                bindingSourceMain.DataMember = "";
                using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    if (filename.ToLower().EndsWith("cdb2"))
                    {
                        var formatter = new BinaryFormatter();
                        var total = (int)formatter.Deserialize(fs);
                        for (int i = 0; i < total; i++)
                        {
                            var c = (Crystal2)formatter.Deserialize(fs);
                            dataSet.DataTable.Add(c);

                            if (i > progressStep * 2 && i % progressStep == 0)
                                reportProgress(i, total, stopwatch.ElapsedMilliseconds, "Loading database...");
                        }
                    }
                    else if (filename.ToLower().EndsWith("cdb3"))
                    {
                        var flag = readByte(fs);
                        var total = readInt(fs); ;
                        //単一ファイルの場合でも、分割ファイルの場合でも使えるように、Actionを定義
                        var action = new Action<Stream>(f =>
                            {
                                while (f.Position < f.Length)
                                {
                                    var rows = deserialize<Crystal2[]>(f).Select(c => dataSet.DataTable.CreateRow(c)).ToList();
                                    try
                                    {
                                        rwlock.EnterWriteLock();
                                        foreach (var r in rows)
                                            dataSet.DataTable.Add(r);
                                    }
                                    finally { rwlock.ExitWriteLock(); }
                                    ip.Report((dataSet.DataTable.Rows.Count, total, stopwatch.ElapsedMilliseconds, "Loading database..."));
                                }
                            });

                        //単一ファイルの時
                        if (flag == 100)
                            await Task.Run(() => action(fs));
                        //分割ファイルの時
                        else if(flag ==200)
                        {
                            var fileNum = readInt(fs);
                            var fileNames = Enumerable.Range(0, fileNum).Select(i =>
                                    $"{filename.Remove(filename.Length - 5, 5)}\\{Path.GetFileNameWithoutExtension(filename)}.{i:000}").AsParallel();

                            await Task.Run(() => fileNames.ForAll(fn => action(new FileStream(fn, FileMode.Open))));
                        }
                    }
                    else
                        return;
                }

                toolStripStatusLabel.Text = $"Toatal loading time: {stopwatch.ElapsedMilliseconds / 1E3:f1} sec.";
                bindingSourceMain.DataMember = "dataTable";
                GC.Collect();
            }
            catch
            {
                MessageBox.Show("Failed to load database. Sorry.");
            }
            bindingSourceMain.Position = 0;
        }

        /// <summary>
        /// データベース書き込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var thresholdBytes = 30000000;

            var dlg = new SaveFileDialog() { Filter = "Database File[*.cdb3]|*.cdb3" };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fn = dlg.FileName;
                var total = dataSet.Tables[0].Rows.Count;
                stopwatch.Restart();
                using (var fs = new FileStream(fn, FileMode.Create, FileAccess.Write))
                {
                    //とりあえず先頭に100 (分割なし)を書き込む
                    writeByte(fs, 100);
                    //データの個数
                    writeInt(fs, total);

                    var division = 1000;//分割単位 たぶんパフォーマンスに効く
                    var byteList = new List<byte>();
                    var filecounter = 0;
                    var subDir = fn.Remove(fn.Length - 5, 5) + "\\";
                    var header = subDir + Path.GetFileNameWithoutExtension(fn) + ".";
                    var fileSize = new List<long>();
                    for (int i = 0; i < total; i += division)
                    {
                        var crystal2List = new List<Crystal2>();
                        for (int j = i; j < total && j < i + division; j++)
                        {
                            var c2 = deserialize<Crystal2>(((DataRowView)bindingSourceMain[j]).Row[0]);
                            crystal2List.Add(c2);
                        }
                        byteList.AddRange(serialize(crystal2List.ToArray()));

                        //最後まで来ている時で、かつ閾値以下の容量で、かつこれまで一度も分割もしていない場合
                        if (i + division >= total && byteList.Count <= thresholdBytes && filecounter == 0)
                            fs.Write(byteList.ToArray(), 0, byteList.Count);//最初のファイルに書き込んで終了
                        //最後まで来ている時か、閾値以上の容量の場合
                        else if (i + division >= total || byteList.Count > thresholdBytes)
                        {
                            if (filecounter == 0)
                                Directory.CreateDirectory(fn.Remove(fn.Length - 5, 5));
                            using (var fs1 = new FileStream(header + filecounter.ToString("000"), FileMode.Create, FileAccess.Write))
                                fs1.Write(byteList.ToArray(), 0, byteList.Count);
                            fileSize.Add(byteList.Count);
                            byteList.Clear();

                            filecounter++;
                        }
                        reportProgress(i, total, stopwatch.ElapsedMilliseconds, "Saving database...");
                    }

                    if (filecounter > 0)//分割ファイルになった場合
                    {
                        //分割ファイル数書き込み
                        writeInt(fs, filecounter);
                        //ファイルサイズ書き込み
                        for(int i=0; i< filecounter; i++)
                             writeLong(fs, fileSize[i]);
                        //チェックサムを書き込み
                        for (int i = 0; i < filecounter; i++)
                            writeBytes(fs, getMD5(header + i.ToString("000")));
                        //最後に先頭に戻って200を書き込み
                        fs.Position = 0;
                        writeByte(fs, 200);
                    }
                }
                toolStripStatusLabel.Text = $"Total saving time: {stopwatch.ElapsedMilliseconds / 1E3:f1} sec.";
            }
        }

        /// <summary>
        /// 分割ファイルがきちんと作成されているかをチェック
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private (bool Valid, int DataNum, int FileNum, long[] FileSizes, byte[][] CheckSums) checkDatabaseFiles(string path, bool checkValidity)
        {
            stopwatch.Restart();
            var nameWithoutExt = Path.GetFileNameWithoutExtension(path);
            var subDir = Path.GetDirectoryName(path) + "\\" + nameWithoutExt + "\\";
            try
            {
                int dataNum = 0, fileNum = 0;
                var fileSizes = new long[0];
                var checkSums = new byte[0][];

                if (File.Exists(path))
                {
                    //データ個数、ファイル数を取得
                    using (var fs = new FileStream(path, FileMode.Open))
                    {
                        var head = readByte(fs);
                        dataNum = readInt(fs);
                        fileNum = readInt(fs);

                        fileSizes = new long[fileNum];
                        for (int i = 0; i < fileNum; i++)
                            fileSizes[i] = readLong(fs);

                        checkSums = new byte[fileNum][];
                        for (int i=0; i< fileNum; i++)
                            checkSums[i] = readBytes(fs,16);
                    }
                    if (checkValidity)
                    {
                        //md5をチェック
                        bool flag = true;
                        var counter = 0;
                        for (int i = 0; i < fileNum; i++)
                        //  Parallel.For(0, fileNum, i =>
                        {
                            if (flag)
                                flag = checkMD5($"{subDir}{nameWithoutExt}.{i:000}", checkSums[i]);
                            ip.Report((counter++, fileNum, stopwatch.ElapsedMilliseconds, "Now checking database... "));
                        }
                        // );
                        return (flag, dataNum, fileNum, fileSizes, checkSums);
                    }
                    else
                        return (false, dataNum, fileNum, fileSizes, checkSums);
                }
                return (false, 0, 0, null, null);
            }
            catch
            { return (false, 0, 0, null, null); }
        }


       
        /// <summary>
        /// CODデータベースのダウンロードや読み込み. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemReadDefault2_Click(object sender, EventArgs e)
        {
            var (Valid, DataNum, FileNum, FileSizes, CheckSums) = checkDatabaseFiles(UserAppDataPath + "COD.cdb3", true);
            string urlHeader = "https://github.com/seto77/CSManager/raw/master/COD/";
            if (Valid)
            {//適切にダウンロードされている場合
                try//web上に新しいデータがあるかどうかをチェック
                {
                    bool noNeedToUpdate;
                    using (var fs = new FileStream(UserAppDataPath + "COD.cdb3", FileMode.Open))
                        noNeedToUpdate = new WebClient().DownloadData(new Uri(urlHeader + "COD.cdb3")).SequenceEqual(readAll(fs));

                    if (noNeedToUpdate)
                    {//ローカルのCODが最新版の場合
                        readDatabase(UserAppDataPath + "COD.cdb3");
                        return;
                    }
                    else
                    {//更新版が存在する場合
                        var result = MessageBox.Show("Now, new database is available.\r\n  Download and load the new database: YES\r\n" +
                            "  Use the current database: No\r\n  Cancel database loading: Cancel", "  New database is available", MessageBoxButtons.YesNoCancel);

                        if (result == DialogResult.No) //Noの場合 (更新せずに現状を読み込む場合)
                            readDatabase(UserAppDataPath + "COD.cdb3");

                        if (result == DialogResult.No || result == DialogResult.Cancel)//NoかCancelの場合
                            return;
                    }

                }
                catch //WEBが落ちている場合は、現状のCODを読み込む 
                {
                    readDatabase(UserAppDataPath + "COD.cdb3");
                    return;
                }
            }
            else//CODデータが存在しないか、適切でない場合
            {
                if (MessageBox.Show("Local COD database is missing.\r\n  Do you download the new database now ?", "Local COD database is missing.",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            //ここからCODをダウンロード
            try
            {
                stopwatch.Restart();
                new WebClient().DownloadFile(new Uri(urlHeader + "COD.cdb3"), UserAppDataPath + "COD.cdb3");
                
                Directory.CreateDirectory(UserAppDataPath + "COD");

                (_, DataNum, FileNum, FileSizes, CheckSums) = checkDatabaseFiles(UserAppDataPath + "COD.cdb3", false);
                
                var wc = new MyWebClient[FileNum];
                var total = FileSizes.Sum();
                var current = new long[FileNum];
                var completedCount = 0;
                long n = 1;
                for (int i = 0; i < wc.Length; i++)
                {
                    wc[i] = new MyWebClient();
                    var _i = i;//このインスタンスで作成する必要あり
                    wc[i].DownloadProgressChanged +=  (s, ev) =>
                    {
                        current[_i] = ev.BytesReceived;
                        if (n++ % 100 == 0)
                            ip.Report((current.Sum(), total, stopwatch.ElapsedMilliseconds,
                           $"Dowonloading database.  {current.Sum() / 1E6:f0} MB / {total / 1E6:f0} MB.  "));
                    };
                    wc[i].DownloadFileCompleted += (s, ev) =>
                    {
                        if (!ev.Cancelled)
                            completedCount++;
                        if(completedCount==FileNum)
                            readDatabase(UserAppDataPath + "COD.cdb3");//読み込む
                    };
                }

                for (int i = 0; i < wc.Length; i++)
                    wc[i].DownloadFileAsync(new Uri($"{urlHeader}COD/COD.{i:000}"), $"{UserAppDataPath}COD\\COD.{i:000}");
            }
            catch
            {
                MessageBox.Show("Failed to download new COD database. Sorry.", "Error", MessageBoxButtons.OK);
            }
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

        private void importAllCrystalsMenuItem_Click(object sender, EventArgs e) => GetAllImport();

        /// <summary>
        /// フォルダ内に存在する全てのCIF,AMCファイルを取得し、データベースに書き込む
        /// </summary>
        private async void GetAllImport()
        {
            var dlg = new FolderBrowserDialog() { SelectedPath = "D:\\Users\\seto\\Documents\\研究\\CrystallographyData" };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            var current = new DirectoryInfo(dlg.SelectedPath);
            var fn = new List<string>();
            var dr = MessageBox.Show("Also search subdirectory?", "Serch option", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Cancel)
                return;
            await Task.Run(() =>
            {
                foreach (var file in current.GetFiles("*", dr == DialogResult.Yes ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))  // ファイルの一覧表示
                    if (file.FullName.EndsWith("amc") || file.FullName.EndsWith("cif"))
                        fn.Add(file.FullName);
            });

            var failedFile = new List<string>();
            stopwatch.Restart();

            var division = 1000;//分割単位
            for (int i = 0; i < fn.Count; i += division)
            {
                var crystalList = new List<Crystal2>();
                Parallel.For(i, i + division < fn.Count ? i + division : fn.Count, j =>
                {
                    var crystal2 = ConvertCrystalData.ConvertToCrystal2(fn[j]);
                    try
                    {
                        rwlock.EnterWriteLock();//書き込みロック
                                if (crystal2 != null)
                            crystalList.Add(crystal2);
                        else
                            failedFile.Add(fn[j]);
                    }
                    finally { rwlock.ExitWriteLock(); }//書き込み解放
                        });
                //進捗状況報告
                reportProgress(i, fn.Count, stopwatch.ElapsedMilliseconds, "Converting...");

                foreach (var r in crystalList)
                    dataSet.DataTable.Add( r);

            }

            //失敗ファイルを書き込む
            using (var writer = new StreamWriter(dlg.SelectedPath + "_failed.txt"))
                foreach (var s in failedFile)
                    writer.WriteLine(Path.GetFileNameWithoutExtension(s));
        }

        #endregion

        private void bindingSourceMain_CurrentChanged(object sender, EventArgs e)
        {
             try
            {
                var c2 = dataSet.DataTable.Get(bindingSourceMain.Current);
                if (c2 != null)
                {
                    var c = Crystal2.GetCrystal(c2);
                    if (c != null)
                    {
                        crystalControl.Crystal = c;
                        Clipboard.SetDataObject(c2);
                    }
                }
            }
             catch { return; }
        }

        #region 

        //重複ファイルを削除
        private void checkDuplicatedFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //重複があるかどうかチェック
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
                                if (src.atoms[l].X[0] != target.atoms[l].X[0] || src.atoms[l].X[1] != target.atoms[l].X[1] || src.atoms[l].X[2] != target.atoms[l].X[2])
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
        }


        #endregion

        private void buttonAddCrystal_Click(object sender, EventArgs e)
        {
            crystalControl.GenerateFromInterface();
            if (crystalControl.Crystal != null)
            {
                Crystal2 crystal2 = Crystal2.FromCrystal(crystalControl.Crystal);
                dataSet.DataTable.Add(crystal2);
            }
        }

        private void buttonChangeCrystal_Click(object sender, EventArgs e)
        {
            crystalControl.GenerateFromInterface();
            Crystal2 crystal;
            if (crystalControl.Crystal != null)
            {
                int i = bindingSourceMain.IndexOf(bindingSourceMain.Current);
                if (i < 0)
                    buttonAddCrystal_Click(new object(), new EventArgs());

                crystal = Crystal2.FromCrystal(crystalControl.Crystal);
                dataSet.DataTable.Replace(bindingSourceMain.Current, crystal);
            }
        }

        private void buttonDeleteCrystal_Click(object sender, EventArgs e) => bindingSourceMain.RemoveCurrent();

        private void textBoxSearchAllField_TextChanged(object sender, EventArgs e)
        {
            if (incrementalSearchToolStripMenuItem.Checked)
                buttonSearch_Click(sender, e);
        }

        private void toolTipToolStripMenuItem_Click(object sender, EventArgs e)
            => toolTip.Active = crystalControl.toolTip.Active = toolTipToolStripMenuItem.Checked;

        private void buttonPeriodicTable_Click(object sender, EventArgs e)
            => formPeriodicTable.Visible = true;

        private void toolStripMenuItemReadDefault1_Click(object sender, EventArgs e)
        {
            if (File.Exists(UserAppDataPath + "StdDB.cdb3"))
                readDatabase(UserAppDataPath + "StdDB.cdb3");
        }


        private void toolStripMenuItemImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.cif, *.amc file | *.amc;*.cif";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Crystal2 c = ConvertCrystalData.ConvertToCrystal(dlg.FileName).ToCrystal2();
                    if (c != null)
                        dataSet.DataTable.Add(c);
                }
                catch { }
            }
        }

        private void toolStripMenuItemImportPDI_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "PDIndexer Crystal data *.xml | *.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
                readXml(dlg.FileName);
        }

        private void readXml(string filename)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Crystal[]));
            System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open);
            Crystal[] cry = (Crystal[])serializer.Deserialize(fs);
            fs.Close();
            for (int i = 0; i < cry.Length; i++)
            {
                cry[i].SetAxis();
                dataSet.DataTable.Add(Crystal2.FromCrystal(cry[i]));
            }
        }

        private void clearDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
            => dataSet.DataTable.Clear();

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
            => this.Close();

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            try
            {
                if (fileName.Length == 1)
                {
                    if (fileName[0].EndsWith("cdb"))
                        readDatabase(fileName[0]);
                    if (fileName[0].EndsWith("xml"))
                        readXml(fileName[0]);
                }
            }
            catch { return; }
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
            => e.Effect = (e.Data.GetData(DataFormats.FileDrop) != null) ? DragDropEffects.Copy : DragDropEffects.None;

        private void helpwebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://pmsl.planet.sci.kobe-u.ac.jp/~seto/software/CSManager/CSManagerHelp.html");
            }
            catch { }
        }

        private void checkBoxDspacing_CheckedChanged(object sender, EventArgs e)
            => groupBoxDspacing.Enabled = checkBoxDspacing.Checked;

        private void checkBoxD1_CheckedChanged(object sender, EventArgs e)
            => numericBoxD1.Enabled = numericBoxD1Err.Enabled = checkBoxD1.Checked;

        private void checkBoxD2_CheckedChanged(object sender, EventArgs e)
            => numericBoxD2.Enabled = numericBoxD2Err.Enabled = checkBoxD2.Checked;

        private void checkBoxD3_CheckedChanged(object sender, EventArgs e)
            => numericBoxD3.Enabled = numericBoxD3Err.Enabled = checkBoxD3.Checked;


        private void hintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialDialog.DialogMode = Crystallography.Controls.CommonDialog.DialogModeEnum.Hint;
            initialDialog.Visible = true;
        }


        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
            => bindingSourceMain.RemoveCurrent();

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
                    try
                    {
                        wc.DownloadFileAsync(new Uri(URL), Path);
                    }
                    catch
                    {
                        MessageBox.Show("Failed update check. \r\nServer may be down. \r\nAccess https://github.com/seto77/CSManager/releases/latest"," Error");
                    }
                }
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

        private void increaseToolStripMenuItem_Click(object sender, EventArgs e) => dataGridViewMain.Font = new Font(dataGridViewMain.Font.FontFamily, dataGridViewMain.Font.Size * 1.1f);

        private void decreaseToolStripMenuItem_Click(object sender, EventArgs e) => dataGridViewMain.Font = new Font(dataGridViewMain.Font.FontFamily, dataGridViewMain.Font.Size * 0.9f);

        private void toolStripMenuItemShowFileName_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(((Crystal2)((DataRowView)bindingSourceMain.Current).Row[0]).fileName);
            }
            catch { }
        }


       
    }
}