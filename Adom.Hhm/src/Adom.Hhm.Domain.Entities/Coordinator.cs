using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities
{
    public class Coordinator
    {
        public int CoordinatorId { get; set; }
        public int UserId { get; set; }
        public string Document { get; set; }
        public string BirthDate { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public int GenderId { get; set; }
        public int DocumentTypeId { get; set; }
        public bool State { get; set; }
        public int TotalRows { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public string Email { get; set; }
    }
}
