using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IParameterRepository
    {
        IEnumerable<Parameter> GetAccountType();
        IEnumerable<Parameter> GetSpecialties();
        IEnumerable<Parameter> GetZones();
        IEnumerable<Parameter> GetGender();
        IEnumerable<Parameter> GetDocumentType();
        IEnumerable<Parameter> GetServiceType();
        IEnumerable<Parameter> GetClassification();
        IEnumerable<Parameter> GetUnitTime();
    }
}