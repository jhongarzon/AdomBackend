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
        public ProfessionalAssignedServicesController(IProfessionalAssignedDomainService professionalAssignedDomainService)
        {
            _professionalAssignedDomainService = professionalAssignedDomainService;
        }
        [Authorize(Policy = "/ProfessionalAssignedServices/Get")]
        [HttpGet("{userId}/{statusId}")]
        public ServiceResult<IEnumerable<ProfessionalAssignedServices>> Get(int userId, int statusId)
        {
            ServiceResult<IEnumerable<ProfessionalAssignedServices>> result = null;
            try
            {
                result = _professionalAssignedDomainService.GetAssignedServices(userId, statusId);
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
