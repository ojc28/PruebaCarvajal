using System;
using System.Security.Cryptography;
using System.Text;
using Shop.Clases;

namespace Shop.Controllers
{
    public class LoginDto
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public Usuario UsuarioBD { get; set; }
        public string Mensaje{get;set;}
    }


}