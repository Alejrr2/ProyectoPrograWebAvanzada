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
                var consecutivoUsuarioLogueado = int.Parse(Session["IdUsuario"].ToString());
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
                var consecutivoUsuarioLogueado = long.Parse(Session["Consecutivo"].ToString());
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
        public ActionResult PagarCarrito()
        {
            return View();

        }
    }
}