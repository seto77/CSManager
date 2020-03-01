using System;
using System.Drawing;
using System.Windows.Forms;

namespace Crystallography.Controls
{
    public partial class FormSymmetryInformation : Form
    {
        public Crystal crystal;
        public CrystalControl crystalControl;

        public FormSymmetryInformation()
        {
            InitializeComponent();
        }

        private void crystalControl_CrystalChanged(Crystal crystal)
        {
            ChangeCrystal(crystal);
        }

        private void ConvertRichTextBox1(ref RichTextBox rTB)
        {
            ConvertRichTextBoxOffsetSub(ref rTB, "sub1", 12); ConvertRichTextBoxOffsetSub(ref rTB, "sub2", 12); ConvertRichTextBoxOffsetSub(ref rTB, "sub3", 12);
            ConvertRichTextBoxOffsetSub(ref rTB, "sub4", 12); ConvertRichTextBoxOffsetSub(ref rTB, "sub5", 12);

            ConvertRichTextBoxItalic(ref rTB, "P", 14); ConvertRichTextBoxItalic(ref rTB, "A", 14); ConvertRichTextBoxItalic(ref rTB, "B", 14);
            ConvertRichTextBoxItalic(ref rTB, "C", 14); ConvertRichTextBoxItalic(ref rTB, "F", 14); ConvertRichTextBoxItalic(ref rTB, "I", 14);
            ConvertRichTextBoxItalic(ref rTB, "a", 14); ConvertRichTextBoxItalic(ref rTB, "b", 14); ConvertRichTextBoxItalic(ref rTB, "c", 14);
            ConvertRichTextBoxItalic(ref rTB, "n", 14); ConvertRichTextBoxItalic(ref rTB, "d", 14); ConvertRichTextBoxItalic(ref rTB, "m", 14);
            ConvertRichTextBoxItalic(ref rTB, "u", 14); ConvertRichTextBoxItalic(ref rTB, "v", 14); ConvertRichTextBoxItalic(ref rTB, "w", 14);
            ConvertRichTextBoxItalic(ref rTB, "x", 14); ConvertRichTextBoxItalic(ref rTB, "y", 14); ConvertRichTextBoxItalic(ref rTB, "z", 14);
        }

        private void ConvertRichTextBox2(ref RichTextBox rTB)
        {
            rTB.SelectAll();
            rTB.SelectionFont = new Font("Times New Roman", 12, FontStyle.Regular);
            rTB.SelectionCharOffset = -3;

            ConvertRichTextBoxItalic(ref rTB, "C", 12); ConvertRichTextBoxItalic(ref rTB, "D", 12); ConvertRichTextBoxItalic(ref rTB, "S", 12);
            ConvertRichTextBoxItalic(ref rTB, "T", 12); ConvertRichTextBoxItalic(ref rTB, "O", 12);

            ConvertRichTextBoxItalicSub(ref rTB, "i", 12); ConvertRichTextBoxItalicSub(ref rTB, "s", 12); ConvertRichTextBoxItalicSub(ref rTB, "h", 12);
            ConvertRichTextBoxItalicSub(ref rTB, "v", 12); ConvertRichTextBoxItalicSub(ref rTB, "d", 12);
            for (int n = 30; n > 0; n--)
            {
                string s = "^" + n.ToString();
                ConvertRichTextBoxOffsetSup(ref rTB, s, 12);
            }
        }

        private void ConvertRichTextBox3(ref RichTextBox rTB)
        {
            rTB.SelectAll();
            rTB.SelectionFont = new Font("Times New Roman", 13, FontStyle.Regular);
            if (rTB.Text == "No Condition") return;
            ConvertRichTextBoxOffsetSub(ref rTB, "sub1", 10); ConvertRichTextBoxOffsetSub(ref rTB, "sub2", 10); ConvertRichTextBoxOffsetSub(ref rTB, "sub3", 10);
            ConvertRichTextBoxOffsetSub(ref rTB, "sub4", 10); ConvertRichTextBoxOffsetSub(ref rTB, "sub5", 10);

            ConvertRichTextBoxItalic(ref rTB, "A", 12); ConvertRichTextBoxItalic(ref rTB, "B", 12); ConvertRichTextBoxItalic(ref rTB, "C", 12);
            ConvertRichTextBoxItalic(ref rTB, "I", 12); ConvertRichTextBoxItalic(ref rTB, "F", 12); ConvertRichTextBoxItalic(ref rTB, "R", 12);
            ConvertRichTextBoxItalic(ref rTB, "h", 12); ConvertRichTextBoxItalic(ref rTB, "k", 12); ConvertRichTextBoxItalic(ref rTB, "l", 12);
            ConvertRichTextBoxItalic(ref rTB, "a", 12); ConvertRichTextBoxItalic(ref rTB, "b", 12); ConvertRichTextBoxItalic(ref rTB, "c", 12);
            ConvertRichTextBoxItalic(ref rTB, "d", 12); ConvertRichTextBoxItalic(ref rTB, " n", 12);
        }

