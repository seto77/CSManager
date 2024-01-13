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
        components = new System.ComponentModel.Container();
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
        splitContainer1 = new System.Windows.Forms.SplitContainer();
        crystalDatabaseControl = new Crystallography.Controls.CrystalDatabaseControl();
        splitContainer2 = new System.Windows.Forms.SplitContainer();
        crystalControl = new Crystallography.Controls.CrystalControl();
        buttonChange = new System.Windows.Forms.Button();
        buttonAdd = new System.Windows.Forms.Button();
        searchCrystalControl = new Crystallography.Controls.SearchCrystalControl();
        statusStrip = new System.Windows.Forms.StatusStrip();
        toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
        toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        menuStrip = new System.Windows.Forms.MenuStrip();
        fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItemReadDefault1 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItemReadDefault2 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
        readDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        saveDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        clearDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        toolStripMenuItemImport = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItemImportPDI = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
        debugFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        compressAndSplitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        showIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        checkDuplicatedFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        importAllFileCIFOrAMCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        recalculateDensityFormulaAndDvaluesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolTipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        readDefaultDatabaseOnNextBootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        incrementalSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
        increaseFontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        increaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        decreaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        programUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        hintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        versionHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
        toolStripMenuItemGithubPage = new System.Windows.Forms.ToolStripMenuItem();
        repportBugsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        helpwebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        japaneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolTip = new System.Windows.Forms.ToolTip(components);
        backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
        splitContainer2.Panel1.SuspendLayout();
        splitContainer2.Panel2.SuspendLayout();
        splitContainer2.SuspendLayout();
        statusStrip.SuspendLayout();
        menuStrip.SuspendLayout();
        SuspendLayout();
        // 
        // splitContainer1
        // 
        resources.ApplyResources(splitContainer1, "splitContainer1");
        splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        resources.ApplyResources(splitContainer1.Panel1, "splitContainer1.Panel1");
        splitContainer1.Panel1.Controls.Add(crystalDatabaseControl);
        toolTip.SetToolTip(splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.ToolTip"));
        // 
        // splitContainer1.Panel2
        // 
        resources.ApplyResources(splitContainer1.Panel2, "splitContainer1.Panel2");
        splitContainer1.Panel2.Controls.Add(splitContainer2);
        splitContainer1.Panel2.Controls.Add(statusStrip);
        toolTip.SetToolTip(splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.ToolTip"));
        toolTip.SetToolTip(splitContainer1, resources.GetString("splitContainer1.ToolTip"));
        // 
        // crystalDatabaseControl
        // 
        resources.ApplyResources(crystalDatabaseControl, "crystalDatabaseControl");
        crystalDatabaseControl.Filter = null;
        crystalDatabaseControl.FontSize = 9.75F;
        crystalDatabaseControl.Name = "crystalDatabaseControl";
        toolTip.SetToolTip(crystalDatabaseControl, resources.GetString("crystalDatabaseControl.ToolTip"));
        crystalDatabaseControl.CrystalChanged += crystalDatabaseControl_CrystalChanged;
        crystalDatabaseControl.ProgressChanged += crystalDatabaseControl_ProgressChanged;
        // 
        // splitContainer2
        // 
        resources.ApplyResources(splitContainer2, "splitContainer2");
        splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        splitContainer2.Name = "splitContainer2";
        // 
        // splitContainer2.Panel1
        // 
        resources.ApplyResources(splitContainer2.Panel1, "splitContainer2.Panel1");
        splitContainer2.Panel1.Controls.Add(crystalControl);
        splitContainer2.Panel1.Controls.Add(buttonChange);
        splitContainer2.Panel1.Controls.Add(buttonAdd);
        toolTip.SetToolTip(splitContainer2.Panel1, resources.GetString("splitContainer2.Panel1.ToolTip"));
        // 
        // splitContainer2.Panel2
        // 
        resources.ApplyResources(splitContainer2.Panel2, "splitContainer2.Panel2");
        splitContainer2.Panel2.Controls.Add(searchCrystalControl);
        toolTip.SetToolTip(splitContainer2.Panel2, resources.GetString("splitContainer2.Panel2.ToolTip"));
        toolTip.SetToolTip(splitContainer2, resources.GetString("splitContainer2.ToolTip"));
        // 
        // crystalControl
        // 
        crystalControl.A = 0D;
        resources.ApplyResources(crystalControl, "crystalControl");
        crystalControl.AllowDrop = true;
        crystalControl.Alpha = 0D;
        crystalControl.B = 0D;
        crystalControl.Beta = 0D;
        crystalControl.C = 0D;
        crystalControl.ColorControlVisible = true;
        crystalControl.DefaultTabNumber = 0;
        crystalControl.Gamma = 0D;
        crystalControl.Name = "crystalControl";
        crystalControl.ScatteringFactorVisible = false;
        crystalControl.SkipEvent = false;
        crystalControl.SymmetryInformationVisible = false;
        crystalControl.SymmetrySeriesNumber = 0;
        toolTip.SetToolTip(crystalControl, resources.GetString("crystalControl.ToolTip"));
        crystalControl.VisibleAtomTab = true;
        crystalControl.VisibleBasicInfoTab = true;
        crystalControl.VisibleBondsPolyhedraTab = true;
        crystalControl.VisibleBoundTab = false;
        crystalControl.VisibleElasticityTab = true;
        crystalControl.VisibleEOSTab = true;
        crystalControl.VisibleLatticePlaneTab = false;
        crystalControl.VisiblePolycrystallineTab = false;
        crystalControl.VisibleReferenceTab = true;
        crystalControl.VisibleStressStrainTab = false;
        // 
        // buttonChange
        // 
        resources.ApplyResources(buttonChange, "buttonChange");
        buttonChange.BackColor = System.Drawing.Color.SteelBlue;
        buttonChange.ForeColor = System.Drawing.Color.White;
        buttonChange.Name = "buttonChange";
        toolTip.SetToolTip(buttonChange, resources.GetString("buttonChange.ToolTip"));
        buttonChange.UseVisualStyleBackColor = false;
        buttonChange.Click += buttonChangeCrystal_Click;
        // 
        // buttonAdd
        // 
        resources.ApplyResources(buttonAdd, "buttonAdd");
        buttonAdd.BackColor = System.Drawing.Color.SteelBlue;
        buttonAdd.ForeColor = System.Drawing.Color.White;
        buttonAdd.Name = "buttonAdd";
        toolTip.SetToolTip(buttonAdd, resources.GetString("buttonAdd.ToolTip"));
        buttonAdd.UseVisualStyleBackColor = false;
        buttonAdd.Click += buttonAddCrystal_Click;
        // 
        // searchCrystalControl
        // 
        resources.ApplyResources(searchCrystalControl, "searchCrystalControl");
        searchCrystalControl.Name = "searchCrystalControl";
        toolTip.SetToolTip(searchCrystalControl, resources.GetString("searchCrystalControl.ToolTip"));
        searchCrystalControl.ProgressChanged += SearchCrystalControl_ProgressChanged;
        // 
        // statusStrip
        // 
        resources.ApplyResources(statusStrip, "statusStrip");
        statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripProgressBar, toolStripStatusLabel });
        statusStrip.Name = "statusStrip";
        toolTip.SetToolTip(statusStrip, resources.GetString("statusStrip.ToolTip"));
        // 
        // toolStripProgressBar
        // 
        resources.ApplyResources(toolStripProgressBar, "toolStripProgressBar");
        toolStripProgressBar.Name = "toolStripProgressBar";
        // 
        // toolStripStatusLabel
        // 
        resources.ApplyResources(toolStripStatusLabel, "toolStripStatusLabel");
        toolStripStatusLabel.Name = "toolStripStatusLabel";
        // 
        // menuStrip
        // 
        resources.ApplyResources(menuStrip, "menuStrip");
        menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, optionToolStripMenuItem, helpToolStripMenuItem, languageToolStripMenuItem });
        menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
        menuStrip.Name = "menuStrip";
        toolTip.SetToolTip(menuStrip, resources.GetString("menuStrip.ToolTip"));
        // 
        // fileToolStripMenuItem
        // 
        resources.ApplyResources(fileToolStripMenuItem, "fileToolStripMenuItem");
        fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemReadDefault1, toolStripMenuItemReadDefault2, toolStripSeparator4, readDatabaseToolStripMenuItem, saveDatabaseToolStripMenuItem, clearDatabaseToolStripMenuItem, toolStripSeparator3, toolStripMenuItemImport, toolStripMenuItemImportPDI, toolStripSeparator1, closeToolStripMenuItem, toolStripSeparator6, debugFunctionsToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        // 
        // toolStripMenuItemReadDefault1
        // 
        resources.ApplyResources(toolStripMenuItemReadDefault1, "toolStripMenuItemReadDefault1");
        toolStripMenuItemReadDefault1.Name = "toolStripMenuItemReadDefault1";
        toolStripMenuItemReadDefault1.Click += toolStripMenuItemReadDefault1_Click;
        // 
        // toolStripMenuItemReadDefault2
        // 
        resources.ApplyResources(toolStripMenuItemReadDefault2, "toolStripMenuItemReadDefault2");
        toolStripMenuItemReadDefault2.Name = "toolStripMenuItemReadDefault2";
        toolStripMenuItemReadDefault2.Click += toolStripMenuItemReadDefault2_Click;
        // 
        // toolStripSeparator4
        // 
        resources.ApplyResources(toolStripSeparator4, "toolStripSeparator4");
        toolStripSeparator4.Name = "toolStripSeparator4";
        // 
        // readDatabaseToolStripMenuItem
        // 
        resources.ApplyResources(readDatabaseToolStripMenuItem, "readDatabaseToolStripMenuItem");
        readDatabaseToolStripMenuItem.Name = "readDatabaseToolStripMenuItem";
        readDatabaseToolStripMenuItem.Click += readDatabaseToolStripMenuItem_Click;
        // 
        // saveDatabaseToolStripMenuItem
        // 
        resources.ApplyResources(saveDatabaseToolStripMenuItem, "saveDatabaseToolStripMenuItem");
        saveDatabaseToolStripMenuItem.Name = "saveDatabaseToolStripMenuItem";
        saveDatabaseToolStripMenuItem.Click += saveDatabaseToolStripMenuItem_Click;
        // 
        // clearDatabaseToolStripMenuItem
        // 
        resources.ApplyResources(clearDatabaseToolStripMenuItem, "clearDatabaseToolStripMenuItem");
        clearDatabaseToolStripMenuItem.Name = "clearDatabaseToolStripMenuItem";
        clearDatabaseToolStripMenuItem.Click += clearDatabaseToolStripMenuItem_Click;
        // 
        // toolStripSeparator3
        // 
        resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
        toolStripSeparator3.Name = "toolStripSeparator3";
        // 
        // toolStripMenuItemImport
        // 
        resources.ApplyResources(toolStripMenuItemImport, "toolStripMenuItemImport");
        toolStripMenuItemImport.Name = "toolStripMenuItemImport";
        toolStripMenuItemImport.Click += toolStripMenuItemImport_Click;
        // 
        // toolStripMenuItemImportPDI
        // 
        resources.ApplyResources(toolStripMenuItemImportPDI, "toolStripMenuItemImportPDI");
        toolStripMenuItemImportPDI.Name = "toolStripMenuItemImportPDI";
        toolStripMenuItemImportPDI.Click += toolStripMenuItemImportPDI_Click;
        // 
        // toolStripSeparator1
        // 
        resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
        toolStripSeparator1.Name = "toolStripSeparator1";
        // 
        // closeToolStripMenuItem
        // 
        resources.ApplyResources(closeToolStripMenuItem, "closeToolStripMenuItem");
        closeToolStripMenuItem.Name = "closeToolStripMenuItem";
        closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
        // 
        // toolStripSeparator6
        // 
        resources.ApplyResources(toolStripSeparator6, "toolStripSeparator6");
        toolStripSeparator6.Name = "toolStripSeparator6";
        // 
        // debugFunctionsToolStripMenuItem
        // 
        resources.ApplyResources(debugFunctionsToolStripMenuItem, "debugFunctionsToolStripMenuItem");
        debugFunctionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { compressAndSplitToolStripMenuItem, showIndexToolStripMenuItem, checkDuplicatedFileToolStripMenuItem1, importAllFileCIFOrAMCToolStripMenuItem, recalculateDensityFormulaAndDvaluesToolStripMenuItem });
        debugFunctionsToolStripMenuItem.Name = "debugFunctionsToolStripMenuItem";
        // 
        // compressAndSplitToolStripMenuItem
        // 
        resources.ApplyResources(compressAndSplitToolStripMenuItem, "compressAndSplitToolStripMenuItem");
        compressAndSplitToolStripMenuItem.Name = "compressAndSplitToolStripMenuItem";
        // 
        // showIndexToolStripMenuItem
        // 
        resources.ApplyResources(showIndexToolStripMenuItem, "showIndexToolStripMenuItem");
        showIndexToolStripMenuItem.Name = "showIndexToolStripMenuItem";
        showIndexToolStripMenuItem.Click += toolStripMenuItemShowFileName_Click;
        // 
        // checkDuplicatedFileToolStripMenuItem1
        // 
        resources.ApplyResources(checkDuplicatedFileToolStripMenuItem1, "checkDuplicatedFileToolStripMenuItem1");
        checkDuplicatedFileToolStripMenuItem1.Name = "checkDuplicatedFileToolStripMenuItem1";
        checkDuplicatedFileToolStripMenuItem1.Click += checkDuplicatedFileToolStripMenuItem_Click;
        // 
        // importAllFileCIFOrAMCToolStripMenuItem
        // 
        resources.ApplyResources(importAllFileCIFOrAMCToolStripMenuItem, "importAllFileCIFOrAMCToolStripMenuItem");
        importAllFileCIFOrAMCToolStripMenuItem.Name = "importAllFileCIFOrAMCToolStripMenuItem";
        importAllFileCIFOrAMCToolStripMenuItem.Click += importAllCrystalsMenuItem_Click;
        // 
        // recalculateDensityFormulaAndDvaluesToolStripMenuItem
        // 
        resources.ApplyResources(recalculateDensityFormulaAndDvaluesToolStripMenuItem, "recalculateDensityFormulaAndDvaluesToolStripMenuItem");
        recalculateDensityFormulaAndDvaluesToolStripMenuItem.Name = "recalculateDensityFormulaAndDvaluesToolStripMenuItem";
        // 
        // optionToolStripMenuItem
        // 
        resources.ApplyResources(optionToolStripMenuItem, "optionToolStripMenuItem");
        optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolTipToolStripMenuItem, toolStripSeparator2, readDefaultDatabaseOnNextBootToolStripMenuItem, incrementalSearchToolStripMenuItem, toolStripSeparator5, increaseFontSizeToolStripMenuItem });
        optionToolStripMenuItem.Name = "optionToolStripMenuItem";
        // 
        // toolTipToolStripMenuItem
        // 
        resources.ApplyResources(toolTipToolStripMenuItem, "toolTipToolStripMenuItem");
        toolTipToolStripMenuItem.Checked = true;
        toolTipToolStripMenuItem.CheckOnClick = true;
        toolTipToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
        toolTipToolStripMenuItem.Name = "toolTipToolStripMenuItem";
        toolTipToolStripMenuItem.Click += toolTipToolStripMenuItem_Click;
        // 
        // toolStripSeparator2
        // 
        resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
        toolStripSeparator2.Name = "toolStripSeparator2";
        // 
        // readDefaultDatabaseOnNextBootToolStripMenuItem
        // 
        resources.ApplyResources(readDefaultDatabaseOnNextBootToolStripMenuItem, "readDefaultDatabaseOnNextBootToolStripMenuItem");
        readDefaultDatabaseOnNextBootToolStripMenuItem.Checked = true;
        readDefaultDatabaseOnNextBootToolStripMenuItem.CheckOnClick = true;
        readDefaultDatabaseOnNextBootToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
        readDefaultDatabaseOnNextBootToolStripMenuItem.Name = "readDefaultDatabaseOnNextBootToolStripMenuItem";
        // 
        // incrementalSearchToolStripMenuItem
        // 
        resources.ApplyResources(incrementalSearchToolStripMenuItem, "incrementalSearchToolStripMenuItem");
        incrementalSearchToolStripMenuItem.CheckOnClick = true;
        incrementalSearchToolStripMenuItem.Name = "incrementalSearchToolStripMenuItem";
        // 
        // toolStripSeparator5
        // 
        resources.ApplyResources(toolStripSeparator5, "toolStripSeparator5");
        toolStripSeparator5.Name = "toolStripSeparator5";
        // 
        // increaseFontSizeToolStripMenuItem
        // 
        resources.ApplyResources(increaseFontSizeToolStripMenuItem, "increaseFontSizeToolStripMenuItem");
        increaseFontSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { increaseToolStripMenuItem, decreaseToolStripMenuItem });
        increaseFontSizeToolStripMenuItem.Name = "increaseFontSizeToolStripMenuItem";
        // 
        // increaseToolStripMenuItem
        // 
        resources.ApplyResources(increaseToolStripMenuItem, "increaseToolStripMenuItem");
        increaseToolStripMenuItem.Name = "increaseToolStripMenuItem";
        increaseToolStripMenuItem.Click += increaseToolStripMenuItem_Click;
        // 
        // decreaseToolStripMenuItem
        // 
        resources.ApplyResources(decreaseToolStripMenuItem, "decreaseToolStripMenuItem");
        decreaseToolStripMenuItem.Name = "decreaseToolStripMenuItem";
        decreaseToolStripMenuItem.Click += decreaseToolStripMenuItem_Click;
        // 
        // helpToolStripMenuItem
        // 
        resources.ApplyResources(helpToolStripMenuItem, "helpToolStripMenuItem");
        helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { programUpdatesToolStripMenuItem, hintToolStripMenuItem, versionHistoryToolStripMenuItem, licenseToolStripMenuItem, toolStripSeparator7, toolStripMenuItemGithubPage, repportBugsToolStripMenuItem, helpwebToolStripMenuItem });
        helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        // 
        // programUpdatesToolStripMenuItem
        // 
        resources.ApplyResources(programUpdatesToolStripMenuItem, "programUpdatesToolStripMenuItem");
        programUpdatesToolStripMenuItem.Name = "programUpdatesToolStripMenuItem";
        programUpdatesToolStripMenuItem.Click += programUpdatesToolStripMenuItem_Click;
        // 
        // hintToolStripMenuItem
        // 
        resources.ApplyResources(hintToolStripMenuItem, "hintToolStripMenuItem");
        hintToolStripMenuItem.Name = "hintToolStripMenuItem";
        hintToolStripMenuItem.Click += hintToolStripMenuItem_Click;
        // 
        // versionHistoryToolStripMenuItem
        // 
        resources.ApplyResources(versionHistoryToolStripMenuItem, "versionHistoryToolStripMenuItem");
        versionHistoryToolStripMenuItem.Name = "versionHistoryToolStripMenuItem";
        versionHistoryToolStripMenuItem.Click += versionHistoryToolStripMenuItem_Click;
        // 
        // licenseToolStripMenuItem
        // 
        resources.ApplyResources(licenseToolStripMenuItem, "licenseToolStripMenuItem");
        licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
        licenseToolStripMenuItem.Click += licenseToolStripMenuItem_Click;
        // 
        // toolStripSeparator7
        // 
        resources.ApplyResources(toolStripSeparator7, "toolStripSeparator7");
        toolStripSeparator7.Name = "toolStripSeparator7";
        // 
        // toolStripMenuItemGithubPage
        // 
        resources.ApplyResources(toolStripMenuItemGithubPage, "toolStripMenuItemGithubPage");
        toolStripMenuItemGithubPage.Name = "toolStripMenuItemGithubPage";
        toolStripMenuItemGithubPage.Click += toolStripMenuItemGithubPage_Click;
        // 
        // repportBugsToolStripMenuItem
        // 
        resources.ApplyResources(repportBugsToolStripMenuItem, "repportBugsToolStripMenuItem");
        repportBugsToolStripMenuItem.Name = "repportBugsToolStripMenuItem";
        repportBugsToolStripMenuItem.Click += repportBugsToolStripMenuItem_Click;
        // 
        // helpwebToolStripMenuItem
        // 
        resources.ApplyResources(helpwebToolStripMenuItem, "helpwebToolStripMenuItem");
        helpwebToolStripMenuItem.Name = "helpwebToolStripMenuItem";
        helpwebToolStripMenuItem.Click += helpwebToolStripMenuItem_Click;
        // 
        // languageToolStripMenuItem
        // 
        resources.ApplyResources(languageToolStripMenuItem, "languageToolStripMenuItem");
        languageToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { englishToolStripMenuItem, japaneseToolStripMenuItem });
        languageToolStripMenuItem.Name = "languageToolStripMenuItem";
        // 
        // englishToolStripMenuItem
        // 
        resources.ApplyResources(englishToolStripMenuItem, "englishToolStripMenuItem");
        englishToolStripMenuItem.Checked = true;
        englishToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
        englishToolStripMenuItem.Name = "englishToolStripMenuItem";
        englishToolStripMenuItem.Click += languageToolStripMenuItem_Click;
        // 
        // japaneseToolStripMenuItem
        // 
        resources.ApplyResources(japaneseToolStripMenuItem, "japaneseToolStripMenuItem");
        japaneseToolStripMenuItem.Name = "japaneseToolStripMenuItem";
        japaneseToolStripMenuItem.Click += languageToolStripMenuItem_Click;
        // 
        // toolTip
        // 
        toolTip.IsBalloon = true;
        // 
        // FormMain
        // 
        resources.ApplyResources(this, "$this");
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        Controls.Add(splitContainer1);
        Controls.Add(menuStrip);
        DoubleBuffered = true;
        IsMdiContainer = true;
        MainMenuStrip = menuStrip;
        Name = "FormMain";
        toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
        FormClosing += FormMain_FormClosing;
        Load += FormMain_Load;
        ResizeBegin += FormMain_ResizeBegin;
        ResizeEnd += FormMain_ResizeEnd;
        DragDrop += FormMain_DragDrop;
        DragEnter += FormMain_DragEnter;
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel1.PerformLayout();
        splitContainer1.Panel2.ResumeLayout(false);
        splitContainer1.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        splitContainer2.Panel1.ResumeLayout(false);
        splitContainer2.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
        splitContainer2.ResumeLayout(false);
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
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
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGithubPage;
    private System.Windows.Forms.ToolStripMenuItem repportBugsToolStripMenuItem;
}

