using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Services.Interface;
using CsvHelper;

namespace Adom.Hhm.Domain.Services
{
    public class RipsGenerator:IRipsGenerator
    {
        public string GenerateAfFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips)
        {
            var consecutive = Path.GetFileName(basePath);
            var afFiles = rips.Select(rip => new AfFile
            {
                ProviderCode = rip.ProviderCode,
                BusinessName = rip.BusinessName,
                InitialDate = rip.InitialDate,
                FinalDate = rip.FinalDate,
                AdomIdentiticationNumber = rip.AdomIdentificationNumber,
                AdomIdentiticationTypeId = rip.AdomIdentificationNumber,
                Comission = "",
                InvoiceDate = ripsFilter.InvoiceDate,
                InvoiceNumber = ripsFilter.InvoiceNumber,
                NetValue = ripsFilter.NetValue,
                OtherValuesReceived = rip.OtherValuesReceived,
                TotalCopaymentReceived = rip.TotalCopaymentReceived
            }).ToList();
            var filePath = string.Format(@"{0}\AF{1}.txt",basePath, consecutive);
            using (var streamWriter = File.CreateText(filePath))
            {
                var writer = new CsvWriter(streamWriter);
                writer.Configuration.HasHeaderRecord = false;
                writer.WriteRecords(afFiles);
            }
            return filePath;
        }

        public string GenerateUsFile(string basePath, IEnumerable<Rips> rips)
        {
            throw new System.NotImplementedException();
        }

        public string GenerateApFile(string basePath, IEnumerable<Rips> rips)
        {
            throw new System.NotImplementedException();
        }

        public string GenerateAcFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips)
        {
            throw new System.NotImplementedException();
        }

        public string GenerateAtFile(string basePath, IEnumerable<Rips> rips)
        {
            throw new System.NotImplementedException();
        }

        public string GenerateCtFile(string basePath, IEnumerable<Rips> rips)
        {
            throw new System.NotImplementedException();
        }
    }
}
