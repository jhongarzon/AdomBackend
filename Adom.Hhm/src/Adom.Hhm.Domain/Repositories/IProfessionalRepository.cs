using Adom.Hhm.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Repositories
{
    public interface IProfessionalRepository
    {
        IEnumerable<Professional> GetProfessionals(int pageNumber, int pageSize);
        IEnumerable<Professional> GetProfessionals();
        Professional GetProfessionalById(int ProfessionalId);
        Professional GetProfessionalByEmail(string email);
        Professional GetProfessionalByEmailWithoutId(int ProfessionalId, string email);
        Professional Insert(Professional Professional);
        Professional Update(Professional Professional);
        Professional GetByDocument(int documentType, string document);
    }
}
