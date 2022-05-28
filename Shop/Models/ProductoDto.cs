namespace Shop.Controllers
{
    public class ProductoDto
    {
        public int ?id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string Imagen { get; set; }
        public string Mensaje { get; set; }
    }
}