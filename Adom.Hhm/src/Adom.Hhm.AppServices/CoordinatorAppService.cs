using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.AppServices
{
    public class CoordinatorAppService : ICoordinatorAppService
    {
        private readonly ICoordinatorDomainService service;

        public CoordinatorAppService(ICoordinatorDomainService service)
        {
            this.service = service;
        }

        public ServiceResult<Coordinator> GetCoordinatorById(int coordinatorId)
        {
            return this.service.GetCoordinatorById(coordinatorId);
        }

        public ServiceResult<IEnumerable<Coordinator>> GetCoordinators(int pageNumber, int pageSize)
        {
            return this.service.GetCoordinators(pageNumber, pageSize);
        }

        public ServiceResult<IEnumerable<Coordinator>> GetCoordinators()
        {
            return this.service.GetCoordinators();
        }

        public ServiceResult<Coordinator> Insert(Coordinator coordinator)
        {
            return this.service.Insert(coordinator);
        }

        public ServiceResult<Coordinator> Update(Coordinator coordinator)
        {
            return this.service.Update(coordinator);
        }
    }
}
