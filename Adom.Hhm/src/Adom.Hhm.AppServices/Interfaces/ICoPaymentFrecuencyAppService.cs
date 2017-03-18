using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.AppServices.Interfaces
{
    public interface ICoPaymentFrecuencyAppService
    {
        ServiceResult<IEnumerable<CoPaymentFrecuency>> GetCoPaymentFrecuency(int pageNumber, int pageSize);
        ServiceResult<IEnumerable<CoPaymentFrecuency>> GetCoPaymentFrecuency();
        ServiceResult<CoPaymentFrecuency> GetCoPaymentFrecuencyById(int CoPaymentFrecuencyId);
        ServiceResult<CoPaymentFrecuency> Insert(CoPaymentFrecuency CoPaymentFrecuency);
        ServiceResult<CoPaymentFrecuency> Update(CoPaymentFrecuency CoPaymentFrecuency);
    }
}
