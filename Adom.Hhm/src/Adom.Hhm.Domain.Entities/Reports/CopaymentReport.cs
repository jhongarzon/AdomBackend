using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Entities.Reports
{
    public class CopaymentReport
    {
        [ExcelReportCell("NOMBRE PROFESIONAL")]
        public string ProfessionalName { get; set; }
        [ExcelReportCell("NÚMERO DOCUMENTO")]
        public string ProfessionalDocument { get; set; }
        [ExcelReportCell("SERVICIO")]
        public string ServiceName { get; set; }
        [ExcelReportCell("FECHA INICIO")]
        public string InitialDate { get; set; }
        [ExcelReportCell("FECHA FIN")]
        public string FinalDate { get; set; }
        [ExcelReportCell("COMPLETADO")]
        public string QuantityCompleted { get; set; }
        [ExcelReportCell("PROGRAMADO")]
        public string QuantityProgrammed { get; set; }
        [ExcelReportCell("ESTADO")]
        public string StateName { get; set; }
        [ExcelReportCell("COPAGO")]
        public string CoPaymentAmount { get; set; }
        [ExcelReportCell("FRECUENCIA COPAGO")]
        public string CopaymentFrecuency { get; set; }
        [ExcelReportCell("HONORARIOS")]
        public string Rate { get; set; }
        [ExcelReportCell("ESTADO COPAGOS")]
        public string CopaymentStatus { get; set; }
        [ExcelReportCell("EFECTIVO REPORTADO")]
        public string ReceivedAmount { get; set; }
        [ExcelReportCell("OTROS REPORTADOS")]
        public string ReportedAmount { get; set; }
        [ExcelReportCell("EFECTIVO RECIBIDO VERIFICADO")]
        public string OtherAmount { get; set; }
        [ExcelReportCell("EFECTIVO ENTREGADO")]
        public string TotalCopaymentReceived { get; set; }
        [ExcelReportCell("OTROS RECIBIDOS")]
        public string OtherReceived { get; set; }
        [ExcelReportCell("OTROS ENTREGADOS")]
        public string OtherDelivered { get; set; }
        [ExcelReportCell("DESCUENTOS")]
        public string Discounts { get; set; }
        [ExcelReportCell("VALOR A PAGAR AL PROFESIONAL")]
        public string ValueToPayToProfessional { get; set; }
        [ExcelReportCell("RECIBIDO POR")]
        public string ReceivedBy { get; set; }
        [ExcelReportCell("FECHA Y HORA RECIBIDO")]
        public string ReceivedDateTime { get; set; }
        [ExcelReportCell("NOMBRE PACIENTE")]
        public string PatientName { get; set; }
        [ExcelReportCell("TIPO DOCUMENTO PACIENTE")]
        public string PatientDocumentTypeName { get; set; }
        [ExcelReportCell("No. DOCUMENTO PACIENTE")]
        public string PatientDocument { get; set; }
        [ExcelReportCell("ENTIDAD")]
        public string EntityName { get; set; }
        [ExcelReportCell("PLAN")]
        public string PlanEntityName { get; set; }
        [ExcelReportCell("FECHA SOLICITUD")]
        public string RecordDate { get; set; }
    }
}
