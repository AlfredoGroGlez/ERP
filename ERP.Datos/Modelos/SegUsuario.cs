using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Datos.Modelos
{
    public partial class SegUsuario
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int IdRol { get; set; }
        public bool? Habilitado { get; set; }

        public virtual CatRole IdRolNavigation { get; set; }
    }
}
