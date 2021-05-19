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
            processes = Process.GetProcesses();

            foreach (Process p in processes)
            {
                textBox1.AppendText(p.Id + "\t" + Acortar(p.ProcessName, 15) + "\t" + p.MainWindowTitle + "\r\n");
            }
        }

        private void GetProcessInfo()
        {
            try
            {
                int pid = Convert.ToInt32(textBox2.Text);
                proceso = Process.GetProcessById(pid);
            }
            catch (FormatException)
            {

            }

            textBox1.ResetText();
            try
            {

            }
            catch (System.ComponentModel.Win32Exception)
            {
                textBox1.Text = String.Format("{0}\r\n{1}\r\n{2}\r\n{3}", proceso.Id, proceso.StartTime, proceso.MainModule, proceso.ProcessName);
            }
        }

        private void CloseProcess()
        {
            try
            {
                int pid = Convert.ToInt32(textBox2.Text);
                proceso = Process.GetProcessById(pid);
            }
            catch (FormatException)
            {

            }

            proceso.Close();
        }

        private void KillProcess()
        {
            try
            {
                int pid = Convert.ToInt32(textBox2.Text);
                proceso = Process.GetProcessById(pid);
            }
            catch (FormatException)
            {

            }

            proceso.Kill();
        }

        private void RunApp()
        {
            string appName = textBox2.Text;
            proceso = Process.Start(appName);
        }

        private string Acortar(string cadena, int longitud)
        {
            if (!string.IsNullOrEmpty(cadena) && cadena.Length > longitud)
            {
                return cadena.Substring(0, longitud) + "...";
            }
            return cadena;
        }
    }
}
