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
using FrontShop.Clases.Ventas;
using FrontShop.Modelos;

namespace FrontShop.Vista.Menu
{
    public partial class MacBurger : Form
    {
        private static bool _exiting;
        public MacBurger()
        {
            
            InitializeComponent();
            TokenDto token = TokenDto.GetInstance();
            if (token.Administrador)
            {
                TLP_Contenedor.Visible = false;
                this.buscarToolStripMenuItem.Visible = false;
            }
            else 
            {
                this.registrarToolStripMenuItem.Visible = false;
                this.estadisticasToolStripMenuItem.Visible = false;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_exiting && MessageBox.Show("Esta Seguro que quiere Salir?",
                               "MacBurger",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Information) == DialogResult.OK)
            {
                _exiting = true;
                // this.Close(); // you don't need that, it's already closing
                Environment.Exit(1);
            }
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos.FrmProductos productos = new Productos.FrmProductos();
            productos.Show();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CarritoCompras();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CarritoCompras()
        {
            try
            {
                FLPVentas.Controls.Clear();
                TokenDto token = TokenDto.GetInstance();
                List<CarShopDto> carrito = ClsVentas.CarritoxidUsuario(token.idUsuario);
                int total = 0;
                if (carrito != null && carrito.Count() > 0)
                {
                    foreach (var item in carrito)
                    {
                        List<ListItem> ListItems = new List<ListItem>();
                        ListItem pro = new ListItem()
                        {
                            MostrarCarrito = false,
                            MostrarCantidad = true,
                            Precio = item.Precio,
                            CodDescripcion = $"{item.Codigo}-{item.Descripcion}",
                            Imagen = ClsUtils.stringToImage(item.Imagen),
                            Nombre = item.Nombre,
                            Identificador = item.id,
                            Cantidad = item.Cantidad
                        };
                        total += item.Precio * item.Cantidad;
                        ListItems.Add(pro);
                        FLPVentas.Controls.Add(pro);
                    }
                }
                lblTotal.Text = $"Tiene un Total de {total.ToString()} Pesos.";
                lblTotal.Visible = true;
                txtBuscar.Visible = false;
                btnBuscar.Text = "Pagar";
                btnEliminar.Visible = true;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            FLPVentas.Controls.Clear();
            List<ProductoDto> Productos = ClsProducto.GetProductos();
            if (Productos != null && Productos.Count() > 0)
            {
                foreach (var item in Productos)
                {
                    List<ListItem> ListItems = new List<ListItem>();
                    ListItem pro = new ListItem()
                    {
                        MostrarCantidad = true,
                        Precio = int.Parse(item.Precio),
                        CodDescripcion = $"{item.Codigo}-{item.Descripcion}",
                        Imagen = ClsUtils.stringToImage(item.Imagen),
                        Nombre = item.Nombre,
                        Identificador = item.id
                    };
                    ListItems.Add(pro);
                    FLPVentas.Controls.Add(pro);
                }
            }
        }

        private void MacBurger_Load(object sender, EventArgs e)
        {
            try
            {
                TokenDto s = TokenDto.GetInstance();
                if (s.Administrador)
                {
                    TLP_Contenedor.Visible = false;
                }
                else
                {
                    lblTotal.Text = "";
                    lblUsuario.Text = $"Bienvenido {s.NombreCompleto}";
                    CargarProductos();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void CargarProductos()
        {
            FLPVentas.Controls.Clear();
            List<ProductoDto> Productos = ClsProducto.GetProductos();
            if (Productos != null && Productos.Count() > 0)
            {
                foreach (var item in Productos)
                {
                    List<ListItem> ListItems = new List<ListItem>();
                    ListItem pro = new ListItem()
                    {
                        MostrarEliminar = false,
                        MostrarCantidad = true,
                        Precio = int.Parse(item.Precio),
                        CodDescripcion = $"{item.Codigo}-{item.Descripcion}",
                        Imagen = ClsUtils.stringToImage(item.Imagen),
                        Nombre = item.Nombre,
                        Identificador = item.id
                    };
                    ListItems.Add(pro);
                    FLPVentas.Controls.Add(pro);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnBuscar.Text=="Pagar")
                {
                    Pagar();
                }


                if (txtBuscar.Text != "")
                {
                    FLPVentas.Controls.Clear();
                    List<ProductoDto> Productos = ClsProducto.GetProductos();
                    List<ProductoDto> filtrados = Productos.Where(x => x.Descripcion.IndexOf(txtBuscar.Text,StringComparison.OrdinalIgnoreCase)>=0
                                                                    || x.Nombre.IndexOf(txtBuscar.Text, StringComparison.OrdinalIgnoreCase) >= 0
                                                                    || x.Codigo.IndexOf(txtBuscar.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    if (filtrados != null && filtrados.Count() > 0)
                    {
                        foreach (var item in filtrados)
                        {
                            List<ListItem> ListItems = new List<ListItem>();
                            ListItem pro = new ListItem()
                            {
                                MostrarCantidad = true,
                                Precio = int.Parse(item.Precio),
                                CodDescripcion = $"{item.Codigo}-{item.Descripcion}",
                                Imagen = ClsUtils.stringToImage(item.Imagen),
                                Nombre = item.Nombre,
                                Identificador = item.id
                            };
                            ListItems.Add(pro);
                            FLPVentas.Controls.Add(pro);
                        }
                    }
                }
                else
                {
                    CargarProductos();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Pagar()
        {
            try
            {
                TokenDto token = TokenDto.GetInstance();
                if (FLPVentas.Controls.Count ==0)
                {
                    MessageBox.Show("No hay articulos que pagar.");
                    return;
                }

                if (ClsVentas.PagarCarrito(token.idUsuario)>0)
                {
                    MessageBox.Show("Gracias por su compra.");
                    productosToolStripMenuItem_Click(null, null);
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TokenDto token = TokenDto.GetInstance();
                if (!token.Administrador)
                {
                    btnBuscar.Visible = true;
                    btnBuscar.Text = "Buscar";
                    btnEliminar.Visible = false;
                    txtBuscar.Visible = true;
                    lblTotal.Visible = false;
                    txtBuscar.Visible = true;
                    
                    CargarProductos();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (FLPVentas.Controls.Count>0)
                {
                    foreach (ListItem item in FLPVentas.Controls)
                    {
                        if (item.ValueEliminar)
                        {
                            ClsVentas.DeleteProductosEnCarrito(item.Identificador);
                        }
                    }
                }
                CarritoCompras();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void estadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estadisticas.FrmEstadisticas estadisticas = new Estadisticas.FrmEstadisticas();
            estadisticas.Show();
        }
    }
}
