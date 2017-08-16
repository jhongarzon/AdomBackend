namespace Adom.Hhm.Domain.Entities.Reports
{
    public class AssignedProfessional
    {
        [ExcelReportCell("DOC PROF {0}")]
        public string DocumentNumber { get; set; }
        [ExcelReportCell("PROFESIONAL ASIGNADO {0}")]
        public string ProfessionalName { get; set; }
    }
}
