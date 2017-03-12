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
    public class EntityController : Controller
    {
        private readonly ILogger logger;
        private readonly IEntityAppService appService;
        private readonly EntityValidator validator;
        private readonly IConfigurationRoot configuration;

        public EntityController(IEntityAppService appService, EntityValidator validator, IConfigurationRoot configuration)
        {
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/Entity/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<Entity>> Get()
        {
            ServiceResult<IEnumerable<Entity>> result = null;

            try
            {
                result = this.appService.GetEntities();
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<Entity>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Entity/Get")]
        [HttpGet("{id}")]
        public ServiceResult<Entity> Get(int id)
        {
            ServiceResult<Entity> result = null;

            try
            {
                result = this.appService.GetEntityById(id);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<Entity>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Entity/Create")]
        [HttpPost]
        public ServiceResult<Entity> Post([FromBody]Entity model)
        {
            ServiceResult<Entity> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Insert(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<Entity>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<Entity>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Entity/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<Entity> Put(int id, [FromBody]Entity model)
        {
            ServiceResult<Entity> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Update(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<Entity>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<Entity>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }
    }
}
