using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Data.Querys;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Reports;
using Adom.Hhm.Domain.Repositories;
using Dapper;

namespace Adom.Hhm.Data.Repositories
{
    public class SpecialReportRepository : ISpecialReportRepository
    {
        private readonly IDbConnection _dbConnection;

        public SpecialReportRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public IEnumerable<SpecialSummaryReport> GetSpecialSummaryReport()
        {
            var specialReport = _dbConnection.Query<SpecialSummaryReport>(SpecialReportQuerys.GetSummaryReport).ToList();

            foreach (var specialSummaryReport in specialReport)
            {
                specialSummaryReport.AssignedProfessionals = _dbConnection.Query<AssignedProfessional>(SpecialReportQuerys.GetAssignedProfessionals, new
                {
                    specialSummaryReport.AssignServiceId
                });
            }
            return specialReport.OrderByDescending(x => x.AssignedProfessionals.Count());
        }

        public IEnumerable<SpecialDetailedReport> GetSpecialDetailedReport()
        {
            var detailedReport = _dbConnection.Query<SpecialDetailedReport>(SpecialReportQuerys.GetDetailedReport).ToList();
            foreach (var row in detailedReport)
            {
                row.QualityQuestions = _dbConnection.Query<QualityQuestion>(SpecialReportQuerys.GetQualityQuestions,
                    new
                    {
                        row.AssignServiceDetailId
                    });
            }
            return detailedReport.OrderByDescending(x => x.QualityQuestions.Count()); ;
        }
    }
}
