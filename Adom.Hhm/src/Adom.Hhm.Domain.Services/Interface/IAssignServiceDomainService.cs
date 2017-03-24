﻿using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IAssignServiceDomainService
    {
        ServiceResult<IEnumerable<AssignService>> GetAssignServices(int pageNumber, int pageSize);
        ServiceResult<IEnumerable<AssignService>> GetAssignServices();
        ServiceResult<AssignService> GetAssignServiceById(int assignServiceId);
        ServiceResult<AssignService> GetAssignServiceByPatientId(int patientId);
        ServiceResult<AssignService> Insert(AssignService assignService);
        ServiceResult<AssignService> Update(AssignService assignService);
    }
}
