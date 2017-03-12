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
    public class SupplyController : Controller
    {
        private readonly ILogger logger;
        private readonly ISupplyAppService appService;
        private readonly SupplyValidator validator;
        private readonly IConfigurationRoot configuration;

        public SupplyController(ISupplyAppService appService, SupplyValidator validator, IConfigurationRoot configuration)
        {
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/Supply/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<Supply>> Get()
        {
            ServiceResult<IEnumerable<Supply>> result = null;

            try
            {
                result = this.appService.GetSupplies();
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<Supply>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Supply/Get")]
        [HttpGet("{id}")]
        public ServiceResult<Supply> Get(int id)
        {
            ServiceResult<Supply> result = null;

            try
            {
                result = this.appService.GetSupplyById(id);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<Supply>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Supply/Create")]
        [HttpPost]
        public ServiceResult<Supply> Post([FromBody]Supply model)
        {
            ServiceResult<Supply> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Insert(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<Supply>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<Supply>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Supply/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<Supply> Put(int id, [FromBody]Supply model)
        {
            ServiceResult<Supply> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Update(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<Supply>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<Supply>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }
    }
}
