using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IAssignServiceSupplyRepository
    {
        IEnumerable<AssignServiceSupply> GetAssignServiceSupplies(int pageNumber, int pageSize);
        IEnumerable<AssignServiceSupply> GetAssignServiceSupplies();
        AssignServiceSupply GetAssignServiceSupplyById(int assignServiceSupplyId);
        IEnumerable<AssignServiceSupply> GetAssignServiceSupplyByAssignServiceId(int assignServiceId);
        AssignServiceSupply Insert(AssignServiceSupply assignServiceSupply);
        AssignServiceSupply Update(AssignServiceSupply assignServiceSupply);
        bool Delete(int assignServiceSupplyId);
    }
}
