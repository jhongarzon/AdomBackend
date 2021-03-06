﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Microsoft.AspNetCore.Cors;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Adom.Hhm.Web.Rest.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {
        private readonly IAssignServiceDetailAppService _appService;
        public QuestionsController(IAssignServiceDetailAppService appService)
        {
            this._appService = appService;
        }
        [Authorize(Policy = "/Questions/Get")]
        [HttpGet("{serviceId}")]
        public ServiceResult<IEnumerable<QualityQuestion>> GetQuestions(int serviceId)
        {
            ServiceResult<IEnumerable<QualityQuestion>> result;

            try
            {
                result = this._appService.GetQuestions(serviceId);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<QualityQuestion>>();
                result.Errors = new string[] { ex.Message };
                result.Success = false;
            }
            return result;
        }
        [Authorize(Policy = "/Questions/Create")]
        [HttpPost("{assignServiceDetailId}/{qualityCallUser}")]
        public ServiceResult<string> SaveAnswers(int assignServiceDetailId, int qualityCallUser, [FromBody]IEnumerable<QualityQuestion> answers)
        {
            ServiceResult<string> result;

            try
            {
                result = _appService.SaveAnswers(assignServiceDetailId, qualityCallUser, answers);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<string>();
                result.Errors = new[] { ex.Message };
                result.Success = false;
            }
            return result;
        }
    }
}
