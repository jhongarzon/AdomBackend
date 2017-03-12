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
    public class ServiceDomainServices : IServiceDomainService
    {
        private readonly IServiceRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IConfigurationRoot configuration;

        public ServiceDomainServices(IConfigurationRoot configuration, IServiceRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        public ServiceResult<Service> GetServiceById(int ServiceId)
        {
            var getService = this.repository.GetServiceById(ServiceId);

            return new ServiceResult<Service>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getService
            };
        }

        public ServiceResult<IEnumerable<Service>> GetServices(int pageNumber, int pageSize)
        {
            var getServices = this.repository.GetServices(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<Service>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getServices
            };
        }

        public ServiceResult<IEnumerable<Service>> GetServices()
        {
            var getServices = this.repository.GetServices();
            return new ServiceResult<IEnumerable<Service>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getServices
            };
        }

        public ServiceResult<Service> Insert(Service Service)
        {
            Service ServiceExist = this.repository.GetServiceByName(Service.Name);

            if (ServiceExist == null)
            {
                var ServiceInserted = this.repository.Insert(Service);
                return new ServiceResult<Service>
                {
                    Success = true,
                    Result = ServiceInserted
                };
            }

            return new ServiceResult<Service>
            {
                Success = false,
                Errors = new string[] { MessageError.NameServiceExists }
            };
        }

        public ServiceResult<Service> Update(Service Service)
        {
            Service ServiceExist = this.repository.GetServiceByNameWithoutId(Service.ServiceId, Service.Name);

            if (ServiceExist == null)
            {
                var updated = this.repository.Update(Service);
                return new ServiceResult<Service>
                {
                    Success = true,
                    Result = updated
                };
            }

            return new ServiceResult<Service>
            {
                Success = false,
                Errors = new string[] { MessageError.NameServiceExists }
            };
        }
    }
}
