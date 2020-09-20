using CRUDTask.Core.Domain;
using CRUDTask.Core.Repositories;
using System;
using System.Collections.Generic;
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
    }
}