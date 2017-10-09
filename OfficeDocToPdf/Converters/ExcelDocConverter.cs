using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

namespace OfficeDocToPdf.Converters
{
    public class ExcelDocConverter : IDocConverter
    {
        private readonly List<string> _extensions = new List<string>
        {
            ".xls", ".xlsx", ".xlsm", ".xlsb", ".csv",
        };

        public bool CanConvert(string fileExtension)
        {
            return _extensions.Contains(fileExtension);
        }

        public ConversionResult Convert(object inputFile, object outputFile)
        {
            Workbook excelWorkbook = null;

            // Create new instance of Excel
            // open excel application
            var excelApplication = new Application { ScreenUpdating = false, DisplayAlerts = false };

            try
            {
                excelWorkbook = excelApplication.Workbooks.Open(inputFile.ToString());
                excelWorkbook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, outputFile);
            }
            catch (Exception e)
            {
                return new ConversionResult {Success = false, Message = e.Message};
            }
            finally
            {
                // Close the workbook, quit the Excel, and clean up regardless of the results...
                excelWorkbook?.Close();
                excelApplication.Quit();

                Util.ReleaseObject(excelWorkbook);
                Util.ReleaseObject(excelApplication);
            }

            return new ConversionResult { Success = true };
        }
    }
}
