using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.AppServices
{
    public class CoPaymentFrecuencyAppService : ICoPaymentFrecuencyAppService
    {
        private readonly ICoPaymentFrecuencyDomainService service;

        public CoPaymentFrecuencyAppService(ICoPaymentFrecuencyDomainService service)
        {
            this.service = service;
        }

        public ServiceResult<CoPaymentFrecuency> GetCoPaymentFrecuencyById(int CoPaymentFrecuencyId)
        {
            return this.service.GetCoPaymentFrecuencyById(CoPaymentFrecuencyId);
        }

        public ServiceResult<IEnumerable<CoPaymentFrecuency>> GetCoPaymentFrecuency(int pageNumber, int pageSize)
        {
            return this.service.GetCoPaymentFrecuency(pageNumber, pageSize);
        }

        public ServiceResult<IEnumerable<CoPaymentFrecuency>> GetCoPaymentFrecuency()
        {
            return this.service.GetCoPaymentFrecuency();
        }

        public ServiceResult<CoPaymentFrecuency> Insert(CoPaymentFrecuency coPaymentFrecuency)
        {
            return this.service.Insert(coPaymentFrecuency);
        }

        public ServiceResult<CoPaymentFrecuency> Update(CoPaymentFrecuency coPaymentFrecuency)
        {
            return this.service.Update(coPaymentFrecuency);
        }
    }
}
