using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace Shop.Controllers
{
    internal class ClsProducto
    {
        public static object Registrar(ProductoDto producto)
        {
            try
            {
                string NL = Environment.NewLine;
                if (producto.Precio < 0)
                {
                    producto.Mensaje += $"El precio debe ser mayor a 0. {NL}";
                }
                if (producto.Descripcion.Length < 0)
                {
                    producto.Mensaje += $"El producto debe tener descripcion. {NL}";
                }
                if (producto.Imagen.Length < 0)
                {
                    producto.Mensaje += $"El producto debe tener imagen. {NL}";
                }
                using (ShopEntities db = new ShopEntities())
                {
                    if (db.Productos.Count(x => x.Codigo == producto.Codigo) > 0)
                    {
                        producto.Mensaje += $"El codigo {producto.Codigo} ya existe en la Base de Datos. {NL}";
                    }
                    if (db.Productos.Count(x => x.Nombre == producto.Nombre) > 0)
                    {
                        producto.Mensaje += $"El Nombre {producto.Nombre} ya existe en la Base de Datos. {NL}";
                    }
                    if (!string.IsNullOrWhiteSpace(producto.Mensaje))
                    {
                        return producto;
                    }
                    Productos NewProd = new Productos()
                    {
                        Codigo = producto.Codigo,
                        Nombre = producto.Nombre,
                        Descripcion = producto.Descripcion,
                        Precio = producto.Precio,
                        Imagen = producto.Imagen,
                        FechaRegistro = System.DateTime.Now
                    };
                    db.Productos.Add(NewProd);
                    db.SaveChanges();
                }
                return producto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static object ActualizarProducto(ProductoDto producto)
        {
            try
            {
                Productos produc = new Productos();
                using (ShopEntities db = new ShopEntities())
                {
                    produc = db.Productos.Where(x => x.id == producto.id).FirstOrDefault();
                    if (produc != null)
                    {
                        produc.Codigo = producto.Codigo;
                        produc.Descripcion = producto.Descripcion;
                        produc.Imagen = producto.Imagen;
                        produc.Nombre = producto.Nombre;
                        produc.Precio = producto.Precio;
                        db.SaveChanges();
                    }
                }
                return producto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static object GetEstadisticas()
        {
            try
            {
                DataTable MasVendidos = new DataTable();
                DataTable MenosVendidos = new DataTable();
                EstadisticaDto estadisticaDto = new EstadisticaDto();
                using (ShopEntities db = new ShopEntities())
                {
                    using (var cmd = db.Database.Connection.CreateCommand())
                    {
                        cmd.CommandText = $"[dbo].[StatMasVendidos]";
                        cmd.Connection.Open();
                        MasVendidos.Load(cmd.ExecuteReader());
                    }
                }
                estadisticaDto.MasVendidos = new List<datos>();
                estadisticaDto.MasVendidos = Clases.ClsUtils.DataTableToList(MasVendidos);
                using (ShopEntities db = new ShopEntities())
                {
                    using (var cmd2 = db.Database.Connection.CreateCommand())
                    {
                        cmd2.CommandText = $"[dbo].[StatMenosVendidos]";
                        cmd2.Connection.Open();
                        MenosVendidos.Load(cmd2.ExecuteReader());
                    }
                }
                estadisticaDto.MenosVendidos = new List<datos>();
                estadisticaDto.MenosVendidos = Clases.ClsUtils.DataTableToList(MenosVendidos);
                return estadisticaDto;
            }
            catch (Exception)
            {

                throw;
            }
        }



        internal static object GetProductos()
        {
            try
            {
                List<Productos> productos = new List<Productos>();
                List<ProductoDto> productosDto = new List<ProductoDto>();
                using (ShopEntities db = new ShopEntities())
                {
                    productos = db.Productos.Where(x => x.id > 0).ToList();
                }
                if (productos != null && productos.Count > 0)
                {
                    foreach (var item in productos)
                    {
                        ProductoDto pro = new ProductoDto()
                        {
                            Descripcion = item.Descripcion,
                            Codigo = item.Codigo,
                            id = item.id,
                            Imagen = item.Imagen,
                            Nombre = item.Nombre,
                            Precio = item.Precio
                        };
                        productosDto.Add(pro);
                    }
                }

                return productosDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static object GetProductosxID(int id)
        {
            try
            {
                Productos producto = new Productos();
                ProductoDto pro = new ProductoDto();
                using (ShopEntities db = new ShopEntities())
                {
                    producto = db.Productos.Where(x => x.id == id).FirstOrDefault();
                    if (producto != null)
                    {
                        pro.Descripcion = producto.Descripcion;
                        pro.Codigo = producto.Codigo;
                        pro.Nombre = producto.Nombre;
                        pro.Precio = producto.Precio;
                        pro.Imagen = producto.Imagen;
                        pro.id = producto.id;
                        pro.Mensaje = "OK";
                    }
                }
                return pro;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static object EliminarProducto(int idProducto)
        {
            try
            {
                Productos producto = new Productos();
                using (ShopEntities db = new ShopEntities())
                {
                    producto = db.Productos.Where(x => x.id == idProducto).FirstOrDefault();
                    if (producto != null)
                    {
                        db.Productos.Remove(producto);
                        db.SaveChanges();
                    }
                }
                return producto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Producto mas Vendido
        //Producto menos vendido
    }
}