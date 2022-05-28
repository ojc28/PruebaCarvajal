using Shop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Clases.Login
{
    public class ClsLogin
    {
        //public static bool Validar(LoginDto usuario)
        //{
        //    try
        //    {
        //        if (usuario.NombreUsuario==null)
        //        {
        //            return false;
        //        }
        //        if (usuario.Contraseña == null)
        //        {
        //            return false;
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static bool ValidarBD(LoginDto usuario)
        {
            try
            {
                using (ShopEntities db=new ShopEntities())
                {
                    var Pass = ClsUtils.ComputeSha256Hash(usuario.Contraseña);
                    usuario.UsuarioBD = db.Usuario.Where(x => x.NombreUsuario == usuario.NombreUsuario && x.Contraseña == Pass).FirstOrDefault();
                    if (usuario.UsuarioBD!=null)
                    {
                        usuario.Mensaje = "Ok";
                        return true;
                    }
                }
                usuario.Mensaje = "Usuario no encontrado.";
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}