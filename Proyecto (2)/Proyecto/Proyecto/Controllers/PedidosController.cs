using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class PedidosController : Controller
    {
        [HttpGet]
        public ActionResult ConsultarPedidos()
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                

                var pedidos = context.tPedidos.ToList();

                return View(pedidos);
            }
        }
    }
}