        private void ConvertRichTextBoxItalic(ref RichTextBox rTB, string s, int size)
        {
            int n = -1;
            while (rTB.Find(s, n + 1, RichTextBoxFinds.MatchCase) > n)
            {
                rTB.SelectionCharOffset = 0;
                rTB.SelectionFont = new Font("Times New Roman", size, FontStyle.Italic);
                n = rTB.Find(s, n + 1, RichTextBoxFinds.MatchCase);
            }
        }

        private void ConvertRichTextBoxItalicSub(ref RichTextBox rTB, string s, int size)
        {
            int n = -1;
            while (rTB.Find(s, n + 1, RichTextBoxFinds.MatchCase) > n)
            {
                rTB.SelectionCharOffset = -3;
                rTB.SelectionFont = new Font("Times New Roman", size, FontStyle.Italic);
                n = rTB.Find(s, n + 1, RichTextBoxFinds.MatchCase);
            }
        }

        private void ConvertRichTextBoxOffsetSub(ref RichTextBox rTB, string s, int size)
        {
            if (rTB.Find(s, 0, RichTextBoxFinds.MatchCase) > -1)
            {
                int n = -1;
                while (rTB.Find(s, n + 1, RichTextBoxFinds.MatchCase) > n)
                {
                    rTB.SelectionFont = new Font("Times New Roman", size, FontStyle.Regular);
                    rTB.SelectionCharOffset = -3;
                    n = rTB.Find(s, n + 1, RichTextBoxFinds.MatchCase);
                    rTB.Rtf = rTB.Rtf.Remove(rTB.Rtf.IndexOf(s), 3);
                }
            }
        }

        private void ConvertRichTextBoxOffsetSup(ref RichTextBox rTB, string s, int size)
        {
            if (rTB.Find(s, 0, RichTextBoxFinds.MatchCase) > -1)
            {
                int n = -1;
                while (rTB.Find(s, n + 1, RichTextBoxFinds.MatchCase) > n)
                {
                    rTB.SelectionFont = new Font("Times New Roman", size, FontStyle.Regular);
                    rTB.SelectionCharOffset = +3;
                    n = rTB.Find(s, n + 1, RichTextBoxFinds.MatchCase);
                    rTB.Rtf = rTB.Rtf.Remove(rTB.Rtf.IndexOf("^"), 1);
                }
            }
        }

        private void ConvertRichTextBoxReset(ref RichTextBox rTB)
        {
            rTB.SelectAll();
            rTB.SelectionFont = new Font("Times New Roman", 14, FontStyle.Regular);
        }

        private void FormCrystallographicInformation_Load(object sender, EventArgs e)
        {
            crystalControl.CrystalChanged += new CrystalControl.MyEventHandler(crystalControl_CrystalChanged);
            ChangeCrystal(crystal);
        }

