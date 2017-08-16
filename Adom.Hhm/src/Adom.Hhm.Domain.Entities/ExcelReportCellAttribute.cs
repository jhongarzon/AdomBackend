using System;

namespace Adom.Hhm.Domain.Entities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcelReportCellAttribute : Attribute
    {
        private string _title;
        public ExcelReportCellAttribute(string title)
        {
            _title = title;
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public bool IsDate { get; set; }
        public string DateFormat { get; set; } = "dd/MM/yyyy";
        public bool IsBold { get; set; }
        public bool IsUpperCase { get; set; }
        public bool IsVisible { get; set; } = true;
        public bool IsNumber { get; set; }
        public bool IsMoney { get; set; }
        public bool IsListField { get; set; } = false;

        public bool IsHeaderAutoNumeric { get; set; } = true;
        /// <summary>
        /// Se usa cuando el Título (Header) es dinámico y depende de otra propiedad
        /// </summary>
        public string SubTitlePropertyName { get; set; }
    }
}
