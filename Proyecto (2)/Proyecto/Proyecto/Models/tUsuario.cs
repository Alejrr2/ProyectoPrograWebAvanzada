//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tUsuario
    {
        public int Consecutivo { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Contrasenna { get; set; }
        public int ConsecutivoRol { get; set; }
        public bool Activo { get; set; }
        public bool TieneContrasennaTemp { get; set; }
        public System.DateTime FechaVencimientoTemp { get; set; }
    
        public virtual tPedidos tPedidos { get; set; }
        public virtual tRoles tRoles { get; set; }
    }
}
