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
    public class ProfessionalController : Controller
    {
        private readonly ILogger logger;
        private readonly IProfessionalAppService appService;
        private readonly ProfessionalValidator validator;
        private readonly IConfigurationRoot configuration;

        public ProfessionalController(IProfessionalAppService appService, ProfessionalValidator validator, IConfigurationRoot configuration)
        {
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/Professional/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<Professional>> Get()
        {
            ServiceResult<IEnumerable<Professional>> result = null;

            try
            {
                result = this.appService.GetProfessionals();
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<Professional>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Professional/Get")]
        [HttpGet("{id}")]
        public ServiceResult<Professional> Get(int id)
        {
            ServiceResult<Professional> result = null;

            try
            {
                result = this.appService.GetProfessionalById(id);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<Professional>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Professional/Create")]
        [HttpPost]
        public ServiceResult<Professional> Post([FromBody]Professional model)
        {
            ServiceResult<Professional> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Insert(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<Professional>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<Professional>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Professional/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<Professional> Put(int id, [FromBody]Professional model)
        {
            ServiceResult<Professional> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Update(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<Professional>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<Professional>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }
    }
}
