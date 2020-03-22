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

namespace CSManager
{
    public partial class FormMain : Form
    {
        #region クリップボード関連
        private IntPtr NextHandle;
        private const int WM_DRAWCLIPBOARD = 0x0308;
        private const int WM_CHANGECBCHAIN = 0x030D;


        [DllImport("user32")]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
        [DllImport("user32")]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        public bool EnableClipboard = false;
        protected override void WndProc(ref System.Windows.Forms.Message msg)
        {
            switch (msg.Msg)
            {
                case WM_DRAWCLIPBOARD:

                    if (EnableClipboard && ((IDataObject)Clipboard.GetDataObject()).GetDataPresent(typeof(Crystal2)))
                    {
                        IDataObject data = Clipboard.GetDataObject();
                        var c2 = (Crystal2)data.GetData(typeof(Crystal2));
                        crystalControl.Crystal = Crystal2.GetCrystal(c2);
                    }
                    if ((int)NextHandle != 0)
                        SendMessage(NextHandle, msg.Msg, msg.WParam, msg.LParam);
                    break;
                case WM_CHANGECBCHAIN:
                    if (msg.WParam == NextHandle)
                        NextHandle = (IntPtr)msg.LParam;
                    else if ((int)NextHandle != 0)
                        SendMessage(NextHandle, msg.Msg, msg.WParam, msg.LParam);
                    break;
            }
            base.WndProc(ref msg);
        }
        #endregion

        public FormPeriodicTable formPeriodicTable;

        public string UserAppDataPath = new DirectoryInfo(Application.UserAppDataPath).Parent.FullName + @"\";

        Stopwatch stopwatch { get; set; } = new Stopwatch();
        bool skipProgressEvent { get; set; } = false;


        WaitDlg initialDialog;

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
            File.Copy("StdDB.cdb3", UserAppDataPath + "StdDB.cdb3", true);

            initialDialog = new WaitDlg();
            readRegistry();
            initialDialog.Owner = this;
            initialDialog.Version = "CSManager  " + Version.VersionAndDate;
            initialDialog.Text = "Now Loading...";
            initialDialog.ShowVersion = true;
            initialDialog.Hint = Version.Hint;

            englishToolStripMenuItem.Checked = Thread.CurrentThread.CurrentUICulture.Name != "ja";
            japaneseToolStripMenuItem.Checked = Thread.CurrentThread.CurrentUICulture.Name == "ja";

            initialDialog.Show();
            Application.DoEvents();
            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.1);

