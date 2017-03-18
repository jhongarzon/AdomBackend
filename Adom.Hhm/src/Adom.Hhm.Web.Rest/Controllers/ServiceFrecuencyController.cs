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
    public class ServiceFrecuencyController : Controller
    {
        private readonly ILogger logger;
        private readonly IServiceFrecuencyAppService appService;
        private readonly ServiceFrecuencyValidator validator;
        private readonly IConfigurationRoot configuration;

        public ServiceFrecuencyController(IServiceFrecuencyAppService appService, ServiceFrecuencyValidator validator, IConfigurationRoot configuration)
        {
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/ServiceFrecuency/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<ServiceFrecuency>> Get()
        {
            ServiceResult<IEnumerable<ServiceFrecuency>> result = null;

            try
            {
                result = this.appService.GetServiceFrecuency();
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<ServiceFrecuency>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/ServiceFrecuency/Get")]
        [HttpGet("{id}")]
        public ServiceResult<ServiceFrecuency> Get(int id)
        {
            ServiceResult<ServiceFrecuency> result = null;

            try
            {
                result = this.appService.GetServiceFrecuencyById(id);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<ServiceFrecuency>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/ServiceFrecuency/Create")]
        [HttpPost]
        public ServiceResult<ServiceFrecuency> Post([FromBody]ServiceFrecuency model)
        {
            ServiceResult<ServiceFrecuency> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Insert(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<ServiceFrecuency>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<ServiceFrecuency>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/ServiceFrecuency/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<ServiceFrecuency> Put(int id, [FromBody]ServiceFrecuency model)
        {
            ServiceResult<ServiceFrecuency> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Update(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<ServiceFrecuency>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<ServiceFrecuency>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }
    }
}
