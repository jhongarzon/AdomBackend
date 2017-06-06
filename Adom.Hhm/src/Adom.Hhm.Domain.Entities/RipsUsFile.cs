namespace Adom.Hhm.Domain.Entities
{
    public class RipsUsFile
    {
        public string DocumentTypeName { get; set; }
        public string PatientDocument { get; set; }
        public long ProviderCode { get; set; }
        public string RipsUserType { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public int AgeUnit { get; set; }
        public string Gender { get; set; }
        public string DeparmentCode { get; set; }
        public string CityCode { get; set; }
        public string ResidenceArea { get; set; }
    }
}
