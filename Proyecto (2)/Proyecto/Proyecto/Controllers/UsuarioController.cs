using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]

        public ActionResult ActualizarPerfil()
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                String Identificacion = Session["IdUsuario"].ToString();
                var datos = context.ObtenerDatosUsuario(Identificacion).FirstOrDefault();

                if (datos == null)
                {
                    ViewBag.MensajePantalla = "No se encontraron datos del usuario.";
                    return RedirectToAction("Index", "Home");
                }

                var usuario = new Usuario
                {
                    Consecutivo = datos.Consecutivo,
                    Identificacion = datos.Identificacion,
                    Nombre = datos.Nombre,
                    Apellido = datos.Apellido,
                    CorreoElectronico = datos.CorreoElectronico,
                    Telefono = datos.Telefono
                };

                return View(usuario);
            }

        }

        [HttpPost]

        public ActionResult ActualizarPerfil(Usuario model)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                
                var datos = context.tUsuario.Where(x => x.Identificacion == model.Identificacion).FirstOrDefault();
               
                if (datos == null)
                {
                    ViewBag.MensajePantalla = "Usuario no encontrado.";
                    return View();
                }
          
                bool correoExiste = false;
                if (datos.CorreoElectronico != model.CorreoElectronico)
                {
                    correoExiste = context.tUsuario.Any(u => u.CorreoElectronico == model.CorreoElectronico);
                }

                if (correoExiste)
                {
                    ViewBag.MensajePantalla = "El correo ingresado ya existe.";
                    return View(model);
                }

                var respuesta = context.ActualizarPerfil(model.Identificacion, model.Nombre, model.Apellido, model.CorreoElectronico, model.Telefono);

                if (respuesta > 0)
                {
                    Session["NombreUsuario"] = model.Nombre;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.MensajePantalla = "Su información no se ha podido actualizar correctamente.";
                    return View(model);
                }
            }
        }

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

        [HttpGet]
        public ActionResult ActualizarEmpleado(string id)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                // buscar el empleado                
                var datos = context.tUsuario.FirstOrDefault(e => e.Identificacion == id);
                var empleado = new Usuario();

                if (datos != null)
                {
                    empleado.Identificacion = datos.Identificacion;
                    empleado.Nombre = datos.Nombre;
                    empleado.Apellido = datos.Apellido;
                    empleado.CorreoElectronico = datos.CorreoElectronico;
                    empleado.Telefono = datos.Telefono;
                    return View(empleado);
                }
                else
                {
                    ViewBag.MensajePantalla = "Empleado no encontrado";
                    return RedirectToAction("VerEmpleados", "Usuario");
                }
               
            }
        }



        [HttpPost]
        public ActionResult ActualizarEmpleado(Usuario model)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {

                var empleadoExistente = context.tUsuario.FirstOrDefault(e => e.Identificacion == model.Identificacion);

                if (empleadoExistente != null)
                {
                    empleadoExistente.Nombre = model.Nombre;
                    empleadoExistente.Apellido = model.Apellido;
                    empleadoExistente.CorreoElectronico = model.CorreoElectronico;
                    empleadoExistente.Telefono = model.Telefono;

     
                    context.SaveChanges();

                    return RedirectToAction("VerEmpleados", "Usuario");
                }

                ViewBag.MensajePantalla = "La información no se ha podido actualizar correctamente";
                return View();
            }
        }

        [HttpPost]
        public ActionResult ActualizarEstado(Usuario model)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var datos = context.tUsuario.Where(x => x.Consecutivo == 2).FirstOrDefault();

                if (datos != null)
                {
                    datos.Activo = (datos.Activo ? false : true);
                    context.SaveChanges();
                    return RedirectToAction("VerEmpleados", "Usuario");
                }

                ViewBag.MensajePantalla = "La información no se ha podido actualizar correctamente";
                return View();
            }
        }
        [HttpPost]
        public ActionResult EliminarEmpleado(string id)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var empleado = context.tUsuario.FirstOrDefault(x => x.Identificacion == id);

                if (empleado != null)
                {
                    context.tUsuario.Remove(empleado);
                    context.SaveChanges();
                    ViewBag.MensajePantalla = "Empleado eliminado correctamente.";

                    return RedirectToAction("VerEmpleados", "Usuario");
                }
                ViewBag.MensajePantalla = "No se pudo eliminar el empleado. Verifique el ID.";

                return RedirectToAction("VerEmpleados", "Usuario");
            }
        }

    }
}