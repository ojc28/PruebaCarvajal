using Shop.Clases.Serilog;
using Shop.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Shop.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [AllowAnonymous]
    [RoutePrefix("api/Venta")]

    public class VentasController : ApiController
    {
        [HttpPost]
        [Route("GuardarVenta")]
        public IHttpActionResult GuardarVenta(VentasDto ventas)
        {
            try
            {
                return Ok(ClsVenta.GuardarVenta(ventas));
            }
            catch (Exception ex)
            {
                ClsSerilog log = new ClsSerilog();
                LogDto Result = log.RegistrarError(ex.InnerException.InnerException);
                return new System.Web.Http.Results.ResponseMessageResult(
                  Request.CreateErrorResponse(
                     HttpStatusCode.InternalServerError,
                      new HttpError($"{Result.ErrorCode}//{Result.Message}")));
            }

        }

        [HttpGet]
        [Route("GetProductosEnCarrito")]
        public IHttpActionResult GetProductosEnCarrito(int IdUsuario)
        {
            try
            {
                return Ok(ClsVenta.GetProductosEnCarrito(IdUsuario));
            }
            catch (Exception ex)
            {
                ClsSerilog log = new ClsSerilog();
                LogDto Result = log.RegistrarError(ex.InnerException.InnerException);
                return new System.Web.Http.Results.ResponseMessageResult(
                  Request.CreateErrorResponse(
                     HttpStatusCode.InternalServerError,
                      new HttpError($"{Result.ErrorCode}//{Result.Message}")));
            }

        }

        [HttpPost]
        [Route("PagarCarrito")]
        public IHttpActionResult PagarCarrito(int IdUsuario)
        {
            try
            {
                return Ok(ClsVenta.PagarCarrito(IdUsuario));
            }
            catch (Exception ex)
            {
                ClsSerilog log = new ClsSerilog();
                LogDto Result = log.RegistrarError(ex.InnerException.InnerException);
                return new System.Web.Http.Results.ResponseMessageResult(
                  Request.CreateErrorResponse(
                     HttpStatusCode.InternalServerError,
                      new HttpError($"{Result.ErrorCode}//{Result.Message}")));
            }

        }

        [HttpDelete]
        [Route("DeleteProductosEnCarrito")]
        public IHttpActionResult DeleteProductosEnCarrito(int id)
        {
            try
            {
                return Ok(ClsVenta.DeleteProductosEnCarrito(id));
            }
            catch (Exception ex)
            {
                ClsSerilog log = new ClsSerilog();
                LogDto Result = log.RegistrarError(ex.InnerException.InnerException);
                return new System.Web.Http.Results.ResponseMessageResult(
                  Request.CreateErrorResponse(
                     HttpStatusCode.InternalServerError,
                      new HttpError($"{Result.ErrorCode}//{Result.Message}")));
            }

        }

    }
}