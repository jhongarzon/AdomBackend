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
    public class SupplyDomainServices : ISupplyDomainService
    {
        private readonly ISupplyRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IConfigurationRoot configuration;

        public SupplyDomainServices(IConfigurationRoot configuration, ISupplyRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        public ServiceResult<Supply> GetSupplyById(int SupplyId)
        {
            var getSupply = this.repository.GetSupplyById(SupplyId);

            return new ServiceResult<Supply>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getSupply
            };
        }

        public ServiceResult<IEnumerable<Supply>> GetSupplies(int pageNumber, int pageSize)
        {
            var getSupplys = this.repository.GetSupplies(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<Supply>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getSupplys
            };
        }

        public ServiceResult<IEnumerable<Supply>> GetSupplies()
        {
            var getSupplys = this.repository.GetSupplies();
            return new ServiceResult<IEnumerable<Supply>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getSupplys
            };
        }

        public ServiceResult<Supply> Insert(Supply Supply)
        {
            Supply SupplyExist = this.repository.GetSupplyByName(Supply.Name);

            if (SupplyExist == null)
            {
                var SupplyInserted = this.repository.Insert(Supply);
                return new ServiceResult<Supply>
                {
                    Success = true,
                    Result = SupplyInserted
                };
            }

            return new ServiceResult<Supply>
            {
                Success = false,
                Errors = new string[] { MessageError.NameSupplyExists }
            };
        }

        public ServiceResult<Supply> Update(Supply Supply)
        {
            Supply SupplyExist = this.repository.GetSupplyByNameWithoutId(Supply.SupplyId, Supply.Name);

            if (SupplyExist == null)
            {
                var updated = this.repository.Update(Supply);
                return new ServiceResult<Supply>
                {
                    Success = true,
                    Result = updated
                };
            }

            return new ServiceResult<Supply>
            {
                Success = false,
                Errors = new string[] { MessageError.NameSupplyExists }
            };
        }
    }
}
