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
    public class PatientDomainServices : IPatientDomainService
    {
        private readonly IPatientRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IConfigurationRoot configuration;

        public PatientDomainServices(IConfigurationRoot configuration, IPatientRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        public ServiceResult<Patient> GetPatientById(int PatientId)
        {
            var getPatient = this.repository.GetPatientById(PatientId);

            return new ServiceResult<Patient>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getPatient
            };
        }

        public ServiceResult<IEnumerable<Patient>> GetPatients(int pageNumber, int pageSize)
        {
            var getPatients = this.repository.GetPatients(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<Patient>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getPatients
            };
        }

        public ServiceResult<IEnumerable<Patient>> GetByNamesOrDocument(string dataFind)
        {
            var getPatients = this.repository.GetByNamesOrDocument(dataFind);

            return new ServiceResult<IEnumerable<Patient>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getPatients
            };
        }

        public ServiceResult<IEnumerable<Patient>> GetPatients()
        {
            var getPatients = this.repository.GetPatients();
            return new ServiceResult<IEnumerable<Patient>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getPatients
            };
        }

        public ServiceResult<Patient> Insert(Patient patient)
        {
            Patient emailExist = this.repository.GetPatientByEmail(patient.Email);
            Patient documentExist = this.repository.GetPatientByDocument(patient.Document);

            if (documentExist == null)
            {
                if (emailExist == null)
                {
                    var PatientInserted = this.repository.Insert(patient);
                    return new ServiceResult<Patient>
                    {
                        Success = true,
                        Result = PatientInserted
                    };
                }
                else
                {
                    return new ServiceResult<Patient>
                    {
                        Success = false,
                        Errors = new string[] { MessageError.EmailExists }
                    };
                }
            }
            else
            {
                return new ServiceResult<Patient>
                {
                    Success = false,
                    Errors = new string[] { MessageError.DocumentExists }
                };
            }
        }

        public ServiceResult<Patient> Update(Patient patient)
        {
            Patient emailExist = this.repository.GetPatientByEmailWithoutId(patient.PatientId, patient.Email);
            Patient documentExist = this.repository.GetPatientByDocumentWithoutId(patient.PatientId, patient.Document);

            if (documentExist == null)
            {
                if (emailExist == null)
                {
                    var updated = this.repository.Update(patient);
                    return new ServiceResult<Patient>
                    {
                        Success = true,
                        Result = updated
                    };
                }

                else
                {
                    return new ServiceResult<Patient>
                    {
                        Success = false,
                        Errors = new string[] { MessageError.EmailExists }
                    };
                }
            }
            else
            {
                return new ServiceResult<Patient>
                {
                    Success = false,
                    Errors = new string[] { MessageError.DocumentExists }
                };
            }
        }
    }
}
