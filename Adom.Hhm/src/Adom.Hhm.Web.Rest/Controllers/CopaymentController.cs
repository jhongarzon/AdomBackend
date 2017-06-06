using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Services.Interface;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Adom.Hhm.Web.Rest.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class CopaymentController : Controller
    {
        private readonly ICopaymentDomainService _copaymentDomainService;
        public CopaymentController(ICopaymentDomainService copaymentDomainService)
        {
            _copaymentDomainService = copaymentDomainService;
        }
        [Authorize(Policy = "/Copayment/Get")]
        [HttpGet("{professionalId}/{serviceStatusId}/{copaymentStatusId}")]
        public ServiceResult<IEnumerable<Copayment>> Get(int professionalId, int serviceStatusId, int copaymentStatusId)
        {
            ServiceResult<IEnumerable<Copayment>> result = null;
            try
            {
                result = _copaymentDomainService.GetCopayments(professionalId, serviceStatusId, copaymentStatusId);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<Copayment>>();
                result.Errors = new[] { ex.Message };
                result.Success = false;
            }

            return result;
        }
        [Authorize(Policy = "/Copayment/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<Copayment> Put(int id, [FromBody]Copayment copayment)
        {
            ServiceResult<Copayment> result;
            try
            {
                result = _copaymentDomainService.UpdateCopayment(copayment);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<Copayment>();
                result.Errors = new[] { ex.Message };
                result.Success = false;
            }
            return result;
        }
    }
}
