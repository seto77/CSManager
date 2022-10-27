namespace CSManager;

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
        this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        this.splitContainer2 = new System.Windows.Forms.SplitContainer();
        this.buttonChange = new System.Windows.Forms.Button();
        this.buttonAdd = new System.Windows.Forms.Button();
        this.statusStrip = new System.Windows.Forms.StatusStrip();
        this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
        this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
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
        this.recalculateDensityFormulaAndDvaluesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
        this.crystalDatabaseControl = new Crystallography.Controls.CrystalDatabaseControl();
        this.crystalControl = new Crystallography.Controls.CrystalControl();
        this.searchCrystalControl = new Crystallography.Controls.SearchCrystalControl();
        ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
        this.splitContainer1.Panel1.SuspendLayout();
        this.splitContainer1.Panel2.SuspendLayout();
        this.splitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
        this.splitContainer2.Panel1.SuspendLayout();
        this.splitContainer2.Panel2.SuspendLayout();
        this.splitContainer2.SuspendLayout();
        this.statusStrip.SuspendLayout();
        this.menuStrip.SuspendLayout();
        this.SuspendLayout();
        // 
        // splitContainer1
        // 
        resources.ApplyResources(this.splitContainer1, "splitContainer1");
        this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        this.splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        this.splitContainer1.Panel1.Controls.Add(this.crystalDatabaseControl);
        // 
        // splitContainer1.Panel2
        // 
        this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
        this.splitContainer1.Panel2.Controls.Add(this.statusStrip);
        // 
        // splitContainer2
        // 
        resources.ApplyResources(this.splitContainer2, "splitContainer2");
        this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
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
        this.splitContainer2.Panel2.Controls.Add(this.searchCrystalControl);
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
        this.recalculateDensityFormulaAndDvaluesToolStripMenuItem});
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
        this.recalculateDensityFormulaAndDvaluesToolStripMenuItem.Name = "recalculaeDensityFormulaAndDvaluesToolStripMenuItem";
        resources.ApplyResources(this.recalculateDensityFormulaAndDvaluesToolStripMenuItem, "recalculaeDensityFormulaAndDvaluesToolStripMenuItem");
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
        // crystalDatabaseControl
        // 
        resources.ApplyResources(this.crystalDatabaseControl, "crystalDatabaseControl");
        this.crystalDatabaseControl.Filter = null;
        this.crystalDatabaseControl.FontSize = 9.75F;
        this.crystalDatabaseControl.Name = "crystalDatabaseControl";
        this.crystalDatabaseControl.CrystalChanged += new System.EventHandler(this.crystalDatabaseControl_CrystalChanged);
        this.crystalDatabaseControl.ProgressChanged += new Crystallography.Controls.CrystalDatabaseControl.ProgressChangedEventHandler(this.crystalDatabaseControl_ProgressChanged);
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
        // searchCrystalControl
        // 
        resources.ApplyResources(this.searchCrystalControl, "searchCrystalControl");
        this.searchCrystalControl.Name = "searchCrystalControl";
        this.searchCrystalControl.ProgressChanged += SearchCrystalControl_ProgressChanged;
        // 
        // FormMain
        // 
        resources.ApplyResources(this, "$this");
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.Controls.Add(this.splitContainer1);
        this.Controls.Add(this.menuStrip);
        this.DoubleBuffered = true;
        this.IsMdiContainer = true;
        this.MainMenuStrip = this.menuStrip;
        this.Name = "FormMain";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
        this.Load += new System.EventHandler(this.FormMain_Load);
        this.ResizeBegin += new System.EventHandler(this.FormMain_ResizeBegin);
        this.ResizeEnd += new System.EventHandler(this.FormMain_ResizeEnd);
        this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
        this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
        this.splitContainer1.Panel1.ResumeLayout(false);
        this.splitContainer1.Panel1.PerformLayout();
        this.splitContainer1.Panel2.ResumeLayout(false);
        this.splitContainer1.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
        this.splitContainer1.ResumeLayout(false);
        this.splitContainer2.Panel1.ResumeLayout(false);
        this.splitContainer2.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
        this.splitContainer2.ResumeLayout(false);
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
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
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolTipToolStripMenuItem;
    public System.Windows.Forms.ToolTip toolTip;
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
    private System.Windows.Forms.ToolStripMenuItem recalculateDensityFormulaAndDvaluesToolStripMenuItem;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private Crystallography.Controls.SearchCrystalControl searchCrystalControl;
    private Crystallography.Controls.CrystalDatabaseControl crystalDatabaseControl;
}

