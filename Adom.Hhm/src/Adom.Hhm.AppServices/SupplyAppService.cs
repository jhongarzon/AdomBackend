using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.AppServices
{
    public class SupplyAppService : ISupplyAppService
    {
        private readonly ISupplyDomainService service;

        public SupplyAppService(ISupplyDomainService service)
        {
            this.service = service;
        }

        public ServiceResult<Supply> GetSupplyById(int SupplyId)
        {
            return this.service.GetSupplyById(SupplyId);
        }

        public ServiceResult<IEnumerable<Supply>> GetSupplies(int pageNumber, int pageSize)
        {
            return this.service.GetSupplies(pageNumber, pageSize);
        }

        public ServiceResult<IEnumerable<Supply>> GetSupplies()
        {
            return this.service.GetSupplies();
        }

        public ServiceResult<Supply> Insert(Supply Supply)
        {
            return this.service.Insert(Supply);
        }

        public ServiceResult<Supply> Update(Supply Supply)
        {
            return this.service.Update(Supply);
        }
    }
}
