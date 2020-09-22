using CRUDTask.Core.Domain;
using CRUDTask.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDTask.DataAccessLayer.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {
        }


    }
}