using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERV_tema1_ej2
{
    public partial class Form1 : Form
    {
        Process process;
        Process[] processes;

        public Form1()
        {
            InitializeComponent();
            //textBox1.Text.Font = new Font("Lucida Console", FontStyle.Bold, 16);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string name;
            string windowTitle;
            textBox1.Text = "";
            processes = Process.GetProcesses();

            foreach (Process p in processes)
            {
                name = stringCropper(p.ProcessName);
                windowTitle = stringCropper(p.MainWindowTitle);
                textBox1.AppendText($"PID: {p.Id}, ProcessName: {name}, WindowTitle: {windowTitle} {Environment.NewLine}");
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            try
            {
                getPID(int.Parse(textBox2.Text));
                textBox1.Text = $"PID: {process.Id}, ProcessName: {process.ProcessName}, WindowTitle: {process.MainWindowTitle}";
            }
            catch (FormatException)
            {
                label1.Text = "(!) Programa no encontrado";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                getPID(int.Parse(textBox2.Text));
                process.CloseMainWindow();
            }
            catch (FormatException)
            {
                label1.Text = "(!) Programa no encontrado";
            }
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            try
            {
                getPID(int.Parse(textBox2.Text));
                process.Kill();
            }
            catch (FormatException)
            {
                label1.Text = "(!) Programa no encontrado";
            }
        }

        private void btnRunApp_Click(object sender, EventArgs e)
        {
            string programa = textBox2.Text;
            try
            {
                //processes = Process.GetProcessesByName(textBox2.Text.ToString());
                process = Process.Start(programa);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is Win32Exception)
                    label1.Text = "(!) Programa no encontrado";
            }
        }

        private void btnStartsWith_Click(object sender, EventArgs e) // Array.Find, Array.Foreach y .ToArray
        {
            textBox1.Text = "";
            List<Process> prcs = new List<Process>();
            processes = Process.GetProcesses();

            foreach (Process p in processes)
            {
                if (p.ProcessName.StartsWith(textBox2.Text))
                {
                    prcs.Add(p);
                }

            }
            foreach (Process alvaro in prcs )
            {
                textBox1.AppendText ($"PID: {alvaro.Id}, ProcessName: {alvaro.ProcessName}, WindowTitle: {alvaro.MainWindowTitle} {Environment.NewLine}");
            }
        }

        public void getPID(int pid) // Con return int da nullreferenceexception si no encuentra
        {
            try
            {
                process = Process.GetProcessById(pid);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is FormatException)
                    label1.Text = "(!) Programa no encontrado";
            }
        }

        public string stringCropper(string titulo)
        {
            if (!string.IsNullOrEmpty(titulo) && titulo.Length > 12)
            {
                return titulo.Substring(0, 12) + "...";
            }

            return titulo;
        }
    }
}