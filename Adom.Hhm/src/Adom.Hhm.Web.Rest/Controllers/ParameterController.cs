using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Web.Rest.Validators;
using Adom.Hhm.Web.Rest.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Adom.Hhm.Web.Rest.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class ParameterController : Controller
    {
        private readonly IParameterAppService appService;
        private readonly IConfigurationRoot configuration;

        public ParameterController(IParameterAppService appService, IConfigurationRoot configuration)
        {
            this.appService = appService;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/Parameter/Get")]
        [HttpGet("{parametricTable}")]
        public ServiceResult<IEnumerable<Parameter>> Get(string parametricTable)
        {
            ServiceResult<IEnumerable<Parameter>> result = null;

            try
            {
                result = this.appService.GetDataParametricTable(parametricTable);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<Parameter>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }
    }
}