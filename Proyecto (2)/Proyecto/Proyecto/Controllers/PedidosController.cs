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
        [HttpGet]
        public ActionResult MisPedidos()
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                if (Session["Consecutivo"] != null && int.TryParse(Session["Consecutivo"].ToString(), out int userId))
                {
                    var pedidos = context.tPedidos.Where(p => p.ConsecutivoUsuario == userId).ToList();

                    return View(pedidos);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

    }
}