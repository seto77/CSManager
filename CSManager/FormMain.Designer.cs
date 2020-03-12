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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.columnNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnFormulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDensityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAlphaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnBetaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnGammaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCrystalSystemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPointGroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSpaceGroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAuthorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnJournalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new System.Data.DataSet();
            this.dataTable = new System.Data.DataTable();
            this.dataColumnName = new System.Data.DataColumn();
            this.dataColumnFormula = new System.Data.DataColumn();
            this.dataColumnDensity = new System.Data.DataColumn();
            this.dataColumnA = new System.Data.DataColumn();
            this.dataColumnB = new System.Data.DataColumn();
            this.dataColumnC = new System.Data.DataColumn();
            this.dataColumnAlpha = new System.Data.DataColumn();
            this.dataColumnBeta = new System.Data.DataColumn();
            this.dataColumnGamma = new System.Data.DataColumn();
            this.dataColumnCrystalSystem = new System.Data.DataColumn();
            this.dataColumnPointGroup = new System.Data.DataColumn();
            this.dataColumnSpaceGroup = new System.Data.DataColumn();
            this.dataColumnAuthor = new System.Data.DataColumn();
            this.dataColumnTitle = new System.Data.DataColumn();
            this.dataColumnJournal = new System.Data.DataColumn();
            this.dataColumnElementList = new System.Data.DataColumn();
            this.dataColumnD1 = new System.Data.DataColumn();
            this.dataColumnD2 = new System.Data.DataColumn();
            this.dataColumnD3 = new System.Data.DataColumn();
            this.dataColumnD4 = new System.Data.DataColumn();
            this.dataColumnD5 = new System.Data.DataColumn();
            this.dataColumnD6 = new System.Data.DataColumn();
            this.dataColumnD7 = new System.Data.DataColumn();
            this.dataColumnD8 = new System.Data.DataColumn();
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
            this.textBoxSearchCellA = new System.Windows.Forms.TextBox();
            this.textBoxSearchCellBeta = new System.Windows.Forms.TextBox();
            this.textBoxSearchCellAlpha = new System.Windows.Forms.TextBox();
            this.numericUpDownSearchCellLengthError = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSearchCellAngleError = new System.Windows.Forms.NumericUpDown();
            this.label34 = new System.Windows.Forms.Label();
            this.textBoxSearchCellC = new System.Windows.Forms.TextBox();
            this.textBoxSearchCellGamma = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.textBoxSearchCellB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxDspacing = new System.Windows.Forms.CheckBox();
            this.groupBoxDspacing = new System.Windows.Forms.GroupBox();
            this.numericUpDownD3err = new System.Windows.Forms.NumericUpDown();
            this.checkBoxD3 = new System.Windows.Forms.CheckBox();
            this.checkBoxD2 = new System.Windows.Forms.CheckBox();
            this.checkBoxD1 = new System.Windows.Forms.CheckBox();
            this.numericUpDownD2err = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDownD1err = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxD3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxD1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxD2 = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.readDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemReadDefault1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemReadDefault2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.developperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemImportPDI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressAndSplitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.aboutMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpwebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.japaneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dataColumnCrystal = new System.Data.DataColumn();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.checkDuplicatedFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBoxCellParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearchCellLengthError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearchCellAngleError)).BeginInit();
            this.groupBoxDspacing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownD3err)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownD2err)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownD1err)).BeginInit();
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
            this.columnNameDataGridViewTextBoxColumn,
            this.columnFormulaDataGridViewTextBoxColumn,
            this.columnDensityDataGridViewTextBoxColumn,
            this.columnADataGridViewTextBoxColumn,
            this.columnBDataGridViewTextBoxColumn,
            this.columnCDataGridViewTextBoxColumn,
            this.columnAlphaDataGridViewTextBoxColumn,
            this.columnBetaDataGridViewTextBoxColumn,
            this.columnGammaDataGridViewTextBoxColumn,
            this.columnCrystalSystemDataGridViewTextBoxColumn,
            this.columnPointGroupDataGridViewTextBoxColumn,
            this.columnSpaceGroupDataGridViewTextBoxColumn,
            this.columnAuthorDataGridViewTextBoxColumn,
            this.columnTitleDataGridViewTextBoxColumn,
            this.columnJournalDataGridViewTextBoxColumn});
            this.dataGridViewMain.DataSource = this.bindingSourceMain;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMain.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dataGridViewMain, "dataGridViewMain");
            this.dataGridViewMain.MultiSelect = false;
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewMain.RowHeadersVisible = false;
            this.dataGridViewMain.RowTemplate.Height = 21;
            this.dataGridViewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.toolTip.SetToolTip(this.dataGridViewMain, resources.GetString("dataGridViewMain.ToolTip"));
            this.dataGridViewMain.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dataGridViewMain.Click += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // columnNameDataGridViewTextBoxColumn
            // 
            this.columnNameDataGridViewTextBoxColumn.DataPropertyName = "ColumnName";
            resources.ApplyResources(this.columnNameDataGridViewTextBoxColumn, "columnNameDataGridViewTextBoxColumn");
            this.columnNameDataGridViewTextBoxColumn.Name = "columnNameDataGridViewTextBoxColumn";
            this.columnNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnFormulaDataGridViewTextBoxColumn
            // 
            this.columnFormulaDataGridViewTextBoxColumn.DataPropertyName = "ColumnFormula";
            resources.ApplyResources(this.columnFormulaDataGridViewTextBoxColumn, "columnFormulaDataGridViewTextBoxColumn");
            this.columnFormulaDataGridViewTextBoxColumn.Name = "columnFormulaDataGridViewTextBoxColumn";
            this.columnFormulaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnDensityDataGridViewTextBoxColumn
            // 
            this.columnDensityDataGridViewTextBoxColumn.DataPropertyName = "ColumnDensity";
            resources.ApplyResources(this.columnDensityDataGridViewTextBoxColumn, "columnDensityDataGridViewTextBoxColumn");
            this.columnDensityDataGridViewTextBoxColumn.Name = "columnDensityDataGridViewTextBoxColumn";
            this.columnDensityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnADataGridViewTextBoxColumn
            // 
            this.columnADataGridViewTextBoxColumn.DataPropertyName = "ColumnA";
            resources.ApplyResources(this.columnADataGridViewTextBoxColumn, "columnADataGridViewTextBoxColumn");
            this.columnADataGridViewTextBoxColumn.Name = "columnADataGridViewTextBoxColumn";
            this.columnADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnBDataGridViewTextBoxColumn
            // 
            this.columnBDataGridViewTextBoxColumn.DataPropertyName = "ColumnB";
            resources.ApplyResources(this.columnBDataGridViewTextBoxColumn, "columnBDataGridViewTextBoxColumn");
            this.columnBDataGridViewTextBoxColumn.Name = "columnBDataGridViewTextBoxColumn";
            this.columnBDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnCDataGridViewTextBoxColumn
            // 
            this.columnCDataGridViewTextBoxColumn.DataPropertyName = "ColumnC";
            resources.ApplyResources(this.columnCDataGridViewTextBoxColumn, "columnCDataGridViewTextBoxColumn");
            this.columnCDataGridViewTextBoxColumn.Name = "columnCDataGridViewTextBoxColumn";
            this.columnCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnAlphaDataGridViewTextBoxColumn
            // 
            this.columnAlphaDataGridViewTextBoxColumn.DataPropertyName = "ColumnAlpha";
            resources.ApplyResources(this.columnAlphaDataGridViewTextBoxColumn, "columnAlphaDataGridViewTextBoxColumn");
            this.columnAlphaDataGridViewTextBoxColumn.Name = "columnAlphaDataGridViewTextBoxColumn";
            this.columnAlphaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnBetaDataGridViewTextBoxColumn
            // 
            this.columnBetaDataGridViewTextBoxColumn.DataPropertyName = "ColumnBeta";
            resources.ApplyResources(this.columnBetaDataGridViewTextBoxColumn, "columnBetaDataGridViewTextBoxColumn");
            this.columnBetaDataGridViewTextBoxColumn.Name = "columnBetaDataGridViewTextBoxColumn";
            this.columnBetaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnGammaDataGridViewTextBoxColumn
            // 
            this.columnGammaDataGridViewTextBoxColumn.DataPropertyName = "ColumnGamma";
            resources.ApplyResources(this.columnGammaDataGridViewTextBoxColumn, "columnGammaDataGridViewTextBoxColumn");
            this.columnGammaDataGridViewTextBoxColumn.Name = "columnGammaDataGridViewTextBoxColumn";
            this.columnGammaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnCrystalSystemDataGridViewTextBoxColumn
            // 
            this.columnCrystalSystemDataGridViewTextBoxColumn.DataPropertyName = "ColumnCrystalSystem";
            resources.ApplyResources(this.columnCrystalSystemDataGridViewTextBoxColumn, "columnCrystalSystemDataGridViewTextBoxColumn");
            this.columnCrystalSystemDataGridViewTextBoxColumn.Name = "columnCrystalSystemDataGridViewTextBoxColumn";
            this.columnCrystalSystemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnPointGroupDataGridViewTextBoxColumn
            // 
            this.columnPointGroupDataGridViewTextBoxColumn.DataPropertyName = "ColumnPointGroup";
            resources.ApplyResources(this.columnPointGroupDataGridViewTextBoxColumn, "columnPointGroupDataGridViewTextBoxColumn");
            this.columnPointGroupDataGridViewTextBoxColumn.Name = "columnPointGroupDataGridViewTextBoxColumn";
            this.columnPointGroupDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnSpaceGroupDataGridViewTextBoxColumn
            // 
            this.columnSpaceGroupDataGridViewTextBoxColumn.DataPropertyName = "ColumnSpaceGroup";
            resources.ApplyResources(this.columnSpaceGroupDataGridViewTextBoxColumn, "columnSpaceGroupDataGridViewTextBoxColumn");
            this.columnSpaceGroupDataGridViewTextBoxColumn.Name = "columnSpaceGroupDataGridViewTextBoxColumn";
            this.columnSpaceGroupDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnAuthorDataGridViewTextBoxColumn
            // 
            this.columnAuthorDataGridViewTextBoxColumn.DataPropertyName = "ColumnAuthor";
            resources.ApplyResources(this.columnAuthorDataGridViewTextBoxColumn, "columnAuthorDataGridViewTextBoxColumn");
            this.columnAuthorDataGridViewTextBoxColumn.Name = "columnAuthorDataGridViewTextBoxColumn";
            this.columnAuthorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnTitleDataGridViewTextBoxColumn
            // 
            this.columnTitleDataGridViewTextBoxColumn.DataPropertyName = "ColumnTitle";
            resources.ApplyResources(this.columnTitleDataGridViewTextBoxColumn, "columnTitleDataGridViewTextBoxColumn");
            this.columnTitleDataGridViewTextBoxColumn.Name = "columnTitleDataGridViewTextBoxColumn";
            this.columnTitleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnJournalDataGridViewTextBoxColumn
            // 
            this.columnJournalDataGridViewTextBoxColumn.DataPropertyName = "ColumnJournal";
            resources.ApplyResources(this.columnJournalDataGridViewTextBoxColumn, "columnJournalDataGridViewTextBoxColumn");
            this.columnJournalDataGridViewTextBoxColumn.Name = "columnJournalDataGridViewTextBoxColumn";
            this.columnJournalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSourceMain
            // 
            this.bindingSourceMain.DataMember = "dataTable";
            this.bindingSourceMain.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "NewDataSet";
            this.dataSet.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable});
            // 
            // dataTable
            // 
            this.dataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnCrystal,
            this.dataColumnName,
            this.dataColumnFormula,
            this.dataColumnDensity,
            this.dataColumnA,
            this.dataColumnB,
            this.dataColumnC,
            this.dataColumnAlpha,
            this.dataColumnBeta,
            this.dataColumnGamma,
            this.dataColumnCrystalSystem,
            this.dataColumnPointGroup,
            this.dataColumnSpaceGroup,
            this.dataColumnAuthor,
            this.dataColumnTitle,
            this.dataColumnJournal,
            this.dataColumnElementList,
            this.dataColumnD1,
            this.dataColumnD2,
            this.dataColumnD3,
            this.dataColumnD4,
            this.dataColumnD5,
            this.dataColumnD6,
            this.dataColumnD7,
            this.dataColumnD8});
            this.dataTable.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.dataTable.TableName = "dataTable";
            // 
            // dataColumnName
            // 
            this.dataColumnName.ColumnName = "ColumnName";
            // 
            // dataColumnFormula
            // 
            this.dataColumnFormula.ColumnName = "ColumnFormula";
            // 
            // dataColumnDensity
            // 
            this.dataColumnDensity.ColumnName = "ColumnDensity";
            this.dataColumnDensity.DataType = typeof(double);
            // 
            // dataColumnA
            // 
            this.dataColumnA.ColumnName = "ColumnA";
            this.dataColumnA.DataType = typeof(double);
            // 
            // dataColumnB
            // 
            this.dataColumnB.ColumnName = "ColumnB";
            this.dataColumnB.DataType = typeof(double);
            // 
            // dataColumnC
            // 
            this.dataColumnC.ColumnName = "ColumnC";
            this.dataColumnC.DataType = typeof(double);
            // 
            // dataColumnAlpha
            // 
            this.dataColumnAlpha.ColumnName = "ColumnAlpha";
            this.dataColumnAlpha.DataType = typeof(double);
            // 
            // dataColumnBeta
            // 
            this.dataColumnBeta.ColumnName = "ColumnBeta";
            this.dataColumnBeta.DataType = typeof(double);
            // 
            // dataColumnGamma
            // 
            this.dataColumnGamma.ColumnName = "ColumnGamma";
            this.dataColumnGamma.DataType = typeof(double);
            // 
            // dataColumnCrystalSystem
            // 
            this.dataColumnCrystalSystem.ColumnName = "ColumnCrystalSystem";
            // 
            // dataColumnPointGroup
            // 
            this.dataColumnPointGroup.ColumnName = "ColumnPointGroup";
            // 
            // dataColumnSpaceGroup
            // 
            this.dataColumnSpaceGroup.ColumnName = "ColumnSpaceGroup";
            // 
            // dataColumnAuthor
            // 
            this.dataColumnAuthor.ColumnName = "ColumnAuthor";
            // 
            // dataColumnTitle
            // 
            this.dataColumnTitle.ColumnName = "ColumnTitle";
            // 
            // dataColumnJournal
            // 
            this.dataColumnJournal.ColumnName = "ColumnJournal";
            // 
            // dataColumnElementList
            // 
            this.dataColumnElementList.ColumnName = "ColumnElementList";
            // 
            // dataColumnD1
            // 
            this.dataColumnD1.ColumnName = "ColumnD1";
            this.dataColumnD1.DataType = typeof(double);
            // 
            // dataColumnD2
            // 
            this.dataColumnD2.ColumnName = "ColumnD2";
            this.dataColumnD2.DataType = typeof(double);
            // 
            // dataColumnD3
            // 
            this.dataColumnD3.ColumnName = "ColumnD3";
            this.dataColumnD3.DataType = typeof(double);
            // 
            // dataColumnD4
            // 
            this.dataColumnD4.ColumnName = "ColumnD4";
            this.dataColumnD4.DataType = typeof(double);
            // 
            // dataColumnD5
            // 
            this.dataColumnD5.ColumnName = "ColumnD5";
            this.dataColumnD5.DataType = typeof(double);
            // 
            // dataColumnD6
            // 
            this.dataColumnD6.ColumnName = "ColumnD6";
            this.dataColumnD6.DataType = typeof(double);
            // 
            // dataColumnD7
            // 
            this.dataColumnD7.ColumnName = "ColumnD7";
            this.dataColumnD7.DataType = typeof(double);
            // 
            // dataColumnD8
            // 
            this.dataColumnD8.ColumnName = "ColumnD8";
            this.dataColumnD8.DataType = typeof(double);
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
            this.crystalControl.CellConstants = new double[] {
        0D,
        0D,
        0D,
        0D,
        0D,
        0D};
            this.crystalControl.Crystal = null;
            this.crystalControl.DefaultTabNumber = 0;
            this.crystalControl.Name = "crystalControl";
            this.crystalControl.ScatteringFactorVisible = false;
            this.crystalControl.SymmetryInformationVisible = false;
            this.crystalControl.SymmetrySeriesNumber = 0;
            this.crystalControl.VisibleAtomAdvancedTab = true;
            this.crystalControl.VisibleAtomTab = true;
            this.crystalControl.VisibleBasicInfoTab = true;
            this.crystalControl.VisibleBondsPolyhedraTab = true;
            this.crystalControl.VisibleElasticityTab = true;
            this.crystalControl.VisibleEOSTab = true;
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
            this.groupBoxCellParameter.Controls.Add(this.textBoxSearchCellA);
            this.groupBoxCellParameter.Controls.Add(this.textBoxSearchCellBeta);
            this.groupBoxCellParameter.Controls.Add(this.textBoxSearchCellAlpha);
            this.groupBoxCellParameter.Controls.Add(this.numericUpDownSearchCellLengthError);
            this.groupBoxCellParameter.Controls.Add(this.numericUpDownSearchCellAngleError);
            this.groupBoxCellParameter.Controls.Add(this.label34);
            this.groupBoxCellParameter.Controls.Add(this.textBoxSearchCellC);
            this.groupBoxCellParameter.Controls.Add(this.textBoxSearchCellGamma);
            this.groupBoxCellParameter.Controls.Add(this.label35);
            this.groupBoxCellParameter.Controls.Add(this.label36);
            this.groupBoxCellParameter.Controls.Add(this.label37);
            this.groupBoxCellParameter.Controls.Add(this.label38);
            this.groupBoxCellParameter.Controls.Add(this.label42);
            this.groupBoxCellParameter.Controls.Add(this.label41);
            this.groupBoxCellParameter.Controls.Add(this.label3);
            this.groupBoxCellParameter.Controls.Add(this.label2);
            this.groupBoxCellParameter.Controls.Add(this.label1);
            this.groupBoxCellParameter.Controls.Add(this.label43);
            this.groupBoxCellParameter.Controls.Add(this.label40);
            this.groupBoxCellParameter.Controls.Add(this.label39);
            this.groupBoxCellParameter.Controls.Add(this.textBoxSearchCellB);
            this.groupBoxCellParameter.Controls.Add(this.label4);
            this.groupBoxCellParameter.Controls.Add(this.label5);
            this.groupBoxCellParameter.Controls.Add(this.label6);
            resources.ApplyResources(this.groupBoxCellParameter, "groupBoxCellParameter");
            this.groupBoxCellParameter.Name = "groupBoxCellParameter";
            this.groupBoxCellParameter.TabStop = false;
            // 
            // textBoxSearchCellA
            // 
            resources.ApplyResources(this.textBoxSearchCellA, "textBoxSearchCellA");
            this.textBoxSearchCellA.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxSearchCellA.Name = "textBoxSearchCellA";
            // 
            // textBoxSearchCellBeta
            // 
            resources.ApplyResources(this.textBoxSearchCellBeta, "textBoxSearchCellBeta");
            this.textBoxSearchCellBeta.Name = "textBoxSearchCellBeta";
            // 
            // textBoxSearchCellAlpha
            // 
            resources.ApplyResources(this.textBoxSearchCellAlpha, "textBoxSearchCellAlpha");
            this.textBoxSearchCellAlpha.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxSearchCellAlpha.Name = "textBoxSearchCellAlpha";
            // 
            // numericUpDownSearchCellLengthError
            // 
            this.numericUpDownSearchCellLengthError.DecimalPlaces = 1;
            resources.ApplyResources(this.numericUpDownSearchCellLengthError, "numericUpDownSearchCellLengthError");
            this.numericUpDownSearchCellLengthError.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownSearchCellLengthError.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownSearchCellLengthError.Name = "numericUpDownSearchCellLengthError";
            this.numericUpDownSearchCellLengthError.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericUpDownSearchCellAngleError
            // 
            this.numericUpDownSearchCellAngleError.DecimalPlaces = 1;
            resources.ApplyResources(this.numericUpDownSearchCellAngleError, "numericUpDownSearchCellAngleError");
            this.numericUpDownSearchCellAngleError.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownSearchCellAngleError.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownSearchCellAngleError.Name = "numericUpDownSearchCellAngleError";
            this.numericUpDownSearchCellAngleError.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.Name = "label34";
            // 
            // textBoxSearchCellC
            // 
            resources.ApplyResources(this.textBoxSearchCellC, "textBoxSearchCellC");
            this.textBoxSearchCellC.Name = "textBoxSearchCellC";
            // 
            // textBoxSearchCellGamma
            // 
            resources.ApplyResources(this.textBoxSearchCellGamma, "textBoxSearchCellGamma");
            this.textBoxSearchCellGamma.Name = "textBoxSearchCellGamma";
            // 
            // label35
            // 
            resources.ApplyResources(this.label35, "label35");
            this.label35.Name = "label35";
            // 
            // label36
            // 
            resources.ApplyResources(this.label36, "label36");
            this.label36.Name = "label36";
            // 
            // label37
            // 
            resources.ApplyResources(this.label37, "label37");
            this.label37.Name = "label37";
            // 
            // label38
            // 
            resources.ApplyResources(this.label38, "label38");
            this.label38.Name = "label38";
            // 
            // label42
            // 
            resources.ApplyResources(this.label42, "label42");
            this.label42.Name = "label42";
            // 
            // label41
            // 
            resources.ApplyResources(this.label41, "label41");
            this.label41.Name = "label41";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label43
            // 
            resources.ApplyResources(this.label43, "label43");
            this.label43.Name = "label43";
            // 
            // label40
            // 
            resources.ApplyResources(this.label40, "label40");
            this.label40.Name = "label40";
            // 
            // label39
            // 
            resources.ApplyResources(this.label39, "label39");
            this.label39.Name = "label39";
            // 
            // textBoxSearchCellB
            // 
            resources.ApplyResources(this.textBoxSearchCellB, "textBoxSearchCellB");
            this.textBoxSearchCellB.Name = "textBoxSearchCellB";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
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
            this.groupBoxDspacing.Controls.Add(this.numericUpDownD3err);
            this.groupBoxDspacing.Controls.Add(this.checkBoxD3);
            this.groupBoxDspacing.Controls.Add(this.checkBoxD2);
            this.groupBoxDspacing.Controls.Add(this.checkBoxD1);
            this.groupBoxDspacing.Controls.Add(this.numericUpDownD2err);
            this.groupBoxDspacing.Controls.Add(this.label13);
            this.groupBoxDspacing.Controls.Add(this.numericUpDownD1err);
            this.groupBoxDspacing.Controls.Add(this.label9);
            this.groupBoxDspacing.Controls.Add(this.textBoxD3);
            this.groupBoxDspacing.Controls.Add(this.label12);
            this.groupBoxDspacing.Controls.Add(this.label10);
            this.groupBoxDspacing.Controls.Add(this.label8);
            this.groupBoxDspacing.Controls.Add(this.label11);
            this.groupBoxDspacing.Controls.Add(this.textBoxD1);
            this.groupBoxDspacing.Controls.Add(this.label7);
            this.groupBoxDspacing.Controls.Add(this.label15);
            this.groupBoxDspacing.Controls.Add(this.label16);
            this.groupBoxDspacing.Controls.Add(this.textBoxD2);
            resources.ApplyResources(this.groupBoxDspacing, "groupBoxDspacing");
            this.groupBoxDspacing.Name = "groupBoxDspacing";
            this.groupBoxDspacing.TabStop = false;
            // 
            // numericUpDownD3err
            // 
            this.numericUpDownD3err.DecimalPlaces = 1;
            resources.ApplyResources(this.numericUpDownD3err, "numericUpDownD3err");
            this.numericUpDownD3err.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownD3err.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownD3err.Name = "numericUpDownD3err";
            this.numericUpDownD3err.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
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
            // numericUpDownD2err
            // 
            this.numericUpDownD2err.DecimalPlaces = 1;
            resources.ApplyResources(this.numericUpDownD2err, "numericUpDownD2err");
            this.numericUpDownD2err.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownD2err.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownD2err.Name = "numericUpDownD2err";
            this.numericUpDownD2err.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // numericUpDownD1err
            // 
            this.numericUpDownD1err.DecimalPlaces = 1;
            resources.ApplyResources(this.numericUpDownD1err, "numericUpDownD1err");
            this.numericUpDownD1err.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownD1err.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownD1err.Name = "numericUpDownD1err";
            this.numericUpDownD1err.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // textBoxD3
            // 
            resources.ApplyResources(this.textBoxD3, "textBoxD3");
            this.textBoxD3.Name = "textBoxD3";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // textBoxD1
            // 
            resources.ApplyResources(this.textBoxD1, "textBoxD1");
            this.textBoxD1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxD1.Name = "textBoxD1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // textBoxD2
            // 
            resources.ApplyResources(this.textBoxD2, "textBoxD2");
            this.textBoxD2.Name = "textBoxD2";
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
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            resources.ApplyResources(this.toolStripProgressBar, "toolStripProgressBar");
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
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
            this.readDatabaseToolStripMenuItem,
            this.saveDatabaseToolStripMenuItem,
            this.clearDatabaseToolStripMenuItem,
            this.toolStripSeparator4,
            this.toolStripMenuItemReadDefault1,
            this.toolStripMenuItemReadDefault2,
            this.toolStripSeparator3,
            this.toolStripMenuItemImport,
            this.developperToolStripMenuItem,
            this.toolStripMenuItemImportPDI,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem,
            this.toolStripSeparator6,
            this.debugFunctionsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
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
            // developperToolStripMenuItem
            // 
            this.developperToolStripMenuItem.Name = "developperToolStripMenuItem";
            resources.ApplyResources(this.developperToolStripMenuItem, "developperToolStripMenuItem");
            this.developperToolStripMenuItem.Click += new System.EventHandler(this.developperToolStripMenuItem_Click);
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
            // debugFunctionsToolStripMenuItem
            // 
            this.debugFunctionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compressAndSplitToolStripMenuItem,
            this.showIndexToolStripMenuItem,
            this.checkDuplicatedFileToolStripMenuItem1});
            this.debugFunctionsToolStripMenuItem.Name = "debugFunctionsToolStripMenuItem";
            resources.ApplyResources(this.debugFunctionsToolStripMenuItem, "debugFunctionsToolStripMenuItem");
            // 
            // compressAndSplitToolStripMenuItem
            // 
            this.compressAndSplitToolStripMenuItem.Name = "compressAndSplitToolStripMenuItem";
            resources.ApplyResources(this.compressAndSplitToolStripMenuItem, "compressAndSplitToolStripMenuItem");
            this.compressAndSplitToolStripMenuItem.Click += new System.EventHandler(this.compressAndSplitToolStripMenuItem_Click);
            // 
            // showIndexToolStripMenuItem
            // 
            this.showIndexToolStripMenuItem.Name = "showIndexToolStripMenuItem";
            resources.ApplyResources(this.showIndexToolStripMenuItem, "showIndexToolStripMenuItem");
            this.showIndexToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemShowFileName_Click);
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
            this.aboutMeToolStripMenuItem,
            this.programUpdatesToolStripMenuItem,
            this.hintToolStripMenuItem,
            this.helpwebToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutMeToolStripMenuItem
            // 
            this.aboutMeToolStripMenuItem.Name = "aboutMeToolStripMenuItem";
            resources.ApplyResources(this.aboutMeToolStripMenuItem, "aboutMeToolStripMenuItem");
            this.aboutMeToolStripMenuItem.Click += new System.EventHandler(this.aboutMeToolStripMenuItem_Click);
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
            // dataColumnCrystal
            // 
            this.dataColumnCrystal.ColumnName = "ColumnCrystal";
            this.dataColumnCrystal.DataType = typeof(object);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // checkDuplicatedFileToolStripMenuItem1
            // 
            this.checkDuplicatedFileToolStripMenuItem1.Name = "checkDuplicatedFileToolStripMenuItem1";
            resources.ApplyResources(this.checkDuplicatedFileToolStripMenuItem1, "checkDuplicatedFileToolStripMenuItem1");
            this.checkDuplicatedFileToolStripMenuItem1.Click += new System.EventHandler(this.checkDuplicatedFileToolStripMenuItem_Click);
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBoxCellParameter.ResumeLayout(false);
            this.groupBoxCellParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearchCellLengthError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearchCellAngleError)).EndInit();
            this.groupBoxDspacing.ResumeLayout(false);
            this.groupBoxDspacing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownD3err)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownD2err)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownD1err)).EndInit();
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
        private System.Data.DataSet dataSet;
        private System.Data.DataTable dataTable;
        private System.Data.DataColumn dataColumnCrystal;
        private System.Data.DataColumn dataColumnName;
        private System.Data.DataColumn dataColumnFormula;
        private System.Data.DataColumn dataColumnDensity;
        private System.Data.DataColumn dataColumnA;
        private System.Data.DataColumn dataColumnB;
        private System.Data.DataColumn dataColumnC;
        private System.Data.DataColumn dataColumnAlpha;
        private System.Data.DataColumn dataColumnBeta;
        private System.Data.DataColumn dataColumnGamma;
        private System.Data.DataColumn dataColumnCrystalSystem;
        private System.Data.DataColumn dataColumnPointGroup;
        private System.Data.DataColumn dataColumnSpaceGroup;
        private System.Data.DataColumn dataColumnAuthor;
        private System.Data.DataColumn dataColumnTitle;
        private System.Data.DataColumn dataColumnJournal;
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
        private System.Windows.Forms.NumericUpDown numericUpDownSearchCellLengthError;
        private System.Windows.Forms.NumericUpDown numericUpDownSearchCellAngleError;
        private System.Windows.Forms.Label label34;
        public System.Windows.Forms.TextBox textBoxSearchCellC;
        public System.Windows.Forms.TextBox textBoxSearchCellGamma;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        public System.Windows.Forms.TextBox textBoxSearchCellA;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        public System.Windows.Forms.TextBox textBoxSearchCellB;
        public System.Windows.Forms.TextBox textBoxSearchCellAlpha;
        public System.Windows.Forms.TextBox textBoxSearchCellBeta;
        private System.Windows.Forms.CheckBox checkBoxSearchElements;
        private System.Windows.Forms.CheckBox checkBoxSearchCrystalSystem;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem developperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolTipToolStripMenuItem;
        public System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPeriodicTable;
        private System.Data.DataColumn dataColumnElementList;
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
        private System.Data.DataColumn dataColumnD1;
        private System.Data.DataColumn dataColumnD2;
        private System.Data.DataColumn dataColumnD3;
        private System.Data.DataColumn dataColumnD4;
        private System.Data.DataColumn dataColumnD5;
        private System.Data.DataColumn dataColumnD6;
        private System.Data.DataColumn dataColumnD7;
        private System.Data.DataColumn dataColumnD8;
        private System.Windows.Forms.GroupBox groupBoxDspacing;
        private System.Windows.Forms.NumericUpDown numericUpDownD1err;
        private System.Windows.Forms.CheckBox checkBoxDspacing;
        public System.Windows.Forms.TextBox textBoxD3;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox textBoxD1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox textBoxD2;
        private System.Windows.Forms.NumericUpDown numericUpDownD3err;
        private System.Windows.Forms.CheckBox checkBoxD1;
        private System.Windows.Forms.NumericUpDown numericUpDownD2err;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxD3;
        private System.Windows.Forms.CheckBox checkBoxD2;
        private System.Windows.Forms.ToolStripMenuItem hintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReadDefault2;
        private System.Windows.Forms.ToolStripMenuItem readDefaultDatabaseOnNextBootToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem programUpdatesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem japaneseToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFormulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDensityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAlphaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnBetaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnGammaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCrystalSystemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPointGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSpaceGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAuthorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnJournalDataGridViewTextBoxColumn;
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
    }
}

