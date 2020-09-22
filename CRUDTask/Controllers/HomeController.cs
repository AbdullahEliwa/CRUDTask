using CRUDTask.Core;
using CRUDTask.Core.Domain;
using CRUDTask.DataAccessLayer;
using CRUDTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        #region Read Operation
        // GET: Home
        public ActionResult Index()
        {
            var reports = _unitOfWork.Reports.GetAll();
            return View(reports);
        }
        #endregion

        #region Create Operation
        public ActionResult Create()
        {
            var reportProductVM = new ReportProductViewModel()
            {
                report = new Report()
                {
                    ID = 0,
                    Date = DateTime.UtcNow
                }
            };

            return View("ReportForm", reportProductVM);
        }
        #endregion

        // TODO: Update method need to retrive products, that's retalted to report
        #region Update Operation
        public ActionResult Update(int id)
        {
            var reportInDb = _unitOfWork.Reports.GetReportWithProducts(id);
            if (reportInDb is null)
                return HttpNotFound();

            var reportProductVM = new ReportProductViewModel()
            {
                report = reportInDb,
                Products = reportInDb.Products,
                AllCategories = _unitOfWork.Categories.GetAll(),
                AllProducts = _unitOfWork.Products.GetAll()
            };

            return View("ReportForm", reportProductVM);
        }
        #endregion



        #region Save action for [Create - Update]
        // TODO: Not Finished(Need to handle Update)
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(ReportProductViewModel orderProductVM, int[] ProductIds)
        {
            if (!ModelState.IsValid)
                return View("ReportForm", orderProductVM);
            if (ProductIds is null)
            {
                ModelState.AddModelError("", "Report must have at least one product.");
                return View("ReportForm", orderProductVM);
            }

            if (orderProductVM.report.ID == 0)
            {
                var products = new List<Product>();
                foreach (var productId in ProductIds)
                {
                    var product = _unitOfWork.Products.Get(productId);
                    products.Add(product);
                }
                var report = new Report()
                {
                    Date = orderProductVM.report.Date,
                    Notes = orderProductVM.report.Notes,
                    Products = products
                };
                _unitOfWork.Reports.Add(report);
            }
            else
            {
                var reportInDB = _unitOfWork.Reports.Get(orderProductVM.report.ID);
                reportInDB.Date = orderProductVM.report.Date;
                reportInDB.Notes = orderProductVM.report.Notes;
                reportInDB.Products.Clear();
                foreach (var productId in ProductIds)
                {
                    var product = _unitOfWork.Products.Get(productId);
                    reportInDB.Products.Add(product);
                }
            }
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Operation
        public ActionResult Delete(int id)
        {
            var reportInDB = _unitOfWork.Reports.SingleOrDefault(r => r.ID == id);
            if (reportInDB is null)
                return HttpNotFound();
            _unitOfWork.Reports.Delete(reportInDB);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        #endregion


    }
}