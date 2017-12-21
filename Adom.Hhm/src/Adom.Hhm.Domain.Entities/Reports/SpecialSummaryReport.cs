using System.Collections.Generic;

namespace Adom.Hhm.Domain.Entities.Reports
{
    public class SpecialSummaryReport
    {
        [ExcelReportCell("NOMBRE PACIENTE")]
        public string PatientName { get; set; }
        [ExcelReportCell("TIPO DOCUMENTO")]
        public string PatientDocumentType { get; set; }
        [ExcelReportCell("NÚMERO DOCUMENTO")]
        public string PatientDocument { get; set; }
        [ExcelReportCell("ENTIDAD")]
        public string EntityName { get; set; }
        [ExcelReportCell("CONTRATO")]
        public string ContractNumber { get; set; }
        [ExcelReportCell("PLAN")]
        public string PlanEntityName { get; set; }
        [ExcelReportCell("AUTORIZACIÓN", IsNumber = true)]
        public string AuthorizationNumber { get; set; }
        [ExcelReportCell("SERVICIO")]
        public string ServiceName { get; set; }
        [ExcelReportCell("N. TOTAL SESIONES", IsNumber = true)]
        public int TotalSessions { get; set; }
        [ExcelReportCell("N. SESIONES COMPL", IsNumber = true)]
        public int CompletedSessions { get; set; }
        [ExcelReportCell("N. SESIONES PROGRAM", IsNumber = true)]
        public int ProgrammedSessions { get; set; }
        [ExcelReportCell("FREC. SERVICIO")]
        public string ServiceFrecuency { get; set; }
        [ExcelReportCell("ESTADO")]
        public string ServiceStatus { get; set; }
        [ExcelReportCell("TARIFA", IsMoney = true)]
        public int Rate { get; set; }
        [ExcelReportCell("COPAGO", IsMoney = true)]
        public int CoPaymentAmount { get; set; }
        [ExcelReportCell("FREC. COPAGO")]
        public string CopaymentFrecuency { get; set; }
        [ExcelReportCell("ESTADO COPAGO")]
        public string CopaymentStatus { get; set; }
        [ExcelReportCell("FECHA INICIO SOLICITUD", IsDate = true, DateFormat = "dd/mm/yyyy")]
        public string RequestDate { get; set; }
        [ExcelReportCell("FECHA INICIO TENT.", IsDate = true, DateFormat = "dd/mm/yyyy")]
        public string InitialDate { get; set; }
        [ExcelReportCell("FECHA FIN TENT.", IsDate = true, DateFormat = "dd/mm/yyyy")]
        public string FinalDate { get; set; }
        [ExcelReportCell("FECHA INICIO REAL", IsDate = true, DateFormat = "dd/mm/yyyy")]
        public string RealInitialDate { get; set; }
        [ExcelReportCell("FECHA FIN REAL", IsDate = true, DateFormat = "dd/mm/yyyy")]
        public string RealFinalDate { get; set; }
        [ExcelReportCell("CIE10")]
        public string Cie10 { get; set; }
        [ExcelReportCell("DES. CIE10")]
        public string DescriptionCie10 { get; set; }
        [ExcelReportCell("TIPO PACIENTE")]
        public string PatientType { get; set; }
        [ExcelReportCell("EDAD", IsNumber = true)]
        public string Age { get; set; }
        [ExcelReportCell("FECHA NACIMIENTO", IsDate = true, DateFormat = "dd/mm/yyyy")]
        public string PatientBirthday { get; set; }
        [ExcelReportCell("GENERO")]
        public string PatientGender { get; set; }
        [ExcelReportCell("TELÉFONO 1", IsNumber = true)]
        public long PatientPhone1 { get; set; }
        [ExcelReportCell("TELÉFONO 2", IsNumber = true)]
        public long PatientPhone2 { get; set; }
        [ExcelReportCell("DIRECCIÓN")]
        public string PatientAddress { get; set; }
        [ExcelReportCell("EMAIL")]
        public string PatientEmail { get; set; }
        [ExcelReportCell("ASIGNADO POR")]
        public string AssignedBy { get; set; }
        [ExcelReportCell("OBSERVACIONES")]
        public string Observations { get; set; }
        [ExcelReportCell("", IsListField = true)]
        public IEnumerable<AssignedProfessional> AssignedProfessionals { get; set; }
        [ExcelReportCell("ID", IsVisible = false)]
        public string AssignServiceId { get; set; }
    }
}
