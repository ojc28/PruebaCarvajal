namespace Shop.Controllers
{
    public class VentasDto
    {
        public int idUsuario { get; set; }
        public int idProducto { get; set; }
        public bool Pagado { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnidad { get; set; }
    }
}