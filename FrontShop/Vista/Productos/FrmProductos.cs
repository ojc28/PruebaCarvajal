using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrontShop.Clases;
using FrontShop.Clases.Productos;
using FrontShop.Modelos;

namespace FrontShop.Vista.Productos
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FrmProductos_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //Acepta un punto digital
           /*  if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.txtRuta.Text = openFileDialog1.FileName;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Msg = "Ok";
                ProductoDto Producto = new ProductoDto();
                TokenDto token = TokenDto.GetInstance();
                Producto.Descripcion = txtDescripcion.Text;
                Producto.Nombre = txtNombre.Text;
                Producto.Codigo = txtCodigo.Text;
                Producto.Precio = txtPrecio.Text;
                Producto.Imagen = txtRuta.Text;
                Producto.FechaRegistro = System.DateTime.Now;

                Msg = Producto.Validar();
                if (Msg == "Ok" && btnGuardar.Text == "Guardar")
                {
                    Producto = ClsProducto.RegistrarProducto(Producto);
                    token.identificador = 0;
                    FrmProductos_Load(null,null);
                }
                else
                {
                    Producto.id = token.identificador;
                    Producto = ClsProducto.ModificarProducto(Producto);
                    btnGuardar.Text = "Guardar";
                    FrmProductos_Load(null, null);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            try
            {
                //Get Productos
                FLPVisualizador.Controls.Clear();
                List<ProductoDto> Productos= ClsProducto.GetProductos();
                if (Productos!=null && Productos.Count()>0)
                {
                    foreach (var item in Productos)
                    {
                        List<ListItem> ListItems = new List<ListItem>();
                        ListItem pro = new ListItem()
                        {
                            MostrarCantidad = false,
                            MostrarCarrito= false,
                            Precio = int.Parse(item.Precio),
                            CodDescripcion = $"{item.Codigo}-{item.Descripcion}",
                            Imagen = ClsUtils.stringToImage(item.Imagen),
                            Nombre=item.Nombre,
                            Identificador=item.id
                        };
                        ListItems.Add(pro);
                        FLPVisualizador.Controls.Add(pro);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                TokenDto d = TokenDto.GetInstance();
                ProductoDto pro= ClsProducto.GetProductosxID(d.identificador);
                if (pro!=null)
                {
                    txtCodigo.Text = pro.Codigo;
                    txtDescripcion.Text = pro.Descripcion;
                    txtNombre.Text = pro.Nombre;
                    txtPrecio.Text = pro.Precio;
                    txtRuta.Text = pro.Imagen;
                }
                btnGuardar.Text = "Modificar";

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
