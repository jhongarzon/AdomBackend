using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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
    public class PatientController : Controller
    {
        private readonly ILogger logger;
        private readonly IPatientAppService appService;
        private readonly PatientValidator validator;
        private readonly IConfigurationRoot configuration;

        public PatientController(IPatientAppService appService, PatientValidator validator, IConfigurationRoot configuration)
        {
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/Patient/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<Patient>> Get(int? pageNumber, int? pageSize)
        {
            ServiceResult<IEnumerable<Patient>> result = null;

            try
            {
                if (pageNumber == null)
                    pageNumber = 1;

                if (pageSize == null)
                    pageSize = int.Parse(this.configuration["RowsSize"]);

                result = this.appService.GetPatients(pageNumber.Value, pageSize.Value);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<Patient>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Patient/Get")]
        [HttpGet("{id}")]
        public ServiceResult<Patient> Get(int id)
        {
            ServiceResult<Patient> result = null;

            try
            {
                result = this.appService.GetPatientById(id);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<Patient>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Patient/Create")]
        [HttpPost]
        public ServiceResult<Patient> Post([FromBody]Patient model)
        {
            ServiceResult<Patient> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Insert(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<Patient>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<Patient>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Patient/Edit")]
        [HttpPut("{id}")]
        public ServiceResult<Patient> Put(int id, [FromBody]Patient model)
        {
            ServiceResult<Patient> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Update(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<Patient>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<Patient>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }
    }
}
