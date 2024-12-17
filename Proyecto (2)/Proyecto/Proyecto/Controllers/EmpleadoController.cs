using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult VerEmpleados()
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var datos = context.tUsuario.Where(x => x.ConsecutivoRol == 2).ToList();

                List<Usuario> empleados = new List<Usuario>();

                foreach (var dato in datos)
                {
                    empleados.Add(new Usuario
                    {
                        Consecutivo = dato.Consecutivo,
                        Identificacion = dato.Identificacion,
                        Nombre = dato.Nombre,
                        Apellido = dato.Apellido,
                        CorreoElectronico = dato.CorreoElectronico,
                        Telefono = dato.Telefono,
                        ConsecutivoRol = dato.ConsecutivoRol,
                        NombreRol = "Empleado"
                    });
                }

                return View(empleados);
            }
        }
    }
}