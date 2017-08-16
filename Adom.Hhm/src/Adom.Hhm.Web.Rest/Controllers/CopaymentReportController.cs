using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
    public class CopaymentReportController : Controller
    {
        private readonly IExcelReportService _excelReportService;
        private readonly ICopaymentReportService _copaymentReportService;
        public CopaymentReportController(IExcelReportService excelReportService, ICopaymentReportService copaymentReportService)
        {
            _excelReportService = excelReportService;
            _copaymentReportService = copaymentReportService;
        }
        [Authorize(Policy = "/SpecialReport/Create")]
        [HttpPost]
        public FileResult Post([FromBody] CopaymentReportFilter copaymentReportFilter)
        {
            var data = _copaymentReportService.GetCopaymentReport();
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
