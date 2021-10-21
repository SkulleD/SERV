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
            textBox1.Text = "";
            processes = Process.GetProcesses();

            foreach (Process p in processes) {
                textBox1.AppendText($"PID: {p.Id}, ProcessName: {p.ProcessName}, WindowTitle: {p.MainWindowTitle} {Environment.NewLine}");
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            getPID(int.Parse(textBox2.Text));
            textBox1.Text = $"PID: {process.Id}, ProcessName: {process.ProcessName}, WindowTitle: {process.MainWindowTitle}";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            getPID(int.Parse(textBox2.Text));
            process.CloseMainWindow();
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            getPID(int.Parse(textBox2.Text));
            process.Kill();
        }

        private void btnRunApp_Click(object sender, EventArgs e)
        {

            if (process.)
            process.Start();
        }

        private void btnStartsWith_Click(object sender, EventArgs e)
        {
            foreach (Process p in processes)
            {
                if (p.ProcessName.Contains(textBox1.Text))
                {

                }
            }
        }

        public void getPID(int pid) // Con return int da nullreferenceexception si no encuentra
        {
            try
            {
                process = Process.GetProcessById(pid);
            } catch (ArgumentException)
            {
                label1.Text = "(!) Programa no existente";
            }
        }
    }
}