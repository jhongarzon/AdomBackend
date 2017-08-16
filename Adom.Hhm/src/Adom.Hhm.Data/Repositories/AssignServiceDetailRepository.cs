using Adom.Hhm.Data.Repositories;
using Adom.Hhm.Domain.Secutiry.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adom.Hhm.Domain.Entities.Security;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Data;
using Adom.Hhm.Data.Querys;
using Dapper;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Repositories;

namespace Adom.Hhm.Data.Repositories
{
    public class AssignServiceDetailRepository : IAssignServiceDetailRepository
    {
        private readonly IDbConnection connection;

        public AssignServiceDetailRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<AssignServiceDetail> GetAssignServiceDetailByAssignServiceId(int assignServiceId)
        {
            return connection.Query<AssignServiceDetail>(AssignServiceDetailQuerys.GetByAssignServiceId, new { AssignServiceId = assignServiceId });
        }

        public AssignServiceDetail GetAssignServiceDetailById(int assignServiceDetailId)
        {
            return connection.Query<AssignServiceDetail>(AssignServiceDetailQuerys.GetById, new { AssignServiceDetailId = assignServiceDetailId }).FirstOrDefault();
        }

        public IEnumerable<AssignServiceDetail> GetAssignServiceDetails(int pageNumber, int pageSize)
        {
            return connection.Query<AssignServiceDetail>(AssignServiceDetailQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public IEnumerable<AssignServiceDetail> GetAssignServiceDetails()
        {
            return connection.Query<AssignServiceDetail>(AssignServiceDetailQuerys.GetAllWithoutPagination);
        }

        public AssignServiceDetail Update(AssignServiceDetail assignServiceDetail)
        {
            var id = connection.Query<int>(AssignServiceDetailQuerys.Update,
                new
                {
                    assignServiceDetail.AssignServiceId,
                    assignServiceDetail.AssignServiceDetailId,
                    StateAssignServiceDetailId = assignServiceDetail.StateId,
                    assignServiceDetail.ProfessionalId,
                    assignServiceDetail.DateVisit,
                    assignServiceDetail.Observation,
                    assignServiceDetail.PaymentType,
                    assignServiceDetail.ReceivedAmount,
                    assignServiceDetail.OtherAmount,
                    assignServiceDetail.Pin,
                    assignServiceDetail.Verified,
                    assignServiceDetail.VerifiedBy
                }, commandType: CommandType.StoredProcedure).Single();
            assignServiceDetail.AssignServiceDetailId = id;
            return assignServiceDetail;
        }

        public IEnumerable<QualityQuestion> GetQuestions(int serviceId)
        {
            return connection.Query<QualityQuestion>(AssignServiceDetailQuerys.GetQuestions, new { @ServiceId = serviceId });
        }

        public string SaveAnswers(int assignServiceDetailId, IEnumerable<QualityQuestion> answers)
        {
            var result = "";
            foreach (var answer in answers)
            {
                var count = connection.Execute(AssignServiceDetailQuerys.SaveQuestion, new { answer.AnswerId, @AssignServiceDetailId = assignServiceDetailId });
                if (count != 0) continue;
                result = "No se guardó la respuesta";
                break;
            }
            return result;
        }
    }
}
