using Shop.Clases.Login;
using Shop.Clases.Serilog;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Shop.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginDto usr)
        {
            try
            {
                
                //if (!ClsLogin.Validar(usr))
                //{
                //    throw new HttpResponseException(HttpStatusCode.BadRequest);
                //}
                if (!ClsLogin.ValidarBD(usr))
                {
                    return BadRequest(usr.Mensaje);
                }

                TokenDto token = new TokenDto
                {
                    Token = ClsTokenGenerator.GenerateTokenJwt(usr.NombreUsuario),
                    idUsuario = usr.UsuarioBD.id,
                    NombreCompleto = usr.UsuarioBD.NombreUsuario,
                    Message = "Ok",
                    Administrador=usr.UsuarioBD.Administrador
                };
                return Ok(token);

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