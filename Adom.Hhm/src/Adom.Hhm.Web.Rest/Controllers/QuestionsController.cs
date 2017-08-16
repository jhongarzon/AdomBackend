using System;
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
        private readonly IMailService _mailService;
        public QuestionsController(IAssignServiceDetailAppService appService, IMailService mailService)
        {
            this._appService = appService;
            _mailService = mailService;
        }
        [Authorize(Policy = "/Questions/Get")]
        [HttpGet("{serviceId}")]
        public ServiceResult<IEnumerable<QualityQuestion>> GetQuestions(int serviceId)
        {
            ServiceResult<IEnumerable<QualityQuestion>> result;

            try
            {
                var mailMessage = new MailMessage();
                mailMessage.To = new MailAccount("Jhon", "johngarzon86@gmail.com");
                mailMessage.Body = "Prueba Body ADOM";
                mailMessage.Subject = "Mensaje prueba ADOM";
                _mailService.SendMail(mailMessage);
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
        [HttpPost("{assignServiceDetailId}")]
        public ServiceResult<string> SaveAnswers(int assignServiceDetailId, [FromBody]IEnumerable<QualityQuestion> answers)
        {
            ServiceResult<string> result;

            try
            {
                result = _appService.SaveAnswers(assignServiceDetailId, answers);
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
