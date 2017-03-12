using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.AppServices
{
    public class ProfessionalAppService : IProfessionalAppService
    {
        private readonly IProfessionalDomainService service;

        public ProfessionalAppService(IProfessionalDomainService service)
        {
            this.service = service;
        }

        public ServiceResult<Professional> GetProfessionalById(int ProfessionalId)
        {
            return this.service.GetProfessionalById(ProfessionalId);
        }

        public ServiceResult<IEnumerable<Professional>> GetProfessionals(int pageNumber, int pageSize)
        {
            return this.service.GetProfessionals(pageNumber, pageSize);
        }

        public ServiceResult<IEnumerable<Professional>> GetProfessionals()
        {
            return this.service.GetProfessionals();
        }

        public ServiceResult<Professional> Insert(Professional Professional)
        {
            return this.service.Insert(Professional);
        }

        public ServiceResult<Professional> Update(Professional Professional)
        {
            return this.service.Update(Professional);
        }
    }
}
