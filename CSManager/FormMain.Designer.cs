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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.checkBoxDspacing = new System.Windows.Forms.CheckBox();
            this.groupBoxDspacing = new System.Windows.Forms.GroupBox();
            this.checkBoxD3 = new System.Windows.Forms.CheckBox();
            this.checkBoxD2 = new System.Windows.Forms.CheckBox();
            this.checkBoxD1 = new System.Windows.Forms.CheckBox();
            this.checkBoxDensity = new System.Windows.Forms.CheckBox();
            this.groupBoxDensity = new System.Windows.Forms.GroupBox();
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
            this.crystalControl = new Crystallography.Controls.CrystalControl();
            this.numericBoxCellGamma = new Crystallography.Controls.NumericBox();
            this.numericBoxCellAngleErr = new Crystallography.Controls.NumericBox();
            this.numericBoxCellLengthErr = new Crystallography.Controls.NumericBox();
            this.numericBoxCellC = new Crystallography.Controls.NumericBox();
            this.numericBoxCellBeta = new Crystallography.Controls.NumericBox();
            this.numericBoxCellAlpha = new Crystallography.Controls.NumericBox();
            this.numericBoxCellB = new Crystallography.Controls.NumericBox();
            this.numericBoxCellA = new Crystallography.Controls.NumericBox();
            this.numericBoxD3Err = new Crystallography.Controls.NumericBox();
            this.numericBoxD2Err = new Crystallography.Controls.NumericBox();
            this.numericBoxD1Err = new Crystallography.Controls.NumericBox();
            this.numericBoxD3 = new Crystallography.Controls.NumericBox();
            this.numericBoxD2 = new Crystallography.Controls.NumericBox();
            this.numericBoxD1 = new Crystallography.Controls.NumericBox();
            this.numericBoxDensity = new Crystallography.Controls.NumericBox();
            this.numericBoxDensityErr = new Crystallography.Controls.NumericBox();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMain.DefaultCellStyle = dataGridViewCellStyle9;
            resources.ApplyResources(this.dataGridViewMain, "dataGridViewMain");
            this.dataGridViewMain.MultiSelect = false;
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
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
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.densityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Format = "#.######";
            dataGridViewCellStyle3.NullValue = null;
            this.aDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.aDataGridViewTextBoxColumn, "aDataGridViewTextBoxColumn");
            this.aDataGridViewTextBoxColumn.Name = "aDataGridViewTextBoxColumn";
            this.aDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bDataGridViewTextBoxColumn
            // 
            this.bDataGridViewTextBoxColumn.DataPropertyName = "B";
            dataGridViewCellStyle4.Format = "#.######";
            dataGridViewCellStyle4.NullValue = null;
            this.bDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.bDataGridViewTextBoxColumn, "bDataGridViewTextBoxColumn");
            this.bDataGridViewTextBoxColumn.Name = "bDataGridViewTextBoxColumn";
            this.bDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cDataGridViewTextBoxColumn
            // 
            this.cDataGridViewTextBoxColumn.DataPropertyName = "C";
            dataGridViewCellStyle5.Format = "#.######";
            dataGridViewCellStyle5.NullValue = null;
            this.cDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.cDataGridViewTextBoxColumn, "cDataGridViewTextBoxColumn");
            this.cDataGridViewTextBoxColumn.Name = "cDataGridViewTextBoxColumn";
            this.cDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // alphaDataGridViewTextBoxColumn
            // 
            this.alphaDataGridViewTextBoxColumn.DataPropertyName = "Alpha";
            dataGridViewCellStyle6.Format = "#.####";
            dataGridViewCellStyle6.NullValue = null;
            this.alphaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.alphaDataGridViewTextBoxColumn, "alphaDataGridViewTextBoxColumn");
            this.alphaDataGridViewTextBoxColumn.Name = "alphaDataGridViewTextBoxColumn";
            this.alphaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // betaDataGridViewTextBoxColumn
            // 
            this.betaDataGridViewTextBoxColumn.DataPropertyName = "Beta";
            dataGridViewCellStyle7.Format = "#.####";
            dataGridViewCellStyle7.NullValue = null;
            this.betaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.betaDataGridViewTextBoxColumn, "betaDataGridViewTextBoxColumn");
            this.betaDataGridViewTextBoxColumn.Name = "betaDataGridViewTextBoxColumn";
            this.betaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gammaDataGridViewTextBoxColumn
            // 
            this.gammaDataGridViewTextBoxColumn.DataPropertyName = "Gamma";
            dataGridViewCellStyle8.Format = "#.####";
            dataGridViewCellStyle8.NullValue = null;
            this.gammaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
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
            this.importAllFileCIFOrAMCToolStripMenuItem});
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
            // numericBoxCellGamma
            // 
            this.numericBoxCellGamma.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxCellGamma, "numericBoxCellGamma");
            this.numericBoxCellGamma.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellGamma.DecimalPlaces = -2;
            this.numericBoxCellGamma.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellGamma.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellGamma.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellGamma.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellGamma.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxCellGamma.Maximum = 179D;
            this.numericBoxCellGamma.Minimum = 1D;
            this.numericBoxCellGamma.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxCellGamma.MouseSpeed = 1D;
            this.numericBoxCellGamma.Multiline = false;
            this.numericBoxCellGamma.Name = "numericBoxCellGamma";
            this.numericBoxCellGamma.RadianValue = 1.5707963267948966D;
            this.numericBoxCellGamma.ReadOnly = false;
            this.numericBoxCellGamma.RestrictLimitValue = true;
            this.numericBoxCellGamma.ShowFraction = false;
            this.numericBoxCellGamma.ShowPositiveSign = false;
            this.numericBoxCellGamma.SkipEventDuringInput = false;
            this.numericBoxCellGamma.SmartIncrement = true;
            this.numericBoxCellGamma.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxCellGamma.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxCellGamma.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxCellGamma.ThonsandsSeparator = true;
            this.numericBoxCellGamma.UpDown_Increment = 1D;
            this.numericBoxCellGamma.Value = 90D;
            this.numericBoxCellGamma.WordWrap = true;
            // 
            // numericBoxCellAngleErr
            // 
            this.numericBoxCellAngleErr.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxCellAngleErr, "numericBoxCellAngleErr");
            this.numericBoxCellAngleErr.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellAngleErr.DecimalPlaces = 1;
            this.numericBoxCellAngleErr.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellAngleErr.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellAngleErr.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellAngleErr.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellAngleErr.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxCellAngleErr.Maximum = 50D;
            this.numericBoxCellAngleErr.Minimum = 0D;
            this.numericBoxCellAngleErr.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxCellAngleErr.MouseSpeed = 1D;
            this.numericBoxCellAngleErr.Multiline = false;
            this.numericBoxCellAngleErr.Name = "numericBoxCellAngleErr";
            this.numericBoxCellAngleErr.RadianValue = 0.052359877559829883D;
            this.numericBoxCellAngleErr.ReadOnly = false;
            this.numericBoxCellAngleErr.RestrictLimitValue = true;
            this.numericBoxCellAngleErr.ShowFraction = false;
            this.numericBoxCellAngleErr.ShowPositiveSign = false;
            this.numericBoxCellAngleErr.ShowUpDown = true;
            this.numericBoxCellAngleErr.SkipEventDuringInput = false;
            this.numericBoxCellAngleErr.SmartIncrement = false;
            this.numericBoxCellAngleErr.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxCellAngleErr.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxCellAngleErr.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxCellAngleErr.ThonsandsSeparator = true;
            this.numericBoxCellAngleErr.UpDown_Increment = 0.5D;
            this.numericBoxCellAngleErr.Value = 3D;
            this.numericBoxCellAngleErr.WordWrap = true;
            // 
            // numericBoxCellLengthErr
            // 
            this.numericBoxCellLengthErr.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxCellLengthErr, "numericBoxCellLengthErr");
            this.numericBoxCellLengthErr.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellLengthErr.DecimalPlaces = 1;
            this.numericBoxCellLengthErr.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellLengthErr.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellLengthErr.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellLengthErr.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellLengthErr.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxCellLengthErr.Maximum = 50D;
            this.numericBoxCellLengthErr.Minimum = 0D;
            this.numericBoxCellLengthErr.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxCellLengthErr.MouseSpeed = 1D;
            this.numericBoxCellLengthErr.Multiline = false;
            this.numericBoxCellLengthErr.Name = "numericBoxCellLengthErr";
            this.numericBoxCellLengthErr.RadianValue = 0.052359877559829883D;
            this.numericBoxCellLengthErr.ReadOnly = false;
            this.numericBoxCellLengthErr.RestrictLimitValue = true;
            this.numericBoxCellLengthErr.ShowFraction = false;
            this.numericBoxCellLengthErr.ShowPositiveSign = false;
            this.numericBoxCellLengthErr.ShowUpDown = true;
            this.numericBoxCellLengthErr.SkipEventDuringInput = false;
            this.numericBoxCellLengthErr.SmartIncrement = false;
            this.numericBoxCellLengthErr.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxCellLengthErr.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxCellLengthErr.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxCellLengthErr.ThonsandsSeparator = true;
            this.numericBoxCellLengthErr.UpDown_Increment = 0.5D;
            this.numericBoxCellLengthErr.Value = 3D;
            this.numericBoxCellLengthErr.WordWrap = true;
            // 
            // numericBoxCellC
            // 
            this.numericBoxCellC.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxCellC, "numericBoxCellC");
            this.numericBoxCellC.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellC.DecimalPlaces = -2;
            this.numericBoxCellC.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellC.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellC.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellC.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellC.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxCellC.Maximum = 100D;
            this.numericBoxCellC.Minimum = 0D;
            this.numericBoxCellC.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxCellC.MouseSpeed = 1D;
            this.numericBoxCellC.Multiline = false;
            this.numericBoxCellC.Name = "numericBoxCellC";
            this.numericBoxCellC.RadianValue = 0D;
            this.numericBoxCellC.ReadOnly = false;
            this.numericBoxCellC.RestrictLimitValue = true;
            this.numericBoxCellC.ShowFraction = false;
            this.numericBoxCellC.ShowPositiveSign = false;
            this.numericBoxCellC.SkipEventDuringInput = false;
            this.numericBoxCellC.SmartIncrement = true;
            this.numericBoxCellC.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxCellC.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxCellC.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxCellC.ThonsandsSeparator = true;
            this.numericBoxCellC.UpDown_Increment = 1D;
            this.numericBoxCellC.Value = 0D;
            this.numericBoxCellC.WordWrap = true;
            // 
            // numericBoxCellBeta
            // 
            this.numericBoxCellBeta.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxCellBeta, "numericBoxCellBeta");
            this.numericBoxCellBeta.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellBeta.DecimalPlaces = -2;
            this.numericBoxCellBeta.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellBeta.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellBeta.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellBeta.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellBeta.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxCellBeta.Maximum = 179D;
            this.numericBoxCellBeta.Minimum = 1D;
            this.numericBoxCellBeta.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxCellBeta.MouseSpeed = 1D;
            this.numericBoxCellBeta.Multiline = false;
            this.numericBoxCellBeta.Name = "numericBoxCellBeta";
            this.numericBoxCellBeta.RadianValue = 1.5707963267948966D;
            this.numericBoxCellBeta.ReadOnly = false;
            this.numericBoxCellBeta.RestrictLimitValue = true;
            this.numericBoxCellBeta.ShowFraction = false;
            this.numericBoxCellBeta.ShowPositiveSign = false;
            this.numericBoxCellBeta.SkipEventDuringInput = false;
            this.numericBoxCellBeta.SmartIncrement = true;
            this.numericBoxCellBeta.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxCellBeta.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxCellBeta.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxCellBeta.ThonsandsSeparator = true;
            this.numericBoxCellBeta.UpDown_Increment = 1D;
            this.numericBoxCellBeta.Value = 90D;
            this.numericBoxCellBeta.WordWrap = true;
            // 
            // numericBoxCellAlpha
            // 
            this.numericBoxCellAlpha.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxCellAlpha, "numericBoxCellAlpha");
            this.numericBoxCellAlpha.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellAlpha.DecimalPlaces = -2;
            this.numericBoxCellAlpha.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellAlpha.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellAlpha.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellAlpha.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellAlpha.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxCellAlpha.Maximum = 179D;
            this.numericBoxCellAlpha.Minimum = 1D;
            this.numericBoxCellAlpha.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxCellAlpha.MouseSpeed = 1D;
            this.numericBoxCellAlpha.Multiline = false;
            this.numericBoxCellAlpha.Name = "numericBoxCellAlpha";
            this.numericBoxCellAlpha.RadianValue = 1.5707963267948966D;
            this.numericBoxCellAlpha.ReadOnly = false;
            this.numericBoxCellAlpha.RestrictLimitValue = true;
            this.numericBoxCellAlpha.ShowFraction = false;
            this.numericBoxCellAlpha.ShowPositiveSign = false;
            this.numericBoxCellAlpha.SkipEventDuringInput = false;
            this.numericBoxCellAlpha.SmartIncrement = true;
            this.numericBoxCellAlpha.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxCellAlpha.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxCellAlpha.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxCellAlpha.ThonsandsSeparator = true;
            this.numericBoxCellAlpha.UpDown_Increment = 1D;
            this.numericBoxCellAlpha.Value = 90D;
            this.numericBoxCellAlpha.WordWrap = true;
            // 
            // numericBoxCellB
            // 
            this.numericBoxCellB.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxCellB, "numericBoxCellB");
            this.numericBoxCellB.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellB.DecimalPlaces = -2;
            this.numericBoxCellB.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellB.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellB.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellB.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellB.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxCellB.Maximum = 100D;
            this.numericBoxCellB.Minimum = 0D;
            this.numericBoxCellB.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxCellB.MouseSpeed = 1D;
            this.numericBoxCellB.Multiline = false;
            this.numericBoxCellB.Name = "numericBoxCellB";
            this.numericBoxCellB.RadianValue = 0D;
            this.numericBoxCellB.ReadOnly = false;
            this.numericBoxCellB.RestrictLimitValue = true;
            this.numericBoxCellB.ShowFraction = false;
            this.numericBoxCellB.ShowPositiveSign = false;
            this.numericBoxCellB.SkipEventDuringInput = false;
            this.numericBoxCellB.SmartIncrement = true;
            this.numericBoxCellB.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxCellB.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxCellB.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxCellB.ThonsandsSeparator = true;
            this.numericBoxCellB.UpDown_Increment = 1D;
            this.numericBoxCellB.Value = 0D;
            this.numericBoxCellB.WordWrap = true;
            // 
            // numericBoxCellA
            // 
            this.numericBoxCellA.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxCellA, "numericBoxCellA");
            this.numericBoxCellA.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellA.DecimalPlaces = -2;
            this.numericBoxCellA.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellA.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellA.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxCellA.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxCellA.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxCellA.Maximum = 100D;
            this.numericBoxCellA.Minimum = 0D;
            this.numericBoxCellA.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxCellA.MouseSpeed = 1D;
            this.numericBoxCellA.Multiline = false;
            this.numericBoxCellA.Name = "numericBoxCellA";
            this.numericBoxCellA.RadianValue = 0D;
            this.numericBoxCellA.ReadOnly = false;
            this.numericBoxCellA.RestrictLimitValue = true;
            this.numericBoxCellA.ShowFraction = false;
            this.numericBoxCellA.ShowPositiveSign = false;
            this.numericBoxCellA.SkipEventDuringInput = false;
            this.numericBoxCellA.SmartIncrement = true;
            this.numericBoxCellA.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxCellA.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxCellA.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxCellA.ThonsandsSeparator = true;
            this.numericBoxCellA.UpDown_Increment = 1D;
            this.numericBoxCellA.Value = 0D;
            this.numericBoxCellA.WordWrap = true;
            // 
            // numericBoxD3Err
            // 
            this.numericBoxD3Err.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxD3Err, "numericBoxD3Err");
            this.numericBoxD3Err.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxD3Err.DecimalPlaces = 1;
            this.numericBoxD3Err.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxD3Err.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxD3Err.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxD3Err.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxD3Err.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxD3Err.Maximum = 50D;
            this.numericBoxD3Err.Minimum = 0D;
            this.numericBoxD3Err.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxD3Err.MouseSpeed = 1D;
            this.numericBoxD3Err.Multiline = false;
            this.numericBoxD3Err.Name = "numericBoxD3Err";
            this.numericBoxD3Err.RadianValue = 0.052359877559829883D;
            this.numericBoxD3Err.ReadOnly = false;
            this.numericBoxD3Err.RestrictLimitValue = true;
            this.numericBoxD3Err.ShowFraction = false;
            this.numericBoxD3Err.ShowPositiveSign = false;
            this.numericBoxD3Err.ShowUpDown = true;
            this.numericBoxD3Err.SkipEventDuringInput = false;
            this.numericBoxD3Err.SmartIncrement = false;
            this.numericBoxD3Err.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxD3Err.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxD3Err.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxD3Err.ThonsandsSeparator = true;
            this.numericBoxD3Err.UpDown_Increment = 0.5D;
            this.numericBoxD3Err.Value = 3D;
            this.numericBoxD3Err.WordWrap = true;
            // 
            // numericBoxD2Err
            // 
            this.numericBoxD2Err.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxD2Err, "numericBoxD2Err");
            this.numericBoxD2Err.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxD2Err.DecimalPlaces = 1;
            this.numericBoxD2Err.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxD2Err.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxD2Err.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxD2Err.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxD2Err.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxD2Err.Maximum = 50D;
            this.numericBoxD2Err.Minimum = 0D;
            this.numericBoxD2Err.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxD2Err.MouseSpeed = 1D;
            this.numericBoxD2Err.Multiline = false;
            this.numericBoxD2Err.Name = "numericBoxD2Err";
            this.numericBoxD2Err.RadianValue = 0.052359877559829883D;
            this.numericBoxD2Err.ReadOnly = false;
            this.numericBoxD2Err.RestrictLimitValue = true;
            this.numericBoxD2Err.ShowFraction = false;
            this.numericBoxD2Err.ShowPositiveSign = false;
            this.numericBoxD2Err.ShowUpDown = true;
            this.numericBoxD2Err.SkipEventDuringInput = false;
            this.numericBoxD2Err.SmartIncrement = false;
            this.numericBoxD2Err.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxD2Err.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxD2Err.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxD2Err.ThonsandsSeparator = true;
            this.numericBoxD2Err.UpDown_Increment = 0.5D;
            this.numericBoxD2Err.Value = 3D;
            this.numericBoxD2Err.WordWrap = true;
            // 
            // numericBoxD1Err
            // 
            this.numericBoxD1Err.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxD1Err, "numericBoxD1Err");
            this.numericBoxD1Err.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxD1Err.DecimalPlaces = 1;
            this.numericBoxD1Err.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxD1Err.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxD1Err.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxD1Err.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxD1Err.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxD1Err.Maximum = 50D;
            this.numericBoxD1Err.Minimum = 0D;
            this.numericBoxD1Err.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxD1Err.MouseSpeed = 1D;
            this.numericBoxD1Err.Multiline = false;
            this.numericBoxD1Err.Name = "numericBoxD1Err";
            this.numericBoxD1Err.RadianValue = 0.052359877559829883D;
            this.numericBoxD1Err.ReadOnly = false;
            this.numericBoxD1Err.RestrictLimitValue = true;
            this.numericBoxD1Err.ShowFraction = false;
            this.numericBoxD1Err.ShowPositiveSign = false;
            this.numericBoxD1Err.ShowUpDown = true;
            this.numericBoxD1Err.SkipEventDuringInput = false;
            this.numericBoxD1Err.SmartIncrement = false;
            this.numericBoxD1Err.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxD1Err.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxD1Err.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxD1Err.ThonsandsSeparator = true;
            this.numericBoxD1Err.UpDown_Increment = 0.5D;
            this.numericBoxD1Err.Value = 3D;
            this.numericBoxD1Err.WordWrap = true;
            // 
            // numericBoxD3
            // 
            this.numericBoxD3.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxD3, "numericBoxD3");
            this.numericBoxD3.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxD3.DecimalPlaces = 2;
            this.numericBoxD3.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxD3.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxD3.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxD3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxD3.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxD3.Maximum = 100D;
            this.numericBoxD3.Minimum = 0D;
            this.numericBoxD3.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxD3.MouseSpeed = 1D;
            this.numericBoxD3.Multiline = false;
            this.numericBoxD3.Name = "numericBoxD3";
            this.numericBoxD3.RadianValue = 0D;
            this.numericBoxD3.ReadOnly = false;
            this.numericBoxD3.RestrictLimitValue = true;
            this.numericBoxD3.ShowFraction = false;
            this.numericBoxD3.ShowPositiveSign = false;
            this.numericBoxD3.SkipEventDuringInput = false;
            this.numericBoxD3.SmartIncrement = true;
            this.numericBoxD3.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxD3.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxD3.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxD3.ThonsandsSeparator = true;
            this.numericBoxD3.UpDown_Increment = 1D;
            this.numericBoxD3.Value = 0D;
            this.numericBoxD3.WordWrap = true;
            // 
            // numericBoxD2
            // 
            this.numericBoxD2.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxD2, "numericBoxD2");
            this.numericBoxD2.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxD2.DecimalPlaces = 2;
            this.numericBoxD2.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxD2.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxD2.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxD2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxD2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxD2.Maximum = 100D;
            this.numericBoxD2.Minimum = 0D;
            this.numericBoxD2.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxD2.MouseSpeed = 1D;
            this.numericBoxD2.Multiline = false;
            this.numericBoxD2.Name = "numericBoxD2";
            this.numericBoxD2.RadianValue = 0D;
            this.numericBoxD2.ReadOnly = false;
            this.numericBoxD2.RestrictLimitValue = true;
            this.numericBoxD2.ShowFraction = false;
            this.numericBoxD2.ShowPositiveSign = false;
            this.numericBoxD2.SkipEventDuringInput = false;
            this.numericBoxD2.SmartIncrement = true;
            this.numericBoxD2.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxD2.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxD2.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxD2.ThonsandsSeparator = true;
            this.numericBoxD2.UpDown_Increment = 1D;
            this.numericBoxD2.Value = 0D;
            this.numericBoxD2.WordWrap = true;
            // 
            // numericBoxD1
            // 
            this.numericBoxD1.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxD1, "numericBoxD1");
            this.numericBoxD1.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxD1.DecimalPlaces = 2;
            this.numericBoxD1.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxD1.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxD1.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxD1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxD1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxD1.Maximum = 100D;
            this.numericBoxD1.Minimum = 0D;
            this.numericBoxD1.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxD1.MouseSpeed = 1D;
            this.numericBoxD1.Multiline = false;
            this.numericBoxD1.Name = "numericBoxD1";
            this.numericBoxD1.RadianValue = 0D;
            this.numericBoxD1.ReadOnly = false;
            this.numericBoxD1.RestrictLimitValue = true;
            this.numericBoxD1.ShowFraction = false;
            this.numericBoxD1.ShowPositiveSign = false;
            this.numericBoxD1.SkipEventDuringInput = false;
            this.numericBoxD1.SmartIncrement = true;
            this.numericBoxD1.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxD1.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxD1.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxD1.ThonsandsSeparator = true;
            this.numericBoxD1.UpDown_Increment = 1D;
            this.numericBoxD1.Value = 0D;
            this.numericBoxD1.WordWrap = true;
            // 
            // numericBoxDensity
            // 
            this.numericBoxDensity.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxDensity, "numericBoxDensity");
            this.numericBoxDensity.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxDensity.DecimalPlaces = 3;
            this.numericBoxDensity.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxDensity.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxDensity.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxDensity.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxDensity.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxDensity.Maximum = 100D;
            this.numericBoxDensity.Minimum = 0D;
            this.numericBoxDensity.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxDensity.MouseSpeed = 1D;
            this.numericBoxDensity.Multiline = false;
            this.numericBoxDensity.Name = "numericBoxDensity";
            this.numericBoxDensity.RadianValue = 0D;
            this.numericBoxDensity.ReadOnly = false;
            this.numericBoxDensity.RestrictLimitValue = true;
            this.numericBoxDensity.ShowFraction = false;
            this.numericBoxDensity.ShowPositiveSign = false;
            this.numericBoxDensity.SkipEventDuringInput = false;
            this.numericBoxDensity.SmartIncrement = true;
            this.numericBoxDensity.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxDensity.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxDensity.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxDensity.ThonsandsSeparator = true;
            this.numericBoxDensity.UpDown_Increment = 1D;
            this.numericBoxDensity.Value = 0D;
            this.numericBoxDensity.WordWrap = true;
            // 
            // numericBoxDensityErr
            // 
            this.numericBoxDensityErr.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxDensityErr, "numericBoxDensityErr");
            this.numericBoxDensityErr.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxDensityErr.DecimalPlaces = 1;
            this.numericBoxDensityErr.FooterBackColor = System.Drawing.Color.Transparent;
            this.numericBoxDensityErr.FooterForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxDensityErr.HeaderBackColor = System.Drawing.Color.Transparent;
            this.numericBoxDensityErr.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.numericBoxDensityErr.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.numericBoxDensityErr.Maximum = 50D;
            this.numericBoxDensityErr.Minimum = 0D;
            this.numericBoxDensityErr.MouseDirection = Crystallography.VH_DirectionEnum.Horizontal;
            this.numericBoxDensityErr.MouseSpeed = 1D;
            this.numericBoxDensityErr.Multiline = false;
            this.numericBoxDensityErr.Name = "numericBoxDensityErr";
            this.numericBoxDensityErr.RadianValue = 0.052359877559829883D;
            this.numericBoxDensityErr.ReadOnly = false;
            this.numericBoxDensityErr.RestrictLimitValue = true;
            this.numericBoxDensityErr.ShowFraction = false;
            this.numericBoxDensityErr.ShowPositiveSign = false;
            this.numericBoxDensityErr.ShowUpDown = true;
            this.numericBoxDensityErr.SkipEventDuringInput = false;
            this.numericBoxDensityErr.SmartIncrement = false;
            this.numericBoxDensityErr.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxDensityErr.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxDensityErr.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxDensityErr.ThonsandsSeparator = true;
            this.numericBoxDensityErr.UpDown_Increment = 0.5D;
            this.numericBoxDensityErr.Value = 3D;
            this.numericBoxDensityErr.WordWrap = true;
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
    }
}

