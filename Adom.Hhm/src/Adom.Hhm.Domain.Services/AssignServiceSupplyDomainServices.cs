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
    public class AssignServiceSupplyDomainServices : IAssignServiceSupplyDomainService
    {
        private readonly IAssignServiceSupplyRepository repository;
        private readonly IConfigurationRoot configuration;

        public AssignServiceSupplyDomainServices(IConfigurationRoot configuration, IAssignServiceSupplyRepository repository)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        public ServiceResult<AssignServiceSupply> GetAssignServiceSupplyById(int assignServiceSupplyId)
        {
            var getAssignServiceSupply = this.repository.GetAssignServiceSupplyById(assignServiceSupplyId);

            return new ServiceResult<AssignServiceSupply>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignServiceSupply
            };
        }

        public ServiceResult<IEnumerable<AssignServiceSupply>> GetAssignServiceSupplyByAssignServiceId(int assignServiceId)
        {
            var getAssignServiceSupply = this.repository.GetAssignServiceSupplyByAssignServiceId(assignServiceId);

            return new ServiceResult<IEnumerable<AssignServiceSupply>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignServiceSupply
            };
        }

        public ServiceResult<IEnumerable<AssignServiceSupply>> GetAssignServiceSupplies(int pageNumber, int pageSize)
        {
            var getAssignServiceSupplys = this.repository.GetAssignServiceSupplies(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<AssignServiceSupply>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignServiceSupplys
            };
        }

        public ServiceResult<IEnumerable<AssignServiceSupply>> GetAssignServiceSupplies()
        {
            var getAssignServiceSupplys = this.repository.GetAssignServiceSupplies();
            return new ServiceResult<IEnumerable<AssignServiceSupply>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignServiceSupplys
            };
        }

        public ServiceResult<AssignServiceSupply> Insert(AssignServiceSupply AssignServiceSupply)
        {
            var AssignServiceSupplyInserted = this.repository.Insert(AssignServiceSupply);
            return new ServiceResult<AssignServiceSupply>
            {
                Success = true,
                Result = AssignServiceSupplyInserted
            };
        }

        public ServiceResult<AssignServiceSupply> Update(AssignServiceSupply AssignServiceSupply)
        {
            var updated = this.repository.Update(AssignServiceSupply);
            return new ServiceResult<AssignServiceSupply>
            {
                Success = true,
                Result = updated
            };
        }

        public ServiceResult<bool> Delete(int assignServiceSupplyId)
        {
            var deleted = this.repository.Delete(assignServiceSupplyId);

            if (deleted)
            {
                return new ServiceResult<bool>
                {
                    Success = true,
                    Result = true
                };
            }
            else
            {
                return new ServiceResult<bool>
                {
                    Success = false,
                    Result = false
                };
            }
        }
    }
}
