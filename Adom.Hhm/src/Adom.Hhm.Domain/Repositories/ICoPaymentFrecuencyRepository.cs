using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface ICoPaymentFrecuencyRepository
    {
        IEnumerable<CoPaymentFrecuency> GetCoPaymentFrecuency(int pageNumber, int pageSize);
        IEnumerable<CoPaymentFrecuency> GetCoPaymentFrecuency();
        CoPaymentFrecuency GetCoPaymentFrecuencyById(int coPaymentFrecuencyId);
        CoPaymentFrecuency GetCoPaymentFrecuencyByName(string name);
        CoPaymentFrecuency GetCoPaymentFrecuencyByNameWithoutId(int coPaymentFrecuencyId, string name);
        CoPaymentFrecuency Insert(CoPaymentFrecuency coPaymentFrecuency);
        CoPaymentFrecuency Update(CoPaymentFrecuency coPaymentFrecuency);
    }
}
