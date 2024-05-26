namespace Gasolinera
{
    partial class Index
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Bomba1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Bomba2 = new System.Windows.Forms.Button();
            this.btn_Bomba3 = new System.Windows.Forms.Button();
            this.btn_Bomba4 = new System.Windows.Forms.Button();
            this.btn_Informe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "GASOLINERA MESOAMERICANA";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(199, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 2);
            this.label2.TabIndex = 1;
            // 
            // btn_Bomba1
            // 
            this.btn_Bomba1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Bomba1.Location = new System.Drawing.Point(123, 165);
            this.btn_Bomba1.Name = "btn_Bomba1";
            this.btn_Bomba1.Size = new System.Drawing.Size(145, 120);
            this.btn_Bomba1.TabIndex = 2;
            this.btn_Bomba1.Text = "V-Power";
            this.btn_Bomba1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Seleccione una acción:";
            // 
            // btn_Bomba2
            // 
            this.btn_Bomba2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Bomba2.Location = new System.Drawing.Point(292, 165);
            this.btn_Bomba2.Name = "btn_Bomba2";
            this.btn_Bomba2.Size = new System.Drawing.Size(145, 120);
            this.btn_Bomba2.TabIndex = 4;
            this.btn_Bomba2.Text = "Super";
            this.btn_Bomba2.UseVisualStyleBackColor = true;
            // 
            // btn_Bomba3
            // 
            this.btn_Bomba3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Bomba3.Location = new System.Drawing.Point(123, 320);
            this.btn_Bomba3.Name = "btn_Bomba3";
            this.btn_Bomba3.Size = new System.Drawing.Size(145, 120);
            this.btn_Bomba3.TabIndex = 5;
            this.btn_Bomba3.Text = "Regular";
            this.btn_Bomba3.UseVisualStyleBackColor = true;
            // 
            // btn_Bomba4
            // 
            this.btn_Bomba4.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Bomba4.Location = new System.Drawing.Point(292, 320);
            this.btn_Bomba4.Name = "btn_Bomba4";
            this.btn_Bomba4.Size = new System.Drawing.Size(145, 120);
            this.btn_Bomba4.TabIndex = 6;
            this.btn_Bomba4.Text = "Diesel";
            this.btn_Bomba4.UseVisualStyleBackColor = true;
            // 
            // btn_Informe
            // 
            this.btn_Informe.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Informe.Location = new System.Drawing.Point(472, 165);
            this.btn_Informe.Name = "btn_Informe";
            this.btn_Informe.Size = new System.Drawing.Size(149, 275);
            this.btn_Informe.TabIndex = 7;
            this.btn_Informe.Text = "Ver informes";
            this.btn_Informe.UseVisualStyleBackColor = true;
            this.btn_Informe.Click += new System.EventHandler(this.btn_Informe_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(740, 512);
            this.Controls.Add(this.btn_Informe);
            this.Controls.Add(this.btn_Bomba4);
            this.Controls.Add(this.btn_Bomba3);
            this.Controls.Add(this.btn_Bomba2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Bomba1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Index";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gasolinera MESO";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Bomba1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Bomba2;
        private System.Windows.Forms.Button btn_Bomba3;
        private System.Windows.Forms.Button btn_Bomba4;
        private System.Windows.Forms.Button btn_Informe;
    }
}

