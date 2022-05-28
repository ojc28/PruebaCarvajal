using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontShop.Modelos
{
    internal class VentaDto
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public int idProducto { get; set; }
        public DateTime FechaFactura { get; set; }
        public bool Pagado { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnidad { get; set; }
    }
}
