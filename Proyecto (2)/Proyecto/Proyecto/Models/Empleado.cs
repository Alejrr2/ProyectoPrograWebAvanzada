using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Empleado
    {
        public int ConsecutivoEmp { get; set; }
        public string IdEmpleado { get; set; }
        public string NombreEmp { get; set; }
        public string ApellidoEmp { get; set; }
        public string CorreoEmp { get; set; }
        public string TelEmp { get; set; }
        public int ConsecutivoPuesto { get; set; }
        public bool ActivoEmp { get; set; }
        public string Contraseña { get; set; }

        public int IdPuesto { get; set; }
        public string NombrePuesto { get; set; }

    }
}