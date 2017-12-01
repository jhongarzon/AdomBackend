using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using Microsoft.AspNetCore.Cors;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Adom.Hhm.Web.Rest.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class ProfessionalAssignedServicesController : Controller
    {
        private readonly IProfessionalAssignedDomainService _professionalAssignedDomainService;
        private readonly IProfessionalDomainService _professionalDomainService;
        public ProfessionalAssignedServicesController(IProfessionalAssignedDomainService professionalAssignedDomainService, IProfessionalDomainService professionalDomainService)
        {
            _professionalAssignedDomainService = professionalAssignedDomainService;
            _professionalDomainService = professionalDomainService;
        }
        [Authorize(Policy = "/ProfessionalAssignedServices/Get")]
        [HttpGet("{userId}")]
        public ServiceResult<Professional> Get(int userId)
        {
            ServiceResult<Professional> result = null;
            try
            {
                result = _professionalDomainService.GetProfessionalByUserId(userId);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<Professional>();
                result.Errors = new[] { ex.Message };
                result.Success = false;
            }

            return result;
        }
        [Authorize(Policy = "/ProfessionalAssignedServices/Get")]
        [HttpGet("{professionalId}/{statusId}")]
        public ServiceResult<IEnumerable<ProfessionalAssignedServices>> Get(int professionalId, int statusId)
        {
            ServiceResult<IEnumerable<ProfessionalAssignedServices>> result = null;
            try
            {
                result = _professionalAssignedDomainService.GetAssignedServices(professionalId, statusId);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<ProfessionalAssignedServices>>();
                result.Errors = new[] { ex.Message };
                result.Success = false;
            }

            return result;
        }
    }
}
