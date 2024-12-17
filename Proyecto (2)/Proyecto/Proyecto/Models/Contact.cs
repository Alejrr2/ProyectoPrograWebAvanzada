using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Contact
    {
        public long id_Contacto { get; set; }

        public String NombreContacto { get; set; }

        public int NumeroTel { get; set; }

        public String Comentario { get; set; }

    }
}