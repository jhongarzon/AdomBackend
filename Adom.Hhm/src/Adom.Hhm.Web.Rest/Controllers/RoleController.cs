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

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Adom.Hhm.Web.Rest.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly ILogger logger;
        private readonly IRoleAppService appService;
        private readonly RoleValidator validator;
        private readonly IConfigurationRoot configuration;

        public RoleController(ILoggerFactory loggerFactory, IRoleAppService appService, RoleValidator validator, IConfigurationRoot configuration)
        {
            this.logger = loggerFactory.CreateLogger<AccountController>();
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/Roles/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<Role>> Get(int? pageNumber, int? pageSize)
        {
            ServiceResult<IEnumerable<Role>> result = null;

            try
            {
                if (pageNumber == null)
                    pageNumber = 1;

                if (pageSize == null)
                    pageSize = int.Parse(this.configuration["RowsSize"]);

                result = this.appService.GetRoles(pageNumber.Value, pageSize.Value);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<Role>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Roles/Get")]
        [HttpGet("{id}")]
        public ServiceResult<Role> Get(int id)
        {
            ServiceResult<Role> result = null;

            try
            {
                result = this.appService.GetRoleById(id);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<Role>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Roles/Create")]
        [HttpPost]
        public ServiceResult<Role> Post([FromBody]Role model)
        {
            ServiceResult<Role> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Insert(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<Role>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<Role>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Roles/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<Role> Put(int id, [FromBody]Role model)
        {
            ServiceResult<Role> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Update(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<Role>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<Role>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }
    }
}
