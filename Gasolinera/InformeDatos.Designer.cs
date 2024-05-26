namespace Gasolinera
{
    partial class InformeDatos
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
            this.dgv_Compras = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_Bombas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Compras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Bombas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Compras
            // 
            this.dgv_Compras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Compras.Location = new System.Drawing.Point(12, 52);
            this.dgv_Compras.Name = "dgv_Compras";
            this.dgv_Compras.ReadOnly = true;
            this.dgv_Compras.Size = new System.Drawing.Size(776, 256);
            this.dgv_Compras.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Informe de Compras";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Informe de Bombas";
            // 
            // dgv_Bombas
            // 
            this.dgv_Bombas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Bombas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Bombas.Location = new System.Drawing.Point(12, 356);
            this.dgv_Bombas.Name = "dgv_Bombas";
            this.dgv_Bombas.ReadOnly = true;
            this.dgv_Bombas.Size = new System.Drawing.Size(776, 153);
            this.dgv_Bombas.TabIndex = 2;
            // 
            // InformeDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(815, 634);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_Bombas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Compras);
            this.Name = "InformeDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InformeDatos";
            this.Load += new System.EventHandler(this.InformeDatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Compras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Bombas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Compras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_Bombas;
    }
}