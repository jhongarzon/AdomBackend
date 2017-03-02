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
    public class UserController : Controller
    {
        private readonly ILogger logger;
        private readonly IUserAppService appService;
        private readonly UserValidator validator;
        private readonly IConfigurationRoot configuration;

        public UserController(ILoggerFactory loggerFactory, IUserAppService appService, UserValidator validator, IConfigurationRoot configuration)
        {
            this.logger = loggerFactory.CreateLogger<AccountController>();
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/Users/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<User>> Get(int? pageNumber, int? pageSize)
        {
            ServiceResult<IEnumerable<User>> result = null;

            try
            {
                if (pageNumber == null)
                    pageNumber = 1;

                if (pageSize == null)
                    pageSize = int.Parse(this.configuration["RowsSize"]);

                result = this.appService.GetUsers(pageNumber.Value, pageSize.Value);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<User>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Users/Get")]
        [HttpGet("{id}")]
        public ServiceResult<User> Get(int id)
        {
            ServiceResult<User> result = null;

            try
            {
                result = this.appService.GetUserById(id);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<User>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Users/Create")]
        [HttpPost]
        public ServiceResult<User> Post([FromBody]User model)
        {
            ServiceResult<User> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Insert(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<User>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<User>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Users/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<User> Put(int id, [FromBody]User model)
        {
            ServiceResult<User> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Update(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<User>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<User>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }
    }
}
