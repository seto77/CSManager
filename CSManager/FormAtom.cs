using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Crystallography;
using GL;
using GLU;
using WGL;
using GLSharp;

namespace CSManager
{
    public partial class FormAtom : Form
    {
        public FormStructureViewer formStructureViewer;
        public int selectedAtom;
        
        public int originalColorSource;
        public float[] originalMatSource ;
        public float originalRadius;
        public bool originalIsDraw;
        public Material originalMat;

        public bool SkipChange=true;

        public FormAtom()
        {
            InitializeComponent();
        }

        internal void SetAtom(atom atom)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        public void SetOriginal()
        {
            originalColorSource = pictureBoxAtomColor.BackColor.ToArgb();
            originalMatSource = new float[]{
                    (float)numericUpDownAtomTransparency.Value, (float)numericUpDownAtomAmbient.Value,           (float)numericUpDownAtomDiffusion.Value,
                    (float)numericUpDownAtomSpecular.Value,                   (float)numericUpDownAtomEmmision.Value,              (float)numericUpDownAtomShininess.Value};
            originalRadius = (float)numericUpDownAtomRadius.Value;

            originalMat = new Material(" ", Color.FromArgb(originalColorSource), originalMatSource[0], originalMatSource[1], originalMatSource[2],
                originalMatSource[3], originalMatSource[4], originalMatSource[5]);
            originalIsDraw = checkBoxIsDraw.Checked;
        }

        private void FormAtom_Load(object sender, EventArgs e)
        {
            
        }

        private void numericUpDownAtomAmbient_ValueChanged(object sender, EventArgs e)
        {
            if (SkipChange) return;//ロードされる前は帰る
            int colorSource = pictureBoxAtomColor.BackColor.ToArgb();
            float[] matSource = new float[]{
                    (float)numericUpDownAtomTransparency.Value, (float)numericUpDownAtomAmbient.Value, (float)numericUpDownAtomDiffusion.Value,
                    (float)numericUpDownAtomSpecular.Value, (float)numericUpDownAtomEmmision.Value, (float)numericUpDownAtomShininess.Value};
            float radius = (float)numericUpDownAtomRadius.Value;

            Material mat = new Material(" ", Color.FromArgb(colorSource), matSource[0], matSource[1], matSource[2], matSource[3], matSource[4], matSource[5]);
            bool IsDraw = checkBoxIsDraw.Checked;

            int MainID = formStructureViewer.atoms[selectedAtom].MainID;

            if (radioButtonAllSameElement.Checked)
            {
                for (int i = 0; i < formStructureViewer.atoms.Count; i++)
                    if (formStructureViewer.atoms[i].element == formStructureViewer.atoms[selectedAtom].element)
                    {
                        formStructureViewer.atoms[i].matSource = matSource;
                        formStructureViewer.atoms[i].colorSource = colorSource;
                        formStructureViewer.atoms[i].radius = radius;
                        formStructureViewer.atoms[i].mat = mat;
                        formStructureViewer.atoms[i].IsDraw = IsDraw;
                    }

           
            }
            else if (radioButtonApplyEquivalentAtoms.Checked)
            {
                for (int i = 0; i < formStructureViewer.atoms.Count; i++)
                    if (formStructureViewer.atoms[i].element == formStructureViewer.atoms[selectedAtom].element)
                    {
                        formStructureViewer.atoms[i].matSource = originalMatSource;
                        formStructureViewer.atoms[i].colorSource = originalColorSource;
                        formStructureViewer.atoms[i].radius = originalRadius;
                        formStructureViewer.atoms[i].mat = originalMat;
                        formStructureViewer.atoms[i].IsDraw = originalIsDraw;
                    }

                for (int i = 0; i < formStructureViewer.atoms.Count; i++)
                    if (formStructureViewer.atoms[i].MainID == MainID && formStructureViewer.atoms[i].IsDraw)
                    {
                        formStructureViewer.atoms[i].matSource = matSource;
                        formStructureViewer.atoms[i].colorSource = colorSource;
                        formStructureViewer.atoms[i].radius = radius;
                        formStructureViewer.atoms[i].mat = mat;
                        formStructureViewer.atoms[i].IsDraw = IsDraw;
                    }

              
            }
            else if (radioButtonApplyThis.Checked)
            {
                for (int i = 0; i < formStructureViewer.atoms.Count; i++)
                    if (formStructureViewer.atoms[i].element == formStructureViewer.atoms[selectedAtom].element)
                    {
                        formStructureViewer.atoms[i].matSource = originalMatSource;
                        formStructureViewer.atoms[i].colorSource = originalColorSource;
                        formStructureViewer.atoms[i].radius = originalRadius;
                        formStructureViewer.atoms[i].mat = originalMat;
                        formStructureViewer.atoms[i].IsDraw = originalIsDraw;
                    }
                formStructureViewer.atoms[selectedAtom].matSource = matSource;
                formStructureViewer.atoms[selectedAtom].colorSource = colorSource;
                formStructureViewer.atoms[selectedAtom].radius = radius;
                formStructureViewer.atoms[selectedAtom].mat = mat;
                formStructureViewer.atoms[selectedAtom].IsDraw = IsDraw;
            }
            formStructureViewer.Draw();

        }

