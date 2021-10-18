using ERP.Entidades.Seguridad;
using System.Collections.Generic;

namespace ERP.Negocio.Login.Interfaces
{
    public interface ILnLogin
    {
        SUsuario ValidaUsuario(SUsuario usuario);
        JsonResponse RecuperaContrasena(string usuario);
        string PaginasMenuRol(int idRol);
    }
}
