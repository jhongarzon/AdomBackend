using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IAssignServiceRepository
    {
        IEnumerable<AssignService> GetAssignServices(int pageNumber, int pageSize);
        IEnumerable<AssignService> GetAssignServices();
        AssignService GetAssignServiceById(int assignServiceId);
        AssignService GetAssignServiceByPatientId(int patientId);
        AssignService Insert(AssignService assignService);
        AssignService Update(AssignService assignService);
    }
}
