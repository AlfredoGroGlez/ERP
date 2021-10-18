using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.AccesoDatos.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ILogin Login { get; }

        void Save();
    }
}
