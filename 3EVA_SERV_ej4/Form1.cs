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

namespace _3EVA_SERV_ej4
{
    public partial class Form1 : Form
    {
        Process[] processes;
        Process proceso;
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
                textBox1.AppendText(string.Format("{0, 6}{1, 6}{2, 6}", p.Id, Acortar(p.ProcessName, 15), p.MainWindowTitle)); //string.Format
            }
        }

        private void GetProcessInfo() // Poner los DLLs
        {
            try
            {
                textBox1.ResetText();
                label1.Text = "";
                int pid = Convert.ToInt32(textBox2.Text);
                proceso = Process.GetProcessById(pid);
                textBox1.ResetText();
                textBox1.Text = string.Format("{0}\r\n{1}\r\n{2}\r\n{3}", proceso.Id, proceso.StartTime, proceso.MainModule, proceso.ProcessName);
            }
            catch (FormatException)
            {
                label1.Text = "(!) Introduce un PID válido.";
            }
            catch (ArgumentException)
            {
                label1.Text = "(!) No se está ejecutando ningún\nproceso con ese PID.";
            }
            catch (OverflowException)
            {
                label1.Text = "(!) No existe ese proceso.";
            }
            catch (Win32Exception)
            {
                label1.Text = "(!) No tienes permisos.";
            }
        }

        private void CloseProcess()
        {
            try
            {
                textBox1.ResetText();
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    label1.Text = "";
                    int pid = Convert.ToInt32(textBox2.Text);
                    proceso = Process.GetProcessById(pid);
                    proceso.CloseMainWindow();
                }
            }
            catch (FormatException)
            {
                label1.Text = "(!) Introduce un PID válido.";
            }
            catch (ArgumentException)
            {
                label1.Text = "(!) No se está ejecutando ningún\nproceso con ese PID.";
            }
            catch (OverflowException)
            {
                label1.Text = "(!) No existe ese proceso.";
            }
            catch (InvalidOperationException)
            {

            }
            catch (Win32Exception)
            {
                label1.Text = "(!) No tienes permisos.";
            }

        }

        private void KillProcess()
        {
            try
            {
                textBox1.ResetText();
                label1.Text = "";
                int pid = Convert.ToInt32(textBox2.Text);
                proceso = Process.GetProcessById(pid);
                proceso.Kill();
            }
            catch (FormatException)
            {
                label1.Text = "(!) Introduce un PID válido.";
            }
            catch (ArgumentException)
            {
                label1.Text = "(!) No se está ejecutando ningún\nproceso con ese PID.";
            }
            catch (OverflowException)
            {
                label1.Text = "(!) No existe ese proceso.";
            }
            catch (InvalidOperationException)
            {

            }
            catch (Win32Exception)
            {
                label1.Text = "(!) No tienes permisos.";
            }
        }

        private void RunApp()
        {
            try
            {
                textBox1.ResetText();
                label1.Text = "";
                string appName = textBox2.Text;
                proceso = Process.Start(appName);
            }
            catch (Win32Exception)
            {
                label1.Text = "(!) No se encuentra la aplicación.";
            }
            catch (InvalidOperationException)
            {

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

        private void SaveLog()
        {
            //PID y texto 
        }
    }
}
