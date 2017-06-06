using System.Collections.Generic;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.Domain.Repositories
{
    public interface ICopaymentRepository
    {
        IEnumerable<Copayment> GetCopayments(int professionalId, int serviceStatusId, int copaymentStatusId);
        Copayment UpdateCopayment(Copayment copayment);
    }
}
