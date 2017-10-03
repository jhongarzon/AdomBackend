using System.Collections.Generic;
using System.Data;
using System.Linq;
using Adom.Hhm.Data.Querys;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Repositories;
using Dapper;

namespace Adom.Hhm.Data.Repositories
{
    public class AssignServiceDetailRepository : IAssignServiceDetailRepository
    {
        private readonly IDbConnection _connection;

        public AssignServiceDetailRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<AssignServiceDetail> GetAssignServiceDetailByAssignServiceId(int assignServiceId)
        {
            return _connection.Query<AssignServiceDetail>(AssignServiceDetailQuerys.GetByAssignServiceId, new { AssignServiceId = assignServiceId });
        }

        public AssignServiceDetail GetAssignServiceDetailById(int assignServiceDetailId)
        {
            return _connection.Query<AssignServiceDetail>(AssignServiceDetailQuerys.GetById, new { AssignServiceDetailId = assignServiceDetailId }).FirstOrDefault();
        }

        public IEnumerable<AssignServiceDetail> GetAssignServiceDetails(int pageNumber, int pageSize)
        {
            return _connection.Query<AssignServiceDetail>(AssignServiceDetailQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public IEnumerable<AssignServiceDetail> GetAssignServiceDetails()
        {
            return _connection.Query<AssignServiceDetail>(AssignServiceDetailQuerys.GetAllWithoutPagination);
        }

        public AssignServiceDetail Update(AssignServiceDetail assignServiceDetail)
        {
            var id = _connection.Query<int>(AssignServiceDetailQuerys.Update,
                new
                {
                    assignServiceDetail.AssignServiceId,
                    assignServiceDetail.AssignServiceDetailId,
                    StateAssignServiceDetailId = assignServiceDetail.StateId,
                    assignServiceDetail.ProfessionalId,
                    @DateVisitP = assignServiceDetail.DateVisit,
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
            return _connection.Query<QualityQuestion>(AssignServiceDetailQuerys.GetQuestions, new { @ServiceId = serviceId });
        }

        public string SaveAnswers(int assignServiceDetailId, int qualityCallUser, IEnumerable<QualityQuestion> answers)
        {
            var result = "";
            var detailCount = _connection.Execute(AssignServiceDetailQuerys.UpdateQualityCall, new { @AssignServiceDetailId = assignServiceDetailId, @QualityCallUser = qualityCallUser });
            if (detailCount > 0)
            {
                foreach (var answer in answers)
                {
                    var count = _connection.Execute(AssignServiceDetailQuerys.SaveQuestion, new { answer.QuestionId, answer.AnswerId, @AssignServiceDetailId = assignServiceDetailId });
                    if (count != 0) continue;
                    result = "No se guardó la respuesta";
                    break;
                }
            }
            else
            {
                result = "No se guardó la respuesta";
            }
            return result;
        }
    }
}
