using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERV_tema2_ej1
{
    public partial class Form1 : Form
    {
        DirectoryInfo dirInfo;

        public Form1()
        {
            InitializeComponent();
            listBox.Items.Add("..");
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            string newDir = txtDirectorio.Text;

            try
            {
                if (Directory.Exists(newDir))
                {
                    if (newDir.StartsWith("%") && newDir.EndsWith("%"))
                    {
                        Environment.GetEnvironmentVariable(newDir);
                        Directory.SetCurrentDirectory(newDir);
                        lblWarningDir.Text = "";
                    }
                    else
                    {
                        Directory.SetCurrentDirectory(newDir);
                        lblWarningDir.Text = "";
                    }
                }

                dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
                rellenaListBox();
            }
            catch (Exception ex) when (ex is DirectoryNotFoundException || ex is IOException)
            {
                lblWarningDir.Text = "Directory not found!";
            }
        }

        private void rellenaListBox()
        {
            listBox.Items.Clear();
            listBox.Items.Add("..");
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                listBox.Items.Add(dir.Name);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Exit program?", "SERV Tema 2 ej1",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}