using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Adom.Hhm.Domain.Entities;
using Adom.Hhm.Domain.Services.Interface;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Adom.Hhm.Domain.Services
{
    public class ExcelReportService : IExcelReportService
    {
        private readonly List<string> _dynColumns = new List<string>();
        private readonly List<string> _dynAdditionalColumns = new List<string>();
        private int _removedColumns = 0;
        private int _currentIndex = 1;
        public string GenerateExcelReport<T>(string rootPath, IEnumerable<T> data)
        {
            var type = typeof(T).Name;
            var filePath = string.Format(@"{0}\{1}_{2}.xlsx", rootPath, type, DateTime.Now.ToString("yyMMddhhmmss"));
            CreateSpreadSheet(filePath, data);
            return filePath;
        }

        private void CreateSpreadSheet<T>(string filepath, IEnumerable<T> data)
        {
            // Create a spreadsheet document by supplying the filepath.
            // By default, AutoSave = true, Editable = true, and Type = xlsx.
            var spreadsheetDocument = SpreadsheetDocument.Create(filepath, SpreadsheetDocumentType.Workbook);

            // Add a WorkbookPart to the document.
            var workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();

            // Add a WorksheetPart to the WorkbookPart.
            var worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            var workStylePart = workbookpart.AddNewPart<WorkbookStylesPart>();
            workStylePart.Stylesheet = new Stylesheet();
            // Add Sheets to the Workbook.
            var sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            // Append a new worksheet and associate it with the workbook.
            var sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "mySheet" };
            sheets.Append(sheet);

            AddStyleSheet(workStylePart);
            var t = typeof(T);
            var propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            CreateExcelColumns(propInfos);
            if (data != null)
            {
                var enumerable = data as List<T> ?? data.ToList();
                var headerRow = new Row() { RowIndex = uint.Parse((1).ToString()) };
                var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                ProcessColumns(headerRow, 0, propInfos, enumerable, true);
                sheetData.AppendChild(headerRow);

                for (var i = 0; i < enumerable.Count(); i++)
                {
                    var excelRow = new Row() { RowIndex = uint.Parse((i + 2).ToString()) };

                    ProcessColumns(excelRow, i, propInfos, enumerable, false);
                    sheetData.AppendChild(excelRow);
                }
            }
            // Close the document.
            spreadsheetDocument.Close();
        }

        private void ProcessColumns<T>(Row excelRow, int rowIndex, IReadOnlyList<PropertyInfo> propInfos, IReadOnlyList<T> data, bool isHeader)
        {
            if (data == null)
            {
                return;
            }
            if (data.Count == 0)
            {
                return;
            }
            var addedRows = 1;
            if (!isHeader)
            {
                addedRows++;
            }
            for (var j = 0; j < _dynColumns.Count; j++)
            {
                if (_dynColumns[j] == null)
                {
                    continue;
                }

                var reference = string.Format("{0}{1}", _dynColumns[j], rowIndex + addedRows);
                var newCell = new Cell() { CellReference = reference };
                var excelReportAttribute = propInfos[j].GetCustomAttribute<ExcelReportCellAttribute>(true);

                if (excelReportAttribute == null) continue;

                if (excelReportAttribute.IsListField)
                {
                    var typeArguments = propInfos[j].PropertyType.GenericTypeArguments;

                    if (!(typeArguments?.Length > 0)) continue;

                    var listType = typeArguments.First();
                    var listPropInfos = listType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    var dataRow = data[rowIndex];

                    var listData = dataRow.GetType().GetProperty(propInfos[j].Name).GetValue(dataRow, null);
                    var castedList = Cast(listData, propInfos[j].PropertyType);
                    if (castedList == null) continue;

                    var columnIndex = 0;
                    foreach (var additionalItem in castedList)
                    {
                        ProcessAdditionalColumns(excelRow, additionalItem, listPropInfos, rowIndex, columnIndex, isHeader);
                        columnIndex++;
                    }
                }
                else
                {
                    object value;
                    if (isHeader)
                    {
                        value = excelReportAttribute.Title;
                        SetCellBold(newCell);
                    }
                    else
                    {
                        var dataRow = data[rowIndex];

                        value = dataRow.GetType().GetProperty(propInfos[j].Name).GetValue(dataRow, null);
                        if (excelReportAttribute.IsUpperCase)
                        {
                            value = value.ToString()?.ToUpper();
                        }
                    }
                    excelRow.AppendChild(newCell);
                    newCell.CellValue = value == null ? new CellValue("") : new CellValue(value.ToString());
                    newCell.DataType = new EnumValue<CellValues>(CellValues.String);
                }
            }
        }
        public static dynamic Cast(dynamic obj, Type castTo)
        {
            try
            {
                var param = Expression.Parameter(obj.GetType());
                return Expression.Lambda(Expression.Convert(param, castTo), param)
                         .Compile().DynamicInvoke(obj);
            }
            catch (Exception)
            {
                return null;
            }

        }

        private void ProcessAdditionalColumns<T>(Row excelRow, T data, PropertyInfo[] propertyInfo, int rowIndex, int columnIndex, bool isHeader)
        {
            var colIndex = _dynColumns.Count() + columnIndex;
            foreach (var info in propertyInfo)
            {
                var reference = ExcelColumnFromNumber(colIndex);
                var newCell = new Cell() { CellReference = reference };
                var excelReportAttribute = info.GetCustomAttribute<ExcelReportCellAttribute>(true);
                if (excelReportAttribute == null) continue;
                object value;
                if (isHeader)
                {
                    value = excelReportAttribute.IsHeaderAutoNumeric ? string.Format(excelReportAttribute.Title, columnIndex + 1)
                        : string.Format(excelReportAttribute.Title, data.GetType().GetProperty(excelReportAttribute.SubTitlePropertyName).GetValue(data, null));

                    SetCellBold(newCell);
                }
                else
                {

                    value = data.GetType().GetProperty(info.Name).GetValue(data, null);
                    if (excelReportAttribute.IsUpperCase)
                    {
                        value = value.ToString()?.ToUpper();
                    }
                }
                newCell.CellValue = value == null ? new CellValue("") : new CellValue(value.ToString());
                newCell.DataType = new EnumValue<CellValues>(CellValues.String);
                excelRow.AppendChild(newCell);
            }
        }

        private void CreateExcelColumns(IEnumerable<PropertyInfo> propInfos)
        {
            foreach (var excelReportAttribute in propInfos.Select(propertyInfo => propertyInfo.GetCustomAttribute<ExcelReportCellAttribute>(true)))
            {
                if (excelReportAttribute == null)
                {
                    _removedColumns++;
                    continue;
                }
                if (!excelReportAttribute.IsVisible)
                {
                    _removedColumns++;
                    continue;
                }

                var excelColumnName = ExcelColumnFromNumber(_currentIndex - _removedColumns);
                _dynColumns.Add(excelColumnName);
                _currentIndex++;
            }
        }

        public static string ExcelColumnFromNumber(int column)
        {
            var columnString = "";
            decimal columnNumber = column;
            while (columnNumber > 0)
            {
                var currentLetterNumber = (columnNumber - 1) % 26;
                var currentLetter = (char)(currentLetterNumber + 65);
                columnString = currentLetter + columnString;
                columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
            }
            return columnString;
        }

        private static void SetCellBold(CellType cell)
        {
            cell.StyleIndex = Convert.ToUInt32(1);
        }
        private static void AddStyleSheet(WorkbookStylesPart stylesheet)
        {

            var workbookstylesheet = new Stylesheet();

            var font0 = new Font();         // Default font

            var font1 = new Font();         // Bold font
            var bold = new Bold();
            font1.Append(bold);

            var fonts = new Fonts();      // <APENDING Fonts>
            fonts.Append(font0);
            fonts.Append(font1);

            // <Fills>
            var fill0 = new Fill();        // Default fill

            var fills = new Fills();      // <APENDING Fills>
            fills.Append(fill0);

            // <Borders>
            var border0 = new Border();     // Defualt border

            var borders = new Borders();    // <APENDING Borders>
            borders.Append(border0);

            // <CellFormats>
            var cellformat0 = new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 }; // Default style : Mandatory | Style ID =0

            var cellformat1 = new CellFormat() { FontId = 1 };  // Style with Bold text ; Style ID = 1


            // <APENDING CellFormats>
            var cellformats = new CellFormats();
            cellformats.Append(cellformat0);
            cellformats.Append(cellformat1);


            // Append FONTS, FILLS , BORDERS & CellFormats to stylesheet <Preserve the ORDER>
            workbookstylesheet.Append(fonts);
            workbookstylesheet.Append(fills);
            workbookstylesheet.Append(borders);
            workbookstylesheet.Append(cellformats);

            // Finalize
            stylesheet.Stylesheet = workbookstylesheet;
            stylesheet.Stylesheet.Save();
        }
    }
}
