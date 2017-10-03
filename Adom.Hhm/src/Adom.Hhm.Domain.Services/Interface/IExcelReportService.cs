using System.Collections.Generic;
using System.IO;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IExcelReportService
    {
        string GenerateExcelReport<T>(string rootPath, IEnumerable<T> data);
    }
}
