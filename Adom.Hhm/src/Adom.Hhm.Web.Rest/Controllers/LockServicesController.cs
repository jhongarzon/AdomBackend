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

namespace Adom.Hhm.Web.Rest.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class LockServicesController : Controller
    {
        private readonly ILockDateDomainService _lockDateDomainService;
        public LockServicesController(ILockDateDomainService lockDateDomainService)
        {
            _lockDateDomainService = lockDateDomainService;
        }

        [Authorize(Policy = "/LockServices/Edit")]
        [HttpPut]
        public ServiceResult<bool> Update([FromBody] LockService lockService)
        {
            return _lockDateDomainService.UpdateLockDate(lockService.LockDate);
        }
    }
}
