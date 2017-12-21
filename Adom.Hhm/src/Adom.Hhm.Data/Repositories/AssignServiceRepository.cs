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
    public class AssignServiceRepository : IAssignServiceRepository
    {
        private readonly IDbConnection connection;

        public AssignServiceRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<AssignService> GetAssignServiceByPatientId(int patientId)
        {
            return connection.Query<AssignService>(AssignServiceQuerys.GetByPateintId, new { @PatientId = patientId });
        }

        public AssignService GetAssignServiceById(int AssignServiceId)
        {
            return connection.Query<AssignService>(AssignServiceQuerys.GetById, new { AssignServiceId = AssignServiceId }).FirstOrDefault();
        }

        public IEnumerable<AssignService> GetAssignServices(int pageNumber, int pageSize)
        {
            return connection.Query<AssignService>(AssignServiceQuerys.GetAll, new { PageNumber = pageNumber, PageSize = pageSize });
        }

        public IEnumerable<AssignService> GetAssignServices()
        {
            return connection.Query<AssignService>(AssignServiceQuerys.GetAllWithoutPagination);
        }

        public AssignService Insert(AssignService assignService)
        {
            var id = connection.Query<int>(AssignServiceQuerys.CreateAssignServiceAndDetails, new { PatientId = assignService.PatientId, AuthorizationNumber = assignService.AuthorizationNumber, ValidityStr = assignService.Validity, ApplicantName = assignService.ApplicantName, ServiceId = assignService.ServiceId, Quantity = assignService.Quantity, InitialDateStr = assignService.InitialDate, FinalDateStr = assignService.FinalDate, ServiceFrecuencyId = assignService.ServiceFrecuencyId, ProfessionalId = assignService.ProfessionalId, CoPaymentAmount = assignService.CoPaymentAmount, CoPaymentFrecuencyId = assignService.CoPaymentFrecuencyId, Consultation = assignService.Consultation, External = assignService.External, StateId = 1, Observation = assignService.Observation, ContractNumber = assignService.ContractNumber, Cie10 = assignService.Cie10, DescriptionCie10 = assignService.DescriptionCie10, PlanEntityId = assignService.PlanEntityId, EntityId = assignService.EntityId, @AssignedBy = assignService.AssignedBy }, commandType: CommandType.StoredProcedure).Single();
            assignService.AssignServiceId = id;
            return assignService;
        }

        public IEnumerable<ServiceObservation> GetServiceObservations(int assignServiceId, int userId)
        {
            return connection.Query<ServiceObservation>(AssignServiceQuerys.GetServiceObservations, new { assignServiceId, userId });
        }

        public ServiceObservation InsertObservation(ServiceObservation serviceObservation)
        {
            var id = connection.Query<int>(AssignServiceQuerys.InsertServiceObservations, serviceObservation).FirstOrDefault();
            serviceObservation.AssignServiceObservationId = id;
            return serviceObservation;
        }

        public AssignService Update(AssignService assignService)
        {
            var affectedRows = connection.Execute(AssignServiceQuerys.Update, assignService);
            return assignService;
        }

        public string CalculateFinalDateAssignService(int quantity, int serviceFrecuencyId, string initialDate)
        {
            return connection.Query<string>(AssignServiceQuerys.CalculateFinalDateAssignService, new { Quantity = quantity, ServiceFrecuencyId = serviceFrecuencyId, InitialDateStr = initialDate }, commandType: CommandType.StoredProcedure).Single();
        }

        public string DeleteObservation(int assignServiceObservationId)
        {
            var affectedRows = connection.Execute(AssignServiceQuerys.DeleteObservation, new { assignServiceObservationId });
            return affectedRows.ToString();
        }
    }
}
