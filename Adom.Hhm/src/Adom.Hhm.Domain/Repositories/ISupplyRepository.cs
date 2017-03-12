using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface ISupplyRepository
    {
        IEnumerable<Supply> GetSupplies(int pageNumber, int pageSize);
        IEnumerable<Supply> GetSupplies();
        Supply GetSupplyById(int supplyId);
        Supply GetSupplyByName(string name);
        Supply GetSupplyByNameWithoutId(int SupplyId, string name);
        Supply Insert(Supply supply);
        Supply Update(Supply supply);
    }
}
