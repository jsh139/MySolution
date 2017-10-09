using System;
using Microsoft.Office.Interop.Visio;

namespace OfficeDocToPdf.Converters
{
    public class VisioDocConverter : DocConverter, IDocConverter
    {
        protected override string ExtensionList { get; } = "VisioExtensionList";

        public ConversionResult Convert(object inputFile, object outputFile)
        {
            Document vsdDoc = null;
            //Start application
            var msVisioDoc = new InvisibleApp();

            try
            {
                vsdDoc = msVisioDoc.Documents.OpenEx(inputFile.ToString(),
                    (short) VisOpenSaveArgs.visOpenRO + 
                    (short) VisOpenSaveArgs.visOpenDontList +
                    (short) VisOpenSaveArgs.visOpenMacrosDisabled);

                vsdDoc.ExportAsFixedFormat(VisFixedFormatTypes.visFixedFormatPDF, outputFile.ToString(),
                    VisDocExIntent.visDocExIntentPrint, VisPrintOutRange.visPrintAll);
            }
            catch (Exception e)
            {
                return new ConversionResult {Success = false, Message = e.Message};
            }
            finally
            {
                vsdDoc?.Close();
                msVisioDoc.Quit();

                Util.ReleaseObject(vsdDoc);
                Util.ReleaseObject(msVisioDoc);
            }

            return new ConversionResult { Success = true };
        }
    }
}
