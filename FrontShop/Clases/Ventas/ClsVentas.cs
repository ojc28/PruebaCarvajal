using FrontShop.Modelos;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FrontShop.Clases.Ventas
{
    public static class ClsVentas
    {
        internal static VentaDto AgregarCarrito(VentaDto venta)
        {
            try
            {
                TokenDto d = TokenDto.GetInstance();
                JavaScriptSerializer js = new JavaScriptSerializer();
                VentaDto Venta = new VentaDto();
                string URL = $"{ConfigurationManager.AppSettings["webApi"]}/api/Venta/GuardarVenta";
                var client = new RestClient(URL);
                var request = new RestRequest();
                request.AddJsonBody(venta);
                client.AddDefaultHeader("Authorization", $"Bearer {d.Token}");
                var responce = client.Post(request);


                if (responce != null && responce.Content != null)
                {
                   Venta = js.Deserialize<VentaDto>(responce.Content);
                }
                return Venta;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<CarShopDto> CarritoxidUsuario(int idUsuario)
        {
            try
            {
                TokenDto d = TokenDto.GetInstance();
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<CarShopDto> carrito = new List<CarShopDto>();
                string URL = $"{ConfigurationManager.AppSettings["webApi"]}/api/Venta/GetProductosEnCarrito?IdUsuario={idUsuario}";
                var client = new RestClient(URL);
                var request = new RestRequest();

                client.AddDefaultHeader("Authorization", $"Bearer {d.Token}");
                var responce = client.Get(request);


                if (responce != null && responce.Content != null)
                {
                    carrito = js.Deserialize<List<CarShopDto>>(responce.Content);
                }
                return carrito;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static int PagarCarrito(int idUsuario)
        {
            try
            {


                TokenDto d = TokenDto.GetInstance();
                JavaScriptSerializer js = new JavaScriptSerializer();
                int idUser = 0;
                string URL = $"{ConfigurationManager.AppSettings["webApi"]}/api/Venta/PagarCarrito?IdUsuario={idUsuario}";
                var client = new RestClient(URL);
                var request = new RestRequest();
                
                client.AddDefaultHeader("Authorization", $"Bearer {d.Token}");
                var responce = client.Post(request);


                if (responce != null && responce.Content != null)
                {
                    idUser = js.Deserialize<int>(responce.Content);
                }
                return idUser;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static int DeleteProductosEnCarrito(int id)
        {
            try
            {
                TokenDto d = TokenDto.GetInstance();
                JavaScriptSerializer js = new JavaScriptSerializer();
                int idUser = 0;
                string URL = $"{ConfigurationManager.AppSettings["webApi"]}/api/Venta/DeleteProductosEnCarrito?id={id}";
                var client = new RestClient(URL);
                var request = new RestRequest();

                client.AddDefaultHeader("Authorization", $"Bearer {d.Token}");
                var responce = client.Delete(request);


                if (responce != null && responce.Content != null)
                {
                    idUser = js.Deserialize<int>(responce.Content);
                }
                return idUser;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
