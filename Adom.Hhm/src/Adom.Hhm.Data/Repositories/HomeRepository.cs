using System.Data;
using System.Linq;
using Adom.Hhm.Data.Querys;
using Adom.Hhm.Domain.Entities.Reports;
using Adom.Hhm.Domain.Repositories;
using Dapper;

namespace Adom.Hhm.Data.Repositories
{

    public class HomeRepository : IHomeRepository
    {
        private readonly IDbConnection _dbConnection;

        public HomeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public HomeReport GetHomeReport()
        {
            return new HomeReport
            {
                NursingStatuses = _dbConnection.Query<ServiceChartStatus>(HomeQuerys.GetNursingServiceReport),
                TherapyStatuses = _dbConnection.Query<ServiceChartStatus>(HomeQuerys.GetTherapyServiceReport),
                IrreglularServices = _dbConnection.Query<PatientReportData>(HomeQuerys.GetIrregularServices).ToList(),
                PatientsWithoutProfessional = _dbConnection.Query<PatientReportData>(HomeQuerys.GetPatientsWithoutProfessional).ToList(),
                ProfessionalCopayments = _dbConnection.Query<ProfessionalCopaymentReport>(HomeQuerys.GetProfessionalCopayments).ToList()
            };
            
        }
    }
}
