using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Controllers
{
    public static class ClsVenta
    {
        public static object GuardarVenta(VentasDto ventas)
        {
            Ventas Ven = new Ventas();
            try
            {
                Ven = ProductoExistete(ventas);
                if (Ven == null)
                {
                    using (ShopEntities db = new ShopEntities())
                    {
                        Ven = new Ventas()
                        {
                            Cantidad = ventas.Cantidad,
                            idProducto = ventas.idProducto,
                            idUsuario = ventas.idUsuario,
                            PrecioUnidad = ventas.PrecioUnidad,
                            FechaFactura = DateTime.Now
                        };
                        db.Ventas.Add(Ven);
                        db.SaveChanges();
                    }
                }
                return ventas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static Ventas ProductoExistete(VentasDto ventas)
        {
            Ventas venta = new Ventas();
            try
            {
                using (ShopEntities db = new ShopEntities())
                {
                    venta = db.Ventas.Where(x => x.idProducto == ventas.idProducto && x.idUsuario == ventas.idUsuario && x.Pagado == false).FirstOrDefault();
                    if (venta != null)
                    {
                        venta.Cantidad += ventas.Cantidad;
                        db.SaveChanges();
                        return venta;
                    }

                }
                return venta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static object GetProductosEnCarrito(int idUsuario)
        {
            List<CarShopDto> ListCarShop = new List<CarShopDto>();
            Productos pro = new Productos();
            try
            {
                using (ShopEntities db = new ShopEntities())
                {
                    List<Ventas> ventas = db.Ventas.Where(x => x.Pagado == false && x.idUsuario == idUsuario).ToList();
                    foreach (Ventas item in ventas)
                    {
                        pro = db.Productos.Where(x => x.id == item.idProducto).FirstOrDefault();
                        CarShopDto carShop = new CarShopDto()
                        {
                            id = item.id,
                            Cantidad = item.Cantidad,
                            Codigo = pro.Codigo,
                            Nombre = pro.Nombre,
                            Descripcion= pro.Descripcion,
                            Precio = pro.Precio,
                            Imagen = pro.Imagen
                        };
                        ListCarShop.Add(carShop);
                    }
                }
                return ListCarShop;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static object PagarCarrito(int idUsuario)
        {
            try
            {
                DateTime fechaPago = DateTime.Now;
                using (ShopEntities db = new ShopEntities())
                {
                    var ventas = db.Ventas.Where(x => x.idUsuario == idUsuario && x.Pagado==false).ToList();
                    if (ventas != null )
                    {
                        foreach (var item in ventas)
                        {
                            item.Pagado = true;
                            item.FechaFactura = fechaPago;
                        }
                    }
                    db.SaveChanges();
                }
                return idUsuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static object DeleteProductosEnCarrito(int id)
        {
            int idUsuario = 0;
            try
            {
                using (ShopEntities db = new ShopEntities())
                {
                    var ventas = db.Ventas.Where(x => x.id == id).FirstOrDefault();
                    if (ventas != null)
                    {
                        idUsuario = ventas.idUsuario;
                        db.Ventas.Remove(ventas);
                        db.SaveChanges();
                    }
                }
                return idUsuario;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}