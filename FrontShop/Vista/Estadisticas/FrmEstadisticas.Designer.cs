namespace FrontShop.Vista.Estadisticas
{
    partial class FrmEstadisticas
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
            this.DGV_MasVendidos = new System.Windows.Forms.DataGridView();
            this.DGV_MenosVendidos = new System.Windows.Forms.DataGridView();
            this.lblMasVendidos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_MasVendidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_MenosVendidos)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_MasVendidos
            // 
            this.DGV_MasVendidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_MasVendidos.Enabled = false;
            this.DGV_MasVendidos.Location = new System.Drawing.Point(94, 44);
            this.DGV_MasVendidos.MultiSelect = false;
            this.DGV_MasVendidos.Name = "DGV_MasVendidos";
            this.DGV_MasVendidos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.DGV_MasVendidos.Size = new System.Drawing.Size(619, 150);
            this.DGV_MasVendidos.TabIndex = 0;
            // 
            // DGV_MenosVendidos
            // 
            this.DGV_MenosVendidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_MenosVendidos.Location = new System.Drawing.Point(94, 220);
            this.DGV_MenosVendidos.Name = "DGV_MenosVendidos";
            this.DGV_MenosVendidos.Size = new System.Drawing.Size(619, 150);
            this.DGV_MenosVendidos.TabIndex = 1;
            // 
            // lblMasVendidos
            // 
            this.lblMasVendidos.AutoSize = true;
            this.lblMasVendidos.Location = new System.Drawing.Point(94, 28);
            this.lblMasVendidos.Name = "lblMasVendidos";
            this.lblMasVendidos.Size = new System.Drawing.Size(125, 13);
            this.lblMasVendidos.TabIndex = 2;
            this.lblMasVendidos.Text = "Productos Mas Vendidos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Productos Menos Vendidos";
            // 
            // FrmEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMasVendidos);
            this.Controls.Add(this.DGV_MenosVendidos);
            this.Controls.Add(this.DGV_MasVendidos);
            this.Name = "FrmEstadisticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadisticas";
            this.Load += new System.EventHandler(this.FrmEstadisticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_MasVendidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_MenosVendidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_MasVendidos;
        private System.Windows.Forms.DataGridView DGV_MenosVendidos;
        private System.Windows.Forms.Label lblMasVendidos;
        private System.Windows.Forms.Label label1;
    }
}