using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Word;

namespace OfficeDocToPdf.Converters
{
    public class WordDocConverter : IDocConverter
    {
        private readonly List<string> _extensions = new List<string>
        {
            ".doc", ".docx", ".txt", ".rtf", ".docm",
        };

        public bool CanConvert(string fileExtension)
        {
            return _extensions.Contains(fileExtension);
        }

        public ConversionResult Convert(object inputFile, object outputFile)
        {
            Document doc = null;

            var msWordDoc = new Application { Visible = false, ScreenUpdating = false };

            try
            {
                doc = msWordDoc.Documents.Open(ref inputFile);

                if (doc != null)
                {
                    doc.Activate();
                    // save Document as PDF
                    object fileFormat = WdSaveFormat.wdFormatPDF;
                    doc.SaveAs(ref outputFile, ref fileFormat);
                }
            }
            catch (Exception e)
            {
                return new ConversionResult { Success = false, Message = e.Message };
            }
            finally
            {
                // Close and release the Document object.
                if (doc != null)
                {
                    object saveChanges = WdSaveOptions.wdDoNotSaveChanges;
                    doc.Close(ref saveChanges);
                    Util.ReleaseObject(doc);
                }
                
                // Quit Word and release the ApplicationClass object.
                msWordDoc.Quit();
                Util.ReleaseObject(msWordDoc);
            }

            return new ConversionResult { Success = true };
        }
    }
}
