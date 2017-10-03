using System;
using System.Collections.Generic;

namespace Adom.Hhm.Domain.Entities.Reports
{
    public class SpecialDetailedReport
    {
        [ExcelReportCell("NOMBRE PACIENTE")]
        public string PatientName { get; set; }
        [ExcelReportCell("NÚMERO DOCUMENTO")]
        public string PatientDocumentType { get; set; }
        [ExcelReportCell("TIPO DOCUMENTO")]
        public string PatientDocument { get; set; }
        [ExcelReportCell("ENTIDAD")]
        public string EntityName { get; set; }
        [ExcelReportCell("PLAN")]
        public string PlanName { get; set; }
        [ExcelReportCell("AUTORIZACIÓN")]
        public string AuthorizationNumber { get; set; }
        [ExcelReportCell("NÚMERO CONTRATO")]
        public string ContractNumber { get; set; }
        [ExcelReportCell("SERVICIO")]
        public string ServiceName { get; set; }
        [ExcelReportCell("FREC. SERVICIO ")]
        public string ServiceFrecuency { get; set; }
        [ExcelReportCell("CIE 10")]
        public string Cie10 { get; set; }
        [ExcelReportCell("ESTADO")]
        public string VisitStatus { get; set; }
        [ExcelReportCell("FECHA SOLICITUD")]
        public string RequestDate { get; set; }
        [ExcelReportCell("FECHA DE ATENCIÓN")]
        public string DateVisit { get; set; }
        [ExcelReportCell("FRECUENCIA DEL COPAGO")]
        public string CopaymentFrecuency { get; set; }
        [ExcelReportCell("COPAGO RECIBIDO")]
        public string ReceivedAmount { get; set; }
        [ExcelReportCell("PIN")]
        public string Pin { get; set; }
        [ExcelReportCell("OTROS VAL. RECIBIDOS")]
        public string OtherAmount { get; set; }
        [ExcelReportCell("FECHA DE REGISTRO")]
        public string RecordDate { get; set; }
        [ExcelReportCell("PROFESIONAL")]
        public string ProfessionalName { get; set; }
        [ExcelReportCell("DOC. PROF.")]
        public string ProfessionalDocument { get; set; }
        [ExcelReportCell("HORAS INVERTIDAS")]
        public string HoursToInvest { get; set; }
        [ExcelReportCell("FECHA LLAM. CALIDAD")]
        public string QualityCallDate { get; set; }
        [ExcelReportCell("USUARIO")]
        public string QualityCallUser { get; set; }
        [ExcelReportCell("COMENTARIOS")]
        public string Observation { get; set; }
        [ExcelReportCell("VERIFICADO")]
        public string Verified { get; set; }
        [ExcelReportCell("VERIFICADO POR")]
        public string VerifiedBy { get; set; }
        [ExcelReportCell("FECHA VERIFICADO")]
        public string VerificationDate { get; set; }
        [ExcelReportCell("", IsListField = true)]
        public IEnumerable<QualityQuestion> QualityQuestions { get; set; }
        [ExcelReportCell("ID", IsVisible = false)]
        public string AssignServiceDetailId { get; set; }

    }
}
