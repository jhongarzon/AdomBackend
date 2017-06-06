using System.Collections.Generic;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.Domain.Services.Interface
{
    public interface IRipsGenerator
    {

        string GenerateAfFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips);
        string GenerateUsFile(string basePath, IEnumerable<Rips> rips);
        string GenerateApFile(string basePath, IEnumerable<Rips> rips);
        string GenerateAcFile(string basePath, RipsFilter ripsFilter, IEnumerable<Rips> rips);
        string GenerateAtFile(string basePath, IEnumerable<Rips> rips);
        string GenerateCtFile(string basePath, IEnumerable<Rips> rips);


    }
}
