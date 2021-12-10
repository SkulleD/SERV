
namespace SERV_tema2_ej1
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
            this.btnCambiar = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.lblDirectorio = new System.Windows.Forms.Label();
            this.lblWarningDir = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDirectorio
            // 
            this.txtDirectorio.Location = new System.Drawing.Point(12, 50);
            this.txtDirectorio.Name = "txtDirectorio";
            this.txtDirectorio.Size = new System.Drawing.Size(244, 20);
            this.txtDirectorio.TabIndex = 0;
            this.txtDirectorio.Text = "C:\\Users\\AlvaroVila\\source\\repos";
            // 
            // btnCambiar
            // 
            this.btnCambiar.Location = new System.Drawing.Point(262, 42);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(78, 35);
            this.btnCambiar.TabIndex = 1;
            this.btnCambiar.Text = "CHANGE\r\nDIRECTORY";
            this.btnCambiar.UseVisualStyleBackColor = true;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 111);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(328, 303);
            this.listBox.TabIndex = 2;
            this.listBox.SelectedValueChanged += new System.EventHandler(this.listBox_SelectedValueChanged);
            // 
            // lblDirectorio
            // 
            this.lblDirectorio.AutoSize = true;
            this.lblDirectorio.Location = new System.Drawing.Point(12, 34);
            this.lblDirectorio.Name = "lblDirectorio";
            this.lblDirectorio.Size = new System.Drawing.Size(116, 13);
            this.lblDirectorio.TabIndex = 3;
            this.lblDirectorio.Text = "Set new directory route";
            // 
            // lblWarningDir
            // 
            this.lblWarningDir.AutoSize = true;
            this.lblWarningDir.Location = new System.Drawing.Point(193, 77);
            this.lblWarningDir.Name = "lblWarningDir";
            this.lblWarningDir.Size = new System.Drawing.Size(0, 13);
            this.lblWarningDir.TabIndex = 4;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(370, 111);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(328, 303);
            this.listBox2.TabIndex = 5;
            this.listBox2.SelectedValueChanged += new System.EventHandler(this.listBox2_SelectedValueChanged);
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(514, 95);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(0, 13);
            this.lblFileSize.TabIndex = 6;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnCambiar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 450);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.lblWarningDir);
            this.Controls.Add(this.lblDirectorio);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.txtDirectorio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Directories and Files";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDirectorio;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label lblDirectorio;
        private System.Windows.Forms.Label lblWarningDir;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label lblFileSize;
    }
}

