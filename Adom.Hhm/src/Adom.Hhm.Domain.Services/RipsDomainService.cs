using System.Collections.Generic;
using System.IO;
using System.Linq;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Services.Interface;

namespace Adom.Hhm.Domain.Services
{
    public class RipsDomainService : IRipsDomainService
    {
        private readonly IRipsRepository _ripsRepository;
        private readonly IRipsGenerator _ripsGenerator;

        public RipsDomainService(IRipsRepository ripsRepository, IRipsGenerator ripsGenerator)
        {
            _ripsRepository = ripsRepository;
            _ripsGenerator = ripsGenerator;
        }

        public ServiceResult<IEnumerable<Rips>> GetRipsServices(RipsFilter ripsFilter)
        {

            var result = _ripsRepository.GetServiceRips(ripsFilter);
            return new ServiceResult<IEnumerable<Rips>>
            {
                Result = result,
                Errors = new[] { string.Empty },
                Success = true


            };
        }

        public string GenerateRips(string rootPath, RipsGenerationData ripsGenerationData)
        {
            
            var consecutive = _ripsRepository.InsertRipsControl(ripsGenerationData.RipsFilter.InvoiceNumber);
            rootPath = string.Format(@"{0}\{1}", rootPath, consecutive);
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
            var firstRip = ripsGenerationData.Rips.FirstOrDefault();
            if (firstRip == null) return rootPath;
            var groups = ripsGenerationData.Rips.GroupBy(x => x.PatientDocument).Select(group => @group.First());
            var afCount = _ripsGenerator.GenerateAfFile(rootPath, ripsGenerationData.RipsFilter, ripsGenerationData.Rips);
            var usCount = _ripsGenerator.GenerateUsFile(rootPath, groups);
            var apCount = _ripsGenerator.GenerateApFile(rootPath, ripsGenerationData.RipsFilter, ripsGenerationData.Rips);
            var acCount = _ripsGenerator.GenerateAcFile(rootPath, ripsGenerationData.RipsFilter, ripsGenerationData.Rips);
            var atCount = _ripsGenerator.GenerateAtFile(rootPath, ripsGenerationData.RipsFilter, ripsGenerationData.Rips);
            var ctCount = _ripsGenerator.GenerateCtFile(rootPath, firstRip.ProviderCode, afCount, usCount, apCount,
                acCount, atCount);
            UpdateServiceInvoices(ripsGenerationData.Rips, ripsGenerationData.RipsFilter.InvoiceNumber);

            return rootPath;
        }

        public void UpdateServiceInvoices(IEnumerable<Rips> rips, string invoiceNumber)
        {
            foreach (var rip in rips)
            {
                _ripsRepository.UpdateServiceInvoice(rip.AssignServiceId, invoiceNumber);
            }
        }
    }
}
