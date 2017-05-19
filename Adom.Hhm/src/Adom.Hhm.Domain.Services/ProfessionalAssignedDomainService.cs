using System.Collections.Generic;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Services.Interface;

namespace Adom.Hhm.Domain.Services
{
    public class ProfessionalAssignedDomainService : IProfessionalAssignedDomainService
    {
        private readonly IProfessionalAssignedRepository _professionalAssignedRepository;
        public ProfessionalAssignedDomainService(IProfessionalAssignedRepository professionalAssignedRepository)
        {
            _professionalAssignedRepository = professionalAssignedRepository;
        }
        public ServiceResult<IEnumerable<ProfessionalAssignedServices>> GetAssignedServices(int userId, int statusId)
        {
            var result = _professionalAssignedRepository.GetAssignedServices(userId, statusId);

            return new ServiceResult<IEnumerable<ProfessionalAssignedServices>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = result
            };
        }
    }
}
