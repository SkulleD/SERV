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
    public partial class Form2 : Form
    {
        string originalText = "";

        public Form2(string name, string fileText)
        {
            InitializeComponent();
            this.Text = name;
            textBox1.Text = fileText;
            originalText = fileText;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!textBox1.Text.Equals(originalText))
            {
                if (MessageBox.Show("The file has been changed. Do you want to save the changes?",
                    "File changed", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    File.WriteAllText(this.Text, textBox1.Text);
                }
            }
        }
    }
}
