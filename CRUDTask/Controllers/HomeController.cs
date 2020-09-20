using CRUDTask.Core;
using CRUDTask.Core.Domain;
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
            var report = new Report()
            {
                ID = 0,
                Date = DateTime.UtcNow.AddHours(2)
            };

            return View("ReportForm", report);
        }
        #endregion

        #region Update Operation
        public ActionResult Update(int id)
        {
            var reportInDb = _unitOfWork.Reports.SingleOrDefault(r => r.ID == id);
            if (reportInDb is null)
                return HttpNotFound();
            return View("ReportForm", reportInDb);
        }
        #endregion

        #region Save action for [Create - Update]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Report report)
        {
            if (!ModelState.IsValid)
                return View("ReportForm", report);
            if(report.ID == 0)
            {
                _unitOfWork.Reports.Add(report);
            }
            else
            {
                var reportInDB = _unitOfWork.Reports.Get(report.ID);
                reportInDB.Date = report.Date;
                reportInDB.Notes = report.Notes;
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