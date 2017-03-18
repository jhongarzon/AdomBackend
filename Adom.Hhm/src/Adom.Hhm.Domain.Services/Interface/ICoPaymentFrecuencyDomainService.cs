using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface ICoPaymentFrecuencyDomainService
    {
        ServiceResult<IEnumerable<CoPaymentFrecuency>> GetCoPaymentFrecuency(int pageNumber, int pageSize);
        ServiceResult<IEnumerable<CoPaymentFrecuency>> GetCoPaymentFrecuency();
        ServiceResult<CoPaymentFrecuency> GetCoPaymentFrecuencyById(int coPaymentFrecuencyId);
        ServiceResult<CoPaymentFrecuency> Insert(CoPaymentFrecuency coPaymentFrecuency);
        ServiceResult<CoPaymentFrecuency> Update(CoPaymentFrecuency coPaymentFrecuency);
    }
}
