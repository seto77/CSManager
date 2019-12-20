using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSManager
{
    public partial class FormAboutMe : Form
    {
        public FormAboutMe()
        {
            InitializeComponent();
        }

        private void linkLabelHomePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(linkLabelHomePage.Text);
            }
            catch { }
        }

        private void linkLabelMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:"+linkLabelMail.Text);
            }
            catch { }
        }

        private void FormAboutMe_Load(object sender, EventArgs e)
        {
            labelVersion.Text = "CSManager   " + Version.VersionAndDate;


            string str = "";

            str += Version.Introduction + "\r\n\r\n";//�͂��߂�
            str += Version.CopyRight + "\r\n\r\n";//���쌠
            str += Version.Condition + "\r\n\r\n";//���s����
            str += Version.Exemption + "\r\n\r\n";//�Ɛ�
            str += Version.Adress + "\r\n\r\n";//�A����
            str += Version.Acknowledge + "\r\n\r\n";//�ӎ�
            str += Version.History;//����

            textBoxReadMe.Text += str;

        }
    }
}