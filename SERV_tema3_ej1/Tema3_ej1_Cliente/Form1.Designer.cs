
namespace Tema3_ej1_Cliente
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
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnApagar = new System.Windows.Forms.Button();
            this.btnTodo = new System.Windows.Forms.Button();
            this.btnFecha = new System.Windows.Forms.Button();
            this.btnHora = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(100, 68);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 23;
            this.btnSettings.Text = "CONFIG";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click_1);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(5, 103);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(37, 13);
            this.lblResult.TabIndex = 22;
            this.lblResult.Text = "Result";
            // 
            // btnApagar
            // 
            this.btnApagar.ForeColor = System.Drawing.Color.Red;
            this.btnApagar.Location = new System.Drawing.Point(100, 39);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(75, 23);
            this.btnApagar.TabIndex = 21;
            this.btnApagar.Text = "APAGAR";
            this.btnApagar.UseVisualStyleBackColor = true;
            this.btnApagar.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnTodo
            // 
            this.btnTodo.Location = new System.Drawing.Point(8, 39);
            this.btnTodo.Name = "btnTodo";
            this.btnTodo.Size = new System.Drawing.Size(75, 23);
            this.btnTodo.TabIndex = 20;
            this.btnTodo.Text = "TODO";
            this.btnTodo.UseVisualStyleBackColor = true;
            this.btnTodo.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnFecha
            // 
            this.btnFecha.Location = new System.Drawing.Point(100, 10);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(75, 23);
            this.btnFecha.TabIndex = 19;
            this.btnFecha.Text = "FECHA";
            this.btnFecha.UseVisualStyleBackColor = true;
            this.btnFecha.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnHora
            // 
            this.btnHora.Location = new System.Drawing.Point(8, 10);
            this.btnHora.Name = "btnHora";
            this.btnHora.Size = new System.Drawing.Size(75, 23);
            this.btnHora.TabIndex = 18;
            this.btnHora.Text = "HORA";
            this.btnHora.UseVisualStyleBackColor = true;
            this.btnHora.Click += new System.EventHandler(this.btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 129);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnApagar);
            this.Controls.Add(this.btnTodo);
            this.Controls.Add(this.btnFecha);
            this.Controls.Add(this.btnHora);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente ej1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.Button btnTodo;
        private System.Windows.Forms.Button btnFecha;
        private System.Windows.Forms.Button btnHora;
    }
}

