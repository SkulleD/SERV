namespace T3ej1_cliente_graphic
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
            this.btnHora = new System.Windows.Forms.Button();
            this.btnFecha = new System.Windows.Forms.Button();
            this.btnFechaHora = new System.Windows.Forms.Button();
            this.btnApagar = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHora
            // 
            this.btnHora.Location = new System.Drawing.Point(139, 111);
            this.btnHora.Name = "btnHora";
            this.btnHora.Size = new System.Drawing.Size(89, 41);
            this.btnHora.TabIndex = 0;
            this.btnHora.Text = "HORA";
            this.btnHora.UseVisualStyleBackColor = true;
            this.btnHora.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFecha
            // 
            this.btnFecha.Location = new System.Drawing.Point(234, 111);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(89, 41);
            this.btnFecha.TabIndex = 1;
            this.btnFecha.Text = "FECHA";
            this.btnFecha.UseVisualStyleBackColor = true;
            this.btnFecha.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnFechaHora
            // 
            this.btnFechaHora.Location = new System.Drawing.Point(139, 158);
            this.btnFechaHora.Name = "btnFechaHora";
            this.btnFechaHora.Size = new System.Drawing.Size(89, 41);
            this.btnFechaHora.TabIndex = 2;
            this.btnFechaHora.Text = "FECHA HORA";
            this.btnFechaHora.UseVisualStyleBackColor = true;
            this.btnFechaHora.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnApagar
            // 
            this.btnApagar.Location = new System.Drawing.Point(234, 158);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(89, 41);
            this.btnApagar.TabIndex = 3;
            this.btnApagar.Text = "APAGAR";
            this.btnApagar.UseVisualStyleBackColor = true;
            this.btnApagar.Click += new System.EventHandler(this.button4_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(176, 67);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(114, 13);
            this.label.TabIndex = 4;
            this.label.Text = "Aquí van los mensajes";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 370);
            this.Controls.Add(this.label);
            this.Controls.Add(this.btnApagar);
            this.Controls.Add(this.btnFechaHora);
            this.Controls.Add(this.btnFecha);
            this.Controls.Add(this.btnHora);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHora;
        private System.Windows.Forms.Button btnFecha;
        private System.Windows.Forms.Button btnFechaHora;
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.Label label;
    }
}

