using CRUDTask.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDTask.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}