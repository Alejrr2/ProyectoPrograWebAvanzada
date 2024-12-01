﻿using Proyecto.Models;
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

        public ActionResult ListarEmpleado()
        {
            using (var context = new AlaPastaDatabaseEntities())
            {
                var datos = context.tUsuario
                    .Where(x => x.ConsecutivoRol == 2)
                    .ToList();

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


        /*
        [HttpGet]
        public ActionResult EditarEmpleado(Usuario model)
        {
            Usuario usuario = new Usuario();

            using (var context = new AlaPastaDatabaseEntities())
            {
                var datos = context.tUsuario
                    .Where(x => x.Identificacion == model.Identificacion && x.ConsecutivoRol == 2)
                    .FirstOrDefault();

                if (datos != null)
                {
                    usuario.Consecutivo = datos.Consecutivo;
                    usuario.Identificacion = datos.Identificacion;
                    usuario.Nombre = datos.Nombre;
                    usuario.Apellido = datos.Apellido;
                    usuario.CorreoElectronico = datos.CorreoElectronico;
                    usuario.Telefono = datos.Telefono;
                }
                else
                {
                    ViewBag.MensajePantalla = "No se encontró un empleado con el ID especificado.";
                    return RedirectToAction("ListarEmpleado");
                }

                return View(usuario);
            }
        }*/

    }
}