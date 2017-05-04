using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Adom.Hhm.AppServices.Interfaces;
using Microsoft.Extensions.Logging;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Web.Rest.Validators;
using Adom.Hhm.Web.Rest.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;
using System.IdentityModel.Tokens.Jwt;
using Adom.Hhm.Utility;
using Adom.Hhm.Domain.Entities.Security;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Adom.Hhm.Web.Rest.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class NoticesController : Controller
    {
        private readonly ILogger logger;
        private readonly INoticeAppService appService;
        private readonly NoticeValidator validator;
        private readonly IConfigurationRoot configuration;

        public NoticesController(ILoggerFactory loggerFactory, INoticeAppService appService, NoticeValidator validator, IConfigurationRoot configuration)
        {
            this.logger = loggerFactory.CreateLogger<NoticesController>();
            this.appService = appService;
            this.validator = validator;
            this.configuration = configuration;
        }

        [Authorize(Policy = "/Notices/Get")]
        //[AllowAnonymous]
        [HttpGet]
        public ServiceResult<IEnumerable<Notice>> Get()
        {
            ServiceResult<IEnumerable<Notice>> result = null;

            try
            {
                result = this.appService.GetNotices();

            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<Notice>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Notices/Create")]
        [HttpPost]
        public ServiceResult<Notice> Post([FromBody]Notice model)
        {
            ServiceResult<Notice> result = null;
            var validatorResult = validator.Validate(model);

            if (validatorResult.IsValid)
            {
                try
                {
                    result = this.appService.Insert(model);
                }
                catch (Exception ex)
                {
                    result = new ServiceResult<Notice>();
                    result.Errors = new string[] { ex.Message };
                    result.Success = false;
                }
            }
            else
            {
                result = new ServiceResult<Notice>();
                result.Errors = validatorResult.GetErrors();
                result.Success = false;
            }

            return result;
        }

        [Authorize(Policy = "/Notices/Delete")]
        [HttpPut("{id}")]
        public ServiceResult<Notice> Put(long id)
        {
            ServiceResult<Notice> result = null;


            try
            {
                this.appService.Delete(id);
                result = new ServiceResult<Notice>();
                result.Errors = new string[] { "ok" };
                result.Success = true;
            }
            catch (Exception ex)
            {
                result = new ServiceResult<Notice>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }

            return result;
        }


    }
}
