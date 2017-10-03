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
    public class AssignServiceDetailDomainServices : IAssignServiceDetailDomainService
    {
        private readonly IAssignServiceDetailRepository repository;
        private readonly IConfigurationRoot configuration;

        public AssignServiceDetailDomainServices(IConfigurationRoot configuration, IAssignServiceDetailRepository repository)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        public ServiceResult<AssignServiceDetail> GetAssignServiceDetailById(int assignServiceDetailId)
        {
            var getAssignServiceDetail = repository.GetAssignServiceDetailById(assignServiceDetailId);

            return new ServiceResult<AssignServiceDetail>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignServiceDetail
            };
        }

        public ServiceResult<IEnumerable<AssignServiceDetail>> GetAssignServiceDetailByAssignServiceId(int assignServiceId)
        {
            var getAssignServiceDetail = repository.GetAssignServiceDetailByAssignServiceId(assignServiceId);

            return new ServiceResult<IEnumerable<AssignServiceDetail>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignServiceDetail
            };
        }

        public ServiceResult<IEnumerable<AssignServiceDetail>> GetAssignServiceDetails(int pageNumber, int pageSize)
        {
            var getAssignServiceDetails = repository.GetAssignServiceDetails(pageNumber, pageSize);
            return new ServiceResult<IEnumerable<AssignServiceDetail>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignServiceDetails
            };
        }

        public ServiceResult<IEnumerable<AssignServiceDetail>> GetAssignServiceDetails()
        {
            var getAssignServiceDetails = repository.GetAssignServiceDetails();
            return new ServiceResult<IEnumerable<AssignServiceDetail>>
            {
                Success = true,
                Errors = new string[] { string.Empty },
                Result = getAssignServiceDetails
            };
        }

        public ServiceResult<AssignServiceDetail> Update(AssignServiceDetail assignServiceDetail)
        {
            var updated = repository.Update(assignServiceDetail);
            return new ServiceResult<AssignServiceDetail>
            {
                Success = true,
                Result = updated
            };
        }

        public ServiceResult<IEnumerable<QualityQuestion>> GetQuestions(int serviceId)
        {
            var updated = repository.GetQuestions(serviceId);
            return new ServiceResult<IEnumerable<QualityQuestion>>
            {
                Success = true,
                Result = updated
            };
        }

        public ServiceResult<string> SaveAnswers(int assignServiceDetailId, int qualityQuestionUser, IEnumerable<QualityQuestion> answers)
        {
            var updated = repository.SaveAnswers(assignServiceDetailId, qualityQuestionUser, answers);
            return new ServiceResult<string>
            {
                Success = true,
                Result = updated
            };
        }
    }
}
