using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Document { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public int UnitTimeId { get; set; }
        public string UnitTimeName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public string Email { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public string Neighborhood { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string AttendantName { get; set; }
        public string AttendantRelationship { get; set; }
        public string AttendantPhone { get; set; }
        public string AttendantEmail { get; set; }
        public string Profile { get; set; }
        public DateTime CreatedOn { get; set; }
        public int TotalRows { get; set; }
    }
}
