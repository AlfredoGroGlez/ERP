using ERP.AccesoDatos.Models;
using ERP.AccesoDatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.AccesoDatos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ERPContext context;

        public UnitOfWork(ERPContext _dbContext)
        {
            context = _dbContext;
            Login = new LoginRepository(context);
        }

        public ILogin Login { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
