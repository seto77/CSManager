using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Crystallography.Controls
{
    public partial class NumericBox : UserControl
    {
        #region �C�x���g

        public delegate void MyEventHandler(object sender, EventArgs e);

        public event MyEventHandler ValueChanged;

        public event MyEventHandler ReadOnlyChanged;

        public event MyEventHandler Click2;

        public event MyEventHandler LimitChanged;

        #endregion �C�x���g

        #region �v���p�e�B

        /// <summary>
        /// VisualStudio�f�U�C�i�[�̕ҏW�̎���True
        /// </summary>
        public new bool DesignMode
        {
            get
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                    return true;
                Control ctrl = this;
                while (ctrl != null)
                {
                    if (ctrl.Site != null && ctrl.Site.DesignMode)
                        return true;
                    ctrl = ctrl.Parent;
                }
                return false;
            }
        }

        /// <summary>
        /// UpDown�{�^����L���ɂ��邩�ǂ���
        /// </summary>
        public bool ShowUpDown { get => numericUpDown.Visible; set => numericUpDown.Visible = value; }

        /// <summary>
        /// UpDown�{�^�����L���ȏꍇ�AIncrement���擾/�ݒ�
        /// </summary>
        public double UpDown_Increment { set; get; } = 1;

        public bool SmartIncrement { set { smartIncrementToolStripMenuItem.Checked = value; toolStripComboBoxIncrement.Enabled = !value; } get { return smartIncrementToolStripMenuItem.Checked; } }

        private double maximum = double.PositiveInfinity;

        public double Maximum
        {
            set
            {
                if (value > minimum)
                {
                    maximum = value;

                    if (RestrictLimitValue && Value > maximum)
                        Value = maximum;

                    string text = Maximum.ToString(DecimalPlaces >= 0 ? "f" + DecimalPlaces.ToString() : "");
                    text = separateThousands(text);
                    if (!text.StartsWith("-") && ShowPositiveSign && text != "0")
                        text = "+" + text;
                    toolStripTextBoxMaximum.Text = text;
                }
            }
            get { return maximum; }
        }

        private double minimum = double.NegativeInfinity;

        public double Minimum
        {
            set
            {
                if (value < maximum)
                {
                    minimum = value;

                    if (RestrictLimitValue && Value < Minimum)
                        Value = Minimum;

                    string text = Minimum.ToString(DecimalPlaces >= 0 ? "f" + DecimalPlaces.ToString() : "");
                    text = separateThousands(text);
                    if (!text.StartsWith("-") && ShowPositiveSign && text != "0")
                        text = "+" + text;
                    toolStripTextBoxMimimum.Text = text;
                }
            }
            get { return minimum; }
        }

        /// <summary>
        /// Maximum, Minimum�͈̔͂ɓ��͒l�𐧌�����B�͈͊O�̏ꍇ�́A�����I�ɂǂ��炩�̏ꍇ�ɕύX�����
        /// </summary>
        public bool RestrictLimitValue { set => toolStripMenuItemRestrictLimit.Checked = value; get => toolStripMenuItemRestrictLimit.Checked; }

        [Localizable(true)]
        public string ToolTip
        {
            get => toolTip.GetToolTip(textBox);
            set
            {
                toolTip.SetToolTip(textBox, value);
                toolTip.SetToolTip(labelFooter, value);
                toolTip.SetToolTip(labelHeader, value);
            }
        }

        public double MinimalStep { get { return DecimalPlaces >= 0 ? Math.Pow(10, -DecimalPlaces) : 1; } }

        /// <summary>
        /// ���l�̑O�ɕ\������e�L�X�g
        /// </summary>
        [Localizable(true)]
        public string HeaderText { set => labelHeader.Text = value; get => labelHeader.Text; }

        [Localizable(true)]
        public Font HeaderFont { set => labelHeader.Font = value; get => labelHeader.Font; }

        /// <summary>
        /// ���l�̌�ɕ\������e�L�X�g
        /// </summary>
        [Localizable(true)]
        public string FooterText { set => labelFooter.Text = value; get => labelFooter.Text; }

        [Localizable(true)]
        public Font FooterFont { set => labelFooter.Font = value; get => labelFooter.Font; }

        public Color TextBoxForeColor { set => textBox.ForeColor = value; get => textBox.ForeColor; }
        public Color TextBoxBackColor { set => textBox.BackColor = value; get => textBox.BackColor; }

        /// <summary>
        /// font
        /// </summary>
        public Font TextFont
        {
            set
            {
                textBox.Font = value;
                numericUpDown.Font = value;
                if (Multiline)
                {
                    MinimumSize = new Size(0, 0);
                    MaximumSize = new Size(0, 0);
                }
                else
                {
                    this.Height = textBox.Height;
                    MinimumSize = new Size(1, textBox.Height);
                    MaximumSize = new Size(1000, textBox.Height);
                }
            }
            get { return textBox.Font; }
        }

        /// <summary>
        /// �{��\�����邩�ǂ���
        /// </summary>
        public bool ShowPositiveSign { set; get; } = false;

        private double numericalValue = 0;

        /// <summary>
        /// �R���g���[�����ێ����Ă���l
        /// </summary>
        public double Value
        {
            set
            {
                if (InvokeRequired)
                    Invoke(new Action(() => Value = value), null);
                else if (this.numericalValue != value)
                {
                    if (RestrictLimitValue)
                    {
                        if (Maximum <= value)
                            value = Maximum;
                        if (Minimum >= value)
                            value = Minimum;
                    }
                    this.numericalValue = value;
                    skipTextChangeEvent = true;
                    textBox.Text = GetString();
                    skipTextChangeEvent = false;
                    ValueChanged?.Invoke(this, new EventArgs());
                }
            }
            get => numericalValue;
        }

        public int ValueInteger { get => (int)numericalValue; }

        /// <summary>
        /// Radian�Ƃ��Ēl����́B
        /// </summary>
        public double RadianValue { set => Value = value * 180.0 / Math.PI; get => Value / 180.0 * Math.PI; }

        /// <summary>
        /// 3����؂�ŃJ���}��\��������
        /// </summary>
        public bool ThonsandsSeparator { set => thousandsSeparatorToolStripMenuItem.Checked = value; get => thousandsSeparatorToolStripMenuItem.Checked; }

        // private int decimalPlaces = -1;
        /// <summary>
        /// �����_�ȉ��̌���
        /// </summary>
        public int DecimalPlaces
        {
            set
            {
                if (value >= -1 && value < 11)
                {
                    toolStripComboBoxDecimalPlaces.SelectedIndex = value + 1;
                    textBox.Text = GetString();
                }
            }
            get => toolStripComboBoxDecimalPlaces.SelectedIndex - 1;
        }

        /// <summary>
        /// �ǂݎ���p���ǂ���
        /// </summary>
        public bool ReadOnly { set => textBox.ReadOnly = value; get => textBox.ReadOnly; }

        /// <summary>
        /// �����s�\�������邩�ǂ���
        /// </summary>
        public bool Multiline
        {
            set
            {
                textBox.Multiline = value;
                if (value)
                {
                    //textBox.Dock = DockStyle.Fill;
                    MinimumSize = new Size(0, 0);
                    MaximumSize = new Size(0, 0);
                }
                else
                {
                    //textBox.Dock = DockStyle.None;
                    this.Height = textBox.Height;
                    MinimumSize = new Size(1, textBox.Height);
                    MaximumSize = new Size(1000, textBox.Height);
                }
            }
            get { return textBox.Multiline; }
        }

        public bool ShowFraction { set; get; } = false;

        public new string Text { set => textBox.Text = value; get => numericalValue.ToString(); }

        public bool WordWrap { set => textBox.WordWrap = value; get => textBox.WordWrap; }

        #endregion �v���p�e�B

        private void textBox_ReadOnlyChanged(object sender, EventArgs e) => ReadOnlyChanged?.Invoke(sender, e);

        private void textBox_Click(object sender, EventArgs e) => Click2?.Invoke(sender, e);

        public NumericBox()
        {
            InitializeComponent();
            if (DesignMode) return;
            toolStripComboBoxMouseDirection.SelectedIndex = 0;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 13 && ModifierKeys == Keys.Shift) || (e.KeyChar == 10 && ModifierKeys == Keys.Control))
                e.Handled = true;
        }

        public bool SkipEventDuringInput { set; get; }

        private bool skipTextChangeEvent = false;//�e�L�X�g�`�F���W�C�x���g���̂��L�����Z������@

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            if (skipTextChangeEvent || SkipEventDuringInput)
                return;
            try
            {
                int count = 0, selectionLine = 0;
                for (int i = 0; i < textBox.Lines.Length; i++)
                {
                    count += textBox.Lines[i].Length + 2;
                    if (count > textBox.SelectionStart)
                    {
                        selectionLine = i;
                        break;
                    }
                }
                var formula = new string[selectionLine + 1];
                Array.Copy(textBox.Lines, formula, selectionLine + 1);
                var d = NumericalFormula.GetNumetricValue(formula);
                if (!double.IsNaN(d) && d != this.numericalValue)
                {
                    if (RestrictLimitValue)
                    {
                        if (d > Maximum) { d = Maximum; this.numericalValue = Maximum; textBox.Text = GetString(); }
                        if (d < minimum) { d = minimum; this.numericalValue = Minimum; textBox.Text = GetString(); }
                    }

                    this.numericalValue = d;
                    ValueChanged?.Invoke(this, e);
                }
            }
            catch { }
        }

        private void adjustTextBaseLine()
        {
        }

        public bool ValidRange(double d) => d <= Maximum && d >= Minimum;

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control || e.Shift) && e.KeyCode == Keys.Return)
                Calculate(sender, e);
            else if (e.KeyCode == Keys.Return && SkipEventDuringInput)
            {
                SkipEventDuringInput = false;
                textBox_TextChanged(sender, e);
                SkipEventDuringInput = true;
            }
        }

        public void Calculate(object sender, EventArgs e)
        {
            double d = 0;
            //���݂̃J�[�\���ʒu�̃e�L�X�g���v�Z����
            int count = 0;
            int selectionLine = 0;
            for (int i = 0; i < textBox.Lines.Length; i++)
            {
                count += textBox.Lines[i].Length + 2;
                if (count > textBox.SelectionStart)
                {
                    selectionLine = i;
                    break;
                }
            }
            string[] formula = new string[selectionLine + 1];
            Array.Copy(textBox.Lines, formula, selectionLine + 1);
            d = NumericalFormula.GetNumetricValue(formula);
            if (!double.IsNaN(d))
            {
                skipTextChangeEvent = true;
                this.numericalValue = d;
                if (textBox.Multiline)
                {
                    if (textBox.Text.IndexOf("\r\n", textBox.SelectionStart) >= 0)
                        textBox.Text = textBox.Text.Remove(textBox.Text.IndexOf("\r\n", textBox.SelectionStart));

                    textBox.Text += "\r\n" + GetString();
                }
                else
                {
                    textBox.Text = GetString();
                }

                this.numericalValue = d;
                ValueChanged?.Invoke(this, e);

                skipTextChangeEvent = false;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        /// <summary>
        /// ���݂�numericalValue����e�L�X�g�{�b�N�X�̕������ݒ肷��
        /// </summary>
        /// <returns></returns>
        private string GetString()
        {
            if (InvokeRequired)
                return (string)Invoke(new Func<string>(GetString), null);

            string text = "";
            if (double.IsNaN(numericalValue))
                return double.NaN.ToString();

            if (ShowFraction) //�����ŕ\������Ƃ�
            {
                int j = (int)Math.Ceiling(numericalValue - 1);
                if (Math.Abs(numericalValue - j - 1.0 / 2.0) < 0.0000000001) text = (1 + 2 * j).ToString() + "/2";
                else if (Math.Abs(numericalValue - j - 1.0 / 3.0) < 0.0000000001) text = (1 + 3 * j).ToString() + "/3";
                else if (Math.Abs(numericalValue - j - 2.0 / 3.0) < 0.0000000001) text = (2 + 3 * j).ToString() + "/3";
                else if (Math.Abs(numericalValue - j - 1.0 / 4.0) < 0.0000000001) text = (1 + 4 * j).ToString() + "/4";
                else if (Math.Abs(numericalValue - j - 3.0 / 4.0) < 0.0000000001) text = (3 + 4 * j).ToString() + "/4";
                else if (Math.Abs(numericalValue - j - 1.0 / 6.0) < 0.0000000001) text = (1 + 6 * j).ToString() + "/6";
                else if (Math.Abs(numericalValue - j - 5.0 / 6.0) < 0.0000000001) text = (5 + 6 * j).ToString() + "/6";
                else if (Math.Abs(numericalValue - j - 1.0 / 12.0) < 0.0000000001) text = (1 + 12 * j).ToString() + "/12";
                else if (Math.Abs(numericalValue - j - 5.0 / 12.0) < 0.0000000001) text = (5 + 12 * j).ToString() + "/12";
                else if (Math.Abs(numericalValue - j - 7.0 / 12.0) < 0.0000000001) text = (7 + 12 * j).ToString() + "/12";
                else if (Math.Abs(numericalValue - j - 11.0 / 12.0) < 0.0000000001) text = (11 + 12 * j).ToString() + "/12";
            }

            if (text == "")
            {
                text = numericalValue.ToString(DecimalPlaces >= 0 ? "f" + DecimalPlaces.ToString() : "");
                text = separateThousands(text);
            }
            if (!text.StartsWith("-") && ShowPositiveSign && text != "0")
                text = "+" + text;

            return text;
        }

        private string separateThousands(string valueString)
        {
            char decimalPoint = '.';
            if (valueString.Contains(","))
                decimalPoint = ',';

            string[] integer = valueString.Split(new[] { decimalPoint });
            for (int i = integer[0].Length - 3; i > 0; i -= 3)
            {
                if (integer[0][i - 1] != '-')
                    integer[0] = integer[0].Insert(i, ",");
            }
            valueString = integer[0];
            if (integer.Length == 2)
                valueString += decimalPoint + integer[1];
            return valueString;
        }

        private void textBox_FontChanged(object sender, EventArgs e)
        {
            /*  if (Multiline == false)
              {
                  this.Height = textBox.Height+3;
                  this.Width = textBox.Width+1;
              }*/
            TextFont = textBox.Font;
        }

        private void NumericalTextBox_SizeChanged(object sender, EventArgs e)
        {
            if (Multiline == false)
            {
                this.Height = textBox.Height;
                MinimumSize = new Size(1, textBox.Height);
                MaximumSize = new Size(1000, textBox.Height);
            }
        }

        internal void SetToolTip(string p)
        {
            throw new NotImplementedException();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown.ValueChanged -= numericUpDown_ValueChanged;

            if (SmartIncrement)
            {
                double value = Math.Abs(this.Value);

                int n = 0;
                int sign = this.Value > 0 ? 1 : -1;

                if (value != 0)
                    n = (int)(Math.Floor(Math.Log10(Math.Abs(value))));
                else if (DecimalPlaces >= 0)
                    n = -DecimalPlaces;
                else
                    n = -1;

                double step = 0;
                if ((numericUpDown.Value == 1 && sign == 1) || numericUpDown.Value == -1 && sign == -1)
                {
                    if (value < Math.Pow(10, n) * 2.0)
                        step = Math.Pow(10, n - 1);
                    else if (value < Math.Pow(10, n) * 4.0)
                        step = Math.Pow(10, n - 1) * 2;
                    else
                        step = Math.Pow(10, n - 1) * 5;
                    if (DecimalPlaces >= 0)
                        step = Math.Max(step, Math.Pow(10, -DecimalPlaces));
                    value += step;
                }
                else
                {
                    if (value > Math.Pow(10, n) * 4.0)
                        step = Math.Pow(10, n - 1) * 5;
                    else if (value > Math.Pow(10, n) * 2.0)
                        step = Math.Pow(10, n - 1) * 2;
                    else if (value > Math.Pow(10, n) * 1.0)
                        step = Math.Pow(10, n - 1) * 1;
                    else
                        step = Math.Pow(10, n - 1) * 0.5;
                    if (DecimalPlaces >= 0)
                        step = Math.Max(step, Math.Pow(10, -DecimalPlaces));
                    value -= step;
                }
                if (value != 0)
                {
                    n = (int)(Math.Floor(Math.Log10(Math.Abs(value))));
                    double a = Math.Round(value / Math.Pow(10, n - 1), MidpointRounding.ToEven);
                    double b = Math.Pow(10, n - 1);
                    this.Value = sign * a * b;
                }
                else
                    this.Value = 0;
            }
            else
            {
                if (numericUpDown.Value == 1)
                    this.Value += UpDown_Increment;
                else
                    this.Value -= UpDown_Increment;
            }
            numericUpDown.Value = 0;

            numericUpDown.ValueChanged += numericUpDown_ValueChanged;
        }

        private void smartIncrementToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            SmartIncrement = smartIncrementToolStripMenuItem.Checked;
        }

        private void toolStripComboBoxIncrement_TextUpdate(object sender, EventArgs e)
        {
            double.TryParse(toolStripComboBoxIncrement.Text, out double inc);
            if (inc > 0)
                UpDown_Increment = inc;
        }

        private void toolStripComboBoxIncrement_SelectedIndexChanged(object sender, EventArgs e)
        {
            double.TryParse(toolStripComboBoxIncrement.Text, out double inc); ;
            if (inc > 0)
                UpDown_Increment = inc;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if (SkipEventDuringInput)
            {
                SkipEventDuringInput = false;
                textBox_TextChanged(sender, e);
                SkipEventDuringInput = true;
            }
        }

        private void toolStripComboBoxDecimalPlaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox.Text = GetString();
        }

        private void thousandsSeparatorToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            textBox.Text = GetString();
        }

        private void toolStripTextBoxMaximum_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void toolStripTextBoxMaximum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar == '\b');
        }

        private void contextMenuStripBody_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            double.TryParse(toolStripTextBoxMimimum.Text, out double min);
            if (min < Maximum && Minimum != min)
            {
                Minimum = min;
                LimitChanged?.Invoke(this, e);
            }
            double.TryParse(toolStripTextBoxMaximum.Text, out double max);
            if (max > Minimum && Maximum != max)
            {
                Maximum = max;
                LimitChanged?.Invoke(this, e);
            }

            double.TryParse(toolStripTextBoxMouseSpeed.Text, out double speed);
            if (speed > 0)
                mouseSpeed = speed;
        }

        private void toolStripMenuItemRestrictLimit_CheckedChanged(object sender, EventArgs e)
        {
            toolStripMenuItem1.Enabled = toolStripMenuItem2.Enabled = toolStripMenuItemRestrictLimit.Checked;
        }

        #region �}�E�X�R���g���[�����[�h

        public bool AllowMouseControl { get { return allowMouseContlolToolStripMenuItem.Checked; } set { allowMouseContlolToolStripMenuItem.Checked = value; } }

        public VH_DirectionEnum MouseDirection
        {
            get { return toolStripComboBoxMouseDirection.SelectedIndex == 0 ? VH_DirectionEnum.Vertical : VH_DirectionEnum.Horizontal; }
            set { toolStripComboBoxMouseDirection.SelectedIndex = VH_DirectionEnum.Vertical == value ? 0 : 1; }
        }

        private double mouseSpeed = 1;

        public double MouseSpeed
        {
            set
            {
                if (value > 0)
                {
                    mouseSpeed = value;
                    string text = mouseSpeed.ToString();
                    //text = separateThousands(text);
                    toolStripTextBoxMouseSpeed.Text = text;
                }
            }
            get { return mouseSpeed; }
        }

        private Point justBeforeMousePosition = new Point();
        private bool mouseMoving = false;

        private void textBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle && mouseMoving && AllowMouseControl)
            {
                int delta = MouseDirection == VH_DirectionEnum.Vertical ? justBeforeMousePosition.Y - e.Y : e.X - justBeforeMousePosition.X;

                Value += delta * MouseSpeed;

                justBeforeMousePosition = e.Location;
            }
        }

        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                mouseMoving = true;
                justBeforeMousePosition = e.Location;
            }
        }

        private void textBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseMoving = false;
        }

        private void allowMouseContlolToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            toolStripMenuItem3.Enabled = toolStripMenuItem4.Enabled = allowMouseContlolToolStripMenuItem.Checked;
        }

        private void toolStripTextBoxMouseSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar == '\b');
        }

        #endregion �}�E�X�R���g���[�����[�h
    }
}