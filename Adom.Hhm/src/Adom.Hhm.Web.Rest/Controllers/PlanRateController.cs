using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Adom.Hhm.AppServices.Security.Interfaces;
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
    public class PlanRateController : Controller
    {
        private readonly ILogger logger;
        private readonly IPlanRateAppService appService;
        private readonly PlanRateValidator validator;
        private readonly IConfigurationRoot configuration;

        public PlanRateController(IPlanRateAppService appService, PlanRateValidator validator, IConfigurationRoot configuration)
        {
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/PlanRate/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<PlanRate>> Get()
        {
            ServiceResult<IEnumerable<PlanRate>> result = null;

            try
            {
                result = this.appService.GetPlanRate();
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<PlanRate>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/PlanRate/Get")]
        [HttpGet("{id}")]
        public ServiceResult<PlanRate> Get(int id)
        {
            ServiceResult<PlanRate> result = null;

            try
            {
                result = this.appService.GetPlanRateById(id);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<PlanRate>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/PlanRate/Create")]
        [HttpPost]
        public ServiceResult<PlanRate> Post([FromBody]PlanRate model)
        {
            ServiceResult<PlanRate> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Insert(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<PlanRate>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<PlanRate>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/PlanRate/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<PlanRate> Put(int id, [FromBody]PlanRate model)
        {
            ServiceResult<PlanRate> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Update(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<PlanRate>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<PlanRate>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }
    }
}
