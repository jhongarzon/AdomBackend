using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Entities.Security;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IRipsDomainService
    {
        ServiceResult<IEnumerable<Rips>> GetRipsServices(RipsFilter ripsFilter);
        string GenerateRips(string rootPath, RipsGenerationData ripsGenerationData);
        void UpdateServiceInvoices(IEnumerable<Rips> rips, string invoiceNumber);
    }
}
