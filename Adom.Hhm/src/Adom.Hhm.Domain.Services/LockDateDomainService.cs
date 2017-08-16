using System;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Services.Interface;

namespace Adom.Hhm.Domain.Services
{
    public class LockDateDomainService : ILockDateDomainService
    {
        private readonly ILockDateRepository _lockDateRepository;

        public LockDateDomainService(ILockDateRepository lockDateRepository)
        {
            _lockDateRepository = lockDateRepository;
        }
        public ServiceResult<bool> UpdateLockDate(string lockDate)
        {
            var result = _lockDateRepository.UpdateLockDate(lockDate);
            return new ServiceResult<bool>()
            {
                Result = result,
                Success = true,
                Errors = new[] { "" }
            };
        }
    }
}
