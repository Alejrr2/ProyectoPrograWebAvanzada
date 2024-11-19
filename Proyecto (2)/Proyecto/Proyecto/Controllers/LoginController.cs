using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login/InicioSesion
        [HttpGet]
        public ActionResult InicioSesion()
        {
            return View();
        }

        // POST: Login/InicioSesion
        [HttpPost]
        public ActionResult InicioSesion(Usuario model)
        {

            using (var context = new AlaPastaDatabaseEntities1())
            {
                var resultado = context.InicioSesion(model.Identificacion, model.Contrasenna).FirstOrDefault();

                if (resultado != null)
                {
                    if (resultado.TieneContrasennaTemp && resultado.FechaVencimientoTemp < DateTime.Now)
                    {
                        ViewBag.MensajePantalla = "Credenciales Expiradas";
                        return View();
                    }
                    else
                    {
                        Session["IdUsuario"] = resultado.Identificacion;
                        Session["NombreUsuario"] = resultado.Nombre;
                        Session["Rol"] = resultado.ConsecutivoRol;
                        return RedirectToAction("Index", "Home");
                    }
                } else
                {
                    ViewBag.MensajePantalla = "Correo o Contraseña incorrecta";
                    return View();

                }
            }

            
        }

    // GET: Login/Registro
    [HttpGet]
    public ActionResult Registro()
    {
        return View();
    }

    // POST: Login/Registro
    [HttpPost]
    public ActionResult Registro(Usuario model)
    {

        using (var context = new AlaPastaDatabaseEntities1())
        {
                bool identificacionExiste = context.tUsuario.Any(u => u.Identificacion == model.Identificacion);
                bool correoExiste = context.tUsuario.Any(u => u.CorreoElectronico == model.CorreoElectronico);

                if (identificacionExiste || correoExiste)
                {
                    if (identificacionExiste && correoExiste)
                    {
                        ViewBag.MensajePantalla = "La identificación y el correo ya existen.";
                    }
                    else if (identificacionExiste)
                    {
                        ViewBag.MensajePantalla = "La identificación ya existe.";
                    }
                    else if (correoExiste)
                    {
                        ViewBag.MensajePantalla = "El correo ya existe.";
                    }
                    return View(model);
                }

                var respuesta = context.RegistroUsuario(model.Identificacion, model.Nombre, model.Apellido, model.CorreoElectronico, model.Telefono, model.Contrasenna);
                
                if (respuesta > 0)
                {
                    return RedirectToAction("InicioSesion", "Login");
                }
                else
                {
                    ViewBag.MensajePantalla = "No se ha podido regitrar el usuario";
                    return View();
                }
              
        }

       

    }

        [HttpGet]
        public ActionResult RegistroEmpleado()
        {
            return View();
        }

        // POST: Login/Registro
        [HttpPost]
        public ActionResult RegistroEmpleado(Usuario model)
        {

            using (var context = new AlaPastaDatabaseEntities1())
            {
                var respuesta = context.RegistroEmpleado(model.Identificacion, model.Nombre, model.Apellido, model.CorreoElectronico, model.Telefono, model.Contrasenna);

                if (respuesta > 0)
                {
                    return RedirectToAction("InicioSesion", "Login");
                }
                else
                {
                    ViewBag.MensajePantalla = "No se ha podido regitrar el usuario";
                    return View();
                }

            }
        }

        // GET: Login/RecuperarAcceso
        [HttpGet]
    public ActionResult RecuperarAcceso()
    {
        return View();
    }

        // POST: Login/RecuperarAcceso
        [HttpPost]
        public ActionResult RecuperarAcceso(Usuario model)
        {
            using (var context = new AlaPastaDatabaseEntities1())
            {
                var datos = context.tUsuario.Where(x => x.Identificacion == model.Identificacion).FirstOrDefault();

                if (datos != null)
                {
                    datos.Contrasenna = CrearContrasenna();
                    datos.TieneContrasennaTemp = true;
                    datos.FechaVencimientoTemp = DateTime.Now.AddMinutes(double.Parse(ConfigurationManager.AppSettings["MinutosVigenciaTemporal"]));
                    context.SaveChanges();

                    string ruta = AppDomain.CurrentDomain.BaseDirectory + "\\Styles\\TemplateCorreoProyecto.html";
                    string contenido = System.IO.File.ReadAllText(ruta);

                    contenido = contenido.Replace("@@Nombre", datos.Nombre);
                    contenido = contenido.Replace("@@Contrasenna", datos.Contrasenna);
                    contenido = contenido.Replace("@@Vencimiento", datos.FechaVencimientoTemp.ToString("dd/MM/yyyy hh:mm tt"));

                    EnviarCorreo(datos.CorreoElectronico, "Contraseña Temporal", contenido);
                    return RedirectToAction("InicioSesion", "Login");
                }

                ViewBag.MensajePantalla = "Su información no se ha podido validar correctamente";
                return View();
            }
            
        }

        private string CrearContrasenna()
        {
            int length = 10;
            const string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        private void EnviarCorreo(string destino, string asunto, string contenido)
        {
            string cuenta = ConfigurationManager.AppSettings["CorreoNotificaciones"].ToString();
            string contrasenna = ConfigurationManager.AppSettings["ContrasennaNotificaciones"].ToString();

            MailMessage message = new MailMessage();
            message.From = new MailAddress(cuenta);
            message.To.Add(new MailAddress(destino));
            message.Subject = asunto;
            message.Body = contenido;
            message.Priority = MailPriority.Normal;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.Credentials = new System.Net.NetworkCredential(cuenta, contrasenna);
            client.EnableSsl = true;
            client.Send(message);
        }


        [HttpGet]
        public ActionResult CierreSesion()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult CambiarContrasenna()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CambiarContrasenna(Usuario model)
        {
            if (model.ContrasennaAnterior == model.Contrasenna)
            {
                ViewBag.MensajePantalla = "Debe ingresar una contraseña nueva";
                return View();
            }
            else if (model.Contrasenna != model.ConfirmarContrasenna)
            {
                ViewBag.MensajePantalla = "Las nuevas contraseñas no coinciden";
                return View();
            }

            using (var context = new AlaPastaDatabaseEntities1())
            {
                String Identificacion = Session["IdUsuario"].ToString();
                var datos = context.tUsuario.Where(x => x.Identificacion == Identificacion).FirstOrDefault();

                if (datos != null)
                {
                    if (datos.Contrasenna != model.ContrasennaAnterior)
                    {
                        ViewBag.MensajePantalla = "La contraseña anterior no coincide";
                        return View();
                    }
                    var respuesta = context.CambiarContrasenna(Identificacion, model.Contrasenna, false, DateTime.Now);
                    if (respuesta > 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.MensajePantalla = "No se ha Cambiar la contraseña el usuario";
                        return View();
                    }
                    
                }
                ViewBag.MensajePantalla = "Sus credenciales no se han podido actualizar correctamente";
                return View();
            }
        }



    }
}