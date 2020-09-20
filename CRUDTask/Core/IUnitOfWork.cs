using CRUDTask.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTask.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }

        int Complete();
    }
}
