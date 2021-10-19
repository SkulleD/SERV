namespace SERV_tema1_ej2
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnKill = new System.Windows.Forms.Button();
            this.btnStartsWith = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(26, 68);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(404, 352);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(26, 27);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(404, 22);
            this.textBox2.TabIndex = 1;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(451, 67);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(89, 46);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "View\r\nProcesses";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(451, 141);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(89, 46);
            this.btnInfo.TabIndex = 3;
            this.btnInfo.Text = "Process\r\nInfo";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(451, 221);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 46);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close\r\nProcess";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnKill
            // 
            this.btnKill.Location = new System.Drawing.Point(451, 298);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(89, 46);
            this.btnKill.TabIndex = 5;
            this.btnKill.Text = "Kill\r\nProcess";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // btnStartsWith
            // 
            this.btnStartsWith.Location = new System.Drawing.Point(451, 374);
            this.btnStartsWith.Name = "btnStartsWith";
            this.btnStartsWith.Size = new System.Drawing.Size(89, 46);
            this.btnStartsWith.TabIndex = 6;
            this.btnStartsWith.Text = "Starts\r\nWith...";
            this.btnStartsWith.UseVisualStyleBackColor = true;
            this.btnStartsWith.Click += new System.EventHandler(this.btnStartsWith_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStartsWith);
            this.Controls.Add(this.btnKill);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.Button btnStartsWith;
    }
}

