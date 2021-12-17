using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SERV_tema2_ej2
{
    public partial class Form1 : Form
    {
        static object l = new object();
        delegate void Buscador(int contador, TextBox textbox);
        Buscador buscador;
        DirectoryInfo dirInfo;
        Thread[] hilo;
        List<FileInfo> files = new List<FileInfo>();
        string directorio = "";
        string palabra = "";
        string[] extensiones = { ".txt", ".doc", ".docx", ".odt", ".pdf", ".rtf", ".csv", ".xls", ".xlsx", ".ods",
                                ".pps", ".ppt", ".ppsx", ".pptx",".ppsm", ".pptm", ".potx", ".odp" };
        bool terminado = false;

        public Form1()
        {
            InitializeComponent();
            directorio = Directory.GetCurrentDirectory();
            pictureBox1.Image = Image.FromFile("C:\\Users\\AlvaroVila\\source\\repos\\SERV_tema2_ej2\\SERV_tema2_ej2\\bocatagarto.jpg");
        }

        private void FileCheck(string directorio, string palabra) // Comprueba que el directorio existe, encuentra los archivos de texto y llama a los hilos buscadores
        {
            this.directorio = directorio;
            this.palabra = palabra;
            int numberThreads = 0;

            if (Directory.Exists(directorio))
            {
                Directory.SetCurrentDirectory(directorio);
                dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    for (int i = 0; i < extensiones.Length; i++)
                    {
                        if (file.Name.EndsWith(extensiones[i]))
                        {
                            files.Add(file);
                            numberThreads++;
                        }
                    }
                }
            }

            lblInfo.Text = "Number of files: " + numberThreads;

            hilo = new Thread[numberThreads];

            for (int i = 0; i < hilo.Length; i++)
            {
                hilo[i] = new Thread(HiloBuscador);
                hilo[i].Start(files[i]);
            }

            //for (int i = 0; i < hilo.Length; i++)
            //{
            //    hilo[i].Join();
            //}
        }

        private void HiloBuscador(Object file) // Los hilos que buscan la palabra en cada fichero añadido a la List
        {
            FileInfo archivo = (FileInfo)file;
            StreamReader reader;
            buscador = new Buscador(addToTextBox); // Se le pasa al delegado la función que añade al textbox el número de veces que sale la cadena en cada archivo
            string linea = "";
            int contador = 0;

            while (!terminado)
            {
                lock (l)
                {
                    if (!terminado)
                    {
                        using (reader = new StreamReader(archivo.FullName))
                        {
                            while ((linea = reader.ReadLine()) != null)
                            {
                                if (linea.Contains(palabra))
                                {
                                    contador++;
                                }

                                if (linea == null)
                                {
                                    terminado = true;
                                }
                            }

                            this.Invoke(buscador, contador, txtMultiline);
                        }
                    }
                }
            }
        }

        private void addToTextBox(int contador, TextBox textbox)
        {
            txtMultiline.AppendText(contador + "\n");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FileCheck(txtDirectorio.Text, txtPalabra.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Exit program?", "SERV Tema2 ej2",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}