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
    public class PlanEntityController : Controller
    {
        private readonly ILogger logger;
        private readonly IPlanEntityAppService appService;
        private readonly PlanEntityValidator validator;
        private readonly IConfigurationRoot configuration;

        public PlanEntityController(IPlanEntityAppService appService, PlanEntityValidator validator, IConfigurationRoot configuration)
        {
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/PlanRate/Get")]
        [HttpGet("{id}")]
        public ServiceResult<IEnumerable<PlanEntity>> Get(int id)
        {
            ServiceResult<IEnumerable<PlanEntity>> result = null;

            try
            {
                result = this.appService.GetPlanEntity(id);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<PlanEntity>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/PlanRate/Create")]
        [HttpPost]
        public ServiceResult<PlanEntity> Post([FromBody]PlanEntity model)
        {
            ServiceResult<PlanEntity> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Insert(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<PlanEntity>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<PlanEntity>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/PlanRate/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<PlanEntity> Put(int id, [FromBody]PlanEntity model)
        {
            ServiceResult<PlanEntity> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Update(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<PlanEntity>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<PlanEntity>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }
    }
}
