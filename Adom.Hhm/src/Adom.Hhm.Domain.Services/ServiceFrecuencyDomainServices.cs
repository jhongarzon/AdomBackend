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
    public class ServiceFrecuencyDomainServices : IServiceFrecuencyDomainService
    {
        private readonly IServiceFrecuencyRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IConfigurationRoot configuration;

        public ServiceFrecuencyDomainServices(IConfigurationRoot configuration, IServiceFrecuencyRepository repository)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        public ServiceResult<ServiceFrecuency> GetServiceFrecuencyById(int ServiceFrecuencyId)
        {
            var getServiceFrecuency = this.repository.GetServiceFrecuencyById(ServiceFrecuencyId);

            return new ServiceResult<ServiceFrecuency>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getServiceFrecuency
            };
        }

        public ServiceResult<IEnumerable<ServiceFrecuency>> GetServiceFrecuency(int pageNumber, int pageSize)
        {
            var getServiceFrecuencys = this.repository.GetServiceFrecuency(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<ServiceFrecuency>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getServiceFrecuencys
            };
        }

        public ServiceResult<IEnumerable<ServiceFrecuency>> GetServiceFrecuency()
        {
            var getServiceFrecuencys = this.repository.GetServiceFrecuency();
            return new ServiceResult<IEnumerable<ServiceFrecuency>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getServiceFrecuencys
            };
        }

        public ServiceResult<ServiceFrecuency> Insert(ServiceFrecuency serviceFrecuency)
        {
            ServiceFrecuency ServiceFrecuencyExist = this.repository.GetServiceFrecuencyByName(serviceFrecuency.Name);

            if (ServiceFrecuencyExist == null)
            {
                var ServiceFrecuencyInserted = this.repository.Insert(serviceFrecuency);
                return new ServiceResult<ServiceFrecuency>
                {
                    Success = true,
                    Result = ServiceFrecuencyInserted
                };
            }

            return new ServiceResult<ServiceFrecuency>
            {
                Success = false,
                Errors = new string[] { MessageError.NameServiceFrecuencyExists }
            };
        }

        public ServiceResult<ServiceFrecuency> Update(ServiceFrecuency serviceFrecuency)
        {
            ServiceFrecuency ServiceFrecuencyExist = this.repository.GetServiceFrecuencyByNameWithoutId(serviceFrecuency.ServiceFrecuencyId, serviceFrecuency.Name);

            if (ServiceFrecuencyExist == null)
            {
                var updated = this.repository.Update(serviceFrecuency);
                return new ServiceResult<ServiceFrecuency>
                {
                    Success = true,
                    Result = updated
                };
            }

            return new ServiceResult<ServiceFrecuency>
            {
                Success = false,
                Errors = new string[] { MessageError.NameServiceFrecuencyExists }
            };
        }
    }
}
