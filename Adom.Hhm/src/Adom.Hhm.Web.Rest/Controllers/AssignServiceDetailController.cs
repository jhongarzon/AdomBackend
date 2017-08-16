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
    public class AssignServiceDetailController : Controller
    {
        private readonly ILogger _logger;
        private readonly IAssignServiceDetailAppService _appService;
        private readonly AssignServiceDetailValidator _validator;
        private readonly IConfigurationRoot _configuration;

        public AssignServiceDetailController(IAssignServiceDetailAppService appService, AssignServiceDetailValidator validator, IConfigurationRoot configuration)
        {
            this._appService = appService;
            this._validator = validator;
            this._configuration = configuration;
        }

        [Authorize(Policy = "/AssignService/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<AssignServiceDetail>> Get()
        {
            ServiceResult<IEnumerable<AssignServiceDetail>> result = null;

            try
            {
                result = this._appService.GetAssignServiceDetails();
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<AssignServiceDetail>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/AssignService/Get")]
        [HttpGet("{assignServiceId}")]
        public ServiceResult<IEnumerable<AssignServiceDetail>> Get(int assignServiceId)
        {
            ServiceResult<IEnumerable<AssignServiceDetail>> result = null;

            try
            {
                result = this._appService.GetAssignServiceDetailByAssignServiceId(assignServiceId);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<AssignServiceDetail>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/AssignService/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<AssignServiceDetail> Put(int id, [FromBody]IEnumerable<AssignServiceDetail> models)
        {
            ServiceResult<AssignServiceDetail> result = null;

            foreach (var model in models)
            {
                var validatorResult = _validator.Validate(model);

                if (validatorResult.IsValid)
                {
                    try
                    {
                        result = this._appService.Update(model);
                    }
                    catch (Exception ex)
                    {
                        result = new ServiceResult<AssignServiceDetail>();
                        result.Errors = new string[] { ex.Message };
                        result.Success = false;
                    }
                }
                else
                {
                    result = new ServiceResult<AssignServiceDetail>();
                    result.Errors = validatorResult.GetErrors();
                    result.Success = false;
                }
            }

            return result;
        }
    }
}
