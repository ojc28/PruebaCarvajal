using Shop.Clases.Login;
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
    [RoutePrefix("api/Producto")]
    public class ProductosController : ApiController
    {
        [HttpPost]
        [Route("RegistrarProducto")]
        public IHttpActionResult RegistrarProducto(ProductoDto Producto)
        {
            try
            {
                return Ok(ClsProducto.Registrar(Producto));
            }
            catch (Exception ex)
            {
                ClsSerilog log = new ClsSerilog();
                LogDto Result = log.RegistrarError(ex);
                return new System.Web.Http.Results.ResponseMessageResult(
                  Request.CreateErrorResponse(
                     HttpStatusCode.InternalServerError,
                      new HttpError($"{Result.ErrorCode}//{Result.Message}")));
            }
        }

        [HttpDelete]
        [Route("EliminarProducto")]
        public IHttpActionResult EliminarProducto(int idProducto)
        {
            try
            {
                return Ok(ClsProducto.EliminarProducto(idProducto));
            }
            catch (Exception ex)
            {
                ClsSerilog log = new ClsSerilog();
                LogDto Result = log.RegistrarError(ex);
                return new System.Web.Http.Results.ResponseMessageResult(
                  Request.CreateErrorResponse(
                     HttpStatusCode.InternalServerError,
                      new HttpError($"{Result.ErrorCode}//{Result.Message}")));
            }
        }

        [HttpPost]
        [Route("ActualizarProducto")]
        public IHttpActionResult ActualizarProducto(ProductoDto Producto)
        {
            try
            {
                return Ok(ClsProducto.ActualizarProducto(Producto));
            }
            catch (Exception ex)
            {
                ClsSerilog log = new ClsSerilog();
                LogDto Result = log.RegistrarError(ex);
                return new System.Web.Http.Results.ResponseMessageResult(
                  Request.CreateErrorResponse(
                     HttpStatusCode.InternalServerError,
                      new HttpError($"{Result.ErrorCode}//{Result.Message}")));
            }
        }

        [HttpGet]
        [Route("GetEstadisticas")]
        public IHttpActionResult GetEstadisticas()
        {
            try
            {
                return Ok(ClsProducto.GetEstadisticas());
            }
            catch (Exception ex)
            {
                ClsSerilog log = new ClsSerilog();
                LogDto Result = log.RegistrarError(ex);
                return new System.Web.Http.Results.ResponseMessageResult(
                  Request.CreateErrorResponse(
                     HttpStatusCode.InternalServerError,
                      new HttpError($"{Result.ErrorCode}//{Result.Message}")));
            }
        }


        [HttpGet]
        [Route("GetProductos")]
        public IHttpActionResult GetProductos()
        {
            try
            {
                return Ok(ClsProducto.GetProductos());
            }
            catch (Exception ex)
            {
                ClsSerilog log = new ClsSerilog();
                LogDto Result = log.RegistrarError(ex);
                return new System.Web.Http.Results.ResponseMessageResult(
                  Request.CreateErrorResponse(
                     HttpStatusCode.InternalServerError,
                      new HttpError($"{Result.ErrorCode}//{Result.Message}")));
            }
        }

        [HttpPost]
        [Route("GetProductosxID")]
        public IHttpActionResult GetProductosxID(int id)
        {
            try
            {
                return Ok(ClsProducto.GetProductosxID(id));
            }
            catch (Exception ex)
            {
                ClsSerilog log = new ClsSerilog();
                LogDto Result = log.RegistrarError(ex);
                return new System.Web.Http.Results.ResponseMessageResult(
                  Request.CreateErrorResponse(
                     HttpStatusCode.InternalServerError,
                      new HttpError($"{Result.ErrorCode}//{Result.Message}")));
            }
        }
    }
}