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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            GetProcesses();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            GetProcessInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseProcess();
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            KillProcess();
        }

        private void btnRunApp_Click(object sender, EventArgs e)
        {
            RunApp();
        }

        private void btnStartsWith_Click(object sender, EventArgs e)
        {
            StartsWith();
        }

        private void GetProcesses()
        {
            string name;
            string windowTitle;
            textBox1.Text = "";
            processes = Process.GetProcesses();
            List<Process> prcsList = new List<Process>();

            foreach (Process p in processes)
            {
                prcsList.Add(p);
            }

            prcsList.ForEach(process =>   // Mejor con Array.ForEach
            {
                name = stringCropper(process.ProcessName);
                windowTitle = stringCropper(process.MainWindowTitle);
                textBox1.AppendText($"PID: {process.Id,5} | ProcessName: {name,15} | WindowTitle: {windowTitle} {Environment.NewLine}");
            });
        }

        private void GetProcessInfo()
        {
            textBox1.Text = "";

            try
            {
                getPID(int.Parse(textBox2.Text));
                if (process != null)
                {
                    ProcessModuleCollection modules = process.Modules;
                    ProcessThreadCollection threads = process.Threads;

                    textBox1.AppendText($"PID: {process.Id,5}, ProcessName: {process.ProcessName,15}, WindowTitle: {process.MainWindowTitle} {Environment.NewLine}");

                    foreach (ProcessThread pt in threads)
                    {
                        textBox1.AppendText($"Thread ID: {pt.Id}, StartTime: {pt.StartTime.ToShortTimeString()}, PriorityLevel: {pt.PriorityLevel}, ThreadState: {pt.ThreadState} {Environment.NewLine}");
                    }

                    foreach (ProcessModule pm in modules)
                    {
                        textBox1.AppendText($"{pm.ModuleName} ");
                    }
                }
            }
            catch (Exception ex) when (ex is Win32Exception || ex is FormatException)
            {
                label1.Text = "(!) Programa no encontrado";
            }
        }

        private void CloseProcess()
        {
            try
            {
                getPID(int.Parse(textBox2.Text));

                if (process != null)
                {
                    process.CloseMainWindow();
                }
            }
            catch (Exception ex) when (ex is FormatException || ex is ArgumentException)
            {
                label1.Text = "(!) Programa no encontrado";
            }
        }

        private void KillProcess()
        {
            try
            {
                getPID(int.Parse(textBox2.Text));

                if (process != null)
                {
                    process.Kill();
                }
            }
            catch (Exception ex) when (ex is FormatException || ex is ArgumentException || ex is Win32Exception)
            {
                label1.Text = "(!) Programa no encontrado";
            }
        }

        private void RunApp()
        {
            string programa = "";
            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                programa = textBox2.Text;

                try
                {
                    process = Process.Start(programa);
                }
                catch (Exception ex) when (ex is ArgumentException || ex is Win32Exception)
                {
                    label1.Text = "(!) Programa no encontrado";
                }
            }
            else
            {
                programa = "";
                label1.Text = "(!) Programa no encontrado";
            }
        }

        private void StartsWith()
        {
            textBox1.Text = "";
            List<Process> prcs = new List<Process>();
            processes = Process.GetProcesses();
            string processText = textBox2.Text.Trim();

            foreach (Process p in processes)  // Se puede hacer conArray.FindAll
            {
                if (p.ProcessName.StartsWith(processText.ToLower()))
                {
                    prcs.Add(p);
                }
            }

            prcs.ForEach(process => textBox1.AppendText($"PID: {process.Id,5}, ProcessName: {process.ProcessName,15}, WindowTitle: {process.MainWindowTitle} {Environment.NewLine}"));
        }

        private void getPID(int pid)
        {
            try
            {
                process = Process.GetProcessById(pid);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is Win32Exception)
            {
                label1.Text = "(!) Programa no encontrado";
            }
        }

        private string stringCropper(string titulo)
        {
            if (!string.IsNullOrEmpty(titulo) && titulo.Length > 12)
            {
                return titulo.Substring(0, 12) + "...";
            }

            return titulo;
        }
    }
}