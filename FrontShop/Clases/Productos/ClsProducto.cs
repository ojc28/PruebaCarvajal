using FrontShop.Modelos;
using FrontShop.Vista.Productos;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FrontShop.Clases.Productos
{
    public class ClsProducto
    {
        internal static ProductoDto RegistrarProducto(ProductoDto producto)
        {
            try
            {
                TokenDto d = TokenDto.GetInstance();
                ProductoDto tmp = new ProductoDto();
                string URL = $"{ConfigurationManager.AppSettings["webApi"]}/api/Producto/RegistrarProducto";
                var client = new RestClient(URL);
                var request = new RestRequest();
                request.AddJsonBody(producto);
                client.AddDefaultHeader("Authorization", $"Bearer {d.Token}");
                var responce = client.Post(request);
                

                if (responce != null && responce.Content != null)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    tmp = js.Deserialize<ProductoDto>(responce.Content);

                }
                return tmp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static List<ProductoDto> GetProductos()
        {
            try
            {
                TokenDto d = TokenDto.GetInstance();
                List<ProductoDto> ListaProductos = new List<ProductoDto>();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string URL = $"{ConfigurationManager.AppSettings["webApi"]}/api/Producto/GetProductos";
                var client = new RestClient(URL);
                var request = new RestRequest();
                request.Method = Method.GET;
                client.AddDefaultHeader("Authorization", $"Bearer {d.Token}");
                var responce = client.Get(request);

                if (responce != null && responce.Content != null)
                {
                    ListaProductos = js.Deserialize<List<ProductoDto>>(responce.Content);
                }
                return ListaProductos;
            }
            catch (Exception)
            {

                throw;
            }
        }
        internal static EstadisticaDto GetEstadisticas()
        {
            try
            {
                TokenDto d = TokenDto.GetInstance();
                EstadisticaDto estadistica = new EstadisticaDto();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string URL = $"{ConfigurationManager.AppSettings["webApi"]}/api/Producto/GetEstadisticas";
                var client = new RestClient(URL);
                var request = new RestRequest();
                client.AddDefaultHeader("Authorization", $"Bearer {d.Token}");
                var responce = client.Get(request);

                if (responce != null && responce.Content != null)
                {
                    estadistica = js.Deserialize<EstadisticaDto>(responce.Content);
                }
                return estadistica;
            }
            catch (Exception)
            {

                throw;
            }
        }
        internal static ProductoDto GetProductosxID(int id)
        {
            try
            {
                TokenDto d = TokenDto.GetInstance();
                ProductoDto tmp = new ProductoDto();
                string URL = $"{ConfigurationManager.AppSettings["webApi"]}/api/Producto/GetProductosxID?id={id}";
                var client = new RestClient(URL);
                var request = new RestRequest();
                //request.AddJsonBody(id);
                client.AddDefaultHeader("Authorization", $"Bearer {d.Token}");
                var responce = client.Post(request);


                if (responce != null && responce.Content != null)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    tmp = js.Deserialize<ProductoDto>(responce.Content);

                }
                return tmp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static ProductoDto ModificarProducto(ProductoDto producto)
        {
            try
            {
                TokenDto d = TokenDto.GetInstance();
                ProductoDto tmp = new ProductoDto();
                string URL = $"{ConfigurationManager.AppSettings["webApi"]}/api/Producto/ActualizarProducto";
                var client = new RestClient(URL);
                var request = new RestRequest();
                request.AddJsonBody(producto);
                client.AddDefaultHeader("Authorization", $"Bearer {d.Token}");
                var responce = client.Post(request);


                if (responce != null && responce.Content != null)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    tmp = js.Deserialize<ProductoDto>(responce.Content);

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
