using System.Collections.Generic;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IRipsGenerator
    {

        int GenerateAfFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips);
        int GenerateUsFile(string basePath, IEnumerable<Rips> rips);
        int GenerateApFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips);
        int GenerateAcFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips);
        int GenerateAtFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips);
        int GenerateCtFile(string basePath, long providerCode, int afCount, int usCount, int apCount, int acCount, int atCount);


    }
}
