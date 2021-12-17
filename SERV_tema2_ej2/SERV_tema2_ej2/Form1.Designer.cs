
namespace SERV_tema2_ej2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtDirectorio = new System.Windows.Forms.TextBox();
            this.txtPalabra = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.checkMayus = new System.Windows.Forms.CheckBox();
            this.txtMultiline = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblPalabra = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDirectorio
            // 
            this.txtDirectorio.Location = new System.Drawing.Point(12, 23);
            this.txtDirectorio.Name = "txtDirectorio";
            this.txtDirectorio.Size = new System.Drawing.Size(237, 20);
            this.txtDirectorio.TabIndex = 0;
            // 
            // txtPalabra
            // 
            this.txtPalabra.Location = new System.Drawing.Point(12, 71);
            this.txtPalabra.Name = "txtPalabra";
            this.txtPalabra.Size = new System.Drawing.Size(120, 20);
            this.txtPalabra.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(162, 66);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(87, 29);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "SEARCH";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // checkMayus
            // 
            this.checkMayus.AutoSize = true;
            this.checkMayus.Location = new System.Drawing.Point(162, 111);
            this.checkMayus.Name = "checkMayus";
            this.checkMayus.Size = new System.Drawing.Size(101, 17);
            this.checkMayus.TabIndex = 3;
            this.checkMayus.Text = "Mayus sensitive";
            this.checkMayus.UseVisualStyleBackColor = true;
            // 
            // txtMultiline
            // 
            this.txtMultiline.Location = new System.Drawing.Point(317, 23);
            this.txtMultiline.Multiline = true;
            this.txtMultiline.Name = "txtMultiline";
            this.txtMultiline.ReadOnly = true;
            this.txtMultiline.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMultiline.Size = new System.Drawing.Size(309, 406);
            this.txtMultiline.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(12, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(159, 46);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 6;
            // 
            // lblPalabra
            // 
            this.lblPalabra.AutoSize = true;
            this.lblPalabra.Location = new System.Drawing.Point(12, 55);
            this.lblPalabra.Name = "lblPalabra";
            this.lblPalabra.Size = new System.Drawing.Size(80, 13);
            this.lblPalabra.TabIndex = 7;
            this.lblPalabra.Text = "Word to search";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 450);
            this.Controls.Add(this.lblPalabra);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtMultiline);
            this.Controls.Add(this.checkMayus);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtPalabra);
            this.Controls.Add(this.txtDirectorio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Word-Searcher 3000";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDirectorio;
        private System.Windows.Forms.TextBox txtPalabra;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.CheckBox checkMayus;
        private System.Windows.Forms.TextBox txtMultiline;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblPalabra;
    }
}

