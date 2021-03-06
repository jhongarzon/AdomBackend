﻿using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IAssignServiceRepository
    {
        IEnumerable<AssignService> GetAssignServices(int pageNumber, int pageSize);
        IEnumerable<AssignService> GetAssignServices();
        AssignService GetAssignServiceById(int assignServiceId);
        IEnumerable<AssignService> GetAssignServiceByPatientId(int patientId);
        AssignService Insert(AssignService assignService);
        IEnumerable<ServiceObservation> GetServiceObservations(int assignServiceId, int userId);
        ServiceObservation InsertObservation(ServiceObservation serviceObservation);
        AssignService Update(AssignService assignService);
        string CalculateFinalDateAssignService(int quantity, int serviceFrecuencyId, string initialDate);
        string DeleteObservation(int assignServiceObservationId);
    }
}
