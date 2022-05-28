using FrontShop.Clases.Productos;
using FrontShop.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontShop.Vista.Estadisticas
{
    public partial class FrmEstadisticas : Form
    {
        public FrmEstadisticas()
        {
            InitializeComponent();
        }

        private void FrmEstadisticas_Load(object sender, EventArgs e)
        {
            try
            {
               EstadisticaDto estadistica= ClsProducto.GetEstadisticas();
                if (estadistica.MasVendidos.Count()>0)
                {
                    DGV_MasVendidos.DataSource = estadistica.MasVendidos;
                }
                if (estadistica.MenosVendidos.Count() > 0)
                {
                    DGV_MenosVendidos.DataSource = estadistica.MenosVendidos;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
