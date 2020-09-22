using CRUDTask.Core;
using CRUDTask.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDTask.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context
                         ,IProductRepository products
                         ,ICategoryRepository categories
                         ,IReportRepository reports)
        {
            this._context = context;
            this.Products = products;
            this.Categories = categories;
            this.Reports = reports;
        }


        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IReportRepository Reports { get; private set; }
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