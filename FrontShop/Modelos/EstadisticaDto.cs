using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontShop.Modelos
{
    public class EstadisticaDto
    {
        public List<datos> MasVendidos { get; set; }
        public List<datos> MenosVendidos { get; set; }
    }

    public class datos
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Total { get; set; }
    }
}
