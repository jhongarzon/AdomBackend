using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Adom.Hhm.Web.Rest.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class RipsController : Controller
    {
        private readonly IRipsDomainService _ripsDomainService;
        private readonly IHostingEnvironment _hostingEnvironment;
        public RipsController(IHostingEnvironment hostingEnvironment, IRipsDomainService ripsDomainService)
        {
            _ripsDomainService = ripsDomainService;
            _hostingEnvironment = hostingEnvironment;
        }
        [Authorize(Policy = "/Rips/Get")]
        public ServiceResult<IEnumerable<Rips>> Get([FromQuery] RipsFilter ripsFilter)
        {
            ServiceResult<IEnumerable<Rips>> result;
            try
            {
                result = _ripsDomainService.GetRipsServices(ripsFilter);
            }
            catch (Exception ex)
            {
                result = new ServiceResult<IEnumerable<Rips>>();
                result.Errors = new[] { ex.Message };
                result.Success = false;
            }

            return result;
        }
        [Authorize(Policy = "/Rips/Create")]
        [HttpPost]
        public FileResult Post([FromBody] RipsGenerationData ripsGenerationData)
        {
            var folderPath = _ripsDomainService.GenerateRips(ripsGenerationData);
            var fileName = string.Format("{0}/{1}.zip", Path.Combine(_hostingEnvironment.WebRootPath, "Temp"), "Test");
            var zipPath = Path.Combine(folderPath, fileName);
            if (System.IO.File.Exists(zipPath))
            {
                System.IO.File.Delete(zipPath);
            }

            ZipFile.CreateFromDirectory(folderPath, zipPath);


            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var bytes = System.IO.File.ReadAllBytes(zipPath);
            response.Content = new ByteArrayContent(bytes);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
            response.Content.Headers.ContentDisposition.FileName = "RipsFolder";
            return File(bytes, "application/zip", "test.zip");

            //return response;

        }
    }
}
