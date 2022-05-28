using System;

namespace FrontShop.Modelos
{
    public class ProductoDto
    {

        public int id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        public string Imagen { get; set; }
        public DateTime FechaRegistro { get; set; }

        internal string Validar()
        {
            try
            {
                if (string.IsNullOrEmpty(this.Nombre))
                {
                    return "El Nombre es Requerido.";
                }
                if (string.IsNullOrEmpty(this.Codigo))
                {
                    return "El Codigo es Requerido.";
                }
                if (string.IsNullOrEmpty(this.Precio))
                {
                    return "El Precio es Requerido.";
                }
                if (string.IsNullOrEmpty(this.Descripcion))
                {
                    return "La Descripcion es requerida.";
                }
                if (string.IsNullOrEmpty(this.Imagen))
                {
                    return "La imagen es Requerida.";
                }

                return "Ok";
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}