using Adom.Hhm.Domain.Entities.Reports;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Services.Interface;

namespace Adom.Hhm.Domain.Services
{
    public class HomeDomainService:IHomeDomainService
    {
        private readonly IHomeRepository _homeRepository;
        public HomeDomainService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }
        public ServiceResult<HomeReport> GetHomeReport()
        {
            var result = _homeRepository.GetHomeReport();
            return new ServiceResult<HomeReport>
            {
                Success = true,
                Errors = new[] { string.Empty },
                Result = result
            };
        }
    }
}