        //������ύX����
        public void ChangeCrystal(Crystal crystal)
        {
            this.crystal = crystal;
            numericUpDown_ValueChanged(new object(), new EventArgs());
            SetWyckoffPosition();

            ConvertRichTextBoxReset(ref richTextBoxSG_HM);
            ConvertRichTextBoxReset(ref richTextBoxSG_HM_full);
            ConvertRichTextBoxReset(ref richTextBoxSG_SF);
            ConvertRichTextBoxReset(ref richTextBoxSG_Hall);
            ConvertRichTextBoxReset(ref richTextBoxPG_HM);
            ConvertRichTextBoxReset(ref richTextBoxPG_SF);
            ConvertRichTextBoxReset(ref richTextBoxLG);
            ConvertRichTextBoxReset(ref richTextBoxCS);
            ConvertRichTextBoxReset(ref richTextBoxExtinctionRule);

            richTextBoxSG_Num.Text = crystal.Symmetry.SpaceGroupNumber.ToString() + ": " + crystal.Symmetry.SpaceGroupSubNumber.ToString();
            richTextBoxSG_HM.Text = crystal.Symmetry.SpaceGroupHMStr;
            richTextBoxSG_HM_full.Text = crystal.Symmetry.SpaceGroupHMfullStr;
            richTextBoxSG_SF.Text = crystal.Symmetry.SpaceGroupSFStr;
            richTextBoxSG_Hall.Text = crystal.Symmetry.SpaceGroupHallStr;
            richTextBoxPG_HM.Text = crystal.Symmetry.PointGroupHMStr;
            richTextBoxPG_SF.Text = crystal.Symmetry.PointGroupSFStr;
            richTextBoxLG.Text = crystal.Symmetry.LaueGroupStr;
            richTextBoxCS.Text = crystal.Symmetry.CrystalSystemStr;
            richTextBoxExtinctionRule.Text = "";
            for (int n = 0; n < (SymmetryStatic.ExtinctionRule(crystal.Symmetry)).Length; n++)
                richTextBoxExtinctionRule.Text += (SymmetryStatic.ExtinctionRule(crystal.Symmetry))[n] + "\r\n";
            if (richTextBoxExtinctionRule.Text == "")
                richTextBoxExtinctionRule.Text = "No Condition";
            ConvertRichTextBox3(ref richTextBoxExtinctionRule);

            if (crystal.Symmetry.SeriesNumber != 0)
            {
                ConvertRichTextBox1(ref richTextBoxSG_HM);
                ConvertRichTextBox1(ref richTextBoxSG_HM_full);
                ConvertRichTextBox2(ref richTextBoxSG_SF);
                ConvertRichTextBox1(ref richTextBoxSG_Hall);
                ConvertRichTextBox1(ref richTextBoxPG_HM);
                ConvertRichTextBox2(ref richTextBoxPG_SF);
                ConvertRichTextBox1(ref richTextBoxLG);

                richTextBoxCS.SelectAll();
                richTextBoxCS.SelectionFont = new Font("Times New Roman", 15, FontStyle.Regular);
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int h1 = (int)numericUpDownH1.Value;
            int k1 = (int)numericUpDownK1.Value;
            int l1 = (int)numericUpDownL1.Value;
            int h2 = (int)numericUpDownH2.Value;
            int k2 = (int)numericUpDownK2.Value;
            int l2 = (int)numericUpDownL2.Value;
            int u1 = (int)numericUpDownU1.Value;
            int v1 = (int)numericUpDownV1.Value;
            int w1 = (int)numericUpDownW1.Value;
            int u2 = (int)numericUpDownU2.Value;
            int v2 = (int)numericUpDownV2.Value;
            int w2 = (int)numericUpDownW2.Value;

            textBoxLengthPlane1.Text = (crystal.GetLengthPlane(h1, k1, l1) * 10).ToString("f4");
            textBoxLengthPlane2.Text = (crystal.GetLengthPlane(h2, k2, l2) * 10).ToString("f4");
            textBoxLengthAxis1.Text = (crystal.GetLengthAxis(u1, v1, w1) * 10).ToString("f4");
            textBoxLengthAxis2.Text = (crystal.GetLengthAxis(u2, v2, w2) * 10).ToString("f4");

            textBoxAnglePlanes.Text = (crystal.GetAnglePlanes(h1, k1, l1, h2, k2, l2) * 180 / Math.PI).ToString("f4");
            textBoxAngleAxes.Text = (crystal.GetAngleAxes(u1, v1, w1, u2, v2, w2) * 180 / Math.PI).ToString("f4");
            textBoxAnglePlaneAxis1.Text = (crystal.GetAnglePlaneAxis(h1, k1, l1, u1, v1, w1) * 180 / Math.PI).ToString("f4");
            textBoxAnglePlaneAxis2.Text = (crystal.GetAnglePlaneAxis(h2, k2, l2, u2, v2, w2) * 180 / Math.PI).ToString("f4");

            textBoxZoneAxis.Text = "[" + crystal.GetZoneAxis(h1, k1, l1, h2, k2, l2) + " ]";
            textBoxZonePlane.Text = "(" + crystal.GetZoneAxis(u1, v1, w1, u2, v2, w2) + " )";
        }

        private void SetWyckoffPosition()
        {
            dataSet.Tables[0].Clear();
            if (crystal.Symmetry.LatticeTypeStr == "P")
                dataSet.Tables[0].Rows.Add(new object[] { "-", "-", "-", "(0,0,0)+", "", "", "" });
            else if (crystal.Symmetry.LatticeTypeStr == "A")
                dataSet.Tables[0].Rows.Add(new object[] { "-", "-", "-", "(0,0,0)+", "(0,1/2,1/2)+", "", "" });
            else if (crystal.Symmetry.LatticeTypeStr == "B")
                dataSet.Tables[0].Rows.Add(new object[] { "-", "-", "-", "(0,0,0)+", "(1/2,0,1/2)+", "", "" });
            else if (crystal.Symmetry.LatticeTypeStr == "C")
                dataSet.Tables[0].Rows.Add(new object[] { "-", "-", "-", "(0,0,0)+", "(1/2,1/2,0)+", "", "" });
            else if (crystal.Symmetry.LatticeTypeStr == "F")
                dataSet.Tables[0].Rows.Add(new object[] { "-", "-", "-", "(0,0,0)+", "(0,1/2,1/2)+", "(1/2,0,1/2)+", "(1/2,0,1/2)+" });
            else if (crystal.Symmetry.LatticeTypeStr == "I")
                dataSet.Tables[0].Rows.Add(new object[] { "-", "-", "-", "(0,0,0)+", "(1/2,1/2,1/2)+", "", "" });
            else if (crystal.Symmetry.LatticeTypeStr == "H")
                dataSet.Tables[0].Rows.Add(new object[] { "-", "-", "-", "(0,0,0)+", "(1/3,2/3,2/3)+", "(2/3,1/3,1/3)+", "" });

            crystal.Symmetry = SymmetryStatic.Get_Symmetry(crystal.SymmetrySeriesNumber);

            for (int i = 0; i < SymmetryStatic.WyckoffPositions[crystal.SymmetrySeriesNumber].Length; i++)
            {
                int len = SymmetryStatic.WyckoffPositions[crystal.SymmetrySeriesNumber][i].PositionStr.Length;
                for (int j = 0; j < len; j += 4)
                {
                    object[] o;
                    if (j == 0)
                    {
                        o = new object[] {
                               SymmetryStatic.WyckoffPositions[crystal.SymmetrySeriesNumber][i].Multiplicity,
                               SymmetryStatic.WyckoffPositions[crystal.SymmetrySeriesNumber][i].WyckoffLetter,
                                SymmetryStatic.WyckoffPositions[crystal.SymmetrySeriesNumber][i].SiteSymmetry,
                                j<len ? SymmetryStatic.WyckoffPositions[crystal.SymmetrySeriesNumber][i].PositionStr[j] : "",
                                j+1<len ? SymmetryStatic.WyckoffPositions[crystal.SymmetrySeriesNumber][i].PositionStr[j+1] : "",
                                j+2<len ? SymmetryStatic.WyckoffPositions[crystal.SymmetrySeriesNumber][i].PositionStr[j+2] : "",
                                j+3<len ? SymmetryStatic.WyckoffPositions[crystal.SymmetrySeriesNumber][i].PositionStr[j+3] : ""
                            };
                    }
                    else
                    {
                        o = new object[] {
                               "",
                              "",
                                "",
                                j<len ? SymmetryStatic.WyckoffPositions[crystal.SymmetrySeriesNumber][i].PositionStr[j] : "",
                                j+1<len ? SymmetryStatic.WyckoffPositions[crystal.SymmetrySeriesNumber][i].PositionStr[j+1] : "",
                                j+2<len ? SymmetryStatic.WyckoffPositions[crystal.SymmetrySeriesNumber][i].PositionStr[j+2] : "",
                                j+3<len ? SymmetryStatic.WyckoffPositions[crystal.SymmetrySeriesNumber][i].PositionStr[j+3] : ""
                            };
                    }

                    dataSet.Tables[0].Rows.Add(o);
                }
            }
        }

        private void FormCrystallographicInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void label28_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}