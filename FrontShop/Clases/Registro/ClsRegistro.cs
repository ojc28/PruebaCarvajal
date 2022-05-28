using FrontShop.Modelos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FrontShop.Clases.Registro
{
    public class ClsRegistro
    {
        internal static UsuarioDto RegistrarUsuario(UsuarioDto registro)
        {
            try
            {
                UsuarioDto tmp=new UsuarioDto();
                string URL = $"{ConfigurationManager.AppSettings["webApi"]}/api/Usuario/Registrar";
                var client = new RestClient(URL);
                var request = new RestRequest();
                request.AddJsonBody(registro);
                var responce = client.Post(request);

                if (responce!=null && responce.Content!=null)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    tmp = js.Deserialize<UsuarioDto>(responce.Content);

                }
                return tmp;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
