using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Data.Querys;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Repositories;

namespace Adom.Hhm.Data.Repositories
{
    public class CopaymentRepository : ICopaymentRepository
    {
        private readonly IDbConnection _connection;

        public CopaymentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Copayment> GetCopayments(int professionalId, int serviceStatusId, int copaymentStatusId)
        {
            var copaymentQuery = CopaymentQuerys.GetCopayment;
            if (professionalId > 0)
            {
                copaymentQuery += " AND ProfessionalId = @ProfessionalId ";
            }
            if (serviceStatusId > 1)
            {
                copaymentQuery += " AND QuantityCompleted = Quantity ";
            }
            if (copaymentStatusId < 2)
            {
                copaymentQuery += " AND CopaymentStatusId = @copaymentStatusId ";
            }

            copaymentQuery += " ORDER BY StateId ASC, [InitialDate] DESC";


            return _connection.Query<Copayment>(copaymentQuery,
                new
                {
                    ProfessionalId = professionalId,
                    ServiceStatusId = serviceStatusId,
                    CopaymentStatusId = copaymentStatusId
                });
        }

        public Copayment UpdateCopayment(Copayment copayment)
        {
            var result = _connection.Execute(CopaymentQuerys.UpdateCopayment,
                new
                {
                    copayment.AssignServiceId,
                    copayment.TotalCopaymentReceived,
                    copayment.OtherValuesReceived,
                    copayment.DeliveredCopayments,
                    copayment.Discounts,
                    copayment.ReceivedBy
                });
            if (result < 1)
            {
                copayment.AssignServiceId = 0;
            }
            return copayment;

        }
    }
}
