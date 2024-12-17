using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var datos = context.tContactos.ToList();

                var contactos = new List<tContactos>();
                foreach (var item in datos)
                {
                    contactos.Add(new tContactos
                    {
                        Id_Contacto = item.Id_Contacto,
                        NombreContacto = item.NombreContacto,
                        NumeroTel = item.NumeroTel,
                        Comentario = item.Comentario
                    });
                }

                return View(contactos);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpGet]
        public ActionResult AgregarContacto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarContacto(tContactos model)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                context.tContactos.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
