using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Entities.Reports;
using Microsoft.AspNetCore.Authorization;


namespace Adom.Hhm.Web.Rest.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IHomeDomainService _homeDomainService;
        public HomeController(IHomeDomainService homeDomainService)
        {
            _homeDomainService = homeDomainService;
        }
        [Authorize(Policy = "/Home/Get")]
        [HttpGet]
        public ServiceResult<HomeReport> GetHomeReport()
        {
            var result = _homeDomainService.GetHomeReport();
            return result;
        }
    }
}