            formPeriodicTable = new FormPeriodicTable();
            formPeriodicTable.Owner = this;

            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.4);

            this.Text = "CSManager   " + Version.VersionAndDate;

            //string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.7);

            if (readDefaultDatabaseOnNextBootToolStripMenuItem.Checked)
                toolStripMenuItemReadDefault1_Click(new object(), new EventArgs());

            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 1.0);

            if (initialDialog.AutomaricallyClose)
                initialDialog.Visible = false;

            readRegistry();

            NextHandle = SetClipboardViewer(this.Handle);

            EnableClipboard = true;

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                programUpdatesToolStripMenuItem.Visible = false;//click onceの場合
                this.Text += "   Caution! ClickOnce vesion will be not maintained in the future.";
            }
            toolStripMenuItemReadDefault1.Text = toolStripMenuItemReadDefault1.Text.Replace("###", Version.AMCSD.ToString());
            toolStripMenuItemReadDefault2.Text = toolStripMenuItemReadDefault2.Text.Replace("###", Version.COD.ToString());


            if (!File.Exists(UserAppDataPath + "CSManagerSetup.msi"))
                File.Delete(UserAppDataPath + "CSManagerSetup.msi");
            Directory.Delete(Application.UserAppDataPath, true);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveRegistry();
            formPeriodicTable.Close();
            e.Cancel = false;

            ChangeClipboardChain(this.Handle, NextHandle);

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
        private void textBoxNumOnly_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < '.' || e.KeyChar > '9') && e.KeyChar != '\b' && e.KeyChar != 3 && e.KeyChar != 22)
                e.Handled = true;
        }


        public object[] GetTabelRows(Crystal2 crystal)
        {
            Symmetry s = SymmetryStatic.Get_Symmetry(crystal.sym);
            var elementList = "";
            foreach (Atoms2 a in crystal.atoms)
                if (!elementList.Contains(a.AtomNo.ToString("000")))
                    elementList += a.AtomNo.ToString("000") + " ";

            double[] d = new double[8];
            for (int i = 0; i < 8; i++)
                if (crystal.d.Length > i)
                    d[i] = crystal.d[i];
                else
                    d[i] = 0;

            return new object[] {
                    serialize(crystal),
                    crystal.name,
                    crystal.formula,
                    Math.Round(crystal.density,4),
                    Math.Round(crystal.a*10,7),
                    Math.Round(crystal.b*10,7),
                    Math.Round(crystal.c*10,7),
                    Math.Round(crystal.alpha*180/Math.PI,7),
                    Math.Round(crystal.beta*180/Math.PI,7),
                    Math.Round(crystal.gamma*180/Math.PI,7),
                    s.CrystalSystemStr,
                    s.PointGroupHMStr,
                    s.SpaceGroupHMfullStr,
                    crystal.auth,
                    Crystal2.GetFullTitle(crystal.sect),
                    Crystal2.GetFullJournal(crystal.jour),
                    elementList,
                    d[0],
                    d[1],
                    d[2],
                    d[3],
                    d[4],
                    d[5],
                    d[6],
                    d[7]
            };
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            string filter = "";

            //名前
            if (checkBoxSearchName.Checked)
            {
                string[] str = textBoxSearchName.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (str.Length > 0)
                {
                    filter = "( ";
                    foreach (string s in str)
                        filter += $"ColumnName LIKE '*{s}*' AND ";
                    filter = filter.Remove(filter.Length - 4, 3) + ") AND ";
                }
            }

            //Reference
            if (checkBoxSearchRefference.Checked)
            {
                string[] str = textBoxSearchRefference.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (str.Length > 0)
                {

                    filter += "( ";
                    foreach (string s in str)
                        filter +=
                              $"( ColumnAuthor LIKE '*{s}*' OR ColumnTitle LIKE '*{s}*' OR ColumnJournal LIKE '*{s}*' ) AND ";
                    filter = filter.Remove(filter.Length - 4, 3) + " ) AND ";
                }
            }

            if (checkBoxSearchCrystalSystem.Checked)
                filter += $" ColumnCrystalSystem = '{comboBoxSearchCrystalSystem.Text}' AND ";


            //元素のためのフィルター文字列
            if (checkBoxSearchElements.Checked)
            {
                if (formPeriodicTable.textBoxQueryInclude.Text != "")
                {
                    filter += "(";
                    string[] str = formPeriodicTable.textBoxQueryInclude.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string elementNum in str)
                        filter += $"ColumnElementList Like '*{elementNum}*' AND ";
                    filter = filter.Remove(filter.Length - 4, 4) + " ) AND ";
                }

                if (formPeriodicTable.textBoxQueryExclude.Text != "")
                {
                    filter += "( NOT(";
                    string[] str = formPeriodicTable.textBoxQueryExclude.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string elementNum in str)
                        filter += $"ColumnElementList Like '*{elementNum}*' OR ";
                    filter = filter.Remove(filter.Length - 3, 3) + " )) AND ";
                }
            }

            //格子定数のフィルター
            if (checkBoxSearchCellParameter.Checked)
            {
                double LowerA = Convert.ToDouble(textBoxSearchCellA.Text) * (1 - (double)numericUpDownSearchCellLengthError.Value / 100);
                double UpperA = Convert.ToDouble(textBoxSearchCellA.Text) * (1 + (double)numericUpDownSearchCellLengthError.Value / 100);
                double LowerB = Convert.ToDouble(textBoxSearchCellB.Text) * (1 - (double)numericUpDownSearchCellLengthError.Value / 100);
                double UpperB = Convert.ToDouble(textBoxSearchCellB.Text) * (1 + (double)numericUpDownSearchCellLengthError.Value / 100);
                double LowerC = Convert.ToDouble(textBoxSearchCellC.Text) * (1 - (double)numericUpDownSearchCellLengthError.Value / 100);
                double UpperC = Convert.ToDouble(textBoxSearchCellC.Text) * (1 + (double)numericUpDownSearchCellLengthError.Value / 100);

                double LowerAlpha = (Convert.ToDouble(textBoxSearchCellAlpha.Text) - (double)numericUpDownSearchCellAngleError.Value);
                double UpperAlpha = Convert.ToDouble(textBoxSearchCellAlpha.Text) + (double)numericUpDownSearchCellAngleError.Value;
                double LowerBeta = Convert.ToDouble(textBoxSearchCellBeta.Text) - (double)numericUpDownSearchCellAngleError.Value;
                double UpperBeta = Convert.ToDouble(textBoxSearchCellBeta.Text) + (double)numericUpDownSearchCellAngleError.Value;
                double LowerGamma = Convert.ToDouble(textBoxSearchCellGamma.Text) - (double)numericUpDownSearchCellAngleError.Value;
                double UpperGamma = Convert.ToDouble(textBoxSearchCellGamma.Text) + (double)numericUpDownSearchCellAngleError.Value;
                filter += "(";
                if (LowerA != 0)
                    filter += $"ColumnA >{LowerA} AND ColumnA < {UpperA} AND ";
                if (LowerB != 0)
                    filter += $"ColumnB >{LowerB} AND ColumnB < {UpperB} AND ";
                if (LowerC != 0)
                    filter += $"ColumnC >{LowerC} AND ColumnC < {UpperC} AND ";

                filter += $"ColumnAlpha >{LowerAlpha} AND ColumnAlpha < {UpperAlpha} AND ";
                filter += $"ColumnBeta >{LowerBeta} AND ColumnBeta < {UpperBeta} AND ";
                filter += $"ColumnGamma >{LowerGamma} AND ColumnGamma < {UpperGamma}";

                filter += " ) AND ";
            }

            if (checkBoxDspacing.Checked)
            {
                double[] d = new double[3];
                for (int i = 0; i < 3; i++)
                    d[i] = 0;
                double[] err = new double[] { (double)numericUpDownD1err.Value / 100, (double)numericUpDownD2err.Value / 100, (double)numericUpDownD3err.Value / 100 };
                try
                {
                    if (checkBoxD1.Checked)
                        d[0] = Convert.ToDouble(textBoxD1.Text);
                    if (checkBoxD2.Checked)
                        d[1] = Convert.ToDouble(textBoxD2.Text);
                    if (checkBoxD3.Checked)
                        d[2] = Convert.ToDouble(textBoxD3.Text);
                }
                catch { }
                if (!(d[0] == 0 && d[1] == 0 && d[2] == 0))
                {
                    filter += "(";
                    for (int i = 0; i < 3; i++)
                        if (d[i] != 0)
                        {
                            string upper = (0.1 * d[i] * (1 + err[i])).ToString();
                            string lower = (0.1 * d[i] * (1 - err[i])).ToString();
                            filter += "(";
                            for (int j = 1; j < 9; j++)
                                filter += $"( ColumnD{j} >{lower} AND ColumnD{j} < {upper} ) OR ";
                            filter = filter.Remove(filter.Length - 3, 3) + ") AND ";
                        }

                    filter = filter.Remove(filter.Length - 4, 4) + ") AND ";
                }
            }

            if (filter != "")
                filter = filter.Remove(filter.Length - 4, 4);

            bindingSourceMain.Filter = filter;
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
                    if (filename.ToLower().EndsWith("cdb"))
                    {
                        var formatter = new BinaryFormatter();
                        fs.Close();//閉じる
                        var c = (Crystal2[])formatter.Deserialize(fs);
                        toolStripProgressBar.Maximum = c.Length;
                        for (int i = 0; i < c.Length; i++)
                        {
                            dataSet.Tables[0].Rows.Add(GetTabelRows(c[i]));
                            if (i > progressStep * 2 && i % progressStep == 0)
                                reportProgress(i, c.Length, stopwatch.ElapsedMilliseconds, "Loading database...");
                        }
                    }
                    else if (filename.ToLower().EndsWith("cdb2"))
                    {
                        var formatter = new BinaryFormatter();
                        var total = (int)formatter.Deserialize(fs);
                        for (int i = 0; i < total; i++)
                        {
                            var c = (Crystal2)formatter.Deserialize(fs);
                            dataSet.Tables[0].Rows.Add(GetTabelRows(c));

                            if (i > progressStep * 2 && i % progressStep == 0)
                                reportProgress(i, total, stopwatch.ElapsedMilliseconds, "Loading database...");
                        }
                    }
                    else if (filename.ToLower().EndsWith("cdb3"))
                    {
                        var flag = readByte(fs);
                        var total = readInt(fs); ;
                        //IProgress<(int, int, long, string)> ip = new Progress<(int, int, long, string)>(o => reportProgress(o));//IReport
                        //単一ファイルの場合でも、分割ファイルの場合でも使えるように、Actionを定義
                        var action = new Action<Stream>(f =>
                            {
                                while (f.Position < f.Length)
                                {
                                    var rows = deserialize<Crystal2[]>(f).Select(c => GetTabelRows(c)).ToArray();
                                    if (rows != null)
                                        try
                                        {
                                            rwlock.EnterWriteLock();
                                            foreach (var r in rows)
                                                dataSet.Tables[0].Rows.Add(r);
                                        }
                                        finally { rwlock.ExitWriteLock(); }
                                    ip.Report((dataSet.Tables[0].Rows.Count, total, stopwatch.ElapsedMilliseconds, "Loading database..."));
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
                    using (var fs = new FileStream(UserAppDataPath + "COD.cdb3", FileMode.Open))
                    {
                        if (new WebClient().DownloadData(new Uri(urlHeader + "COD.cdb3")).SequenceEqual(readAll(fs)))
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
                
                var wc = new WebClient[FileNum];
                var total = FileSizes.Sum();
                var current = new long[FileNum];
                var completedCount = 0;
                long n = 1;
                for (int i = 0; i < wc.Length; i++)
                {
                    wc[i] = new WebClient();
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

            var dialog = new SaveFileDialog() { Filter = "Database File[*.cdb3]|*.cdb3" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var failedFile = new List<string>();
                using (var fs = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    //最初、全結晶数はわからないので、取りあえず4byte確保しておく
                    fs.Write(new byte[4], 0, 4);
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

                        var bytes = serialize(crystalList.ToArray());
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    //最後に個数を書き込む
                    fs.Position = 0;
                    fs.Write(BitConverter.GetBytes(fn.Count - failedFile.Count), 0, 4);
                }

                //失敗ファイルを書き込む
                using (var writer = new StreamWriter(dialog.FileName.Remove(dialog.FileName.Length - 5, 5) + ".txt"))
                    foreach (var s in failedFile)
                        writer.WriteLine(Path.GetFileNameWithoutExtension(s));
            }
        }

        #endregion


        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var row = bindingSourceMain.Current as DataRowView;
                if (row != null) { 
                var c2 = deserialize<Crystal2>(row[0]);
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

        private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e) => new FormAboutMe().ShowDialog();


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
            WaitDlg wd = new WaitDlg();
            wd.Location = new Point(this.Location.X + this.Width / 2 - wd.Width / 2, this.Location.Y + this.Height / 2 - wd.Height / 2);
            wd.Show(this);

            wd.progressBar.Maximum = list.Count;

            bindingNavigator1.Visible = dataGridViewMain.Visible = false;
            foreach (Crystal2 crystal in list)
            {
                wd.progressBar.Value++;
                dataSet.Tables[0].Rows.Add(GetTabelRows(crystal));
                Application.DoEvents();
            }
            bindingNavigator1.Visible = dataGridViewMain.Visible = true;
            wd.Close();
        }


        #endregion

        private void buttonAddCrystal_Click(object sender, EventArgs e)
        {
            crystalControl.GenerateCrystal();
            if (crystalControl.Crystal != null)
            {
                Crystal2 crystal2 = Crystal2.GetCrystal2(crystalControl.Crystal);
                dataSet.Tables[0].Rows.Add(GetTabelRows(crystal2));
            }
        }

        private void buttonChangeCrystal_Click(object sender, EventArgs e)
        {
            crystalControl.GenerateCrystal();
            Crystal2 crystal;
            if (crystalControl.Crystal != null)
            {
                int i = bindingSourceMain.IndexOf(bindingSourceMain.Current);
                if (i < 0)
                    buttonAddCrystal_Click(new object(), new EventArgs());

                crystal = Crystal2.GetCrystal2(crystalControl.Crystal);
                object[] o = GetTabelRows(crystal);
                for (int j = 0; j < o.Length; j++)
                    ((DataRowView)bindingSourceMain.Current).Row[j] = o[j];
            }
        }

        private void buttonDeleteCrystal_Click(object sender, EventArgs e) => bindingSourceMain.RemoveCurrent();

        private void textBoxSearchAllField_TextChanged(object sender, EventArgs e)
        {
            if (incrementalSearchToolStripMenuItem.Checked)
                buttonSearch_Click(sender, e);
        }

        private void toolTipToolStripMenuItem_Click(object sender, EventArgs e) => toolTip.Active = crystalControl.toolTip.Active = toolTipToolStripMenuItem.Checked;

        private void buttonPeriodicTable_Click(object sender, EventArgs e) => formPeriodicTable.Visible = true;

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
                        dataSet.Tables[0].Rows.Add(GetTabelRows(c));
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
                dataSet.Tables[0].Rows.Add(GetTabelRows(Crystal2.GetCrystal2(cry[i])));
            }
        }

        private void clearDatabaseToolStripMenuItem_Click(object sender, EventArgs e) => dataSet.Tables[0].Clear();

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

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

        private void FormMain_DragEnter(object sender, DragEventArgs e) => e.Effect = (e.Data.GetData(DataFormats.FileDrop) != null) ? DragDropEffects.Copy : DragDropEffects.None;

        private void helpwebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://pmsl.planet.sci.kobe-u.ac.jp/~seto/software/CSManager/CSManagerHelp.html");
            }
            catch { }
        }

        private void checkBoxDspacing_CheckedChanged(object sender, EventArgs e) => groupBoxDspacing.Enabled = checkBoxDspacing.Checked;

        private void checkBoxD1_CheckedChanged(object sender, EventArgs e) => textBoxD1.Enabled = numericUpDownD1err.Enabled = checkBoxD1.Checked;

        private void checkBoxD2_CheckedChanged(object sender, EventArgs e) => textBoxD2.Enabled = numericUpDownD2err.Enabled = checkBoxD2.Checked;

        private void checkBoxD3_CheckedChanged(object sender, EventArgs e) => textBoxD3.Enabled = numericUpDownD3err.Enabled = checkBoxD3.Checked;


        private void hintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialDialog.Visible = true;
            initialDialog.ShowProgressBar = false;
            initialDialog.Text = "Hint";
        }


        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e) => bindingSourceMain.RemoveCurrent();



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
                        MessageBox.Show("Failed update check. Server may be down. Access https://github.com/seto77/CSManager/releases/latest");
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

        private void increaseToolStripMenuItem_Click(object sender, EventArgs e) => dataGridViewMain.Font = new Font(dataGridViewMain.Font.FontFamily, dataGridViewMain.Font.Size * 1.1f);

        private void decreaseToolStripMenuItem_Click(object sender, EventArgs e) => dataGridViewMain.Font = new Font(dataGridViewMain.Font.FontFamily, dataGridViewMain.Font.Size * 0.9f);

        private void toolStripMenuItemShowFileName_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(((Crystal2)(((DataRowView)bindingSourceMain.Current).Row[0])).fileName);
            }
            catch { }
        }

        private void compressAndSplitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (var fs = new FileStream(dlg.FileName, FileMode.Open))
                {
                    var size = 25000000;
                    for (int n = 0; true; n++)
                    {
                        var buffer = new byte[fs.Length - fs.Position > size ? size : fs.Length - fs.Position];
                        if (buffer.Length == 0)
                            break;
                        fs.Read(buffer, 0, buffer.Length);
                        using (var temp = new FileStream(dlg.FileName + "." + n.ToString("000"), FileMode.CreateNew))
                        {
                            temp.Write(buffer, 0, buffer.Length);
                            temp.Flush();
                            temp.Close();
                        }
                    }
                }
            }
        }
    }
}