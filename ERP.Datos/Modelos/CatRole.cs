using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Datos.Modelos
{
    public partial class CatRole
    {
        public CatRole()
        {
            SegUsuarios = new HashSet<SegUsuario>();
        }

        public int Id { get; set; }
        public string Rol { get; set; }
        public bool Habilitado { get; set; }

        public virtual ICollection<SegUsuario> SegUsuarios { get; set; }
    }
}
