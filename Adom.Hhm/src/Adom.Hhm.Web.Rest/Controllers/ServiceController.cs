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
    public class ServiceController : Controller
    {
        private readonly ILogger logger;
        private readonly IServiceAppService appService;
        private readonly ServiceValidator validator;
        private readonly IConfigurationRoot configuration;

        public ServiceController(IServiceAppService appService, ServiceValidator validator, IConfigurationRoot configuration)
        {
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/Service/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<Service>> Get()
        {
            ServiceResult<IEnumerable<Service>> result = null;

            try
            {
                result = this.appService.GetServices();
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<Service>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Service/Get")]
        [HttpGet("{id}")]
        public ServiceResult<Service> Get(int id)
        {
            ServiceResult<Service> result = null;

            try
            {
                result = this.appService.GetServiceById(id);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<Service>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Service/Get")]
        [HttpGet("{planEntityId}/{id2}")]
        public ServiceResult<IEnumerable<Service>> GetServicesByPlanEntityid(int planEntityId, int id2)
        {
            ServiceResult<IEnumerable<Service>> result = null;

            try
            {
                result = this.appService.GetServicesByPlanEntityId(planEntityId);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<Service>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Service/Create")]
        [HttpPost]
        public ServiceResult<Service> Post([FromBody]Service model)
        {
            ServiceResult<Service> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Insert(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<Service>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<Service>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Service/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<Service> Put(int id, [FromBody]Service model)
        {
            ServiceResult<Service> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Update(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<Service>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<Service>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }
    }
}
