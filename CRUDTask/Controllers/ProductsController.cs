using CRUDTask.Core;
using CRUDTask.Core.Domain;
using CRUDTask.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDTask.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        // GET: Products
        [HttpGet]
        public ActionResult GetProductsByCategoryId(int id)
        {
            IEnumerable<Product> products = _unitOfWork.Products.Find(p => p.CategoryID == id);
            var result = products.Select(p => new
            {
                p.ID,
                p.Name
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetProductsDetails(int id)
        {
            //var products = from p in _unitOfWork.Products
            //               where p.ID == id
            //               select new { price = p.UnitPrice, quantity = p.Quantity };
            var product = _unitOfWork.Products.Find(p => p.ID == id);
            var newProduct = from p in product
                             select new { price = p.UnitPrice, quantity = p.Quantity };
            return Json(newProduct, JsonRequestBehavior.AllowGet);
        }


    }
}