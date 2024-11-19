﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AlaPastaDatabaseEntities1 : DbContext
    {
        public AlaPastaDatabaseEntities1()
            : base("name=AlaPastaDatabaseEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tCategorias> tCategorias { get; set; }
        public virtual DbSet<tDetalles> tDetalles { get; set; }
        public virtual DbSet<tDirecciones> tDirecciones { get; set; }
        public virtual DbSet<tMetodos> tMetodos { get; set; }
        public virtual DbSet<tPagos> tPagos { get; set; }
        public virtual DbSet<tPedidos> tPedidos { get; set; }
        public virtual DbSet<tProductos> tProductos { get; set; }
        public virtual DbSet<tPuestos> tPuestos { get; set; }
        public virtual DbSet<tRoles> tRoles { get; set; }
        public virtual DbSet<tUsuario> tUsuario { get; set; }
    
        public virtual int ActualizarContrasenna(string contrasennaTemp, Nullable<bool> tieneContrasennaTemp, Nullable<System.DateTime> fechaVencimientoTemp, Nullable<long> consecutivo)
        {
            var contrasennaTempParameter = contrasennaTemp != null ?
                new ObjectParameter("ContrasennaTemp", contrasennaTemp) :
                new ObjectParameter("ContrasennaTemp", typeof(string));
    
            var tieneContrasennaTempParameter = tieneContrasennaTemp.HasValue ?
                new ObjectParameter("TieneContrasennaTemp", tieneContrasennaTemp) :
                new ObjectParameter("TieneContrasennaTemp", typeof(bool));
    
            var fechaVencimientoTempParameter = fechaVencimientoTemp.HasValue ?
                new ObjectParameter("FechaVencimientoTemp", fechaVencimientoTemp) :
                new ObjectParameter("FechaVencimientoTemp", typeof(System.DateTime));
    
            var consecutivoParameter = consecutivo.HasValue ?
                new ObjectParameter("Consecutivo", consecutivo) :
                new ObjectParameter("Consecutivo", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarContrasenna", contrasennaTempParameter, tieneContrasennaTempParameter, fechaVencimientoTempParameter, consecutivoParameter);
        }
    
        public virtual int ActualizarPerfil(string identificacion, string nombre, string apellido, string correoElectronico, string telefono)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("Identificacion", identificacion) :
                new ObjectParameter("Identificacion", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var correoElectronicoParameter = correoElectronico != null ?
                new ObjectParameter("CorreoElectronico", correoElectronico) :
                new ObjectParameter("CorreoElectronico", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarPerfil", identificacionParameter, nombreParameter, apellidoParameter, correoElectronicoParameter, telefonoParameter);
        }
    
        public virtual int CambiarContrasenna(string identificacion, string contrasenna, Nullable<bool> tieneContrasennaTemp, Nullable<System.DateTime> fechaVencimientoTemp)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("Identificacion", identificacion) :
                new ObjectParameter("Identificacion", typeof(string));
    
            var contrasennaParameter = contrasenna != null ?
                new ObjectParameter("Contrasenna", contrasenna) :
                new ObjectParameter("Contrasenna", typeof(string));
    
            var tieneContrasennaTempParameter = tieneContrasennaTemp.HasValue ?
                new ObjectParameter("TieneContrasennaTemp", tieneContrasennaTemp) :
                new ObjectParameter("TieneContrasennaTemp", typeof(bool));
    
            var fechaVencimientoTempParameter = fechaVencimientoTemp.HasValue ?
                new ObjectParameter("FechaVencimientoTemp", fechaVencimientoTemp) :
                new ObjectParameter("FechaVencimientoTemp", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CambiarContrasenna", identificacionParameter, contrasennaParameter, tieneContrasennaTempParameter, fechaVencimientoTempParameter);
        }
    
        public virtual ObjectResult<InicioSesion_Result> InicioSesion(string identificacion, string contrasenna)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("Identificacion", identificacion) :
                new ObjectParameter("Identificacion", typeof(string));
    
            var contrasennaParameter = contrasenna != null ?
                new ObjectParameter("Contrasenna", contrasenna) :
                new ObjectParameter("Contrasenna", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<InicioSesion_Result>("InicioSesion", identificacionParameter, contrasennaParameter);
        }
    
        public virtual ObjectResult<ObtenerDatosUsuario_Result> ObtenerDatosUsuario(string identificacion)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("Identificacion", identificacion) :
                new ObjectParameter("Identificacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ObtenerDatosUsuario_Result>("ObtenerDatosUsuario", identificacionParameter);
        }
    
        public virtual int RegistroUsuario(string identificacion, string nombre, string apellido, string correoElectronico, string telefono, string contrasenna)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("Identificacion", identificacion) :
                new ObjectParameter("Identificacion", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var correoElectronicoParameter = correoElectronico != null ?
                new ObjectParameter("CorreoElectronico", correoElectronico) :
                new ObjectParameter("CorreoElectronico", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var contrasennaParameter = contrasenna != null ?
                new ObjectParameter("Contrasenna", contrasenna) :
                new ObjectParameter("Contrasenna", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RegistroUsuario", identificacionParameter, nombreParameter, apellidoParameter, correoElectronicoParameter, telefonoParameter, contrasennaParameter);
        }
    
        public virtual int ActualizarProducto(Nullable<int> idProducto, string nombreProducto, string descripción, Nullable<decimal> precio, Nullable<int> consecutivoCat, Nullable<int> stock, string imagenProd, Nullable<bool> activoProd)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var nombreProductoParameter = nombreProducto != null ?
                new ObjectParameter("NombreProducto", nombreProducto) :
                new ObjectParameter("NombreProducto", typeof(string));
    
            var descripciónParameter = descripción != null ?
                new ObjectParameter("Descripción", descripción) :
                new ObjectParameter("Descripción", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var consecutivoCatParameter = consecutivoCat.HasValue ?
                new ObjectParameter("ConsecutivoCat", consecutivoCat) :
                new ObjectParameter("ConsecutivoCat", typeof(int));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("Stock", stock) :
                new ObjectParameter("Stock", typeof(int));
    
            var imagenProdParameter = imagenProd != null ?
                new ObjectParameter("ImagenProd", imagenProd) :
                new ObjectParameter("ImagenProd", typeof(string));
    
            var activoProdParameter = activoProd.HasValue ?
                new ObjectParameter("ActivoProd", activoProd) :
                new ObjectParameter("ActivoProd", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarProducto", idProductoParameter, nombreProductoParameter, descripciónParameter, precioParameter, consecutivoCatParameter, stockParameter, imagenProdParameter, activoProdParameter);
        }
    
        public virtual int EliminarProducto(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminarProducto", idProductoParameter);
        }
    
        public virtual int RegistroProducto(string nombreProducto, string descripción, Nullable<decimal> precio, Nullable<int> consecutivoCat, Nullable<int> stock, string imagenProd, Nullable<bool> activoProd)
        {
            var nombreProductoParameter = nombreProducto != null ?
                new ObjectParameter("NombreProducto", nombreProducto) :
                new ObjectParameter("NombreProducto", typeof(string));
    
            var descripciónParameter = descripción != null ?
                new ObjectParameter("Descripción", descripción) :
                new ObjectParameter("Descripción", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var consecutivoCatParameter = consecutivoCat.HasValue ?
                new ObjectParameter("ConsecutivoCat", consecutivoCat) :
                new ObjectParameter("ConsecutivoCat", typeof(int));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("Stock", stock) :
                new ObjectParameter("Stock", typeof(int));
    
            var imagenProdParameter = imagenProd != null ?
                new ObjectParameter("ImagenProd", imagenProd) :
                new ObjectParameter("ImagenProd", typeof(string));
    
            var activoProdParameter = activoProd.HasValue ?
                new ObjectParameter("ActivoProd", activoProd) :
                new ObjectParameter("ActivoProd", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RegistroProducto", nombreProductoParameter, descripciónParameter, precioParameter, consecutivoCatParameter, stockParameter, imagenProdParameter, activoProdParameter);
        }
    }
}
