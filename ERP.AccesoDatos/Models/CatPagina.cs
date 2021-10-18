using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.AccesoDatos.Models
{
    public partial class CatPagina
    {
        public byte Id { get; set; }
        public string Mensaje { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public bool? Habilitado { get; set; }
        public string Icono { get; set; }
        public byte? Orden { get; set; }
    }
}
