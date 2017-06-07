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

        public string GenerateRips(RipsGenerationData ripsGenerationData)
        {
            var basePath = @"D:\Jhon\Projects\Adom\Hhm\Backend\Adom.Hhm";
            var consecutive = _ripsRepository.InsertRipsControl(ripsGenerationData.RipsFilter.InvoiceNumber);
            basePath = string.Format(@"{0}\{1}", basePath, consecutive);
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            _ripsGenerator.GenerateAfFile(basePath, ripsGenerationData.RipsFilter, ripsGenerationData.Rips);
            var groups = ripsGenerationData.Rips.GroupBy(x => x.PatientDocument).Select(group => group.First());
            _ripsGenerator.GenerateUsFile(basePath, groups);
            _ripsGenerator.GenerateApFile(basePath, ripsGenerationData.RipsFilter, ripsGenerationData.Rips);
            _ripsGenerator.GenerateAcFile(basePath, ripsGenerationData.RipsFilter, ripsGenerationData.Rips);
            _ripsGenerator.GenerateAtFile(basePath, ripsGenerationData.RipsFilter, ripsGenerationData.Rips);
            UpdateServiceInvoices(ripsGenerationData.Rips, ripsGenerationData.RipsFilter.InvoiceNumber);
            return basePath;
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
