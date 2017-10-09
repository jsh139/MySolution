using System;
using System.Collections.Generic;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;

namespace OfficeDocToPdf.Converters
{
    public class PowerPointDocConverter : IDocConverter
    {
        private readonly List<string> _extensions = new List<string>
        {
            ".ppt", ".pptx", ".pptm",
        };

        public bool CanConvert(string fileExtension)
        {
            return _extensions.Contains(fileExtension);
        }

        public ConversionResult Convert(object inputFile, object outputFile)
        {
            Presentation pptPresentation = null;

            //start power point 
            var pptApplication = new Application();

            try
            {
                pptPresentation = pptApplication.Presentations.Open(inputFile.ToString(),
                    MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoFalse);

                pptPresentation.ExportAsFixedFormat((string)outputFile, PpFixedFormatType.ppFixedFormatTypePDF,
                    PpFixedFormatIntent.ppFixedFormatIntentPrint, MsoTriState.msoFalse, 
                    PpPrintHandoutOrder.ppPrintHandoutVerticalFirst, PpPrintOutputType.ppPrintOutputSlides, 
                    MsoTriState.msoFalse, null, PpPrintRangeType.ppPrintAll, string.Empty, true);
            }
            catch (Exception e)
            {
                return new ConversionResult {Success = false, Message = e.Message};
            }
            finally
            {
                // Close and release the Document object.
                if (pptPresentation != null)
                {
                    pptPresentation.Close();
                    Util.ReleaseObject(pptPresentation);
                }

                pptApplication.Quit();
                Util.ReleaseObject(pptApplication);
            }

            return new ConversionResult { Success = true };
        }
    }
}
