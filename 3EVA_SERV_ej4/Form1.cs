using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _3EVA_SERV_ej4
{
    public partial class Form1 : Form
    {
        Process[] processes;
        Process proceso;
        bool success = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetProcesses();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetProcessInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CloseProcess();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KillProcess();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RunApp();
        }

        private void GetProcesses()
        {
            label1.Text = "";
            processes = Process.GetProcesses();

            textBox1.ResetText();
            foreach (Process p in processes)
            {
                textBox1.AppendText(string.Format("{0}\t{1}\t{2}\r\n", p.Id, Acortar(p.ProcessName, 15), p.MainWindowTitle));
            }
        }

        private void GetProcessInfo() // Poner los DLLs y subprocesos
        {
            int pid = 0;
            try
            {
                textBox1.ResetText();
                label1.Text = "";
                pid = Convert.ToInt32(textBox2.Text);
                proceso = Process.GetProcessById(pid);
                textBox1.ResetText();
                textBox1.Text = string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n", proceso.Id, proceso.ProcessName, proceso.StartTime, proceso.MainModule, proceso.Modules);
                success = true;
            }
            catch (FormatException)
            {
                success = false;
                label1.Text = "(!) Introduce un PID válido.";
            }
            catch (ArgumentException)
            {
                success = false;
                label1.Text = "(!) No se está ejecutando ningún\nproceso con ese PID.";
            }
            catch (OverflowException)
            {
                success = false;
                label1.Text = "(!) No existe ese proceso.";
            }
            catch (Win32Exception)
            {
                success = false;
                label1.Text = "(!) No tienes permisos.";
            }

            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string txtFile = ruta + "\\TaskManager.txt";
            if (success)
            {
                using (StreamWriter writer = new StreamWriter(txtFile, true))
                {
                    try
                    {
                        writer.Write(proceso.StartTime.ToString() + " PID: " + pid.ToString() + " Action: GetProcessInfo\n");
                        writer.Flush();
                        writer.Close();
                    }
                    catch (Win32Exception)
                    {
                        success = false;
                        label1.Text = "(!) No tienes permisos.";
                    }
                }
            }
        }

        private void CloseProcess()
        {
            int pid = 0;
            try
            {
                textBox1.ResetText();
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    label1.Text = "";
                    pid = Convert.ToInt32(textBox2.Text);
                    proceso = Process.GetProcessById(pid);
                    proceso.CloseMainWindow();
                    success = true;
                }
            }
            catch (FormatException)
            {
                success = false;
                label1.Text = "(!) Introduce un PID válido.";
            }
            catch (ArgumentException)
            {
                success = false;
                label1.Text = "(!) No se está ejecutando ningún\nproceso con ese PID.";
            }
            catch (OverflowException)
            {
                success = false;
                label1.Text = "(!) No existe ese proceso.";
            }
            catch (InvalidOperationException)
            {
                success = false;
            }
            catch (Win32Exception)
            {
                success = false;
                label1.Text = "(!) No tienes permisos.";
            }

            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string txtFile = ruta + "\\TaskManager.txt";
            if (success)
            {
                using (StreamWriter writer = new StreamWriter(txtFile, true))
                {
                    try
                    {
                        writer.Write(proceso.StartTime.ToString() + " PID: " + pid.ToString() + " Action: CloseProcess\n");
                        writer.Flush();
                        writer.Close();
                    }
                    catch (Win32Exception)
                    {
                        success = false;
                        label1.Text = "(!) No tienes permisos.";
                    }

                }
            }
        }

        private void KillProcess()
        {
            int pid = 0;
            try
            {
                textBox1.ResetText();
                label1.Text = "";
                pid = Convert.ToInt32(textBox2.Text);
                proceso = Process.GetProcessById(pid);
                proceso.Kill();
                success = true;
            }
            catch (FormatException)
            {
                success = false;
                label1.Text = "(!) Introduce un PID válido.";
            }
            catch (ArgumentException)
            {
                success = false;
                label1.Text = "(!) No se está ejecutando ningún\nproceso con ese PID.";
            }
            catch (OverflowException)
            {
                success = false;
                label1.Text = "(!) No existe ese proceso.";
            }
            catch (InvalidOperationException)
            {
                success = false;
            }
            catch (Win32Exception)
            {
                success = false;
                label1.Text = "(!) No tienes permisos.";
            }

            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string txtFile = ruta + "\\TaskManager.txt";
            if (success)
            {
                using (StreamWriter writer = new StreamWriter(txtFile, true))
                {
                    try
                    {
                        writer.Write(proceso.StartTime.ToString() + " PID: " + pid.ToString() + " Action: KillProcess\n");
                        writer.Flush();
                        writer.Close();
                    }
                    catch (Win32Exception)
                    {
                        success = false;
                        label1.Text = "(!) No tienes permisos.";
                    }
                }
            }
        }

        private void RunApp()
        {
            int pid = 0;
            try
            {
                textBox1.ResetText();
                label1.Text = "";
                pid = Convert.ToInt32(textBox2.Text);
                proceso = Process.GetProcessById(pid);
                string appName = textBox2.Text;
                proceso = Process.Start(appName);
                success = true;
            }
            catch (Win32Exception)
            {
                success = false;
                label1.Text = "(!) No se encuentra la aplicación.";
            }
            catch (InvalidOperationException)
            {
                success = false;
            }
            catch (ArgumentException)
            {
                success = false;
                label1.Text = "(!) No se está ejecutando ningún\nproceso con ese PID.";
            }
            catch (FormatException)
            {
                success = false;
                label1.Text = "(!) Introduce un PID válido.";
            }

            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string txtFile = ruta + "\\TaskManager.txt";
            if (success)
            {
                using (StreamWriter writer = new StreamWriter(txtFile, true))
                {
                    try
                    {
                        writer.Write(proceso.StartTime.ToString() + " PID: " + pid.ToString() + " Action: RunApp\n");
                        writer.Flush();
                        writer.Close();
                    }
                    catch (Win32Exception)
                    {
                        success = false;
                        label1.Text = "(!) No tienes permisos.";
                    }
                }
            }
        }

        private string Acortar(string cadena, int longitud)
        {
            if (!string.IsNullOrEmpty(cadena) && cadena.Length > longitud)
            {
                return cadena.Substring(0, longitud - 3) + "...";
            }
            return cadena;
        }
    }
}
