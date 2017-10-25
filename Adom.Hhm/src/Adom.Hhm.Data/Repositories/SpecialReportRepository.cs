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
        public IEnumerable<SpecialSummaryReport> GetSpecialSummaryReport(SpecialReportFilter specialReportFilter)
        {
            var summaryReport = SpecialReportQuerys.GetSummaryReport;
            if (!string.IsNullOrEmpty(specialReportFilter.InitialDateIni))
            {
                summaryReport += " AND Ags.[InitialDate] > CONVERT(DATE, @InitialDateIni, 105) ";
            }
            if (!string.IsNullOrEmpty(specialReportFilter.InitialDateEnd))
            {
                summaryReport += " AND Ags.[InitialDate] < CONVERT(DATE, @InitialDateEnd, 105) ";
            }
            if (!string.IsNullOrEmpty(specialReportFilter.VisitDateIni))
            {
                summaryReport += " AND EXISTS(SELECT 1 FROM[sas].[AssignServiceDetails] WHERE DateVisit > CONVERT(DATE, @VisitDateIni, 105)) ";
            }
            if (!string.IsNullOrEmpty(specialReportFilter.VisitDateEnd))
            {
                summaryReport += " AND EXISTS(SELECT 1 FROM[sas].[AssignServiceDetails] WHERE DateVisit < CONVERT(DATE, @VisitDateEnd,105)) ";
            }
            if (!string.IsNullOrEmpty(specialReportFilter.RequestDateIni))
            {
                summaryReport += " AND EXISTS(SELECT 1 FROM[sas].[AssignServiceDetails] WHERE RecordDate > CONVERT(DATE, @RequestDateIni, 105)) ";
            }
            if (!string.IsNullOrEmpty(specialReportFilter.RequestDateEnd))
            {
                summaryReport += " AND EXISTS(SELECT 1 FROM[sas].[AssignServiceDetails] WHERE RecordDate < CONVERT(DATE, @RequestDateEnd,105)) ";
            }
            if (specialReportFilter.EntityId > 0)
            {
                summaryReport += "AND Ags.[EntityId] = @EntityId ";
            }
            if (specialReportFilter.PatientType > 0)
            {
                summaryReport += "AND pt.[Id] = @PatientType ";
            }
            if (specialReportFilter.ServiceId > 0)
            {
                summaryReport += "AND Ags.[ServiceId] = @ServiceId ";
            }
            var specialReport = _dbConnection.Query<SpecialSummaryReport>(summaryReport, specialReportFilter).ToList();

            foreach (var specialSummaryReport in specialReport)
            {
                specialSummaryReport.AssignedProfessionals = _dbConnection.Query<AssignedProfessional>(SpecialReportQuerys.GetAssignedProfessionals, new
                {
                    specialSummaryReport.AssignServiceId
                });
            }
            return specialReport.OrderByDescending(x => x.AssignedProfessionals.Count());
        }

        public IEnumerable<SpecialDetailedReport> GetSpecialDetailedReport(SpecialReportFilter specialReportFilter)
        {
            var detailedReportQuery = SpecialReportQuerys.GetDetailedReport;
            if (!string.IsNullOrEmpty(specialReportFilter.InitialDateIni))
            {
                detailedReportQuery += " AND Ags.[InitialDate] > CONVERT(DATE, @InitialDateIni, 105) ";
            }
            if (!string.IsNullOrEmpty(specialReportFilter.InitialDateEnd))
            {
                detailedReportQuery += " AND Ags.[InitialDate] < CONVERT(DATE, @InitialDateEnd, 105) ";
            }
            if (!string.IsNullOrEmpty(specialReportFilter.VisitDateIni))
            {
                detailedReportQuery += " AND Asd.[DateVisit] > CONVERT(DATE, @VisitDateIni, 105) ";
            }
            if (!string.IsNullOrEmpty(specialReportFilter.VisitDateEnd))
            {
                detailedReportQuery += " AND Asd.[DateVisit] < CONVERT(DATE, @VisitDateEnd, 105) ";
            }
            if (!string.IsNullOrEmpty(specialReportFilter.RequestDateIni))
            {
                detailedReportQuery += " AND Asd.[RecordDate] > CONVERT(DATE, @RequestDateIni, 105) ";
            }
            if (!string.IsNullOrEmpty(specialReportFilter.RequestDateEnd))
            {
                detailedReportQuery += " AND Asd.[RecordDate] < CONVERT(DATE, @RequestDateEnd,105) ";
            }
            if (specialReportFilter.EntityId > 0)
            {
                detailedReportQuery += "AND Ags.[EntityId] = @EntityId ";
            }
            if (specialReportFilter.PatientType > 0)
            {
                detailedReportQuery += "AND pt.[Id] = @PatientType ";
            }
            if (specialReportFilter.ServiceId > 0)
            {
                detailedReportQuery += "AND Ags.[ServiceId] = @ServiceId ";
            }

            detailedReportQuery += " ORDER BY Asd.AssignServiceDetailId DESC ";

            var detailedReport = _dbConnection.Query<SpecialDetailedReport>(detailedReportQuery, specialReportFilter).ToList();
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
