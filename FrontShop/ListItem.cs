using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrontShop.Modelos;

namespace FrontShop
{
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();
        }

        #region Propiedades

        private string _Nombre;
        private string _CodDescripcion;
        private int _Precio;
        private int _Cantidad;
        private bool _MostrarCantidad;
        private Image _Imagen;
        private bool _MostrarCarrito;
        private bool _Eliminar;
        private int _Identificador;
        private bool _MostrarEliminar;
        private bool _ValueEliminar;


        [Category("Propiedades Personalizadas")]

        

        public int Identificador
        {
            get { return _Identificador; }
            set { _Identificador = value; }
        }

        [Category("Propiedades Personalizadas")]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value;
                lblNombre.Text = value;
            }
        }

        [Category("Propiedades Personalizadas")]
        public string CodDescripcion
        {
            get { return _CodDescripcion; }
            set { _CodDescripcion = value; lblDescripcion.Text = value; }
        }

        [Category("Propiedades Personalizadas")]
        public int Precio
        {
            get { return _Precio; }
            set { _Precio = value;lblPrecio.Text =value.ToString(); }
        }

        [Category("Propiedades Personalizadas")]
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; ndCantidad.Value = value; }
        }

        [Category("Propiedades Personalizadas")]
        public bool MostrarCantidad
        {
            get { return _MostrarCantidad; }
            set { _MostrarCantidad = value; ndCantidad.Visible = value; lblCantidad.Visible = value; }
        }

        [Category("Propiedades Personalizadas")]
        public bool MostrarCarrito
        {
            get { return _MostrarCarrito; }
            set { _MostrarCarrito = value; pbCarrito.Visible = value; }
        }

        [Category("Propiedades Personalizadas")]
        public Image Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; pbImg.Image = value; }
        }


        [Category("Propiedades Personalizadas")]
        public bool Eliminar
        {
            get { return _Eliminar; }
            set { _Eliminar = value; ckEliminar.Checked = value; }
        }

        [Category("Propiedades Personalizadas")]
        public bool MostrarEliminar
        {
            get { return _MostrarEliminar; }
            set { _MostrarEliminar = value; ckEliminar.Visible = value; ckEliminar.Checked = false; }
        }
        [Category("Propiedades Personalizadas")]


        public bool ValueEliminar
        {
            get {
                _ValueEliminar = ckEliminar.Checked;
                return _ValueEliminar; }

        }



        #endregion

        private void pbCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ndCantidad.Value==0)
                {
                    MessageBox.Show("Debe seleccionar la cantidad");
                    return;
                }

                TokenDto d = TokenDto.GetInstance();
                VentaDto venta = new VentaDto()
                { 
                   Cantidad= int.Parse(this.ndCantidad.Value.ToString()),
                   FechaFactura=System.DateTime.Now,
                   idProducto =this.Identificador,
                   idUsuario=d.idUsuario,
                   PrecioUnidad=this.Precio,                
                };

                venta= Clases.Ventas.ClsVentas.AgregarCarrito(venta);
                if (venta!=null)
                {
                    MessageBox.Show("Producto enviado al Carrito.");
                    return;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void pbImg_Click(object sender, EventArgs e)
        {
            try
            {
                TokenDto d = TokenDto.GetInstance();
                d.identificador= this.Identificador;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
