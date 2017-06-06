using System.Collections.Generic;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface ICopaymentDomainService
    {
        ServiceResult<IEnumerable<Copayment>> GetCopayments(int professionalId, int serviceStatusId, int copaymentStatusId);
        ServiceResult<Copayment> UpdateCopayment(Copayment copayment);
    }
}
