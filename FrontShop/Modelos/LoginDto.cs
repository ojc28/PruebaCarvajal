using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontShop.Modelos
{
    public class LoginDto
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

        public  string Validar()
        {
            try
            {
                if (string.IsNullOrEmpty(this.Contraseña))
                {
                    return "La Contraseña es Requerida.";
                }
                if (string.IsNullOrEmpty(this.NombreUsuario))
                {
                    return "El Nombre de Usuario es Requerido.";
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
