﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities
{
    public class Professional
    {
        public int ProfessionalId { get; set; }
        public int UserId { get; set; }
        public string Document { get; set; }
        public string BirthDate { get; set; }
        public string DateAdmission { get; set; }
        public string Availability { get; set; }
        public string Neighborhood { get; set; }
        public string Address { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string AccountNumber { get; set; }
        public string CodeBank { get; set; }
        public int GenderId { get; set; }
        public int SpecialtyId { get; set; }
        public string Coverage { get; set; }
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
