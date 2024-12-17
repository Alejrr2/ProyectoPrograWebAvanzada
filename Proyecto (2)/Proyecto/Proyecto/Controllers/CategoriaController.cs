using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class CategoriaController : Controller
    {
        [HttpGet]
        public ActionResult ListadoCategorias()
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var datos = context.tCategorias.ToList();

                var categorias = new List<Categoria>();
                foreach (var item in datos)
                {
                    categorias.Add(new Categoria
                    {
                        IdCategoria = item.IdCategoria,
                        NombreCat = item.NombreCat
                    });
                }

                return View(categorias);
            }
        }

        [HttpGet]
        public ActionResult AgregarCategorias()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarCategorias(Categoria model)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var tabla = new tCategorias();
                tabla.IdCategoria = 0;
                tabla.NombreCat = model.NombreCat;

                context.tCategorias.Add(tabla);
                var respuesta = context.SaveChanges();

                if (respuesta <= 0)
                {
                    ViewBag.MensajePantalla = "La categoría no se ha podido registrar correctamente";
                    return View();
                }
                return RedirectToAction("ListadoCategorias", "Categoria");
            }
        }

        [HttpGet]
        public ActionResult ActualizarCategoria(long id)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var datos = context.tCategorias.Where(x => x.IdCategoria == id).FirstOrDefault();
                var categoria = new Categoria();

                if (datos != null)
                {
                    categoria.IdCategoria = datos.IdCategoria;
                    categoria.NombreCat = datos.NombreCat;
                }

                return View(categoria);
            }
        }

        [HttpPost]
        public ActionResult ActualizarCategoria(Categoria model)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var datos = context.tCategorias.Where(x => x.IdCategoria == model.IdCategoria).FirstOrDefault();

                if (datos != null)
                {
                    datos.NombreCat = model.NombreCat;

                    var respuesta = context.SaveChanges();

                    if (respuesta > 0)
                    {
                        return RedirectToAction("ListadoCategorias", "Categoria");
                    }
                }

                ViewBag.MensajePantalla = "La categoría no se ha podido actualizar correctamente";
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult EliminarCategoria(long id)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var productosAsociados = context.tProductos.Any(x => x.ConsecutivoCat == id);

                if (productosAsociados)
                {
                    ViewBag.MensajePantalla = "No se puede eliminar la categoría porque existen productos asociados a ella.";
                    var categorias = context.tCategorias.Select(c => new Categoria
                    {
                        IdCategoria = c.IdCategoria,
                        NombreCat = c.NombreCat
                    }).ToList();
                    return View("ListadoCategorias", categorias);
                }

                var datos = context.tCategorias.Where(x => x.IdCategoria == id).FirstOrDefault();

                if (datos != null)
                {
                    context.tCategorias.Remove(datos);
                    context.SaveChanges();

                    return RedirectToAction("ListadoCategorias", "Categoria");
                }

                ViewBag.MensajePantalla = "La categoría no se ha podido eliminar correctamente";
                var categoriasFallback = context.tCategorias.Select(c => new Categoria
                {
                    IdCategoria = c.IdCategoria,
                    NombreCat = c.NombreCat
                }).ToList();
                return View("ListadoCategorias", categoriasFallback);
            }
        }

    }
}