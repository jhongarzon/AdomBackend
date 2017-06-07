using System.Collections.Generic;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IRipsRepository
    {
        IEnumerable<Rips> GetServiceRips(RipsFilter ripsFilter);
        IEnumerable<AssignServiceSupply> GetServiceSupplies(int assignServiceId);
        int InsertRipsControl(string invoiceNumber);
        void UpdateServiceInvoice(int assignServiceId, string invoiceNumber);
    }
}
