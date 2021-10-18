using ERP.AccesoDatos.Models;
using ERP.Entidades.Seguridad;
using System.Collections.Generic;

namespace ERP.AccesoDatos.Repository
{
    public interface ILogin
    {
        SegUsuario ValidaUsuario(string usuario, string contrasena);

        SegUsuario RecuperaContrasena(string usuario);

        List<SPaginasRol> PaginasMenuRol(int idRol);
    }
}
