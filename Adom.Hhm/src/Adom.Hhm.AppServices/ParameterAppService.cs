using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.AppServices.Interfaces;
using Adom.Hhm.Domain.Entities;

namespace Adom.Hhm.AppServices
{
    public class ParameterAppService : IParameterAppService
    {
        private readonly IParameterDomainService service;

        public ParameterAppService(IParameterDomainService service)
        {
            this.service = service;
        }

        public ServiceResult<IEnumerable<Parameter>> GetDataParametricTable(string parametricTable)
        {
            return this.service.GetDataParametricTable(parametricTable);
        }
    }
}
