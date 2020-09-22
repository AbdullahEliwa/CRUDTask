using CRUDTask.Core.Domain;
using CRUDTask.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDTask.DataAccessLayer.Repositories
{
    public class ReportRepository: Repository<Report>, IReportRepository
    {
        public ReportRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public Report GetReportWithProducts(int reportId)
        {
            var reports = _context.Reports.Include(r => r.Products)
                                          .SingleOrDefault(r => r.ID == reportId);
            return reports;
        }
    }
}