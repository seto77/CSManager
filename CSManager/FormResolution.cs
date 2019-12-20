using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSManager
{
    public partial class FormResolution : Form
    {
        public FormResolution()
        {
            InitializeComponent();
        }

        bool SkipEvent=false;
        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            if (SkipEvent) return;
            SkipEvent = true;
            if (checkBoxKeepAspect.Checked)
                numericUpDownHeight.Value = numericUpDownWidth.Value;
            SkipEvent = false;
        }

        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            if (SkipEvent) return;
            SkipEvent = true;
            if (checkBoxKeepAspect.Checked)
                numericUpDownWidth.Value = numericUpDownHeight.Value;
            SkipEvent = false;
        }
    }
}