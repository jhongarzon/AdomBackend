using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IProfessionalDomainService
    {
        ServiceResult<IEnumerable<Professional>> GetProfessionals(int pageNumber, int pageSize);
        ServiceResult<IEnumerable<Professional>> GetProfessionals();
        ServiceResult<Professional> GetProfessionalById(int ProfessionalId);
        ServiceResult<Professional> Insert(Professional Professional);
        ServiceResult<Professional> Update(Professional Professional);
    }
}
