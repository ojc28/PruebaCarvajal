namespace FrontShop
{
    partial class ListItem
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbImg = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.ndCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbCarrito = new System.Windows.Forms.PictureBox();
            this.ckEliminar = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImg
            // 
            this.pbImg.Location = new System.Drawing.Point(12, 22);
            this.pbImg.Name = "pbImg";
            this.pbImg.Size = new System.Drawing.Size(192, 198);
            this.pbImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImg.TabIndex = 0;
            this.pbImg.TabStop = false;
            this.pbImg.Click += new System.EventHandler(this.pbImg_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(227, 17);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(252, 71);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(224, 88);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(248, 75);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Cod/lDescripcion";
            // 
            // lblPrecio
            // 
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(224, 210);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(140, 29);
            this.lblPrecio.TabIndex = 3;
            this.lblPrecio.Text = "Precio";
            // 
            // ndCantidad
            // 
            this.ndCantidad.Location = new System.Drawing.Point(373, 213);
            this.ndCantidad.Name = "ndCantidad";
            this.ndCantidad.Size = new System.Drawing.Size(61, 20);
            this.ndCantidad.TabIndex = 4;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(370, 193);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(64, 17);
            this.lblCantidad.TabIndex = 5;
            this.lblCantidad.Text = "Cantidad";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 245);
            this.panel1.TabIndex = 6;
            // 
            // pbCarrito
            // 
            this.pbCarrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCarrito.Image = global::FrontShop.Properties.Resources.Carrito;
            this.pbCarrito.Location = new System.Drawing.Point(440, 194);
            this.pbCarrito.Name = "pbCarrito";
            this.pbCarrito.Size = new System.Drawing.Size(38, 38);
            this.pbCarrito.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCarrito.TabIndex = 7;
            this.pbCarrito.TabStop = false;
            this.pbCarrito.Click += new System.EventHandler(this.pbCarrito_Click);
            // 
            // ckEliminar
            // 
            this.ckEliminar.AutoSize = true;
            this.ckEliminar.Location = new System.Drawing.Point(410, 166);
            this.ckEliminar.Name = "ckEliminar";
            this.ckEliminar.Size = new System.Drawing.Size(62, 17);
            this.ckEliminar.TabIndex = 8;
            this.ckEliminar.Text = "Eliminar";
            this.ckEliminar.UseVisualStyleBackColor = true;
            // 
            // ListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ckEliminar);
            this.Controls.Add(this.pbCarrito);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.ndCantidad);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pbImg);
            this.Controls.Add(this.panel1);
            this.Name = "ListItem";
            this.Size = new System.Drawing.Size(486, 248);
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImg;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.NumericUpDown ndCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbCarrito;
        private System.Windows.Forms.CheckBox ckEliminar;
    }
}
