using System;
using System.Collections.Generic;
using System.Linq;
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
        public ServiceResult<IEnumerable<Patient>> Get()
        {
            ServiceResult<IEnumerable<Patient>> result = null;

            try
            {
                result = this.appService.GetPatients();
                
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
        [HttpGet("{id}/{id2}")]
        public ServiceResult<Patient> Get(int id, int id2)
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

        [Authorize(Policy = "/Patient/Get")]
        [HttpGet("{documentType}/{dataFind}/{search}")]
        public ServiceResult<IEnumerable<Patient>> Get(int documentType, string dataFind, string search)
        {
            ServiceResult<IEnumerable<Patient>> result;
            if (search == "1")
            {
                try
                {
                    result = this.appService.GetByDocument(documentType, dataFind);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<IEnumerable<Patient>>();
                    result.Errors = new[] { ex.Message };
                    result.Success = false;
                }
                return result;
            }
            result = new ServiceResult<IEnumerable<Patient>>();
            result.Errors = new[] { "Método inválido" };
            result.Success = false;
            return result;
        }
        [Authorize(Policy = "/Patient/Get")]
        [HttpGet("{dataFind}")]
        public ServiceResult<IEnumerable<Patient>> Get(string dataFind)
        {
            ServiceResult<IEnumerable<Patient>> result = null;

            try
            {
                result = this.appService.GetByNames(dataFind);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<Patient>>();
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
