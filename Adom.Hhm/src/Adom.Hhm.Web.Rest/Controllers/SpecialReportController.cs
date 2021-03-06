﻿using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.Domain.Entities.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Adom.Hhm.Web.Rest.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class SpecialReportController : Controller
    {
        private readonly IExcelReportService _excelReportService;
        private readonly ISpecialReportService _specialReportService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public SpecialReportController(IHostingEnvironment hostingEnvironment, IExcelReportService excelReportService, ISpecialReportService specialReportService)
        {
            _excelReportService = excelReportService;
            _specialReportService = specialReportService;
            _hostingEnvironment = hostingEnvironment;
        }
        [Authorize(Policy = "/SpecialReport/Get")]
        public string Get()
        {
            return "Funciona";
        }

        //[HttpPost]
        //[Authorize(Policy = "/SpecialReport/Create")]
        //public FileResult PostFromBody([FromBody] SpecialReportFilter specialReportFilter)
        //{
        //    return GenerateSpecialReport(specialReportFilter);
        //}
        [HttpPost]
        [Authorize(Policy = "/SpecialReport/Create")]
        public FileContentResult Post([FromBody] SpecialReportFilter specialReportFilter)
        {
            //return Json(specialReportFilter);
            return GenerateSpecialReport(specialReportFilter);
        }

        private FileContentResult GenerateSpecialReport(SpecialReportFilter specialReportFilter)
        {
            dynamic data;
            if (specialReportFilter.ReportType == 1)
            {
                data = _specialReportService.GetSpecialSummaryReport(specialReportFilter);
            }
            else
            {
                data = _specialReportService.GetSpecialDetailedReport(specialReportFilter);
            }
            var rootPath = Path.Combine(_hostingEnvironment.WebRootPath, "Temp");
            var excelFile = _excelReportService.GenerateExcelReport(rootPath, data.Result);
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
