using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities
{
    public class Professional
    {
        public int ProfessionalId { get; set; }
        public int UserId { get; set; }
        public int Document { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DateAdmission { get; set; }
        public int Availability { get; set; }
        public string Neighborhood { get; set; }
        public string Address { get; set; }
        public int Telephone1 { get; set; }
        public int Telephone2 { get; set; }
        public int AccountNumber { get; set; }
        public int CodeBank { get; set; }
        public int GenderId { get; set; }
        public int SpecialtyId { get; set; }
        public int ZoneId { get; set; }
        public int DocumentTypeId { get; set; }
        public bool State { get; set; }
        public int TotalRows { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public string Email { get; set; }
        public string FamilyName { get; set; }
        public string FamilyRelationship { get; set; }
        public string FamilyPhone { get; set; }
        public int AccountTypeId { get; set; }
    }
}
