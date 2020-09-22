using CRUDTask.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDTask.ViewModels
{
    public class ReportProductViewModel
    {
        public ReportProductViewModel()
        {
            Products = new List<Product>();
            AllCategories = new List<Category>();
            AllProducts = new List<Product>();
        }
        public Report report { get; set; }

        public IEnumerable<Category> AllCategories { get; set; }
        public IEnumerable<Product> AllProducts { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}