using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities.Reports
{
    public class PaymentReport
    {
        [ExcelReportCell("NOMBRE PROFESIONAL")]
        public string ProfessionalName { get; set; }
        [ExcelReportCell("NÚMERO DOCUMENTO")]
        public string ProfessionalDocument { get; set; }
        [ExcelReportCell("DEPARTAMENTO")]
        public string ServiceType { get; set; }
        [ExcelReportCell("SERVICIO")]
        public string ServiceName { get; set; }
        [ExcelReportCell("FECHA ATENCIÓN")]
        public string InitialDate { get; set; }
        [ExcelReportCell("DÍA")]
        public string DayOfWeek { get; set; }
        [ExcelReportCell("FESTIVO")]
        public string IsHoliday { get; set; }
        [ExcelReportCell("HONORARIOS")]
        public int Rate { get; set; }
        [ExcelReportCell("TIPO COPAGO")]
        public string PaymentType { get; set; }
        [ExcelReportCell("PIN")]
        public int ReceivedAmount { get; set; }
        [ExcelReportCell("EFECTIVO REPORTADO")]
        public int OtherAmount { get; set; }
        [ExcelReportCell("OTROS REPORTADOS")]
        public int Pin { get; set; }
        [ExcelReportCell("NOMBRE PACIENTE")]
        public string PatientName { get; set; }
        [ExcelReportCell("TIPO DOCUMENTO PACIENTE")]
        public string PatientDocumentType { get; set; }
        [ExcelReportCell("No. DOCUMENTO PACIENTE")]
        public string PatientDocument { get; set; }
        [ExcelReportCell("ENTIDAD")]
        public string EntityName { get; set; }
        [ExcelReportCell("PLAN")]
        public string PlanName { get; set; }
        [ExcelReportCell("FECHA SOLICITUD")]
        public string RequestDate { get; set; }
        [ExcelReportCell("HORAS INVERTIDAS")]
        public int HoursToInvest { get; set; }
        [ExcelReportCell("VERIFICADO")]
        public string Verified { get; set; }
        [ExcelReportCell("VERIFICADO POR")]
        public string VerifiedBy { get; set; }
        [ExcelReportCell("FECHA VERIFICADO")]
        public string VerificationDate { get; set; }
    }
}
