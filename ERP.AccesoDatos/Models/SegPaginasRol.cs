using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.AccesoDatos.Models
{
    public partial class SegPaginasRol
    {
        public short Id { get; set; }
        public byte IdPagina { get; set; }
        public int IdRol { get; set; }
        public bool? Habilitado { get; set; }
    }
}
