using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontShop.Modelos
{
    public class UsuarioDto
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public bool Administrador { get; set; }
        public string Mensaje { get; set; }

        internal string Validar(TextBox txtRevalidarContraseña)
        {
            try
            {
                if (string.IsNullOrEmpty(this.Nombre))
                {
                    return "El Nombre es Requerido.";
                }
                if (string.IsNullOrEmpty(this.Apellido))
                {
                    return "El Apellido es Requerido.";
                }
                if (string.IsNullOrEmpty(this.Contraseña))
                {
                    return "La Contraseña es Requerida.";
                }
                if (!string.IsNullOrEmpty(this.Contraseña))
                {
                    if (this.Contraseña != txtRevalidarContraseña.Text)
                    {
                        return "Las Contraseñas no coinciden.";
                    }
                }
                if (string.IsNullOrEmpty(this.NombreUsuario))
                {
                    return "El Nombre Usuario es Requerido.";
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
