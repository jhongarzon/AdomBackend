﻿using System;
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
    public class AssignServiceController : Controller
    {
        private readonly ILogger logger;
        private readonly IAssignServiceAppService appService;
        private readonly AssignServiceValidator validator;
        private readonly IConfigurationRoot configuration;

        public AssignServiceController(IAssignServiceAppService appService, AssignServiceValidator validator, IConfigurationRoot configuration)
        {
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/AssignService/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<AssignService>> Get()
        {
            ServiceResult<IEnumerable<AssignService>> result = null;

            try
            {
                result = this.appService.GetAssignServices();
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<AssignService>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/AssignService/Get")]
        [HttpGet("{patientId}")]
        public ServiceResult<IEnumerable<AssignService>> Get(int patientId)
        {
            ServiceResult<IEnumerable<AssignService>> result = null;

            try
            {
                result = this.appService.GetAssignServiceByPatientId(patientId);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<AssignService>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/AssignService/Create")]
        [HttpPost]
        public ServiceResult<AssignService> Post([FromBody]AssignService model)
        {
            ServiceResult<AssignService> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Insert(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<AssignService>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<AssignService>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/AssignService/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<AssignService> Put(int id, [FromBody]AssignService model)
        {
            ServiceResult<AssignService> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Update(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<AssignService>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<AssignService>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }
    }
}
