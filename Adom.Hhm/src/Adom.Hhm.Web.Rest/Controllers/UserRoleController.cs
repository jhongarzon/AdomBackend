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
    public class UserRoleController : Controller
    {
        private readonly IUserRoleAppService appService;
        private readonly UserRoleValidator validator;
        private readonly IConfigurationRoot configuration;

        public UserRoleController(IUserRoleAppService appService, UserRoleValidator validator, IConfigurationRoot configuration)
        {
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/UserRoles/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<UserRole>> Get(int userId)
        {
            ServiceResult<IEnumerable<UserRole>> result = null;

            try
            {
                result = this.appService.GetRolesByUserId(userId);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<UserRole>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/UserRoles/Edit")]
        [HttpPost]
        public ServiceResult<bool> Post([FromBody] UserRole model)
        {
            ServiceResult<bool> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.ManagerUserRole(model);
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
