namespace Gasolinera
{
    partial class CambiarPrecios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Bomba = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_regular = new System.Windows.Forms.TextBox();
            this.txt_diesel = new System.Windows.Forms.TextBox();
            this.txt_vpower = new System.Windows.Forms.TextBox();
            this.txt_super = new System.Windows.Forms.TextBox();
            this.btn_LlenarBomba = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Bomba
            // 
            this.lbl_Bomba.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Bomba.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Bomba.ForeColor = System.Drawing.Color.White;
            this.lbl_Bomba.Location = new System.Drawing.Point(28, 20);
            this.lbl_Bomba.Name = "lbl_Bomba";
            this.lbl_Bomba.Size = new System.Drawing.Size(244, 29);
            this.lbl_Bomba.TabIndex = 1;
            this.lbl_Bomba.Text = "Cambiar Precios";
            this.lbl_Bomba.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(29, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 22);
            this.label3.TabIndex = 14;
            this.label3.Text = "Bomba V-POWER:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(397, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 22);
            this.label1.TabIndex = 15;
            this.label1.Text = "Bomba REGULAR:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "Bomba SUPER:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(397, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 22);
            this.label4.TabIndex = 17;
            this.label4.Text = "Bomba DIESEL:";
            // 
            // txt_regular
            // 
            this.txt_regular.Location = new System.Drawing.Point(568, 117);
            this.txt_regular.Name = "txt_regular";
            this.txt_regular.Size = new System.Drawing.Size(135, 20);
            this.txt_regular.TabIndex = 18;
            // 
            // txt_diesel
            // 
            this.txt_diesel.Location = new System.Drawing.Point(568, 269);
            this.txt_diesel.Name = "txt_diesel";
            this.txt_diesel.Size = new System.Drawing.Size(135, 20);
            this.txt_diesel.TabIndex = 19;
            // 
            // txt_vpower
            // 
            this.txt_vpower.Location = new System.Drawing.Point(216, 117);
            this.txt_vpower.Name = "txt_vpower";
            this.txt_vpower.Size = new System.Drawing.Size(135, 20);
            this.txt_vpower.TabIndex = 20;
            // 
            // txt_super
            // 
            this.txt_super.Location = new System.Drawing.Point(216, 269);
            this.txt_super.Name = "txt_super";
            this.txt_super.Size = new System.Drawing.Size(135, 20);
            this.txt_super.TabIndex = 21;
            // 
            // btn_LlenarBomba
            // 
            this.btn_LlenarBomba.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LlenarBomba.Location = new System.Drawing.Point(287, 336);
            this.btn_LlenarBomba.Name = "btn_LlenarBomba";
            this.btn_LlenarBomba.Size = new System.Drawing.Size(237, 37);
            this.btn_LlenarBomba.TabIndex = 22;
            this.btn_LlenarBomba.Text = "Actualizar";
            this.btn_LlenarBomba.UseVisualStyleBackColor = true;
            this.btn_LlenarBomba.Click += new System.EventHandler(this.btn_LlenarBomba_Click);
            // 
            // CambiarPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_LlenarBomba);
            this.Controls.Add(this.txt_super);
            this.Controls.Add(this.txt_vpower);
            this.Controls.Add(this.txt_diesel);
            this.Controls.Add(this.txt_regular);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_Bomba);
            this.MaximizeBox = false;
            this.Name = "CambiarPrecios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Precios";
            this.Load += new System.EventHandler(this.CambiarPrecios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Bomba;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_regular;
        private System.Windows.Forms.TextBox txt_diesel;
        private System.Windows.Forms.TextBox txt_vpower;
        private System.Windows.Forms.TextBox txt_super;
        private System.Windows.Forms.Button btn_LlenarBomba;
    }
}