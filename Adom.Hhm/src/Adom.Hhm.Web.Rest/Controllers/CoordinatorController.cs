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
    public class CoordinatorController : Controller
    {
        private readonly ILogger logger;
        private readonly ICoordinatorAppService appService;
        private readonly CoordinatorValidator validator;
        private readonly IConfigurationRoot configuration;

        public CoordinatorController(ICoordinatorAppService appService, CoordinatorValidator validator, IConfigurationRoot configuration)
        {
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/Coordinator/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<Coordinator>> Get(int? pageNumber, int? pageSize)
        {
            ServiceResult<IEnumerable<Coordinator>> result = null;

            try
            {
                if (pageNumber == null)
                    pageNumber = 1;

                if (pageSize == null)
                    pageSize = int.Parse(this.configuration["RowsSize"]);

                result = this.appService.GetCoordinators(pageNumber.Value, pageSize.Value);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<Coordinator>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Coordinator/Get")]
        [HttpGet("{id}")]
        public ServiceResult<Coordinator> Get(int id)
        {
            ServiceResult<Coordinator> result = null;

            try
            {
                result = this.appService.GetCoordinatorById(id);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<Coordinator>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Coordinator/Create")]
        [HttpPost]
        public ServiceResult<Coordinator> Post([FromBody]Coordinator model)
        {
            ServiceResult<Coordinator> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Insert(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<Coordinator>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<Coordinator>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Coordinator/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<Coordinator> Put(int id, [FromBody]Coordinator model)
        {
            ServiceResult<Coordinator> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Update(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<Coordinator>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<Coordinator>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }
    }
}
