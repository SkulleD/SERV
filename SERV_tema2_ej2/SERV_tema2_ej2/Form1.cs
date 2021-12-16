using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERV_tema2_ej2
{
    public partial class Form1 : Form
    {
        static object l = new object();
        delegate void Buscador(string palabra, TextBox textbox);
        Buscador buscador;
        DirectoryInfo dirInfo;
        Thread[] hilo;
        ArrayList files = new ArrayList();
        string directorio = "";
        string palabra = "";
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
            string linea = "";
            int numberThreads = 0;

            if (Directory.Exists(directorio))
            {
                Directory.SetCurrentDirectory(directorio);
                dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
                lblInfo.Text = "Ta bien";
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    try
                    {
                        Stream stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
                        linea = "";

                        for (int i = 0; i < stream.Length; i++) // Comprueba el archivo para ver si es de texto sencillo o no (solo vale texto sencillo)
                        {
                            int chara = stream.ReadByte();

                            if (chara >= 0 && chara <= 127) // Si es un archivo con solo texto sencillo se añade al ArrayList de archivos de texto donde buscar la palabra
                            {
                                files.Add(file);
                                numberThreads++;
                            }
                        }

                        stream.Dispose();
                    }
                    catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException || ex is IOException || ex is UnauthorizedAccessException)
                    {

                    }
                }
            }

            hilo = new Thread[numberThreads];

            for (int i = 0; i < hilo.Length; i++)
            {
                hilo[i] = new Thread(HiloBuscador(files[i]));
            }
        }

        private void HiloBuscador(File file) // Los hilos que buscan la palabra
        {
            while (!terminado)
            {
                lock (l)
                {
                    if (!terminado)
                    {

                    }
                }
            }
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