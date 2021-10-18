using System.Collections.Generic;
using System.Linq;
using ERP.AccesoDatos.Models;
using ERP.AccesoDatos.Repository;
using ERP.Entidades.Seguridad;

namespace ERP.AccesoDatos
{
    public class LoginRepository : Repository<SegUsuario>, ILogin
    {
        private readonly ERPContext context;

        public LoginRepository(ERPContext _dbContext) : base(_dbContext)
        {
            context = _dbContext;
        }

        public List<SPaginasRol> PaginasMenuRol(int idRol)
        {
            using (context)
            {
                var menu = from Pa in context.CatPaginas
                           join Pr in context.SegPaginasRols on Pa.Id equals Pr.IdPagina
                           where Pr.IdRol == idRol && Pa.Habilitado == true
                           orderby Pa.Orden ascending
                           select new SPaginasRol
                           {
                               Id = Pa.Id,
                               Controlador = Pa.Controlador,
                               Accion = Pa.Accion,
                               Mensaje = Pa.Mensaje,
                               Icono = Pa.Icono,
                           };

                List<SPaginasRol> menuRol = menu.ToList();

                return menuRol;
            }

        }

        public SegUsuario RecuperaContrasena(string usuario)
        {
            var usuarioValido = context.SegUsuarios.FirstOrDefault(x => x.Usuario == usuario);
            return usuarioValido;
        }

        public SegUsuario ValidaUsuario(string usuario, string contrasena)
        {
            var usuarioValido = context.SegUsuarios.FirstOrDefault(x => x.Usuario == usuario && x.Contrasena == contrasena && x.Habilitado == true);
            return usuarioValido;
        }

    }
}
