using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class ProductosController : Controller
    {
        [HttpGet]
        public ActionResult Productos()
        {
            using (var context = new AlaPastaDatabaseEntities1())
            {
                var datos = context.tProductos.ToList();

                var productos = new List<Producto>();
                foreach (var item in datos)
                {
                    productos.Add(new Producto
                    {
                        IdProducto = item.IdProducto,
                        NombreProducto = item.NombreProducto,
                        Descripción = item.Descripción,
                        Precio = item.Precio,
                        ConsecutivoCat = item.ConsecutivoCat,
                        Stock = item.Stock,
                        ImagenProd = item.ImagenProd
                    });
                }

                return View(productos);
            }
        }


        [HttpGet]
        public ActionResult AgregarProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarProducto(Producto model, HttpPostedFileBase ImagenProd)
        {
            using (var context = new AlaPastaDatabaseEntities1())
            {
                var tabla = new tProductos();
                tabla.IdProducto = 0;
                tabla.NombreProducto = model.NombreProducto;
                tabla.Descripción = model.Descripción;
                tabla.Precio = model.Precio;
                tabla.ConsecutivoCat = model.ConsecutivoCat;
                tabla.Stock = model.Stock;
                tabla.ImagenProd = string.Empty;
                tabla.ActivoProd = model.ActivoProd;

                context.tProductos.Add(tabla);
                var respuesta = context.SaveChanges();

                if (respuesta > 0)
                {
                    string extension = Path.GetExtension(ImagenProd.FileName);  
                    string ruta = AppDomain.CurrentDomain.BaseDirectory + "ImagenProd\\" + tabla.IdProducto + extension;
                    ImagenProd.SaveAs(ruta);

                    tabla.ImagenProd = "/ImagenProd/" + tabla.IdProducto + extension;
                    context.SaveChanges();

                    return RedirectToAction("Productos", "Productos");
                }

                ViewBag.MensajePantalla = "El producto no se ha podido registrar correctamente";
                return View();
            }
        }



        [HttpPost]
        public ActionResult EliminarProducto(int idProducto)
        {
            using (var context = new AlaPastaDatabaseEntities1())
            {
                var respuesta = context.EliminarProducto(idProducto);

                if (respuesta > 0)
                {
                    ViewBag.MensajePantalla = "Se ha eliminado correctamente";
                }
                else
                {
                    ViewBag.MensajePantalla = "Ha ocurrido algun error";
                }

                return RedirectToAction("Productos");
            }
        }




        /*
        [HttpGet]
        public ActionResult ActualizarProducto(long idProducto)
        {
            using (var context = new AlaPastaDatabaseEntities1())
            {
                var datos = context.tProductos.Where(x => x.IdProducto == idProducto).FirstOrDefault();

                if (datos == null)
                {
                    ViewBag.MensajePantalla = "No se encontró el producto.";
                    return RedirectToAction("ConsultarProductos");
                }
                var producto = new Producto ()
                {
                    IdProducto = datos.IdProducto,
                    NombreProducto = datos.NombreProducto,
                    Descripción = datos.Descripción,
                    Precio = datos.Precio,
                    ConsecutivoCat = datos.ConsecutivoCat,
                    Stock = datos.Stock,
                    ImagenProd = datos.ImagenProd,
                    ActivoProd = datos.ActivoProd
                };

                return View(producto);
            }
        }*/

    }
}