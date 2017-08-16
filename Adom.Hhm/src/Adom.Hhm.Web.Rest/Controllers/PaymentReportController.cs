﻿using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.Domain.Entities.Reports;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Adom.Hhm.Web.Rest.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class PaymentReportController : Controller
    {
        private readonly IExcelReportService _excelReportService;
        private readonly IPaymentReportService _paymentReportService;
        public PaymentReportController(IExcelReportService excelReportService, IPaymentReportService paymentReportService)
        {
            _excelReportService = excelReportService;
            _paymentReportService = paymentReportService;
        }
        [Authorize(Policy = "/PaymentReport/Create")]
        [HttpPost]
        public IActionResult Post([FromBody] PaymentReportFilter paymentReportFilter)
        {
            var data = _paymentReportService.GetPaymentReport();
            var excelFile = _excelReportService.GenerateExcelReport(data.Result);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var bytes = System.IO.File.ReadAllBytes(excelFile);
            var fileName = Path.GetFileNameWithoutExtension(excelFile);

            response.Content = new ByteArrayContent(bytes);

            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            response.Content.Headers.ContentDisposition.FileName = fileName + ".xlsx";

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName + ".xlsx");
        }

    }
}
