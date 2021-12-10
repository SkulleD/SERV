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
        string dirActual = "";
        string fileActual = "";
        double value = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {

            dirActual = txtDirectorio.Text;
            string dirEntorno = Environment.ExpandEnvironmentVariables(dirActual);

            try
            {
                if (Directory.Exists(dirEntorno) || Directory.Exists(dirActual))
                {
                    Directory.SetCurrentDirectory(dirEntorno);
                    lblWarningDir.Text = "";
                }
                else
                {
                    lblWarningDir.Text = "Directory not found!";
                }

                dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
                rellenaDirectorios();
            }
            catch (Exception ex) when (ex is DirectoryNotFoundException || ex is IOException)
            {
                lblWarningDir.Text = "Directory not found!";
            }
        }

        private void rellenaDirectorios()
        {
            listBox.Items.Clear();
            listBox.Items.Add("..");
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                listBox.Items.Add(dir.Name);
            }
        }

        private void rellenaArchivos()
        {
            listBox2.Items.Clear();

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                listBox2.Items.Add(file);
            }
        }

        private void listBox_SelectedValueChanged(object sender, EventArgs e)
        {
            lblWarningDir.Text = "";

            try
            {
                dirActual = listBox.SelectedItem.ToString();
                txtDirectorio.Text = dirActual;
                Directory.SetCurrentDirectory(dirActual);
                listBox.Items.Clear();
                this.btnCambiar_Click(sender, e);
                rellenaDirectorios();
                rellenaArchivos();
            }
            catch (DirectoryNotFoundException)
            {
                lblWarningDir.Text = "Directory not found!";
            }
        }

        private void listBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            lblWarningDir.Text = "";

            fileActual = listBox2.SelectedItem.ToString();
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