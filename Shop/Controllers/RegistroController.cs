
using Shop.Clases.Serilog;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Shop.Models;
using Shop.Clases.Usuario;

namespace Shop.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [AllowAnonymous]
    [RoutePrefix("api/Usuario")]
    public class RegistroController : ApiController
    {
        [HttpPost]
        [Route("Registrar")]
        public IHttpActionResult RegistrarUsuario(UsuarioDto usuario)
        {
            try
            {
                return Ok(ClsUsuario.Registrar(usuario));
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