        private void pictureBoxAtomColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            colorDialog.Color = ((PictureBox)sender).BackColor;
            colorDialog.AllowFullOpen = true; colorDialog.AnyColor = true; colorDialog.SolidColorOnly = false; colorDialog.ShowHelp = true;
            colorDialog.ShowDialog();
            ((PictureBox)sender).BackColor = colorDialog.Color;
            numericUpDownAtomAmbient_ValueChanged(sender, e);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            float[] matSource = new float[]{
                    (float)numericUpDownAtomTransparency.Value, (float)numericUpDownAtomAmbient.Value, (float)numericUpDownAtomDiffusion.Value,
                    (float)numericUpDownAtomSpecular.Value, (float)numericUpDownAtomEmmision.Value, (float)numericUpDownAtomShininess.Value};
            float radius = (float)numericUpDownAtomRadius.Value;

            int MainID = formStructureViewer.atoms[selectedAtom].MainID;
            if (radioButtonAllSameElement.Checked)
            {
                for (int i = 0; i < formStructureViewer.formMain.crystalForm.presentCrystal.atoms.Length; i++)
                    if (formStructureViewer.formMain.crystalForm.presentCrystal.atoms[i].element == formStructureViewer.atoms[selectedAtom].element)
                    {
                        Atoms a = formStructureViewer.formMain.crystalForm.presentCrystal.atoms[i];
                        a.transparency = matSource[0];
                        a.ambient = matSource[1];
                        a.diffusion = matSource[2];
                        a.specular = matSource[3];
                        a.emission = matSource[4];
                        a.shininess = matSource[5];
                        a.radius = (float)radius;
                        
                    }
            }
            else if (radioButtonApplyEquivalentAtoms.Checked)
            {
                Atoms a = formStructureViewer.formMain.crystalForm.presentCrystal.atoms[MainID];
                a.transparency = matSource[0];
                a.ambient = matSource[1];
                a.diffusion = matSource[2];
                a.specular = matSource[3];
                a.emission = matSource[4];
                a.shininess = matSource[5];
                a.radius = (float)radius;
                a.color = pictureBoxAtomColor.BackColor;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

            int MainID = formStructureViewer.atoms[selectedAtom].MainID;
            for (int i = 0; i < formStructureViewer.atoms.Count; i++)
                if (formStructureViewer.atoms[i].MainID == MainID && formStructureViewer.atoms[i].IsDraw)
                {
                    formStructureViewer.atoms[i].matSource = originalMatSource;
                    formStructureViewer.atoms[i].colorSource = originalColorSource;
                    formStructureViewer.atoms[i].radius = originalRadius;
                    formStructureViewer.atoms[i].mat = originalMat;
                    formStructureViewer.atoms[i].IsDraw = originalIsDraw;
                }
        }

        private void FormAtom_Move(object sender, EventArgs e)
        {
            formStructureViewer.Draw();
        }


    }
}