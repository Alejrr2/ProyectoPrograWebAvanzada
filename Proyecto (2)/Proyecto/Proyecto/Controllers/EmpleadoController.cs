using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        [HttpGet]
        public ActionResult VerEmpleados()
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                //long consecutivoUsuarioLogueado = long.Parse(Session["ConsecutivoEmp"].ToString());
                //var datos = context.tEmpleados.Where(x => x.ConsecutivoEmp != consecutivoUsuarioLogueado).ToList();
                var datos = context.tEmpleados.ToList();

                var empleado = new List<Empleado>();
                foreach (var item in datos)
                {
                    empleado.Add(new Empleado
                    {
                        ConsecutivoRol = item.ConsecutivoRol,
                        IdEmpleado = item.IdEmpleado,
                        NombreEmp = item.NombreEmp,
                        ApellidoEmp = item.ApellidoEmp,
                        CorreoEmp = item.CorreoEmp,
                        TelEmp = item.TelEmp,
                        ActivoEmp = item.ActivoEmp,
                        NombreRol = item.tPuestos.NombrePuesto,
                        //NombreRol = (item.tRoles.NombreRol ? "Activo" ? "Activo" : "Inactivo")
                    });
                }

                return View(empleado);
            }


        }

        [HttpGet]
        public ActionResult ActualizarEmpleado(string id)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                // buscar el empleado                
                var empleado = context.tEmpleados.FirstOrDefault(e => e.IdEmpleado == id);

                if (empleado != null)
                {
                    return View(empleado);
                }

                ViewBag.MensajePantalla = "Empleado no encontrado";
                return RedirectToAction("VerEmpleados", "Empleado");
            }
        }



        [HttpPost]
        public ActionResult ActualizarEmpleado(Empleado model)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {

                var empleadoExistente = context.tEmpleados.FirstOrDefault(e => e.IdEmpleado == model.IdEmpleado);

                if (empleadoExistente != null)
                {
                    // Actualice los campos
                    empleadoExistente.NombreEmp = model.NombreEmp;
                    empleadoExistente.ApellidoEmp = model.ApellidoEmp;
                    empleadoExistente.CorreoEmp = model.CorreoEmp;
                    empleadoExistente.TelEmp = model.TelEmp;

                    //Salvar en lal BD
                    context.SaveChanges();

                    return RedirectToAction("VerEmpleados", "Empleado");
                }

                ViewBag.MensajePantalla = "La información no se ha podido actualizar correctamente";
                return View();
            }
        }

        [HttpPost]
        public ActionResult ActualizarEstado(Empleado model)
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var datos = context.tEmpleados.Where(x => x.ConsecutivoEmp == model.ConsecutivoEmp).FirstOrDefault();

                if (datos != null)
                {
                    datos.ActivoEmp = (datos.ActivoEmp ? false : true);
                    context.SaveChanges();
                    return RedirectToAction("VerEmpleados", "Empleado");
                }

                ViewBag.MensajePantalla = "La información no se ha podido actualizar correctamente";
                return View();
            }
        }

        [HttpGet]
        public ActionResult CrearEmpleado()
        {
            return View();

        }


        [HttpPost]
        public ActionResult CrearEmpleado(Empleado model)
        {
            using (var context = new AlaPastaDatabaseEntities()) //definir la base de datos 
            {
                var tabla = new tEmpleados();

                //listar los atributos de la tabla e igualarlos al atributo del modelo LinQ
                tabla.ConsecutivoEmp = 0;
                tabla.IdEmpleado = "0";
                tabla.NombreEmp =
                tabla.ApellidoEmp = model.ApellidoEmp;
                tabla.CorreoEmp = model.CorreoEmp;
                tabla.TelEmp = model.TelEmp;
                tabla.ConsecutivoPuesto = model.ConsecutivoPuesto;
                tabla.ActivoEmp = true;
                tabla.Contraseña = model.Contraseña;

                context.tEmpleados.Add(tabla);
                var respuesta = context.SaveChanges();


                if (respuesta > 0)
                    return RedirectToAction("VerEmpleados", "Empleado");

                ViewBag.MensajePantalla = "Su información no se ha podido registrar correctamente";
                return View();
            }

        }


        private void CargarPuestos()
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var datos = context.tPuestos.ToList();

                var roles = new List<SelectListItem>();

                roles.Add(new SelectListItem
                {
                    Text = "Seleccione",
                    Value = string.Empty,
                    Value = string."Administrador",
                    Value = string."Cocinero",

                    //Esto es para dejar una opcion vacia, se ulitiza en forms que esten siendo llenados por primera vez y se agrega al lado de @class el @required=true
                });

                foreach (var item in datos)
                {
                    roles.Add(new SelectListItem
                    {
                        Text = item.NombrePuesto,
                        Value = item.ConsecutivoEmp.ToString()
                        //Atributos dentro del Modelo 
                    });
                }

                ViewBag.listaPuestos = roles;
                //Se guardan los datos
            }
        }



    }

}