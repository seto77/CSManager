namespace CSManager
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.densityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alphaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.betaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gammaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrystalSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PointGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpaceGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Authors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.journalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new CSManager.DataSet();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.crystalControl = new Crystallography.Controls.CrystalControl();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxSearchName = new System.Windows.Forms.CheckBox();
            this.textBoxSearchName = new System.Windows.Forms.TextBox();
            this.checkBoxSearchElements = new System.Windows.Forms.CheckBox();
            this.buttonPeriodicTable = new System.Windows.Forms.Button();
            this.checkBoxSearchRefference = new System.Windows.Forms.CheckBox();
            this.textBoxSearchRefference = new System.Windows.Forms.TextBox();
            this.checkBoxSearchCrystalSystem = new System.Windows.Forms.CheckBox();
            this.comboBoxSearchCrystalSystem = new System.Windows.Forms.ComboBox();
            this.checkBoxSearchCellParameter = new System.Windows.Forms.CheckBox();
            this.groupBoxCellParameter = new System.Windows.Forms.GroupBox();
            this.numericBoxCellGamma = new Crystallography.Controls.NumericBox();
            this.numericBoxCellAngleErr = new Crystallography.Controls.NumericBox();
            this.numericBoxCellLengthErr = new Crystallography.Controls.NumericBox();
            this.numericBoxCellC = new Crystallography.Controls.NumericBox();
            this.numericBoxCellBeta = new Crystallography.Controls.NumericBox();
            this.numericBoxCellAlpha = new Crystallography.Controls.NumericBox();
            this.numericBoxCellB = new Crystallography.Controls.NumericBox();
            this.numericBoxCellA = new Crystallography.Controls.NumericBox();
            this.checkBoxDspacing = new System.Windows.Forms.CheckBox();
            this.groupBoxDspacing = new System.Windows.Forms.GroupBox();
            this.checkBoxD3 = new System.Windows.Forms.CheckBox();
            this.numericBoxD3Err = new Crystallography.Controls.NumericBox();
            this.numericBoxD2Err = new Crystallography.Controls.NumericBox();
            this.numericBoxD1Err = new Crystallography.Controls.NumericBox();
            this.checkBoxD2 = new System.Windows.Forms.CheckBox();
            this.checkBoxD1 = new System.Windows.Forms.CheckBox();
            this.numericBoxD3 = new Crystallography.Controls.NumericBox();
            this.numericBoxD2 = new Crystallography.Controls.NumericBox();
            this.numericBoxD1 = new Crystallography.Controls.NumericBox();
            this.checkBoxDensity = new System.Windows.Forms.CheckBox();
            this.groupBoxDensity = new System.Windows.Forms.GroupBox();
            this.numericBoxDensity = new Crystallography.Controls.NumericBox();
            this.numericBoxDensityErr = new Crystallography.Controls.NumericBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemReadDefault1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemReadDefault2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.readDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemImportPDI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.debugFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressAndSplitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkDuplicatedFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importAllFileCIFOrAMCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recalculaeDensityFormulaAndDvaluesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.readDefaultDatabaseOnNextBootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incrementalSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.increaseFontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.increaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpwebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.japaneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBoxCellParameter.SuspendLayout();
            this.groupBoxDspacing.SuspendLayout();
            this.groupBoxDensity.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip);
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToDeleteRows = false;
            this.dataGridViewMain.AllowUserToResizeRows = false;
            this.dataGridViewMain.AutoGenerateColumns = false;
            this.dataGridViewMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle41.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F);
            dataGridViewCellStyle41.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle41.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle41;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.densityDataGridViewTextBoxColumn,
            this.formulaDataGridViewTextBoxColumn,
            this.aDataGridViewTextBoxColumn,
            this.bDataGridViewTextBoxColumn,
            this.cDataGridViewTextBoxColumn,
            this.alphaDataGridViewTextBoxColumn,
            this.betaDataGridViewTextBoxColumn,
            this.gammaDataGridViewTextBoxColumn,
            this.CrystalSystem,
            this.PointGroup,
            this.SpaceGroup,
            this.Authors,
            this.titleDataGridViewTextBoxColumn,
            this.journalDataGridViewTextBoxColumn});
            this.dataGridViewMain.DataSource = this.bindingSourceMain;
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle49.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F);
            dataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMain.DefaultCellStyle = dataGridViewCellStyle49;
            resources.ApplyResources(this.dataGridViewMain, "dataGridViewMain");
            this.dataGridViewMain.MultiSelect = false;
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle50.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F);
            dataGridViewCellStyle50.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle50.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle50.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle50;
            this.dataGridViewMain.RowHeadersVisible = false;
            this.dataGridViewMain.RowTemplate.Height = 21;
            this.dataGridViewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.toolTip.SetToolTip(this.dataGridViewMain, resources.GetString("dataGridViewMain.ToolTip"));
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "Name";
            resources.ApplyResources(this.ColumnName, "ColumnName");
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // densityDataGridViewTextBoxColumn
            // 
            this.densityDataGridViewTextBoxColumn.DataPropertyName = "Density";
            dataGridViewCellStyle42.Format = "N4";
            dataGridViewCellStyle42.NullValue = null;
            this.densityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle42;
            resources.ApplyResources(this.densityDataGridViewTextBoxColumn, "densityDataGridViewTextBoxColumn");
            this.densityDataGridViewTextBoxColumn.Name = "densityDataGridViewTextBoxColumn";
            this.densityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // formulaDataGridViewTextBoxColumn
            // 
            this.formulaDataGridViewTextBoxColumn.DataPropertyName = "Formula";
            resources.ApplyResources(this.formulaDataGridViewTextBoxColumn, "formulaDataGridViewTextBoxColumn");
            this.formulaDataGridViewTextBoxColumn.Name = "formulaDataGridViewTextBoxColumn";
            this.formulaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDataGridViewTextBoxColumn
            // 
            this.aDataGridViewTextBoxColumn.DataPropertyName = "A";
            dataGridViewCellStyle43.Format = "#.######";
            dataGridViewCellStyle43.NullValue = null;
            this.aDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle43;
            resources.ApplyResources(this.aDataGridViewTextBoxColumn, "aDataGridViewTextBoxColumn");
            this.aDataGridViewTextBoxColumn.Name = "aDataGridViewTextBoxColumn";
            this.aDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bDataGridViewTextBoxColumn
            // 
            this.bDataGridViewTextBoxColumn.DataPropertyName = "B";
            dataGridViewCellStyle44.Format = "#.######";
            dataGridViewCellStyle44.NullValue = null;
            this.bDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle44;
            resources.ApplyResources(this.bDataGridViewTextBoxColumn, "bDataGridViewTextBoxColumn");
            this.bDataGridViewTextBoxColumn.Name = "bDataGridViewTextBoxColumn";
            this.bDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cDataGridViewTextBoxColumn
            // 
            this.cDataGridViewTextBoxColumn.DataPropertyName = "C";
            dataGridViewCellStyle45.Format = "#.######";
            dataGridViewCellStyle45.NullValue = null;
            this.cDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle45;
            resources.ApplyResources(this.cDataGridViewTextBoxColumn, "cDataGridViewTextBoxColumn");
            this.cDataGridViewTextBoxColumn.Name = "cDataGridViewTextBoxColumn";
            this.cDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // alphaDataGridViewTextBoxColumn
            // 
            this.alphaDataGridViewTextBoxColumn.DataPropertyName = "Alpha";
            dataGridViewCellStyle46.Format = "#.####";
            dataGridViewCellStyle46.NullValue = null;
            this.alphaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle46;
            resources.ApplyResources(this.alphaDataGridViewTextBoxColumn, "alphaDataGridViewTextBoxColumn");
            this.alphaDataGridViewTextBoxColumn.Name = "alphaDataGridViewTextBoxColumn";
            this.alphaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // betaDataGridViewTextBoxColumn
            // 
            this.betaDataGridViewTextBoxColumn.DataPropertyName = "Beta";
            dataGridViewCellStyle47.Format = "#.####";
            dataGridViewCellStyle47.NullValue = null;
            this.betaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle47;
            resources.ApplyResources(this.betaDataGridViewTextBoxColumn, "betaDataGridViewTextBoxColumn");
            this.betaDataGridViewTextBoxColumn.Name = "betaDataGridViewTextBoxColumn";
            this.betaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gammaDataGridViewTextBoxColumn
            // 
            this.gammaDataGridViewTextBoxColumn.DataPropertyName = "Gamma";
            dataGridViewCellStyle48.Format = "#.####";
            dataGridViewCellStyle48.NullValue = null;
            this.gammaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle48;
            resources.ApplyResources(this.gammaDataGridViewTextBoxColumn, "gammaDataGridViewTextBoxColumn");
            this.gammaDataGridViewTextBoxColumn.Name = "gammaDataGridViewTextBoxColumn";
            this.gammaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CrystalSystem
            // 
            this.CrystalSystem.DataPropertyName = "CrystalSystem";
            resources.ApplyResources(this.CrystalSystem, "CrystalSystem");
            this.CrystalSystem.Name = "CrystalSystem";
            this.CrystalSystem.ReadOnly = true;
            // 
            // PointGroup
            // 
            this.PointGroup.DataPropertyName = "PointGroup";
            resources.ApplyResources(this.PointGroup, "PointGroup");
            this.PointGroup.Name = "PointGroup";
            this.PointGroup.ReadOnly = true;
            // 
            // SpaceGroup
            // 
            this.SpaceGroup.DataPropertyName = "SpaceGroup";
            resources.ApplyResources(this.SpaceGroup, "SpaceGroup");
            this.SpaceGroup.Name = "SpaceGroup";
            this.SpaceGroup.ReadOnly = true;
            // 
            // Authors
            // 
            this.Authors.DataPropertyName = "Authors";
            resources.ApplyResources(this.Authors, "Authors");
            this.Authors.Name = "Authors";
            this.Authors.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            resources.ApplyResources(this.titleDataGridViewTextBoxColumn, "titleDataGridViewTextBoxColumn");
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // journalDataGridViewTextBoxColumn
            // 
            this.journalDataGridViewTextBoxColumn.DataPropertyName = "Journal";
            resources.ApplyResources(this.journalDataGridViewTextBoxColumn, "journalDataGridViewTextBoxColumn");
            this.journalDataGridViewTextBoxColumn.Name = "journalDataGridViewTextBoxColumn";
            this.journalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSourceMain
            // 
            this.bindingSourceMain.DataMember = "DataTable";
            this.bindingSourceMain.DataSource = this.dataSet;
            this.bindingSourceMain.CurrentChanged += new System.EventHandler(this.bindingSourceMain_CurrentChanged);
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.crystalControl);
            this.splitContainer2.Panel1.Controls.Add(this.buttonChange);
            this.splitContainer2.Panel1.Controls.Add(this.buttonAdd);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer2.Panel2.Controls.Add(this.buttonSearch);
            // 
            // crystalControl
            // 
            this.crystalControl.AllowDrop = true;
            resources.ApplyResources(this.crystalControl, "crystalControl");
            this.crystalControl.CellConstants = ((System.ValueTuple<double, double, double, double, double, double>)(resources.GetObject("crystalControl.CellConstants")));
            this.crystalControl.Crystal = ((Crystallography.Crystal)(resources.GetObject("crystalControl.Crystal")));
            this.crystalControl.DefaultTabNumber = 0;
            this.crystalControl.Name = "crystalControl";
            this.crystalControl.ScatteringFactorVisible = false;
            this.crystalControl.SkipEvent = false;
            this.crystalControl.SymmetryInformationVisible = false;
            this.crystalControl.SymmetrySeriesNumber = 0;
            this.crystalControl.VisibleAtomTab = true;
            this.crystalControl.VisibleBasicInfoTab = true;
            this.crystalControl.VisibleBondsPolyhedraTab = true;
            this.crystalControl.VisibleBoundTab = false;
            this.crystalControl.VisibleElasticityTab = true;
            this.crystalControl.VisibleEOSTab = true;
            this.crystalControl.VisibleLatticePlaneTab = false;
            this.crystalControl.VisiblePolycrystallineTab = false;
            this.crystalControl.VisibleReferenceTab = true;
            this.crystalControl.VisibleStressStrainTab = false;
            // 
            // buttonChange
            // 
            this.buttonChange.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.buttonChange, "buttonChange");
            this.buttonChange.ForeColor = System.Drawing.Color.White;
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.UseVisualStyleBackColor = false;
            this.buttonChange.Click += new System.EventHandler(this.buttonChangeCrystal_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.buttonAdd, "buttonAdd");
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAddCrystal_Click);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.checkBoxSearchName);
            this.flowLayoutPanel1.Controls.Add(this.textBoxSearchName);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxSearchElements);
            this.flowLayoutPanel1.Controls.Add(this.buttonPeriodicTable);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxSearchRefference);
            this.flowLayoutPanel1.Controls.Add(this.textBoxSearchRefference);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxSearchCrystalSystem);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxSearchCrystalSystem);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxSearchCellParameter);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxCellParameter);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxDspacing);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxDspacing);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxDensity);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxDensity);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // checkBoxSearchName
            // 
            resources.ApplyResources(this.checkBoxSearchName, "checkBoxSearchName");
            this.checkBoxSearchName.Name = "checkBoxSearchName";
            this.checkBoxSearchName.UseVisualStyleBackColor = true;
            this.checkBoxSearchName.CheckedChanged += new System.EventHandler(this.textBoxSearchAllField_TextChanged);
            this.checkBoxSearchName.Click += new System.EventHandler(this.checkBoxSearch_CheckedChanged);
            // 
            // textBoxSearchName
            // 
            resources.ApplyResources(this.textBoxSearchName, "textBoxSearchName");
            this.textBoxSearchName.Name = "textBoxSearchName";
            this.textBoxSearchName.TextChanged += new System.EventHandler(this.textBoxSearchAllField_TextChanged);
            // 
            // checkBoxSearchElements
            // 
            resources.ApplyResources(this.checkBoxSearchElements, "checkBoxSearchElements");
            this.checkBoxSearchElements.Name = "checkBoxSearchElements";
            this.checkBoxSearchElements.UseVisualStyleBackColor = true;
            this.checkBoxSearchElements.CheckedChanged += new System.EventHandler(this.textBoxSearchAllField_TextChanged);
            this.checkBoxSearchElements.Click += new System.EventHandler(this.checkBoxSearch_CheckedChanged);
            // 
            // buttonPeriodicTable
            // 
            resources.ApplyResources(this.buttonPeriodicTable, "buttonPeriodicTable");
            this.buttonPeriodicTable.Name = "buttonPeriodicTable";
            this.buttonPeriodicTable.UseVisualStyleBackColor = true;
            this.buttonPeriodicTable.Click += new System.EventHandler(this.buttonPeriodicTable_Click);
            // 
            // checkBoxSearchRefference
            // 
            resources.ApplyResources(this.checkBoxSearchRefference, "checkBoxSearchRefference");
            this.checkBoxSearchRefference.Name = "checkBoxSearchRefference";
            this.checkBoxSearchRefference.UseVisualStyleBackColor = true;
            this.checkBoxSearchRefference.CheckedChanged += new System.EventHandler(this.textBoxSearchAllField_TextChanged);
            this.checkBoxSearchRefference.Click += new System.EventHandler(this.checkBoxSearch_CheckedChanged);
            // 
            // textBoxSearchRefference
            // 
            resources.ApplyResources(this.textBoxSearchRefference, "textBoxSearchRefference");
            this.textBoxSearchRefference.Name = "textBoxSearchRefference";
            this.textBoxSearchRefference.TextChanged += new System.EventHandler(this.textBoxSearchAllField_TextChanged);
            // 
            // checkBoxSearchCrystalSystem
            // 
            resources.ApplyResources(this.checkBoxSearchCrystalSystem, "checkBoxSearchCrystalSystem");
            this.checkBoxSearchCrystalSystem.Name = "checkBoxSearchCrystalSystem";
            this.checkBoxSearchCrystalSystem.UseVisualStyleBackColor = true;
            this.checkBoxSearchCrystalSystem.CheckedChanged += new System.EventHandler(this.textBoxSearchAllField_TextChanged);
            this.checkBoxSearchCrystalSystem.Click += new System.EventHandler(this.checkBoxSearch_CheckedChanged);
            // 
            // comboBoxSearchCrystalSystem
            // 
            this.comboBoxSearchCrystalSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxSearchCrystalSystem, "comboBoxSearchCrystalSystem");
            this.comboBoxSearchCrystalSystem.Items.AddRange(new object[] {
            resources.GetString("comboBoxSearchCrystalSystem.Items"),
            resources.GetString("comboBoxSearchCrystalSystem.Items1"),
            resources.GetString("comboBoxSearchCrystalSystem.Items2"),
            resources.GetString("comboBoxSearchCrystalSystem.Items3"),
            resources.GetString("comboBoxSearchCrystalSystem.Items4"),
            resources.GetString("comboBoxSearchCrystalSystem.Items5"),
            resources.GetString("comboBoxSearchCrystalSystem.Items6"),
            resources.GetString("comboBoxSearchCrystalSystem.Items7")});
            this.comboBoxSearchCrystalSystem.Name = "comboBoxSearchCrystalSystem";
            // 
            // checkBoxSearchCellParameter
            // 
            resources.ApplyResources(this.checkBoxSearchCellParameter, "checkBoxSearchCellParameter");
            this.checkBoxSearchCellParameter.Name = "checkBoxSearchCellParameter";
            this.checkBoxSearchCellParameter.UseVisualStyleBackColor = true;
            this.checkBoxSearchCellParameter.Click += new System.EventHandler(this.checkBoxSearch_CheckedChanged);
            // 
            // groupBoxCellParameter
            // 
            this.groupBoxCellParameter.Controls.Add(this.numericBoxCellGamma);
            this.groupBoxCellParameter.Controls.Add(this.numericBoxCellAngleErr);
            this.groupBoxCellParameter.Controls.Add(this.numericBoxCellLengthErr);
            this.groupBoxCellParameter.Controls.Add(this.numericBoxCellC);
            this.groupBoxCellParameter.Controls.Add(this.numericBoxCellBeta);
            this.groupBoxCellParameter.Controls.Add(this.numericBoxCellAlpha);
            this.groupBoxCellParameter.Controls.Add(this.numericBoxCellB);
            this.groupBoxCellParameter.Controls.Add(this.numericBoxCellA);
            resources.ApplyResources(this.groupBoxCellParameter, "groupBoxCellParameter");
            this.groupBoxCellParameter.Name = "groupBoxCellParameter";
            this.groupBoxCellParameter.TabStop = false;
            // 
            // numericBoxCellGamma
            // 
            resources.ApplyResources(this.numericBoxCellGamma, "numericBoxCellGamma");
            this.numericBoxCellGamma.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellGamma.Maximum = 179D;
            this.numericBoxCellGamma.Minimum = 1D;
            this.numericBoxCellGamma.Name = "numericBoxCellGamma";
            this.numericBoxCellGamma.RadianValue = 1.5707963267948966D;
            this.numericBoxCellGamma.SkipEventDuringInput = false;
            this.numericBoxCellGamma.SmartIncrement = true;
            this.numericBoxCellGamma.ThonsandsSeparator = true;
            this.numericBoxCellGamma.Value = 90D;
            // 
            // numericBoxCellAngleErr
            // 
            resources.ApplyResources(this.numericBoxCellAngleErr, "numericBoxCellAngleErr");
            this.numericBoxCellAngleErr.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellAngleErr.DecimalPlaces = 1;
            this.numericBoxCellAngleErr.Maximum = 50D;
            this.numericBoxCellAngleErr.Minimum = 0D;
            this.numericBoxCellAngleErr.Name = "numericBoxCellAngleErr";
            this.numericBoxCellAngleErr.RadianValue = 0.052359877559829883D;
            this.numericBoxCellAngleErr.ShowUpDown = true;
            this.numericBoxCellAngleErr.SkipEventDuringInput = false;
            this.numericBoxCellAngleErr.ThonsandsSeparator = true;
            this.numericBoxCellAngleErr.UpDown_Increment = 0.5D;
            this.numericBoxCellAngleErr.Value = 3D;
            // 
            // numericBoxCellLengthErr
            // 
            resources.ApplyResources(this.numericBoxCellLengthErr, "numericBoxCellLengthErr");
            this.numericBoxCellLengthErr.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellLengthErr.DecimalPlaces = 1;
            this.numericBoxCellLengthErr.Maximum = 50D;
            this.numericBoxCellLengthErr.Minimum = 0D;
            this.numericBoxCellLengthErr.Name = "numericBoxCellLengthErr";
            this.numericBoxCellLengthErr.RadianValue = 0.052359877559829883D;
            this.numericBoxCellLengthErr.ShowUpDown = true;
            this.numericBoxCellLengthErr.SkipEventDuringInput = false;
            this.numericBoxCellLengthErr.ThonsandsSeparator = true;
            this.numericBoxCellLengthErr.UpDown_Increment = 0.5D;
            this.numericBoxCellLengthErr.Value = 3D;
            // 
            // numericBoxCellC
            // 
            resources.ApplyResources(this.numericBoxCellC, "numericBoxCellC");
            this.numericBoxCellC.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellC.Maximum = 100D;
            this.numericBoxCellC.Minimum = 0D;
            this.numericBoxCellC.Name = "numericBoxCellC";
            this.numericBoxCellC.SkipEventDuringInput = false;
            this.numericBoxCellC.SmartIncrement = true;
            this.numericBoxCellC.ThonsandsSeparator = true;
            // 
            // numericBoxCellBeta
            // 
            resources.ApplyResources(this.numericBoxCellBeta, "numericBoxCellBeta");
            this.numericBoxCellBeta.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellBeta.Maximum = 179D;
            this.numericBoxCellBeta.Minimum = 1D;
            this.numericBoxCellBeta.Name = "numericBoxCellBeta";
            this.numericBoxCellBeta.RadianValue = 1.5707963267948966D;
            this.numericBoxCellBeta.SkipEventDuringInput = false;
            this.numericBoxCellBeta.SmartIncrement = true;
            this.numericBoxCellBeta.ThonsandsSeparator = true;
            this.numericBoxCellBeta.Value = 90D;
            // 
            // numericBoxCellAlpha
            // 
            resources.ApplyResources(this.numericBoxCellAlpha, "numericBoxCellAlpha");
            this.numericBoxCellAlpha.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellAlpha.Maximum = 179D;
            this.numericBoxCellAlpha.Minimum = 1D;
            this.numericBoxCellAlpha.Name = "numericBoxCellAlpha";
            this.numericBoxCellAlpha.RadianValue = 1.5707963267948966D;
            this.numericBoxCellAlpha.SkipEventDuringInput = false;
            this.numericBoxCellAlpha.SmartIncrement = true;
            this.numericBoxCellAlpha.ThonsandsSeparator = true;
            this.numericBoxCellAlpha.Value = 90D;
            // 
            // numericBoxCellB
            // 
            resources.ApplyResources(this.numericBoxCellB, "numericBoxCellB");
            this.numericBoxCellB.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellB.Maximum = 100D;
            this.numericBoxCellB.Minimum = 0D;
            this.numericBoxCellB.Name = "numericBoxCellB";
            this.numericBoxCellB.SkipEventDuringInput = false;
            this.numericBoxCellB.SmartIncrement = true;
            this.numericBoxCellB.ThonsandsSeparator = true;
            // 
            // numericBoxCellA
            // 
            resources.ApplyResources(this.numericBoxCellA, "numericBoxCellA");
            this.numericBoxCellA.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellA.Maximum = 100D;
            this.numericBoxCellA.Minimum = 0D;
            this.numericBoxCellA.Name = "numericBoxCellA";
            this.numericBoxCellA.SkipEventDuringInput = false;
            this.numericBoxCellA.SmartIncrement = true;
            this.numericBoxCellA.ThonsandsSeparator = true;
            // 
            // checkBoxDspacing
            // 
            resources.ApplyResources(this.checkBoxDspacing, "checkBoxDspacing");
            this.checkBoxDspacing.Name = "checkBoxDspacing";
            this.checkBoxDspacing.UseVisualStyleBackColor = true;
            this.checkBoxDspacing.CheckedChanged += new System.EventHandler(this.checkBoxDspacing_CheckedChanged);
            this.checkBoxDspacing.Click += new System.EventHandler(this.checkBoxSearch_CheckedChanged);
            // 
            // groupBoxDspacing
            // 
            this.groupBoxDspacing.Controls.Add(this.checkBoxD3);
            this.groupBoxDspacing.Controls.Add(this.numericBoxD3Err);
            this.groupBoxDspacing.Controls.Add(this.numericBoxD2Err);
            this.groupBoxDspacing.Controls.Add(this.numericBoxD1Err);
            this.groupBoxDspacing.Controls.Add(this.checkBoxD2);
            this.groupBoxDspacing.Controls.Add(this.checkBoxD1);
            this.groupBoxDspacing.Controls.Add(this.numericBoxD3);
            this.groupBoxDspacing.Controls.Add(this.numericBoxD2);
            this.groupBoxDspacing.Controls.Add(this.numericBoxD1);
            resources.ApplyResources(this.groupBoxDspacing, "groupBoxDspacing");
            this.groupBoxDspacing.Name = "groupBoxDspacing";
            this.groupBoxDspacing.TabStop = false;
            // 
            // checkBoxD3
            // 
            resources.ApplyResources(this.checkBoxD3, "checkBoxD3");
            this.checkBoxD3.Name = "checkBoxD3";
            this.checkBoxD3.UseVisualStyleBackColor = true;
            this.checkBoxD3.CheckedChanged += new System.EventHandler(this.checkBoxD3_CheckedChanged);
            // 
            // numericBoxD3Err
            // 
            resources.ApplyResources(this.numericBoxD3Err, "numericBoxD3Err");
            this.numericBoxD3Err.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxD3Err.DecimalPlaces = 1;
            this.numericBoxD3Err.Maximum = 50D;
            this.numericBoxD3Err.Minimum = 0D;
            this.numericBoxD3Err.Name = "numericBoxD3Err";
            this.numericBoxD3Err.RadianValue = 0.052359877559829883D;
            this.numericBoxD3Err.ShowUpDown = true;
            this.numericBoxD3Err.SkipEventDuringInput = false;
            this.numericBoxD3Err.ThonsandsSeparator = true;
            this.numericBoxD3Err.UpDown_Increment = 0.5D;
            this.numericBoxD3Err.Value = 3D;
            // 
            // numericBoxD2Err
            // 
            resources.ApplyResources(this.numericBoxD2Err, "numericBoxD2Err");
            this.numericBoxD2Err.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxD2Err.DecimalPlaces = 1;
            this.numericBoxD2Err.Maximum = 50D;
            this.numericBoxD2Err.Minimum = 0D;
            this.numericBoxD2Err.Name = "numericBoxD2Err";
            this.numericBoxD2Err.RadianValue = 0.052359877559829883D;
            this.numericBoxD2Err.ShowUpDown = true;
            this.numericBoxD2Err.SkipEventDuringInput = false;
            this.numericBoxD2Err.ThonsandsSeparator = true;
            this.numericBoxD2Err.UpDown_Increment = 0.5D;
            this.numericBoxD2Err.Value = 3D;
            // 
            // numericBoxD1Err
            // 
            resources.ApplyResources(this.numericBoxD1Err, "numericBoxD1Err");
            this.numericBoxD1Err.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxD1Err.DecimalPlaces = 1;
            this.numericBoxD1Err.Maximum = 50D;
            this.numericBoxD1Err.Minimum = 0D;
            this.numericBoxD1Err.Name = "numericBoxD1Err";
            this.numericBoxD1Err.RadianValue = 0.052359877559829883D;
            this.numericBoxD1Err.ShowUpDown = true;
            this.numericBoxD1Err.SkipEventDuringInput = false;
            this.numericBoxD1Err.ThonsandsSeparator = true;
            this.numericBoxD1Err.UpDown_Increment = 0.5D;
            this.numericBoxD1Err.Value = 3D;
            // 
            // checkBoxD2
            // 
            resources.ApplyResources(this.checkBoxD2, "checkBoxD2");
            this.checkBoxD2.Name = "checkBoxD2";
            this.checkBoxD2.UseVisualStyleBackColor = true;
            this.checkBoxD2.CheckedChanged += new System.EventHandler(this.checkBoxD2_CheckedChanged);
            // 
            // checkBoxD1
            // 
            resources.ApplyResources(this.checkBoxD1, "checkBoxD1");
            this.checkBoxD1.Checked = true;
            this.checkBoxD1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxD1.Name = "checkBoxD1";
            this.checkBoxD1.UseVisualStyleBackColor = true;
            this.checkBoxD1.CheckedChanged += new System.EventHandler(this.checkBoxD1_CheckedChanged);
            // 
            // numericBoxD3
            // 
            resources.ApplyResources(this.numericBoxD3, "numericBoxD3");
            this.numericBoxD3.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxD3.DecimalPlaces = 2;
            this.numericBoxD3.Maximum = 100D;
            this.numericBoxD3.Minimum = 0D;
            this.numericBoxD3.Name = "numericBoxD3";
            this.numericBoxD3.SkipEventDuringInput = false;
            this.numericBoxD3.SmartIncrement = true;
            this.numericBoxD3.ThonsandsSeparator = true;
            // 
            // numericBoxD2
            // 
            resources.ApplyResources(this.numericBoxD2, "numericBoxD2");
            this.numericBoxD2.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxD2.DecimalPlaces = 2;
            this.numericBoxD2.Maximum = 100D;
            this.numericBoxD2.Minimum = 0D;
            this.numericBoxD2.Name = "numericBoxD2";
            this.numericBoxD2.SkipEventDuringInput = false;
            this.numericBoxD2.SmartIncrement = true;
            this.numericBoxD2.ThonsandsSeparator = true;
            // 
            // numericBoxD1
            // 
            resources.ApplyResources(this.numericBoxD1, "numericBoxD1");
            this.numericBoxD1.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxD1.DecimalPlaces = 2;
            this.numericBoxD1.Maximum = 100D;
            this.numericBoxD1.Minimum = 0D;
            this.numericBoxD1.Name = "numericBoxD1";
            this.numericBoxD1.SkipEventDuringInput = false;
            this.numericBoxD1.SmartIncrement = true;
            this.numericBoxD1.ThonsandsSeparator = true;
            // 
            // checkBoxDensity
            // 
            resources.ApplyResources(this.checkBoxDensity, "checkBoxDensity");
            this.checkBoxDensity.Name = "checkBoxDensity";
            this.checkBoxDensity.UseVisualStyleBackColor = true;
            this.checkBoxDensity.CheckedChanged += new System.EventHandler(this.textBoxSearchAllField_TextChanged);
            this.checkBoxDensity.Click += new System.EventHandler(this.checkBoxSearch_CheckedChanged);
            // 
            // groupBoxDensity
            // 
            this.groupBoxDensity.Controls.Add(this.numericBoxDensity);
            this.groupBoxDensity.Controls.Add(this.numericBoxDensityErr);
            resources.ApplyResources(this.groupBoxDensity, "groupBoxDensity");
            this.groupBoxDensity.Name = "groupBoxDensity";
            this.groupBoxDensity.TabStop = false;
            // 
            // numericBoxDensity
            // 
            resources.ApplyResources(this.numericBoxDensity, "numericBoxDensity");
            this.numericBoxDensity.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxDensity.DecimalPlaces = 3;
            this.numericBoxDensity.Maximum = 100D;
            this.numericBoxDensity.Minimum = 0D;
            this.numericBoxDensity.Name = "numericBoxDensity";
            this.numericBoxDensity.SkipEventDuringInput = false;
            this.numericBoxDensity.SmartIncrement = true;
            this.numericBoxDensity.ThonsandsSeparator = true;
            // 
            // numericBoxDensityErr
            // 
            resources.ApplyResources(this.numericBoxDensityErr, "numericBoxDensityErr");
            this.numericBoxDensityErr.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxDensityErr.DecimalPlaces = 1;
            this.numericBoxDensityErr.Maximum = 50D;
            this.numericBoxDensityErr.Minimum = 0D;
            this.numericBoxDensityErr.Name = "numericBoxDensityErr";
            this.numericBoxDensityErr.RadianValue = 0.052359877559829883D;
            this.numericBoxDensityErr.ShowUpDown = true;
            this.numericBoxDensityErr.SkipEventDuringInput = false;
            this.numericBoxDensityErr.ThonsandsSeparator = true;
            this.numericBoxDensityErr.UpDown_Increment = 0.5D;
            this.numericBoxDensityErr.Value = 3D;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.Chocolate;
            resources.ApplyResources(this.buttonSearch, "buttonSearch");
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Name = "buttonSearch";
            this.toolTip.SetToolTip(this.buttonSearch, resources.GetString("buttonSearch.ToolTip"));
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            resources.ApplyResources(this.toolStripProgressBar, "toolStripProgressBar");
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            resources.ApplyResources(this.toolStripStatusLabel, "toolStripStatusLabel");
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bindingSourceMain;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.BackColor = System.Drawing.Color.IndianRed;
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.bindingNavigatorDeleteItem, "bindingNavigatorDeleteItem");
            this.bindingNavigatorDeleteItem.ForeColor = System.Drawing.Color.White;
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            // 
            // bindingNavigatorPositionItem
            // 
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            resources.ApplyResources(this.bindingNavigatorSeparator2, "bindingNavigatorSeparator2");
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemReadDefault1,
            this.toolStripMenuItemReadDefault2,
            this.toolStripSeparator4,
            this.readDatabaseToolStripMenuItem,
            this.saveDatabaseToolStripMenuItem,
            this.clearDatabaseToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItemImport,
            this.toolStripMenuItemImportPDI,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem,
            this.toolStripSeparator6,
            this.debugFunctionsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // toolStripMenuItemReadDefault1
            // 
            this.toolStripMenuItemReadDefault1.Name = "toolStripMenuItemReadDefault1";
            resources.ApplyResources(this.toolStripMenuItemReadDefault1, "toolStripMenuItemReadDefault1");
            this.toolStripMenuItemReadDefault1.Click += new System.EventHandler(this.toolStripMenuItemReadDefault1_Click);
            // 
            // toolStripMenuItemReadDefault2
            // 
            this.toolStripMenuItemReadDefault2.Name = "toolStripMenuItemReadDefault2";
            resources.ApplyResources(this.toolStripMenuItemReadDefault2, "toolStripMenuItemReadDefault2");
            this.toolStripMenuItemReadDefault2.Click += new System.EventHandler(this.toolStripMenuItemReadDefault2_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // readDatabaseToolStripMenuItem
            // 
            this.readDatabaseToolStripMenuItem.Name = "readDatabaseToolStripMenuItem";
            resources.ApplyResources(this.readDatabaseToolStripMenuItem, "readDatabaseToolStripMenuItem");
            this.readDatabaseToolStripMenuItem.Click += new System.EventHandler(this.readDatabaseToolStripMenuItem_Click);
            // 
            // saveDatabaseToolStripMenuItem
            // 
            this.saveDatabaseToolStripMenuItem.Name = "saveDatabaseToolStripMenuItem";
            resources.ApplyResources(this.saveDatabaseToolStripMenuItem, "saveDatabaseToolStripMenuItem");
            this.saveDatabaseToolStripMenuItem.Click += new System.EventHandler(this.saveDatabaseToolStripMenuItem_Click);
            // 
            // clearDatabaseToolStripMenuItem
            // 
            this.clearDatabaseToolStripMenuItem.Name = "clearDatabaseToolStripMenuItem";
            resources.ApplyResources(this.clearDatabaseToolStripMenuItem, "clearDatabaseToolStripMenuItem");
            this.clearDatabaseToolStripMenuItem.Click += new System.EventHandler(this.clearDatabaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripMenuItemImport
            // 
            this.toolStripMenuItemImport.Name = "toolStripMenuItemImport";
            resources.ApplyResources(this.toolStripMenuItemImport, "toolStripMenuItemImport");
            this.toolStripMenuItemImport.Click += new System.EventHandler(this.toolStripMenuItemImport_Click);
            // 
            // toolStripMenuItemImportPDI
            // 
            this.toolStripMenuItemImportPDI.Name = "toolStripMenuItemImportPDI";
            resources.ApplyResources(this.toolStripMenuItemImportPDI, "toolStripMenuItemImportPDI");
            this.toolStripMenuItemImportPDI.Click += new System.EventHandler(this.toolStripMenuItemImportPDI_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // debugFunctionsToolStripMenuItem
            // 
            this.debugFunctionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compressAndSplitToolStripMenuItem,
            this.showIndexToolStripMenuItem,
            this.checkDuplicatedFileToolStripMenuItem1,
            this.importAllFileCIFOrAMCToolStripMenuItem,
            this.recalculaeDensityFormulaAndDvaluesToolStripMenuItem});
            this.debugFunctionsToolStripMenuItem.Name = "debugFunctionsToolStripMenuItem";
            resources.ApplyResources(this.debugFunctionsToolStripMenuItem, "debugFunctionsToolStripMenuItem");
            // 
            // compressAndSplitToolStripMenuItem
            // 
            this.compressAndSplitToolStripMenuItem.Name = "compressAndSplitToolStripMenuItem";
            resources.ApplyResources(this.compressAndSplitToolStripMenuItem, "compressAndSplitToolStripMenuItem");
            // 
            // showIndexToolStripMenuItem
            // 
            this.showIndexToolStripMenuItem.Name = "showIndexToolStripMenuItem";
            resources.ApplyResources(this.showIndexToolStripMenuItem, "showIndexToolStripMenuItem");
            this.showIndexToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemShowFileName_Click);
            // 
            // checkDuplicatedFileToolStripMenuItem1
            // 
            this.checkDuplicatedFileToolStripMenuItem1.Name = "checkDuplicatedFileToolStripMenuItem1";
            resources.ApplyResources(this.checkDuplicatedFileToolStripMenuItem1, "checkDuplicatedFileToolStripMenuItem1");
            this.checkDuplicatedFileToolStripMenuItem1.Click += new System.EventHandler(this.checkDuplicatedFileToolStripMenuItem_Click);
            // 
            // importAllFileCIFOrAMCToolStripMenuItem
            // 
            this.importAllFileCIFOrAMCToolStripMenuItem.Name = "importAllFileCIFOrAMCToolStripMenuItem";
            resources.ApplyResources(this.importAllFileCIFOrAMCToolStripMenuItem, "importAllFileCIFOrAMCToolStripMenuItem");
            this.importAllFileCIFOrAMCToolStripMenuItem.Click += new System.EventHandler(this.importAllCrystalsMenuItem_Click);
            // 
            // recalculaeDensityFormulaAndDvaluesToolStripMenuItem
            // 
            this.recalculaeDensityFormulaAndDvaluesToolStripMenuItem.Name = "recalculaeDensityFormulaAndDvaluesToolStripMenuItem";
            resources.ApplyResources(this.recalculaeDensityFormulaAndDvaluesToolStripMenuItem, "recalculaeDensityFormulaAndDvaluesToolStripMenuItem");
            this.recalculaeDensityFormulaAndDvaluesToolStripMenuItem.Click += new System.EventHandler(this.recalculateDensityFormulaAndDvaluesToolStripMenuItem_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTipToolStripMenuItem,
            this.toolStripSeparator2,
            this.readDefaultDatabaseOnNextBootToolStripMenuItem,
            this.incrementalSearchToolStripMenuItem,
            this.toolStripSeparator5,
            this.increaseFontSizeToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            resources.ApplyResources(this.optionToolStripMenuItem, "optionToolStripMenuItem");
            // 
            // toolTipToolStripMenuItem
            // 
            this.toolTipToolStripMenuItem.Checked = true;
            this.toolTipToolStripMenuItem.CheckOnClick = true;
            this.toolTipToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolTipToolStripMenuItem.Name = "toolTipToolStripMenuItem";
            resources.ApplyResources(this.toolTipToolStripMenuItem, "toolTipToolStripMenuItem");
            this.toolTipToolStripMenuItem.Click += new System.EventHandler(this.toolTipToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // readDefaultDatabaseOnNextBootToolStripMenuItem
            // 
            this.readDefaultDatabaseOnNextBootToolStripMenuItem.Checked = true;
            this.readDefaultDatabaseOnNextBootToolStripMenuItem.CheckOnClick = true;
            this.readDefaultDatabaseOnNextBootToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.readDefaultDatabaseOnNextBootToolStripMenuItem.Name = "readDefaultDatabaseOnNextBootToolStripMenuItem";
            resources.ApplyResources(this.readDefaultDatabaseOnNextBootToolStripMenuItem, "readDefaultDatabaseOnNextBootToolStripMenuItem");
            // 
            // incrementalSearchToolStripMenuItem
            // 
            this.incrementalSearchToolStripMenuItem.CheckOnClick = true;
            this.incrementalSearchToolStripMenuItem.Name = "incrementalSearchToolStripMenuItem";
            resources.ApplyResources(this.incrementalSearchToolStripMenuItem, "incrementalSearchToolStripMenuItem");
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // increaseFontSizeToolStripMenuItem
            // 
            this.increaseFontSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.increaseToolStripMenuItem,
            this.decreaseToolStripMenuItem});
            this.increaseFontSizeToolStripMenuItem.Name = "increaseFontSizeToolStripMenuItem";
            resources.ApplyResources(this.increaseFontSizeToolStripMenuItem, "increaseFontSizeToolStripMenuItem");
            // 
            // increaseToolStripMenuItem
            // 
            this.increaseToolStripMenuItem.Name = "increaseToolStripMenuItem";
            resources.ApplyResources(this.increaseToolStripMenuItem, "increaseToolStripMenuItem");
            this.increaseToolStripMenuItem.Click += new System.EventHandler(this.increaseToolStripMenuItem_Click);
            // 
            // decreaseToolStripMenuItem
            // 
            this.decreaseToolStripMenuItem.Name = "decreaseToolStripMenuItem";
            resources.ApplyResources(this.decreaseToolStripMenuItem, "decreaseToolStripMenuItem");
            this.decreaseToolStripMenuItem.Click += new System.EventHandler(this.decreaseToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programUpdatesToolStripMenuItem,
            this.hintToolStripMenuItem,
            this.versionHistoryToolStripMenuItem,
            this.licenseToolStripMenuItem,
            this.helpwebToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // programUpdatesToolStripMenuItem
            // 
            this.programUpdatesToolStripMenuItem.Name = "programUpdatesToolStripMenuItem";
            resources.ApplyResources(this.programUpdatesToolStripMenuItem, "programUpdatesToolStripMenuItem");
            this.programUpdatesToolStripMenuItem.Click += new System.EventHandler(this.programUpdatesToolStripMenuItem_Click);
            // 
            // hintToolStripMenuItem
            // 
            this.hintToolStripMenuItem.Name = "hintToolStripMenuItem";
            resources.ApplyResources(this.hintToolStripMenuItem, "hintToolStripMenuItem");
            this.hintToolStripMenuItem.Click += new System.EventHandler(this.hintToolStripMenuItem_Click);
            // 
            // versionHistoryToolStripMenuItem
            // 
            this.versionHistoryToolStripMenuItem.Name = "versionHistoryToolStripMenuItem";
            resources.ApplyResources(this.versionHistoryToolStripMenuItem, "versionHistoryToolStripMenuItem");
            this.versionHistoryToolStripMenuItem.Click += new System.EventHandler(this.versionHistoryToolStripMenuItem_Click);
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            resources.ApplyResources(this.licenseToolStripMenuItem, "licenseToolStripMenuItem");
            this.licenseToolStripMenuItem.Click += new System.EventHandler(this.licenseToolStripMenuItem_Click);
            // 
            // helpwebToolStripMenuItem
            // 
            this.helpwebToolStripMenuItem.Name = "helpwebToolStripMenuItem";
            resources.ApplyResources(this.helpwebToolStripMenuItem, "helpwebToolStripMenuItem");
            this.helpwebToolStripMenuItem.Click += new System.EventHandler(this.helpwebToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.japaneseToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Checked = true;
            this.englishToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // japaneseToolStripMenuItem
            // 
            resources.ApplyResources(this.japaneseToolStripMenuItem, "japaneseToolStripMenuItem");
            this.japaneseToolStripMenuItem.Name = "japaneseToolStripMenuItem";
            this.japaneseToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonSearch;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBoxCellParameter.ResumeLayout(false);
            this.groupBoxDspacing.ResumeLayout(false);
            this.groupBoxDspacing.PerformLayout();
            this.groupBoxDensity.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.BindingSource bindingSourceMain;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox textBoxSearchRefference;
        private System.Windows.Forms.TextBox textBoxSearchName;
        private System.Windows.Forms.CheckBox checkBoxSearchCellParameter;
        public System.Windows.Forms.ComboBox comboBoxSearchCrystalSystem;
        private System.Windows.Forms.CheckBox checkBoxSearchName;
        private System.Windows.Forms.CheckBox checkBoxSearchRefference;
        private System.Windows.Forms.GroupBox groupBoxCellParameter;
        private System.Windows.Forms.CheckBox checkBoxSearchElements;
        private System.Windows.Forms.CheckBox checkBoxSearchCrystalSystem;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolTipToolStripMenuItem;
        public System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonPeriodicTable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReadDefault1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemImport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemImportPDI;
        private System.Windows.Forms.ToolStripMenuItem clearDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ToolStripMenuItem helpwebToolStripMenuItem;
        public Crystallography.Controls.CrystalControl crystalControl;
        private System.Windows.Forms.GroupBox groupBoxDspacing;
        private System.Windows.Forms.CheckBox checkBoxDspacing;
        private System.Windows.Forms.CheckBox checkBoxD1;
        private System.Windows.Forms.CheckBox checkBoxD3;
        private System.Windows.Forms.CheckBox checkBoxD2;
        private System.Windows.Forms.ToolStripMenuItem hintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReadDefault2;
        private System.Windows.Forms.ToolStripMenuItem readDefaultDatabaseOnNextBootToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem programUpdatesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem japaneseToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem incrementalSearchToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem increaseFontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem increaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decreaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugFunctionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressAndSplitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showIndexToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem checkDuplicatedFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importAllFileCIFOrAMCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
        private DataSet dataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn crystalSytemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn spaceGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authoursDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn densityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn alphaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn betaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gammaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrystalSystem;
        private System.Windows.Forms.DataGridViewTextBoxColumn PointGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpaceGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Authors;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn journalDataGridViewTextBoxColumn;
        private Crystallography.Controls.NumericBox numericBoxCellGamma;
        private Crystallography.Controls.NumericBox numericBoxCellAngleErr;
        private Crystallography.Controls.NumericBox numericBoxCellLengthErr;
        private Crystallography.Controls.NumericBox numericBoxCellC;
        private Crystallography.Controls.NumericBox numericBoxCellBeta;
        private Crystallography.Controls.NumericBox numericBoxCellAlpha;
        private Crystallography.Controls.NumericBox numericBoxCellB;
        private Crystallography.Controls.NumericBox numericBoxCellA;
        private Crystallography.Controls.NumericBox numericBoxD3Err;
        private Crystallography.Controls.NumericBox numericBoxD2Err;
        private Crystallography.Controls.NumericBox numericBoxD1Err;
        private Crystallography.Controls.NumericBox numericBoxD3;
        private Crystallography.Controls.NumericBox numericBoxD2;
        private Crystallography.Controls.NumericBox numericBoxD1;
        private System.Windows.Forms.CheckBox checkBoxDensity;
        private System.Windows.Forms.GroupBox groupBoxDensity;
        private Crystallography.Controls.NumericBox numericBoxDensity;
        private Crystallography.Controls.NumericBox numericBoxDensityErr;
        private System.Windows.Forms.ToolStripMenuItem recalculaeDensityFormulaAndDvaluesToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

