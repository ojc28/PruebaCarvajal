using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Clases.Usuario
{
    public class ClsUsuario
    {
        public static UsuarioDto Registrar(UsuarioDto usuario)
        {

            Shop.Usuario NewUsr = new Shop.Usuario();
            try
            {
                using (ShopEntities db=new ShopEntities())
                {
                    if (db.Usuario.Count(x => x.NombreUsuario == usuario.NombreUsuario) > 0)
                    {
                        usuario.Mensaje = "Nombre de Usuario Existente";
                    }
                    else
                    {
                        NewUsr.Nombre = usuario.Nombre;
                        NewUsr.Apellido = usuario.Apellido;
                        NewUsr.NombreUsuario = usuario.NombreUsuario;
                        NewUsr.Contraseña = ClsUtils.ComputeSha256Hash(usuario.Contraseña);
                        NewUsr.Administrador = usuario.Administrador;
                        NewUsr.FechaRegistro = System.DateTime.Now;
                        db.Usuario.Add(NewUsr);
                        db.SaveChanges();
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}