using System.Collections.Generic;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Services.Interface;

namespace Adom.Hhm.Domain.Services
{
    public class CopaymentDomainService : ICopaymentDomainService
    {
        private readonly ICopaymentRepository _copaymentRepository;
        public CopaymentDomainService(ICopaymentRepository copaymentRepository)
        {
            _copaymentRepository = copaymentRepository;
        }
        public ServiceResult<IEnumerable<Copayment>> GetCopayments(int professionalId, int serviceStatusId, int copaymentStatusId)
        {
            var result = _copaymentRepository.GetCopayments(professionalId, serviceStatusId, copaymentStatusId);
            return new ServiceResult<IEnumerable<Copayment>>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = result
            };
        }

        public ServiceResult<Copayment> UpdateCopayment(Copayment copayment)
        {
            var result = _copaymentRepository.UpdateCopayment(copayment);
            return new ServiceResult<Copayment>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = result
            };
        }
    }
}
