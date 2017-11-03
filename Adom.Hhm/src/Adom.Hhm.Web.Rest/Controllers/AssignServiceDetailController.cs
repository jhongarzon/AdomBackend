using System;
using System.Collections.Generic;
using System.Globalization;
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
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.Domain.Services;

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
        private readonly IMailService _mailService;
        private readonly IAssignServiceDomainService _assignServiceDomainService;
        private readonly IProfessionalDomainService _professionalDomainService;
        private readonly IPatientDomainService _patientDomainService;
        private readonly IServiceDomainService _serviceDomainService;


        public AssignServiceDetailController(IAssignServiceDetailAppService appService, AssignServiceDetailValidator validator,
            IConfigurationRoot configuration, IMailService mailService, IAssignServiceDomainService assignServiceDomainService,
            IProfessionalDomainService professionalDomainService, IPatientDomainService patientDomainService, 
            IServiceDomainService serviceDomainService)
        {
            _appService = appService;
            _validator = validator;
            _configuration = configuration;
            _mailService = mailService;
            _assignServiceDomainService = assignServiceDomainService;
            _professionalDomainService = professionalDomainService;
            _patientDomainService = patientDomainService;
            _serviceDomainService = serviceDomainService;

        }

        [Authorize(Policy = "/AssignService/Get")]
        [HttpGet]
        public ServiceResult<IEnumerable<AssignServiceDetail>> Get()
        {
            ServiceResult<IEnumerable<AssignServiceDetail>> result = null;

            try
            {
                result = _appService.GetAssignServiceDetails();
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
                result = _appService.GetAssignServiceDetailByAssignServiceId(assignServiceId);
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
            ServiceResult<AssignServiceDetail> result = new ServiceResult<AssignServiceDetail>();
            var errorList = new List<string>();
            var isReassignment = false;
            var reasigmentDetailCount = 0;
            AssignServiceDetail currentDetail = null;
            foreach (var model in models)
            {
                if (string.IsNullOrEmpty(model.DateVisit))
                {
                    if (model.Verified)
                    {
                        errorList.Add("Para verificar el registro es necesario ingresar la fecha de visita");
                        result.Success = false;
                        break;

                    }
                    continue;
                }


                DateTime date;
                DateTime.TryParseExact(model.DateVisit, "dd-MM-yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out date);
                if (date > DateTime.Today && model.StateId == 2)
                {
                    errorList.Add("En la visita #" + model.Consecutive + " la fecha de visita es mayor a hoy");
                    result.Success = false;
                    break;
                }
                var validatorResult = _validator.Validate(model);

                if (validatorResult.IsValid)
                {
                    try
                    {
                        var currentDetailResult = _appService.GetAssignServiceDetailById(model.AssignServiceDetailId);
                        currentDetail = currentDetailResult.Result;
                        result = _appService.Update(model);
                        if (currentDetail.ProfessionalId != model.ProfessionalId)
                        {
                            reasigmentDetailCount++;
                            isReassignment = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        result = new ServiceResult<AssignServiceDetail>();
                        errorList.Add(ex.Message);
                        result.Success = false;
                    }
                }
                else
                {
                    result = new ServiceResult<AssignServiceDetail>();
                    errorList = validatorResult.GetErrors().ToList();
                    result.Success = false;
                }
            }
            if (isReassignment && currentDetail!= null)
            {
                ReassignProfessionalMail(currentDetail, reasigmentDetailCount);
            }
            result.Errors = errorList.ToArray();
            return result;
        }

        private void ReassignProfessionalMail(AssignServiceDetail assignServiceDetail, int detailCount)
        {
            var result = _assignServiceDomainService.GetAssignServiceById(assignServiceDetail.AssignServiceId);
            var assingService = result.Result;
            if (assingService == null) return;

            var patientResult = _patientDomainService.GetPatientById(assingService.PatientId);
            var serviceResult = _serviceDomainService.GetServiceById(assingService.ServiceId);
            var service = serviceResult.Result;
            var patient = patientResult.Result;
            var professionalResult = _professionalDomainService.GetProfessionalById(assignServiceDetail.ProfessionalId);
            var professional = professionalResult.Result;
            var professionalFullName = $"{professional.FirstName} {professional.SecondName} {professional.Surname} {professional.SecondSurname}";
            var patientFullName = $"{patient.FirstName} {patient.SecondName} {patient.Surname} {patient.SecondSurname}";
            var mailMessage = new MailMessage
            {
                Body = string.Format(AdomMailContent.ProfessionalReasigmentMail,
                    professionalFullName,
                    patient.Document,
                    patientFullName,
                    service.Name,
                    detailCount),

                Subject = "Cambios en tus servicios - ADOM",
                To = new MailAccount(professional.FirstName, professional.Email)
            };
            _mailService.SendMail(mailMessage);
        }
    }
}
