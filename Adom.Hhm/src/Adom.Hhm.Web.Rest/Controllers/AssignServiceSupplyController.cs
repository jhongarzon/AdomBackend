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
using System.IdentityModel.Tokens.Jwt;
using Adom.Hhm.Utility;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Adom.Hhm.Web.Rest.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class AssignServiceSupplyController : Controller
    {
        private readonly ILogger logger;
        private readonly IAssignServiceSupplyAppService appService;
        private readonly AssignServiceSupplyValidator validator;
        private readonly IConfigurationRoot configuration;

        public AssignServiceSupplyController(IAssignServiceSupplyAppService appService, AssignServiceSupplyValidator validator, IConfigurationRoot configuration)
        {
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/AssignService/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<AssignServiceSupply>> Get()
        {
            ServiceResult<IEnumerable<AssignServiceSupply>> result = null;

            try
            {
                result = this.appService.GetAssignServiceSupplies();
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<AssignServiceSupply>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/AssignService/Get")]
        [HttpGet("{id}")]
        public ServiceResult<IEnumerable<AssignServiceSupply>> Get(int id)
        {
            ServiceResult<IEnumerable<AssignServiceSupply>> result = null;

            try
            {
                result = this.appService.GetAssignServiceSupplyByAssignServiceId(id);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<AssignServiceSupply>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/AssignService/Create")]
        [HttpPost]
        public ServiceResult<AssignServiceSupply> Post([FromBody]AssignServiceSupply model)
        {
            ServiceResult<AssignServiceSupply> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Insert(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<AssignServiceSupply>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<AssignServiceSupply>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/AssignService/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<bool> Put(int id, [FromBody]AssignServiceSupply model)
        {
            ServiceResult<bool> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Delete(id);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<bool>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<bool>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }
    }
}
