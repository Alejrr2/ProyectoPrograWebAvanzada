using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Proyecto.Controllers
{
    public class CarritoController : Controller
    {
        [HttpPost]
        public ActionResult AgregarCarrito(int IdProducto, int Cantidad)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var consecutivoUsuarioLogueado = int.Parse(Session["Consecutivo"].ToString());
                var cantidadExistenteCarrito = context.tCarrito.Where(
                    x => x.ConsecutivoUsuario == consecutivoUsuarioLogueado
                        && x.ConsecutivoProducto == IdProducto).FirstOrDefault();

                if (cantidadExistenteCarrito != null)
                {
                    cantidadExistenteCarrito.Cantidad = Cantidad;
                    cantidadExistenteCarrito.Fecha = DateTime.Now;

                }
                else
                {

                    var tabla = new tCarrito();
                    tabla.Consecutivo = 0;
                    tabla.ConsecutivoUsuario = consecutivoUsuarioLogueado;
                    tabla.ConsecutivoProducto = IdProducto;
                    tabla.Cantidad = Cantidad;
                    tabla.Fecha = DateTime.Now;
                    context.tCarrito.Add(tabla);

                }
                var respuesta = context.SaveChanges();
                var mensaje = (respuesta > 0 ? "OK" : "ERROR");

                ActualizarCarrito();

                return Json("OK", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult RemoverProductoCarrito(Carrito model)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var consecutivoUsuarioLogueado = int.Parse(Session["Consecutivo"].ToString());
                var datos = context.tCarrito.Where(x => x.ConsecutivoProducto == model.ConsecutivoProducto
                                                    && x.ConsecutivoUsuario == consecutivoUsuarioLogueado).FirstOrDefault();

                if (datos != null)
                {
                    context.tCarrito.Remove(datos);
                    context.SaveChanges();

                    ActualizarCarrito();

                    return RedirectToAction("ConsultarCarrito", "Carrito");
                }

                ViewBag.MensajePantalla = "El producto no se ha podido eliminar de su carrito correctamente";
                return View();
            }

        }

        [HttpGet]
        public ActionResult ConsultarCarrito()
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var consecutivoUsuarioLogueado = int.Parse(Session["Consecutivo"].ToString());
                var datos = context.tCarrito.Where(x => x.ConsecutivoUsuario == consecutivoUsuarioLogueado).ToList(); ;

                var carrito = new List<Carrito>();
                foreach (var item in datos)
                {
                    carrito.Add(new Carrito
                    {
                        Consecutivo = item.Consecutivo,
                        ConsecutivoUsuario = item.ConsecutivoUsuario,
                        ConsecutivoProducto = item.ConsecutivoProducto,
                        Precio = item.tProductos.Precio,
                        Cantidad = item.Cantidad,
                        Fecha = item.Fecha,
                        Total = item.tProductos.Precio * item.Cantidad,
                        Nombre = item.tProductos.NombreProducto,
                    });
                }

                return View(carrito);
            }
        }
        private void ActualizarCarrito()
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var consecutivoUsuarioLogueado = int.Parse(Session["Consecutivo"].ToString());

                var datos = context.tCarrito.Where(x => x.ConsecutivoUsuario == consecutivoUsuarioLogueado).ToList();

                if (datos.Count > 0)
                {
                    int contador = 0;
                    decimal total = 0;
                    foreach (var item in datos)
                    {
                        total += item.Cantidad * item.tProductos.Precio;
                        contador++;
                    }

                    Session["Cantidad"] = contador;
                    Session["Total"] = total;
                }
                else
                {
                    Session["Cantidad"] = 0;
                    Session["Total"] = 0;
                }

            }
        }

        [HttpPost]
        public ActionResult PagarCarrito(string Direccion)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var consecutivoUsuarioLogueado = int.Parse(Session["Consecutivo"].ToString());
                var nombreUsuario = Session["NombreUsuario"].ToString();
                var carrito = context.tCarrito
                    .Where(x => x.ConsecutivoUsuario == consecutivoUsuarioLogueado)
                    .ToList();

                if (carrito.Any())
                {
                    var nuevoPedido = new tPedidos
                    {
                        ConsecutivoUsuario = consecutivoUsuarioLogueado,
                        NombreUsuario = nombreUsuario,
                        Direccion = Direccion,
                        FechaPedido = DateTime.Now,
                        Total = carrito.Sum(x => x.Cantidad * x.tProductos.Precio),
                        Estado = "Pagado"
                    };

                    context.tPedidos.Add(nuevoPedido);
                    context.SaveChanges();

                    foreach (var item in carrito)
                    {
                        var detallePedido = new tDetallePedidos
                        {
                            ConsecutivoPedido = nuevoPedido.Consecutivo,
                            ConsecutivoProducto = item.ConsecutivoProducto,
                            NombreProducto = item.tProductos.NombreProducto,
                            Cantidad = item.Cantidad,
                            PrecioUnitario = item.tProductos.Precio,
                            Total = item.Cantidad * item.tProductos.Precio
                        };

                        context.tDetallePedidos.Add(detallePedido);

                        var producto = context.tProductos.FirstOrDefault(p => p.IdProducto == item.ConsecutivoProducto);
                        if (producto != null)
                        {
                            producto.Stock -= item.Cantidad;
                            if (producto.Stock < 0) producto.Stock = 0;
                        }

                        context.tCarrito.Remove(item);
                    }

                    context.SaveChanges();

                    ActualizarCarrito();

                    TempData["Mensaje"] = "El pago se ha realizado correctamente. ¡Gracias por su compra!";
                }
                else
                {
                    TempData["Mensaje"] = "No hay productos en el carrito para procesar el pago.";
                }
            }

            return RedirectToAction("ConsultarCarrito", "Carrito");
        }
    }
}