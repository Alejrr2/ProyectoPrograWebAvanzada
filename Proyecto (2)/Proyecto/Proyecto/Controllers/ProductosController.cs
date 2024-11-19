using Proyecto.Models;
using System;
using System.Collections.Generic;
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
            return View();
        }

        [HttpPost]
        public ActionResult Productos(Producto model)
        {
            return View();
        }
    }
}