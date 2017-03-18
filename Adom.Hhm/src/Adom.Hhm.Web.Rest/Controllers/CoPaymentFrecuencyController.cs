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
    public class CoPaymentFrecuencyController : Controller
    {
        private readonly ILogger logger;
        private readonly ICoPaymentFrecuencyAppService appService;
        private readonly CoPaymentFrecuencyValidator validator;
        private readonly IConfigurationRoot configuration;

        public CoPaymentFrecuencyController(ICoPaymentFrecuencyAppService appService, CoPaymentFrecuencyValidator validator, IConfigurationRoot configuration)
        {
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/CoPaymentFrecuency/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<CoPaymentFrecuency>> Get()
        {
            ServiceResult<IEnumerable<CoPaymentFrecuency>> result = null;

            try
            {
                result = this.appService.GetCoPaymentFrecuency();
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<CoPaymentFrecuency>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/CoPaymentFrecuency/Get")]
        [HttpGet("{id}")]
        public ServiceResult<CoPaymentFrecuency> Get(int id)
        {
            ServiceResult<CoPaymentFrecuency> result = null;

            try
            {
                result = this.appService.GetCoPaymentFrecuencyById(id);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<CoPaymentFrecuency>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/CoPaymentFrecuency/Create")]
        [HttpPost]
        public ServiceResult<CoPaymentFrecuency> Post([FromBody]CoPaymentFrecuency model)
        {
            ServiceResult<CoPaymentFrecuency> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Insert(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<CoPaymentFrecuency>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<CoPaymentFrecuency>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/CoPaymentFrecuency/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<CoPaymentFrecuency> Put(int id, [FromBody]CoPaymentFrecuency model)
        {
            ServiceResult<CoPaymentFrecuency> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Update(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<CoPaymentFrecuency>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<CoPaymentFrecuency>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }
    }
}
