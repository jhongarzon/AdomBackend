using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Microsoft.Extensions.Configuration;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Security.Repositories;
using Adom.Hhm.Utility;

namespace Adom.Hhm.Domain.Services
{
    public class CoPaymentFrecuencyDomainServices : ICoPaymentFrecuencyDomainService
    {
        private readonly ICoPaymentFrecuencyRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IConfigurationRoot configuration;

        public CoPaymentFrecuencyDomainServices(IConfigurationRoot configuration, ICoPaymentFrecuencyRepository repository)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        public ServiceResult<CoPaymentFrecuency> GetCoPaymentFrecuencyById(int coPaymentFrecuencyId)
        {
            var getCoPaymentFrecuency = this.repository.GetCoPaymentFrecuencyById(coPaymentFrecuencyId);

            return new ServiceResult<CoPaymentFrecuency>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getCoPaymentFrecuency
            };
        }

        public ServiceResult<IEnumerable<CoPaymentFrecuency>> GetCoPaymentFrecuency(int pageNumber, int pageSize)
        {
            var getCoPaymentFrecuencys = this.repository.GetCoPaymentFrecuency(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<CoPaymentFrecuency>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getCoPaymentFrecuencys
            };
        }

        public ServiceResult<IEnumerable<CoPaymentFrecuency>> GetCoPaymentFrecuency()
        {
            var getCoPaymentFrecuencys = this.repository.GetCoPaymentFrecuency();
            return new ServiceResult<IEnumerable<CoPaymentFrecuency>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getCoPaymentFrecuencys
            };
        }

        public ServiceResult<CoPaymentFrecuency> Insert(CoPaymentFrecuency coPaymentFrecuency)
        {
            CoPaymentFrecuency CoPaymentFrecuencyExist = this.repository.GetCoPaymentFrecuencyByName(coPaymentFrecuency.Name);

            if (CoPaymentFrecuencyExist == null)
            {
                var coPaymentFrecuencyInserted = this.repository.Insert(coPaymentFrecuency);
                return new ServiceResult<CoPaymentFrecuency>
                {
                    Success = true,
                    Result = coPaymentFrecuencyInserted
                };
            }

            return new ServiceResult<CoPaymentFrecuency>
            {
                Success = false,
                Errors = new string[] { MessageError.NameCoPaymentFrecuencyExists }
            };
        }

        public ServiceResult<CoPaymentFrecuency> Update(CoPaymentFrecuency CoPaymentFrecuency)
        {
            CoPaymentFrecuency CoPaymentFrecuencyExist = this.repository.GetCoPaymentFrecuencyByNameWithoutId(CoPaymentFrecuency.CoPaymentFrecuencyId, CoPaymentFrecuency.Name);

            if (CoPaymentFrecuencyExist == null)
            {
                var updated = this.repository.Update(CoPaymentFrecuency);
                return new ServiceResult<CoPaymentFrecuency>
                {
                    Success = true,
                    Result = updated
                };
            }

            return new ServiceResult<CoPaymentFrecuency>
            {
                Success = false,
                Errors = new string[] { MessageError.NameCoPaymentFrecuencyExists }
            };
        }
    }
}
