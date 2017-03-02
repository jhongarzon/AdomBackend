using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using Adom.Hhm.AppServices.Security.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace Adom.Hhm.Web.Rest.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly ILogger logger;
        private readonly IAuthenticationAppService authenticacion;
        private readonly IAuthorizationAppService authorization;

        public AccountController(ILoggerFactory loggerFactory, IAuthenticationAppService authenticacion, IAuthorizationAppService authorization)
        {
            this.logger = loggerFactory.CreateLogger<AccountController>();
            this.authenticacion = authenticacion;
            this.authorization = authorization;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            ServiceResult<object> result = new ServiceResult<object>();

            try
            {
                user = this.authenticacion.ValidCredentials(user.Email, user.Password);

                if (user == null)
                {
                    result.Errors = new string[] { MessageError.InvalidCredentials };
                    result.Success = false;
                }
                else
                {
                    object token = await this.authenticacion.GetNewToken(user);
                    result.Success = true;
                    result.Result = token;
                }
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return new OkObjectResult(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public ServiceResult<bool> Get(int id, string route)
        {
            ServiceResult<bool> result = new ServiceResult<bool>();

            try
            {
                result.Result = this.authorization.IsAuthorized(id, route);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result = new ServiceResult<bool>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }
    }
}