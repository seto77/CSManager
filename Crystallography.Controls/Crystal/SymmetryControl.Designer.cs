﻿namespace Crystallography.Controls
{
    partial class SymmetryControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SymmetryControl));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBoxSymmetry = new System.Windows.Forms.GroupBox();
            this.comboBoxSpaceGroup = new System.Windows.Forms.ComboBox();
            this.comboBoxPointGroup = new System.Windows.Forms.ComboBox();
            this.comboBoxCrystalSystem = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBoxSearchResult = new System.Windows.Forms.ComboBox();
            this.checkBoxShowError = new System.Windows.Forms.CheckBox();
            this.numericBoxBeta = new Crystallography.Controls.NumericBox();
            this.numericBoxAlpha = new Crystallography.Controls.NumericBox();
            this.numericBoxGammaErr = new Crystallography.Controls.NumericBox();
            this.numericBoxAlphaErr = new Crystallography.Controls.NumericBox();
            this.numericBoxBetaErr = new Crystallography.Controls.NumericBox();
            this.numericBoxA = new Crystallography.Controls.NumericBox();
            this.numericBoxGamma = new Crystallography.Controls.NumericBox();
            this.numericBoxBErr = new Crystallography.Controls.NumericBox();
            this.numericBoxB = new Crystallography.Controls.NumericBox();
            this.numericBoxC = new Crystallography.Controls.NumericBox();
            this.numericBoxCErr = new Crystallography.Controls.NumericBox();
            this.numericBoxAErr = new Crystallography.Controls.NumericBox();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxSymmetry.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxShowError);
            this.groupBox4.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // label46
            // 
            resources.ApplyResources(this.label46, "label46");
            this.label46.Name = "label46";
            // 
            // label47
            // 
            resources.ApplyResources(this.label47, "label47");
            this.label47.Name = "label47";
            // 
            // label48
            // 
            resources.ApplyResources(this.label48, "label48");
            this.label48.Name = "label48";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label48, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.label46, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericBoxBeta, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericBoxAlpha, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label47, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericBoxGammaErr, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.label23, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericBoxAlphaErr, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericBoxBetaErr, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericBoxA, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label26, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label45, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericBoxGamma, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label18, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericBoxBErr, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericBoxB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label24, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label25, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label28, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label27, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericBoxC, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericBoxCErr, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericBoxAErr, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label44, 3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label45
            // 
            resources.ApplyResources(this.label45, "label45");
            this.label45.Name = "label45";
            // 
            // label44
            // 
            resources.ApplyResources(this.label44, "label44");
            this.label44.Name = "label44";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // groupBoxSymmetry
            // 
            this.groupBoxSymmetry.Controls.Add(this.comboBoxSpaceGroup);
            this.groupBoxSymmetry.Controls.Add(this.comboBoxPointGroup);
            this.groupBoxSymmetry.Controls.Add(this.comboBoxCrystalSystem);
            this.groupBoxSymmetry.Controls.Add(this.label20);
            this.groupBoxSymmetry.Controls.Add(this.label17);
            this.groupBoxSymmetry.Controls.Add(this.label19);
            this.groupBoxSymmetry.Controls.Add(this.textBoxSearch);
            this.groupBoxSymmetry.Controls.Add(this.label21);
            this.groupBoxSymmetry.Controls.Add(this.comboBoxSearchResult);
            resources.ApplyResources(this.groupBoxSymmetry, "groupBoxSymmetry");
            this.groupBoxSymmetry.Name = "groupBoxSymmetry";
            this.groupBoxSymmetry.TabStop = false;
            // 
            // comboBoxSpaceGroup
            // 
            resources.ApplyResources(this.comboBoxSpaceGroup, "comboBoxSpaceGroup");
            this.comboBoxSpaceGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxSpaceGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpaceGroup.DropDownWidth = 200;
            this.comboBoxSpaceGroup.Name = "comboBoxSpaceGroup";
            this.comboBoxSpaceGroup.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxSpaceGroup_DrawItem);
            this.comboBoxSpaceGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpaceGroup_SelectedIndexChanged);
            // 
            // comboBoxPointGroup
            // 
            resources.ApplyResources(this.comboBoxPointGroup, "comboBoxPointGroup");
            this.comboBoxPointGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxPointGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPointGroup.Name = "comboBoxPointGroup";
            this.comboBoxPointGroup.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxSpaceGroup_DrawItem);
            this.comboBoxPointGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxPointGroup_SelectedIndexChanged);
            // 
            // comboBoxCrystalSystem
            // 
            resources.ApplyResources(this.comboBoxCrystalSystem, "comboBoxCrystalSystem");
            this.comboBoxCrystalSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCrystalSystem.Items.AddRange(new object[] {
            resources.GetString("comboBoxCrystalSystem.Items"),
            resources.GetString("comboBoxCrystalSystem.Items1"),
            resources.GetString("comboBoxCrystalSystem.Items2"),
            resources.GetString("comboBoxCrystalSystem.Items3"),
            resources.GetString("comboBoxCrystalSystem.Items4"),
            resources.GetString("comboBoxCrystalSystem.Items5"),
            resources.GetString("comboBoxCrystalSystem.Items6"),
            resources.GetString("comboBoxCrystalSystem.Items7")});
            this.comboBoxCrystalSystem.Name = "comboBoxCrystalSystem";
            this.comboBoxCrystalSystem.SelectedIndexChanged += new System.EventHandler(this.comboBoxCrystalSystem_SelectedIndexChanged);
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // textBoxSearch
            // 
            resources.ApplyResources(this.textBoxSearch, "textBoxSearch");
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // comboBoxSearchResult
            // 
            resources.ApplyResources(this.comboBoxSearchResult, "comboBoxSearchResult");
            this.comboBoxSearchResult.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxSearchResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchResult.DropDownWidth = 200;
            this.comboBoxSearchResult.Name = "comboBoxSearchResult";
            this.comboBoxSearchResult.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxSpaceGroup_DrawItem);
            this.comboBoxSearchResult.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchResult_SelectedIndexChanged);
            // 
            // checkBoxShowError
            // 
            resources.ApplyResources(this.checkBoxShowError, "checkBoxShowError");
            this.checkBoxShowError.Name = "checkBoxShowError";
            this.checkBoxShowError.UseVisualStyleBackColor = true;
            this.checkBoxShowError.CheckedChanged += new System.EventHandler(this.checkBoxShowError_CheckedChanged);
            // 
            // numericBoxBeta
            // 
            resources.ApplyResources(this.numericBoxBeta, "numericBoxBeta");
            this.numericBoxBeta.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxBeta.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxBeta.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxBeta.Name = "numericBoxBeta";
            this.numericBoxBeta.RestrictLimitValue = false;
            this.numericBoxBeta.SkipEventDuringInput = false;
            this.numericBoxBeta.SmartIncrement = true;
            this.numericBoxBeta.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxBeta.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxCellConstants_ValueChanged);
            // 
            // numericBoxAlpha
            // 
            resources.ApplyResources(this.numericBoxAlpha, "numericBoxAlpha");
            this.numericBoxAlpha.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAlpha.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAlpha.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAlpha.Name = "numericBoxAlpha";
            this.numericBoxAlpha.RestrictLimitValue = false;
            this.numericBoxAlpha.SkipEventDuringInput = false;
            this.numericBoxAlpha.SmartIncrement = true;
            this.numericBoxAlpha.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxAlpha.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxCellConstants_ValueChanged);
            // 
            // numericBoxGammaErr
            // 
            resources.ApplyResources(this.numericBoxGammaErr, "numericBoxGammaErr");
            this.numericBoxGammaErr.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxGammaErr.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxGammaErr.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxGammaErr.Name = "numericBoxGammaErr";
            this.numericBoxGammaErr.RestrictLimitValue = false;
            this.numericBoxGammaErr.SkipEventDuringInput = false;
            this.numericBoxGammaErr.SmartIncrement = true;
            this.numericBoxGammaErr.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxGammaErr.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxCellConstants_ValueChanged);
            // 
            // numericBoxAlphaErr
            // 
            resources.ApplyResources(this.numericBoxAlphaErr, "numericBoxAlphaErr");
            this.numericBoxAlphaErr.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAlphaErr.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAlphaErr.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAlphaErr.Name = "numericBoxAlphaErr";
            this.numericBoxAlphaErr.RestrictLimitValue = false;
            this.numericBoxAlphaErr.SkipEventDuringInput = false;
            this.numericBoxAlphaErr.SmartIncrement = true;
            this.numericBoxAlphaErr.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxAlphaErr.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxCellConstants_ValueChanged);
            // 
            // numericBoxBetaErr
            // 
            resources.ApplyResources(this.numericBoxBetaErr, "numericBoxBetaErr");
            this.numericBoxBetaErr.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxBetaErr.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxBetaErr.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxBetaErr.Name = "numericBoxBetaErr";
            this.numericBoxBetaErr.RestrictLimitValue = false;
            this.numericBoxBetaErr.SkipEventDuringInput = false;
            this.numericBoxBetaErr.SmartIncrement = true;
            this.numericBoxBetaErr.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxBetaErr.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxCellConstants_ValueChanged);
            // 
            // numericBoxA
            // 
            resources.ApplyResources(this.numericBoxA, "numericBoxA");
            this.numericBoxA.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxA.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxA.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxA.Name = "numericBoxA";
            this.numericBoxA.RestrictLimitValue = false;
            this.numericBoxA.SkipEventDuringInput = false;
            this.numericBoxA.SmartIncrement = true;
            this.numericBoxA.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxA.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxCellConstants_ValueChanged);
            // 
            // numericBoxGamma
            // 
            resources.ApplyResources(this.numericBoxGamma, "numericBoxGamma");
            this.numericBoxGamma.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxGamma.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxGamma.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxGamma.Name = "numericBoxGamma";
            this.numericBoxGamma.RestrictLimitValue = false;
            this.numericBoxGamma.SkipEventDuringInput = false;
            this.numericBoxGamma.SmartIncrement = true;
            this.numericBoxGamma.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxGamma.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxCellConstants_ValueChanged);
            // 
            // numericBoxBErr
            // 
            resources.ApplyResources(this.numericBoxBErr, "numericBoxBErr");
            this.numericBoxBErr.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxBErr.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxBErr.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxBErr.Name = "numericBoxBErr";
            this.numericBoxBErr.RestrictLimitValue = false;
            this.numericBoxBErr.SkipEventDuringInput = false;
            this.numericBoxBErr.SmartIncrement = true;
            this.numericBoxBErr.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxBErr.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxCellConstants_ValueChanged);
            // 
            // numericBoxB
            // 
            resources.ApplyResources(this.numericBoxB, "numericBoxB");
            this.numericBoxB.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxB.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxB.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxB.Name = "numericBoxB";
            this.numericBoxB.RestrictLimitValue = false;
            this.numericBoxB.SkipEventDuringInput = false;
            this.numericBoxB.SmartIncrement = true;
            this.numericBoxB.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxB.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxCellConstants_ValueChanged);
            // 
            // numericBoxC
            // 
            resources.ApplyResources(this.numericBoxC, "numericBoxC");
            this.numericBoxC.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxC.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxC.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxC.Name = "numericBoxC";
            this.numericBoxC.RestrictLimitValue = false;
            this.numericBoxC.SkipEventDuringInput = false;
            this.numericBoxC.SmartIncrement = true;
            this.numericBoxC.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxC.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxCellConstants_ValueChanged);
            // 
            // numericBoxCErr
            // 
            resources.ApplyResources(this.numericBoxCErr, "numericBoxCErr");
            this.numericBoxCErr.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxCErr.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxCErr.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxCErr.Name = "numericBoxCErr";
            this.numericBoxCErr.RestrictLimitValue = false;
            this.numericBoxCErr.SkipEventDuringInput = false;
            this.numericBoxCErr.SmartIncrement = true;
            this.numericBoxCErr.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxCErr.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxCellConstants_ValueChanged);
            // 
            // numericBoxAErr
            // 
            resources.ApplyResources(this.numericBoxAErr, "numericBoxAErr");
            this.numericBoxAErr.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAErr.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAErr.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAErr.Name = "numericBoxAErr";
            this.numericBoxAErr.RestrictLimitValue = false;
            this.numericBoxAErr.SkipEventDuringInput = false;
            this.numericBoxAErr.SmartIncrement = true;
            this.numericBoxAErr.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxAErr.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxCellConstants_ValueChanged);
            // 
            // SymmetryControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBoxSymmetry);
            this.Name = "SymmetryControl";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxSymmetry.ResumeLayout(false);
            this.groupBoxSymmetry.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox4;
        private NumericBox numericBoxGammaErr;
        private NumericBox numericBoxBetaErr;
        private NumericBox numericBoxAlphaErr;
        private NumericBox numericBoxAlpha;
        private NumericBox numericBoxGamma;
        private NumericBox numericBoxBeta;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label45;
        private NumericBox numericBoxAErr;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label24;
        private NumericBox numericBoxCErr;
        private NumericBox numericBoxBErr;
        private System.Windows.Forms.Label label25;
        private NumericBox numericBoxA;
        private NumericBox numericBoxB;
        private NumericBox numericBoxC;
        private System.Windows.Forms.GroupBox groupBoxSymmetry;
        public System.Windows.Forms.ComboBox comboBoxSpaceGroup;
        public System.Windows.Forms.ComboBox comboBoxPointGroup;
        public System.Windows.Forms.ComboBox comboBoxCrystalSystem;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.ComboBox comboBoxSearchResult;
        private System.Windows.Forms.CheckBox checkBoxShowError;
    }
}