using System.Collections.Generic;
using Adom.Hhm.Domain.Entities.Security;
using Microsoft.Extensions.Configuration;
using Adom.Hhm.Domain.Services.Interface;
using Adom.Hhm.Domain.Repositories;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Security.Repositories;
using Adom.Hhm.Utility;

namespace Adom.Hhm.Domain.Services
{
    public class ParameterDomainServices : IParameterDomainService
    {
        private readonly IParameterRepository repository;
        private readonly IConfigurationRoot configuration;

        public ParameterDomainServices(IConfigurationRoot configuration, IParameterRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        public ServiceResult<IEnumerable<Parameter>> GetDataParametricTable(string parametricTable)
        {
            IEnumerable<Parameter> getParameter = null;

            switch (parametricTable)
            {
                case "accountType":
                    getParameter = this.repository.GetAccountType();
                    break;
                case "documentType":
                    getParameter = this.repository.GetDocumentType();
                    break;
                case "gender":
                    getParameter = this.repository.GetGender();
                    break;
                case "specialties":
                    getParameter = this.repository.GetSpecialties();
                    break;
                case "zones":
                    getParameter = this.repository.GetZones();
                    break;
                case "classification":
                    getParameter = this.repository.GetClassification();
                    break;
                case "serviceType":
                    getParameter = this.repository.GetServiceType();
                    break;
                case "unitTime":
                    getParameter = this.repository.GetUnitTime();
                    break;
                case "stateAssignService":
                    getParameter = this.repository.GetStateAssignService();
                    break;
                case "billedTo":
                    getParameter = this.repository.GetBilledTo();
                    break;
                case "patientType":
                    getParameter = this.repository.GetPatientType();
                    break;
            }

            return new ServiceResult<IEnumerable<Parameter>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getParameter
            };
        }
    }
}
