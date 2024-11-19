﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Producto
    {
        public long IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripción { get; set; }
        public Decimal Precio { get; set; }
        public int ConsecutivoCat { get; set; }
        public int Stock { get; set; }
        public string ImagenProd { get; set; }
        public bool ActivoProd { get; set; }
    }
}