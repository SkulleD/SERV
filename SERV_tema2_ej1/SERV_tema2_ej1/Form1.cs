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
    public partial class Form1 : Form // TODO ".. no va bien", "que no salga este directorio al poner otra unidad", "el if de FormClosing"
    {
        DirectoryInfo dirInfo;
        FileInfo fileInfo;
        string dirActual = "";
        Form2 form2;
        DialogResult res;
        string fileSizeText = "";
        int fileSize = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            dirActual = txtDirectorio.Text;
            string dirEntorno = Environment.ExpandEnvironmentVariables(dirActual);
            dirActual = dirEntorno;

            try
            {
                if (Directory.Exists(dirEntorno))
                {
                    txtDirectorio.Text = dirActual;
                    Directory.SetCurrentDirectory(dirEntorno);
                    lblWarningDir.Text = "";
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
            listBox.Items.Clear();
            listBox.Items.Add("..");

            try
            {
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    listBox.Items.Add(dir.Name);
                }
            }
            catch (UnauthorizedAccessException)
            {
                lblWarningDir.Text = "Unauthorized Access!";
            }
        }

        private void rellenaArchivos()
        {
            listBox2.Items.Clear();

            try
            {
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    listBox2.Items.Add(file);
                }
            }
            catch (UnauthorizedAccessException)
            {
                lblWarningDir.Text = "Unauthorized Access!";
            }
        }

        private int checkFileSize(FileInfo file)
        {
            if ((file.Length / 1024) < 1024)
            {
                fileSize = (int)file.Length / 1024;
                fileSizeText = "KB";
            }
            else if (((file.Length / 1024) / 1024) < 1024)
            {
                fileSize = (int)((file.Length / 1024) / 1024);
                fileSizeText = "MB";
            }
            else
            {
                fileSize = (int)((file.Length / 1024) / 1024) / 1024;
                fileSizeText = "GB";
            }

            return fileSize;
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
                    btnCambiar.PerformClick();
                }
            }
            catch (DirectoryNotFoundException)
            {
                lblWarningDir.Text = "Directory not found!";
            }
            catch (UnauthorizedAccessException)
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
                fileSize = checkFileSize(fileInfo);

                if (fileInfo.Name.EndsWith(".txt"))
                {
                    lblFileSize.Text = $"File: {fileInfo.Name} Size: {fileSize} {fileSizeText}";

                    using (reader = new StreamReader(fileInfo.FullName))
                    {
                        try
                        {
                            fileText = reader.ReadToEnd();
                        }
                        catch (Exception ex) when (ex is IOException || ex is IOException)
                        {

                        }
                    }

                    form2 = new Form2(fileInfo.Name, fileText);
                    res = form2.ShowDialog();
                }
                else
                {
                    lblFileSize.Text = $"File: {fileInfo.Name} Size: {fileSize} {fileSizeText}";
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Exit program?", "SERV Tema 2 ej1",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                e.Cancel = false;
            }
        }
    }
}