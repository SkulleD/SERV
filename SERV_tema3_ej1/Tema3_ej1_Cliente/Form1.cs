﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema3_ej1_Cliente
{
    public partial class Form1 : Form
    {
        Form2 form2;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            form2 = new Form2(txtIP.Text, int.Parse(txtPuerto.Text));
            this.Visible = false;
            form2.ShowDialog();
            this.Close();
        }
    }
}