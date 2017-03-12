using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface ICoordinatorRepository
    {
        IEnumerable<Coordinator> GetCoordinators(int pageNumber, int pageSize);
        IEnumerable<Coordinator> GetCoordinators();
        Coordinator GetCoordinatorById(int CoordinatorId);
        Coordinator GetCoordinatorByEmail(string email);
        Coordinator GetCoordinatorByEmailWithoutId(int CoordinatorId, string email);
        Coordinator Insert(Coordinator Coordinator);
        Coordinator Update(Coordinator Coordinator);
    }
}
