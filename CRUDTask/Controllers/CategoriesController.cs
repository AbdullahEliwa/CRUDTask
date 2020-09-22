using CRUDTask.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDTask.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Categories
        public ActionResult GetAllCategories()
        {
            var categories = _unitOfWork.Categories.GetAll()
                .Select(c => new { 
                    c.ID,
                    c.Name
                });
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
    }
}