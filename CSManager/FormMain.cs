using Crystallography;
using Crystallography.Controls;
using Microsoft.Win32;
using SharpCompress.Archives;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProtoBuf;
using ProtoBuf.Meta;
using System.Net;

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
        protected override void WndProc(ref Message msg)
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
        bool skipEvent { get; set; } = false;

        WaitDlg initialDialog;


        public FormMain()
        {
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\CSManager");
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


        private void FormMain_Load(object sender, EventArgs e)
        {
            //#if !DEBUG
            //           Ngen.Compile(new string[] { "Crystallography.dll", "Crystallography.Control.dll", "CSManager.exe" });
            //#endif



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

            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

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

            //ユーザーパスにxmlファイルをコピー
            File.Copy("StdDB.cdb3", UserAppDataPath + "StdDB.cdb3", true);
            Directory.Delete(Application.UserAppDataPath, true);
            if (!File.Exists(UserAppDataPath + "CSManagerSetup.msi"))
                File.Delete(UserAppDataPath + "CSManagerSetup.msi");

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
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\CSManager");
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
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\CSManager");
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

        private void textBoxNumOnly_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < '.' || e.KeyChar > '9') && e.KeyChar != '\b' && e.KeyChar != 3 && e.KeyChar != 22)
                e.Handled = true;
        }


        public object[] GetTabelRows(Crystal2 crystal)
        {
            Symmetry s = SymmetryStatic.Get_Symmetry(crystal.sym);
            string elementList = "";
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
                    crystal,
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
                        filter += "ColumnName LIKE '*" + s + "*' AND ";
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
                              "( ColumnAuthor LIKE '*" + s + "*' OR "
                            + "ColumnTitle LIKE '*" + s + "*' OR "
                            + "ColumnJournal LIKE '*" + s + "*' ) AND ";
                    filter = filter.Remove(filter.Length - 4, 3) + " ) AND ";
                }
            }

            if (checkBoxSearchCrystalSystem.Checked)
                filter += " ColumnCrystalSystem = '" + comboBoxSearchCrystalSystem.Text + "' AND ";


            //元素のためのフィルター文字列
            if (checkBoxSearchElements.Checked)
            {
                if (formPeriodicTable.textBoxQueryInclude.Text != "")
                {
                    filter += "(";
                    string[] str = formPeriodicTable.textBoxQueryInclude.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string elementNum in str)
                        filter += "ColumnElementList Like '*" + elementNum + "*' AND ";
                    filter = filter.Remove(filter.Length - 4, 4) + " ) AND ";
                }

                if (formPeriodicTable.textBoxQueryExclude.Text != "")
                {
                    filter += "( NOT(";
                    string[] str = formPeriodicTable.textBoxQueryExclude.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string elementNum in str)
                        filter += "ColumnElementList Like '*" + elementNum + "*' OR ";
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
                    filter += "ColumnA >" + LowerA.ToString() + " AND ColumnA < " + UpperA.ToString() + " AND ";
                if (LowerB != 0)
                    filter += "ColumnB >" + LowerB.ToString() + " AND ColumnB < " + UpperB.ToString() + " AND ";
                if (LowerC != 0)
                    filter += "ColumnC >" + LowerC.ToString() + " AND ColumnC < " + UpperC.ToString() + " AND ";

                filter += "ColumnAlpha >" + LowerAlpha.ToString() + " AND ColumnAlpha < " + UpperAlpha.ToString() + " AND ";
                filter += "ColumnBeta >" + LowerBeta.ToString() + " AND ColumnBeta < " + UpperBeta.ToString() + " AND ";
                filter += "ColumnGamma >" + LowerGamma.ToString() + " AND ColumnGamma < " + UpperGamma.ToString();

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
                                filter += "( ColumnD" + j.ToString() + " >" + lower + " AND ColumnD" + j.ToString() + " < " + upper + " ) OR ";
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


        private void readDatabase(string filename)
        {
            stopwatch.Restart();
            int progressStep = 500;
            statusStrip.Visible = true;
            this.bindingSourceMain.DataMember = "";
            using (Stream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                if (filename.ToLower().EndsWith("cdb"))
                {
                    var formatter = new BinaryFormatter();
                    Crystal2[] c = (Crystal2[])formatter.Deserialize(fs);
                    fs.Close();//閉じる
                    toolStripProgressBar.Maximum = c.Length;
                    for (int i = 0; i < c.Length; i++)
                    {
                        dataSet.Tables[0].Rows.Add(GetTabelRows(c[i]));
                        if (i > progressStep * 2 && i % progressStep == 0)
                            reportProgress(i, c.Length, stopwatch, "Loading database...");
                    }
                }
                else if (filename.ToLower().EndsWith("cdb2"))
                {
                    var formatter = new BinaryFormatter();
                    var total = (int)formatter.Deserialize(fs);
                    for (int i = 0; i < total; i++)
                    {
                        Crystal2 c = (Crystal2)formatter.Deserialize(fs);
                        dataSet.Tables[0].Rows.Add(GetTabelRows(c));

                        if (i > progressStep * 2 && i % progressStep == 0)
                            reportProgress(i, total, stopwatch, "Loading database...");
                    }
                }
                else if (filename.ToLower().EndsWith("cdb3"))
                {
                    var total = BitConverter.ToInt32(new[] { (byte)fs.ReadByte(), (byte)fs.ReadByte(), (byte)fs.ReadByte(), (byte)fs.ReadByte() }, 0);
                    int i = 0;
                    foreach(var r in Serializer.DeserializeItems<Crystal2>(fs, PrefixStyle.Fixed32, 1).AsParallel().Select(c => GetTabelRows(c))) { 
                        dataSet.Tables[0].Rows.Add(r);
                        if (i++ > progressStep * 2 && i % progressStep == 0)
                            reportProgress(i, total, stopwatch, "Loading database...");
                    }
                }
                else
                    return;
            }
            toolStripStatusLabel.Text = "Toatal loading time: " + (stopwatch.ElapsedMilliseconds / 1000.0).ToString("f1") + " sec.";
            bindingSourceMain.DataMember = "dataTable";
        }

        private void saveDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region
            /*var dialog = new SaveFileDialog();
            dialog.Filter = "Database File[*.cdb2]|*.cdb2";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                WaitDlg wd = new WaitDlg();
                wd.Location = new Point(this.Location.X + this.Width / 2 - wd.Width / 2, this.Location.Y + this.Height / 2 - wd.Height / 2);
                wd.Show(this);
                wd.Text = "Now saving database... wait a few minutes";
                wd.progressBar.Maximum = dataSet.Tables[0].Rows.Count;

                using (Stream stream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, dataSet.Tables[0].Rows.Count);
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();

                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        formatter.Serialize(stream, ((DataRowView)bindingSourceMain[i]).Row[0]);
                        if (i > 1000 && i % 50 == 0)
                        {
                            wd.progressBar.Value += 50;
                            double remain = ((double)sw.ElapsedMilliseconds / i) * (dataSet.Tables[0].Rows.Count - i) / 1000;
                            wd.Text = "Now saving database... wait about " + remain.ToString("f0") + " sec.";
                            Application.DoEvents();
                        }
                    }
                }

                wd.Close();
            }*/
            #endregion

            int progressStep = 500;
            var dialog = new SaveFileDialog();
            dialog.Filter = "Database File[*.cdb3]|*.cdb3";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (var fs = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    var total = dataSet.Tables[0].Rows.Count;
                    fs.Write(BitConverter.GetBytes(total), 0, 4);
                    stopwatch.Restart();
                    for (int i = 0; i < total; i++)
                    {
                        Serializer.SerializeWithLengthPrefix(fs, (Crystal2)((DataRowView)bindingSourceMain[i]).Row[0], PrefixStyle.Fixed32);
                        if (i > progressStep * 2 && i % progressStep == 0)
                            reportProgress(i, total, stopwatch, "Saving database...");
                    }
                    toolStripStatusLabel.Text = "Total saving time: " + (stopwatch.ElapsedMilliseconds / 1000.0).ToString("f2") + " sec.";
                }
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                crystalControl.Crystal = Crystal2.GetCrystal((Crystal2)((DataRowView)bindingSourceMain.Current).Row[0]);
            }
            catch
            {
                return;
            }

            if (crystalControl.Crystal == null)
                return;

            try
            {
                if (crystalControl.Crystal != null)
                    Clipboard.SetDataObject((Crystal2)((DataRowView)bindingSourceMain.Current).Row[0]);
            }
            catch { return; }
        }

        private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAboutMe formAboutMe = new FormAboutMe();
            formAboutMe.ShowDialog();
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


        private void developperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAllImport();
        }


        //ここから
        object lockObj = new object();
        private async void GetAllImport()
        {
            statusStrip.Visible = true;

            ParallelOptions p = new ParallelOptions();
#if DEBUG
            //p.MaxDegreeOfParallelism = 8;   
#endif

            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = "D:\\Users\\seto\\Documents\\研究\\CrystallographyData";
            if (dlg.ShowDialog() != DialogResult.OK) return;
            System.IO.DirectoryInfo current = new DirectoryInfo(dlg.SelectedPath);
            List<string> fn = new List<string>();

            if (File.Exists(dlg.SelectedPath + "\\failedList.txt"))
            {
                StreamReader sr = new StreamReader(dlg.SelectedPath + "\\failedList.txt");
                string s = "";
                while ((s = sr.ReadLine()) != null)
                    fn.Add(dlg.SelectedPath + "\\" + s);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Also search subdirectory?", "Serch option", MessageBoxButtons.YesNoCancel);
                if (dr == System.Windows.Forms.DialogResult.Cancel) return;
                await Task.Run(() =>
                 {
                     foreach (System.IO.FileInfo file in current.GetFiles("*", dr == System.Windows.Forms.DialogResult.Yes ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))  // ファイルの一覧表示
                         if (file.FullName.EndsWith("amc") || file.FullName.EndsWith("cif"))
                             fn.Add(file.FullName);
                 });
            }

            toolStripProgressBar.Maximum = fn.Count;

            var context = SynchronizationContext.Current;
            var dialog = new SaveFileDialog();
            dialog.Filter = "Database File[*.cdb2]|*.cdb2";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                stopwatch.Restart();
                var failedFile = new List<string>();
                await Task.Run(() =>
                {
                    using (Stream stream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(stream, (int)0);

                        var division = 2000;//分割単位

                        var c = new Crystal[division];
                        var c2 = new Crystal2[division];
                        for (int i = 0; i < fn.Count; i += division)
                        {
                            int counter = 0;
                            Parallel.For(i, i + division < fn.Count ? i + division : fn.Count, p, j =>
                            {
                                try
                                {
                                    c[j - i] = ConvertCrystalData.ConvertToCrystal(fn[j]);
                                    if (c[j - i] == null)
                                        c2[j - i] = null;
                                    else
                                    {
                                        c2[j - i] = c[j - i].ToCrystal2();
                                        c2[j - i].fileName = fn[j].Substring(fn[j].LastIndexOf("\\") + 1);
                                    }
                                }
                                catch { c2[j - i] = null; }

                                if (j % 100 == 0)
                                    lock (lockObj)
                                    {
                                        counter += 100;
                                        context.Post(reportProgress =>  //--- UIに同期させて通知
                                        {
                                            double remain = ((double)stopwatch.ElapsedMilliseconds / (i + counter)) * (fn.Count - i - counter) / 1000;
                                            toolStripProgressBar.Value = Math.Min(i + counter, toolStripProgressBar.Maximum);
                                            toolStripStatusLabel.Text = "Success: " + (toolStripProgressBar.Value - failedFile.Count).ToString() +
                                        ".  Failure: " + failedFile.Count.ToString() + ".  Remain: " + (fn.Count - i - counter).ToString() + ".  Wait about " + remain.ToString("f0") + " sec.";
                                        }, null);  //--- ロックしてインクリメント
                                    }

                            });
                            for (int j = 0; j < c2.Length && i + j < fn.Count; j++)
                            {
                                if (c2[j] != null)
                                    formatter.Serialize(stream, c2[j]);
                                else
                                    failedFile.Add(fn[i + j].Substring(fn[i + j].LastIndexOf("\\") + 1));
                            }

                        }
                        stream.Position = 0;
                        formatter.Serialize(stream, fn.Count - failedFile.Count);

                    }
                }
                );
                using (StreamWriter writer = new StreamWriter(dialog.FileName.Remove(dialog.FileName.Length - 5, 5) + ".txt"))
                {
                    foreach (var s in failedFile)
                    {
                        if (s.EndsWith("amc"))
                        {

                            using (StreamReader reader = new System.IO.StreamReader(dlg.SelectedPath + "\\" + s))
                            {
                                string str;
                                while ((str = reader.ReadLine()) != null)
                                {
                                    var split = str.Split(new[] { ' ' });
                                    if (double.TryParse(split[0], out double d))
                                    {
                                        writer.WriteLine(s + " " + str);
                                        break;
                                    }
                                }

                            }
                        }
                        else
                        {
                            writer.WriteLine(s);
                        }
                    }
                }

            }
            statusStrip.Visible = false;
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

        private void buttonDeleteCrystal_Click(object sender, EventArgs e)
        {
            bindingSourceMain.RemoveCurrent();
        }

        private void textBoxSearchAllField_TextChanged(object sender, EventArgs e)
        {
            if (incrementalSearchToolStripMenuItem.Checked)
                buttonSearch_Click(sender, e);
        }

        private void toolTipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolTip.Active = crystalControl.toolTip.Active = toolTipToolStripMenuItem.Checked;
        }

        private void buttonPeriodicTable_Click(object sender, EventArgs e)
        {
            formPeriodicTable.Visible = true;
        }

        private void toolStripMenuItemReadDefault1_Click(object sender, EventArgs e)
        {

            if (File.Exists(UserAppDataPath + "StdDB.cdb3"))
                readDatabase(UserAppDataPath + "StdDB.cdb3");
        }

      

        private void reportProgress(long current, long total, Stopwatch sw, string message, 
            int sleep = 0, bool showEllapsedTime = true, bool showRemainTime = true, int digit = 1)
        {
            if (skipEvent || current > total)
                return;
            skipEvent = true;

            toolStripProgressBar.Maximum = int.MaxValue;
            toolStripProgressBar.Value = (int)((double)current / total * toolStripProgressBar.Maximum);

            toolStripStatusLabel.Text = message;

            var ellapsedSec = sw.ElapsedMilliseconds/1000.0;
            if (showEllapsedTime)
                toolStripStatusLabel.Text += " Elappsed time: " + ellapsedSec.ToString("f" + digit.ToString()) + " sec.";
            if (showRemainTime)
            {
                var remain = ellapsedSec / current * (total - current);
                toolStripStatusLabel.Text += " Remaining time: " + remain.ToString("f" + digit.ToString()) + " sec.";
            }
            
            Application.DoEvents();
            if (sleep != 0)
                Thread.Sleep(sleep);
            skipEvent = false;
        }
        
        private async void toolStripMenuItemReadDefault2_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = true;
            if (File.Exists(UserAppDataPath + "COD.cdb3") && new FileInfo(UserAppDataPath + "COD.cdb3").Length == Version.COD_FileSize)
            {
                readDatabase(UserAppDataPath + "COD.cdb3");
                return;
            }
            else
            {
                string message = File.Exists(UserAppDataPath + "COD.cdb3") ?
                    "New COD database is availble. Do you download it now ?" :
                    "COD database is not yet downloaded. Do you try it now ?";

                if (MessageBox.Show(message, "Download COD", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //分割ファイルをダウンロードする
                    stopwatch.Restart();
                    var wc = new WebClient[Version.COD_Division];
                    for (int i = 0; i < Version.COD_Division; i++)
                    {
                        wc[i] = new WebClient();
                        var filename = "cod.zip." +i.ToString("000");
                        wc[i].DownloadFileAsync(new Uri("https://github.com/seto77/CSManager/raw/master/COD/" + filename), UserAppDataPath + filename);
                    }

                    while (wc.Count(w => !w.IsBusy) != wc.Length)
                        reportProgress(wc.Count(w => !w.IsBusy), wc.Length, stopwatch, "Dowonloading database...", 100);

                    //結合
                    stopwatch.Restart();
                    using (var fs = new FileStream(UserAppDataPath + "cod.zip", FileMode.Create))
                    {
                        for (int i = 0; i < Version.COD_Division; i++)
                        {
                            using (var temp = new FileStream(UserAppDataPath + "cod.zip." + i.ToString("000"), FileMode.Open))
                            {
                                var buffer = new byte[temp.Length];
                                temp.Read(buffer, 0, buffer.Length);
                                fs.Write(buffer, 0, buffer.Length);
                            }
                            fs.Flush();
                            File.Delete(UserAppDataPath + "cod.zip." + i.ToString("000"));
                            reportProgress(i, Version.COD_Division, stopwatch, "Merging database... ");
                        }
                    }

                    //解凍
                    stopwatch.Restart();
                    using (var fs = new FileStream(UserAppDataPath + "cod.zip", FileMode.Open))
                    {
                        int n = 1;
                        var archive = ArchiveFactory.Open(fs);
                        archive.CompressedBytesRead += (s, ev) => 
                        {
                            if (n++ % 50 == 0)
                            {
                                reportProgress(ev.CompressedBytesRead, (s as IArchive).TotalUncompressSize, stopwatch, "Extracting database...");
                                n = 1;
                            }
                        };
                        using (var fs2 = new FileStream(UserAppDataPath + "cod.cdb3", FileMode.Create))
                            foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                                entry.WriteTo(fs2);
                    }

                    //読み込む
                    readDatabase(UserAppDataPath + "COD.cdb3");
                    //zipファイルを削除する
                    File.Delete(UserAppDataPath + "COD.zip");

                }

            }
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
            if (ProgramUpdates.CheckUpdate(Version.Software, Version.VersionAndDate))
                Close();
        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            englishToolStripMenuItem.Checked = ((ToolStripMenuItem)sender).Name.Contains("english");
            japaneseToolStripMenuItem.Checked = !englishToolStripMenuItem.Checked;
            Thread.CurrentThread.CurrentUICulture = englishToolStripMenuItem.Checked ? new System.Globalization.CultureInfo("en") : new System.Globalization.CultureInfo("ja");
            Language.Change(this);
        }

        private void increaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewMain.Font = new Font(dataGridViewMain.Font.FontFamily, dataGridViewMain.Font.Size * 1.1f);
        }

        private void decreaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewMain.Font = new Font(dataGridViewMain.Font.FontFamily, dataGridViewMain.Font.Size * 0.9f);

        }

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