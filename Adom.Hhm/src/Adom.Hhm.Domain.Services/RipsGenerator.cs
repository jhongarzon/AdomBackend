using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Services.Interface;
using CsvHelper;

namespace Adom.Hhm.Domain.Services
{
    public class RipsGenerator : IRipsGenerator
    {
        private IRipsRepository _ripsRepository;
        public RipsGenerator(IRipsRepository ripsRepository)
        {
            _ripsRepository = ripsRepository;
        }
        public string GenerateAfFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips)
        {
            var consecutive = Path.GetFileName(basePath);
            var afFiles = rips.Select(rip => new RipsAfFile
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
            var filePath = string.Format(@"{0}\AF{1}.txt", basePath, consecutive);
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
            var consecutive = Path.GetFileName(basePath);
            var usFiles = rips.Select(rip => new RipsUsFile
            {

                ProviderCode = rip.ProviderCode,
                Age = rip.Age,
                AgeUnit = rip.AgeUnit,
                CityCode = rip.CityCode,
                DeparmentCode = rip.DepartmentCode,
                DocumentTypeName = rip.DocumentTypeName,
                FirstName = rip.FirstName,
                Surname = rip.Surname,
                Gender = rip.Gender,
                PatientDocument = rip.PatientDocument,
                ResidenceArea = rip.ResidenceArea,
                RipsUserType = rip.RipsUserType,
                SecondName = rip.SecondName,
                SecondSurname = rip.SecondSurname

            }).ToList();
            var filePath = string.Format(@"{0}\US{1}.txt", basePath, consecutive);
            using (var streamWriter = File.CreateText(filePath))
            {
                var writer = new CsvWriter(streamWriter);
                writer.Configuration.HasHeaderRecord = false;
                writer.WriteRecords(usFiles);
            }
            return filePath;
        }

        public string GenerateApFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips)
        {
            var consecutive = Path.GetFileName(basePath);

            var apFiles = rips.Select(rip => new RipsApFile
            {

                ProviderCode = rip.ProviderCode,
                DocumentTypeName = rip.DocumentTypeName,
                PatientDocument = rip.PatientDocument,
                InvoiceNumber = ripsFilter.InvoiceNumber,
                FinalDate = ripsFilter.FinalDate,
                AuthorizationNumber = rip.AuthorizationNumber,
                Cie10 = rip.Cie10,
                DescCie10 = string.Format("{0}", rip.Cie10),
                Cups = rip.Cups,
                Rate = rip.Rate
            }).ToList();
            var filePath = string.Format(@"{0}\AP{1}.txt", basePath, consecutive);
            using (var streamWriter = File.CreateText(filePath))
            {
                var writer = new CsvWriter(streamWriter);
                writer.Configuration.HasHeaderRecord = false;
                writer.WriteRecords(apFiles);
            }
            return filePath;
        }

        public string GenerateAcFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips)
        {
            var consecutive = Path.GetFileName(basePath);
            var apFiles = rips.Select(rip => new RipsAcFile
            {
                ProviderCode = rip.ProviderCode,
                DocumentTypeName = rip.DocumentTypeName,
                PatientDocument = rip.PatientDocument,
                InvoiceNumber = ripsFilter.InvoiceNumber,
                FinalDate = ripsFilter.FinalDate,
                AuthorizationNumber = rip.AuthorizationNumber,
                Cie10 = rip.Cie10,
                Cups = rip.Cups,
                Rate = rip.Rate,
                Consultation = rip.Consultation,
                DiagnosticType = "2",
                External = rip.External
            }).ToList();
            var filePath = string.Format(@"{0}\AC{1}.txt", basePath, consecutive);
            using (var streamWriter = File.CreateText(filePath))
            {
                var writer = new CsvWriter(streamWriter);
                writer.Configuration.HasHeaderRecord = false;
                writer.WriteRecords(apFiles);
            }
            return filePath;
        }

        public string GenerateAtFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips)
        {
            var consecutive = Path.GetFileName(basePath);
            var atFiles = new List<RipsAtFile>();

            foreach (var rip in rips)
            {
                var supplies = _ripsRepository.GetServiceSupplies(rip.AssignServiceId);
                atFiles.AddRange(supplies.Select(sup => new RipsAtFile
                {
                    InvoiceNumber = ripsFilter.InvoiceNumber,
                    PatientDocument = rip.PatientDocument,
                    ProviderCode = rip.ProviderCode,
                    AuthorizationNumber = rip.AuthorizationNumber,
                    DocumentTypeName = rip.DocumentTypeAbbreviation,
                    ServiceType = "1",
                    SupplyCode = sup.SupplyCode,
                    SupplyQuantity = sup.Quantity,
                    SupplyName = sup.SupplyName,
                    SupplyTotalValue = (0 * sup.Quantity)
                }));
            }
            var filePath = string.Format(@"{0}\AT{1}.txt", basePath, consecutive);
            using (var streamWriter = File.CreateText(filePath))
            {
                var writer = new CsvWriter(streamWriter);
                writer.Configuration.HasHeaderRecord = false;
                writer.WriteRecords(atFiles);
            }
            return filePath;
        }

        public string GenerateCtFile(string basePath, IEnumerable<Rips> rips)
        {
            throw new System.NotImplementedException();
        }
    }
}
