using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.Domain.Entities.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Adom.Hhm.Web.Rest.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class SpecialReportController : Controller
    {
        private readonly IExcelReportService _excelReportService;
        private readonly ISpecialReportService _specialReportService;
        public SpecialReportController(IExcelReportService excelReportService, ISpecialReportService specialReportService)
        {
            _excelReportService = excelReportService;
            _specialReportService = specialReportService;
        }
        [Authorize(Policy = "/SpecialReport/Create")]
        [HttpPost]
        public FileResult Post([FromBody] SpecialReportFilter specialReportFilter)
        {
            dynamic data;
            if (specialReportFilter.ReportType == 1)
            {
                data = _specialReportService.GetSpecialSummaryReport();
            }
            else
            {
                data = _specialReportService.GetSpecialDetailedReport();
            }
            
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
