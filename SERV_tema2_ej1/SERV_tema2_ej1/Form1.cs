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
        FileInfo fileInfo;
        string dirActual = "";
        Form2 form2;
        DialogResult res;

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
                rellenaArchivos();
            }
            catch (Exception ex) when (ex is DirectoryNotFoundException || ex is IOException)
            {
                lblWarningDir.Text = "Directory not found!";
            }
        }

        private void rellenaDirectorios()
        {
            try
            {
                listBox.Items.Clear();
                listBox.Items.Add("..");
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    listBox.Items.Add(dir.Name);
                }
            } catch (UnauthorizedAccessException)
            {
                lblWarningDir.Text = "Unauthorized Access!";
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
                if (listBox.SelectedItem != null)
                {
                    dirActual = listBox.SelectedItem.ToString();
                    txtDirectorio.Text = dirActual;
                    Directory.SetCurrentDirectory(dirActual);
                    listBox.Items.Clear();
                    this.btnCambiar_Click(sender, e);
                }
            }
            catch (DirectoryNotFoundException)
            {
                lblWarningDir.Text = "Directory not found!";
            } catch (UnauthorizedAccessException)
            {
                lblWarningDir.Text = "Unauthorized Access!";
            }
        }

        private void listBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            lblWarningDir.Text = "";
            StreamReader reader;
            string fileText = "";

            if (listBox2.SelectedItem != null)
            {
                fileInfo = (FileInfo)listBox2.SelectedItem;

                if (fileInfo.Name.EndsWith(".txt"))
                {
                    lblFileSize.Text = $"File: {fileInfo.Name} Size: {fileInfo.Length / 1024} KB";
                    reader = new StreamReader(fileInfo.FullName);
                    fileText = reader.ReadToEnd();
                    reader.Close();
                    form2 = new Form2(fileInfo.Name, fileText);
                    res = form2.ShowDialog();
                } else
                {
                    lblFileSize.Text = $"File: {fileInfo.Name} Size: {fileInfo.Length / 1024} KB";
                }
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