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
    public class AssignServiceDomainServices : IAssignServiceDomainService
    {
        private readonly IAssignServiceRepository repository;
        private readonly IConfigurationRoot configuration;

        public AssignServiceDomainServices(IConfigurationRoot configuration, IAssignServiceRepository repository)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        public ServiceResult<AssignService> GetAssignServiceById(int AssignServiceId)
        {
            var getAssignService = this.repository.GetAssignServiceById(AssignServiceId);

            return new ServiceResult<AssignService>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignService
            };
        }

        public ServiceResult<AssignService> GetAssignServiceByPatientId(int AssignServiceId)
        {
            var getAssignService = this.repository.GetAssignServiceByPatientId(AssignServiceId);

            return new ServiceResult<AssignService>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignService
            };
        }

        public ServiceResult<IEnumerable<AssignService>> GetAssignServices(int pageNumber, int pageSize)
        {
            var getAssignServices = this.repository.GetAssignServices(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<AssignService>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignServices
            };
        }

        public ServiceResult<IEnumerable<AssignService>> GetAssignServices()
        {
            var getAssignServices = this.repository.GetAssignServices();
            return new ServiceResult<IEnumerable<AssignService>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignServices
            };
        }

        public ServiceResult<AssignService> Insert(AssignService assignService)
        {
            var AssignServiceInserted = this.repository.Insert(assignService);
            return new ServiceResult<AssignService>
            {
                Success = true,
                Result = AssignServiceInserted
            };
        }

        public ServiceResult<AssignService> Update(AssignService assignService)
        {
            var updated = this.repository.Update(assignService);
            return new ServiceResult<AssignService>
            {
                Success = true,
                Result = updated
            };
        }
    }
}
