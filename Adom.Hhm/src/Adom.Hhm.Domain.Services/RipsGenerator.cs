﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Services.Interface;
using CsvHelper;

namespace Adom.Hhm.Domain.Services
{
    public class RipsGenerator : IRipsGenerator
    {
        private readonly IRipsRepository _ripsRepository;
        public RipsGenerator(IRipsRepository ripsRepository)
        {
            _ripsRepository = ripsRepository;
        }
        public int GenerateAfFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips)
        {
            var consecutive = Path.GetFileName(basePath);
            var afFiles = rips.Select(rip => new RipsAfFile
            {
                ProviderCode = rip.ProviderCode,
                BusinessName = rip.BusinessName,
                InitialDate = rip.InitialDate.Replace("-", "/"),
                FinalDate = rip.FinalDate.Replace("-", "/"),
                AdomIdentiticationNumber = rip.AdomIdentificationNumber,
                AdomIdentiticationTypeId = rip.AdomIdentificationType,
                Comission = "",
                EntityCode = rip.EntityCode,
                EntityName = rip.EntityName,
                InvoiceDate = ripsFilter.InvoiceDate.Replace("-", "/"),
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
            return afFiles.Count;
        }

        public int GenerateUsFile(string basePath, IEnumerable<Rips> rips)
        {
            var consecutive = Path.GetFileName(basePath);
            var usFiles = rips.Select(rip => new RipsUsFile
            {

                ProviderCode = rip.ProviderCode,
                Age = rip.Age,
                AgeUnit = rip.AgeUnit,
                CityCode = rip.CityCode,
                DeparmentCode = rip.DepartmentCode,
                DocumentTypeName = rip.DocumentTypeAbbreviation,
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
            return usFiles.Count;
        }

        public int GenerateApFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips)
        {
            var consecutive = Path.GetFileName(basePath);
            var apFiles = (
                from rip in rips
                where rip.ClassificationId == 2
                select new RipsApFile
                {
                    ProviderCode = rip.ProviderCode,
                    DocumentTypeName = rip.DocumentTypeAbbreviation,
                    PatientDocument = rip.PatientDocument,
                    InvoiceNumber = ripsFilter.InvoiceNumber,
                    FinalDate = ripsFilter.FinalDate.Replace("-", "/"),
                    AuthorizationNumber = rip.AuthorizationNumber,
                    Cie10 = rip.Cie10,
                    Cups = rip.Cups,
                    Rate = rip.Rate,

                }).ToList();

            var filePath = string.Format(@"{0}\AP{1}.txt", basePath, consecutive);
            using (var streamWriter = File.CreateText(filePath))
            {
                var writer = new CsvWriter(streamWriter);
                writer.Configuration.HasHeaderRecord = false;
                writer.WriteRecords(apFiles);
            }
            return apFiles.Count;
        }

        public int GenerateAcFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips)
        {
            var consecutive = Path.GetFileName(basePath);
            var acFiles = new List<RipsAcFile>();
            foreach (var rip in rips)
            {
                var details = _ripsRepository.GetServiceDetail(rip.AssignServiceId);
                acFiles.AddRange(details.Select(item => new RipsAcFile
                {
                    ProviderCode = rip.ProviderCode,
                    DocumentTypeName = rip.DocumentTypeAbbreviation,
                    PatientDocument = rip.PatientDocument,
                    InvoiceNumber = ripsFilter.InvoiceNumber,
                    FinalDate = ripsFilter.FinalDate.Replace("-", "/"),
                    AuthorizationNumber = rip.AuthorizationNumber,
                    Cie10 = rip.Cie10,
                    Cups = rip.Cups,
                    Rate = rip.Rate,
                    Consultation = rip.Consultation,
                    DiagnosticType = "2",
                    External = rip.External,
                    CopaymentPerSession = rip.CoPaymentAmount,
                    NetValuePerSession = rip.Rate - rip.CoPaymentAmount
                }));

            }
            var filePath = string.Format(@"{0}\AC{1}.txt", basePath, consecutive);
            using (var streamWriter = File.CreateText(filePath))
            {
                var writer = new CsvWriter(streamWriter);
                writer.Configuration.HasHeaderRecord = false;
                writer.WriteRecords(acFiles);
            }
            return acFiles.Count;
        }

        public int GenerateAtFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips)
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
            return atFiles.Count;
        }

        public int GenerateCtFile(string basePath, long providerCode, int afCount, int usCount, int apCount, int acCount, int atCount)
        {
            var consecutive = Path.GetFileName(basePath);
            var currentDate = new DateTime();
            var formattedDate = currentDate.ToString("dd/MM/yyyy");
            var ctFiles = new List<CtFile>
            {
                new CtFile { ProviderCode = providerCode, FileName = string.Format("AF{0}", consecutive),FileRecordCount = afCount, RipsDate = formattedDate},
                new CtFile { ProviderCode = providerCode, FileName = string.Format("US{0}", consecutive),FileRecordCount = usCount, RipsDate = formattedDate},
                new CtFile { ProviderCode = providerCode, FileName = string.Format("AP{0}", consecutive),FileRecordCount = apCount, RipsDate = formattedDate},
                new CtFile { ProviderCode = providerCode, FileName = string.Format("AC{0}", consecutive),FileRecordCount = acCount, RipsDate = formattedDate},
                new CtFile { ProviderCode = providerCode, FileName = string.Format("AT{0}", consecutive),FileRecordCount = atCount, RipsDate = formattedDate},
            };
            var filePath = string.Format(@"{0}\CT{1}.txt", basePath, consecutive);
            using (var streamWriter = File.CreateText(filePath))
            {
                var writer = new CsvWriter(streamWriter);
                writer.Configuration.HasHeaderRecord = false;
                writer.WriteRecords(ctFiles);
            }
            return ctFiles.Count;
        }
    }
}
