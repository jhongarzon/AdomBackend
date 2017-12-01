namespace Adom.Hhm.Domain.Entities
{
    public class QualityQuestion
    {
        
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int IdServiceType { get; set; }
        public string RecordDate { get; set; }
        [ExcelReportCell("PREGUNTA {0}", IsHeaderAutoNumeric = false, SubTitlePropertyName = "QuestionId")]
        public string AnswerId { get; set; }
    }
}
