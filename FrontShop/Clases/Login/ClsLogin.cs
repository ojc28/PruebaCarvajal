using FrontShop.Modelos;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FrontShop.Clases.Login
{
    public class ClsLogin
    {
        internal static infToken Entrar(LoginDto login)
        {
            try
            {
                infToken tmp = new infToken();
                string URL = $"{ConfigurationManager.AppSettings["webApi"]}/api/login/authenticate";
                var client = new RestClient(URL);
                var request = new RestRequest();
                request.AddJsonBody(login);
                var responce = client.Post(request);

                if (responce != null && responce.Content != null)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    tmp = js.Deserialize<infToken>(responce.Content);

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
