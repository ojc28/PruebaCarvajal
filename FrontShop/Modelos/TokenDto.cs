using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontShop.Modelos;

namespace FrontShop.Modelos
{
    public class TokenDto
    {
        private TokenDto() { }
        public string Token { get; set; }
        public int idUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Message { get; set; }
        public bool Administrador { get; set; }
        public int identificador { get; set; }
        public List<ProductoDto> productos { get; set; }

        private static TokenDto _instance;
        public static TokenDto GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TokenDto();
            }
            return _instance;
        }

        public static void Login(infToken t)
        {
            if (_instance==null)
            {
                _instance = new TokenDto();
                _instance.Token = t.Token;
                _instance.idUsuario = t.idUsuario;
                _instance.NombreCompleto = t.NombreCompleto;
                _instance.Administrador = t.Administrador;
                _instance.Message = t.Message;
            }
        }



    }
}
