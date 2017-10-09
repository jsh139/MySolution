using Microsoft.Office.Interop.MSProject;

namespace OfficeDocToPdf.Converters
{
    public class ProjectDocConverter : DocConverter, IDocConverter
    {
        protected override string ExtensionList { get; } = "ProjectExtensionList";

        public ConversionResult Convert(object inputFile, object outputFile)
        {
            //Start application
            var msProjectDoc = new Application { Visible = false };

            try
            {
                msProjectDoc.FileOpen(inputFile, true, null, null, null, null, true);
                msProjectDoc.DocumentExport(outputFile, PjDocExportType.pjPDF, false, false, false);
            }
            catch (System.Exception e)
            {
                return new ConversionResult { Success = false, Message = e.Message };
            }
            finally
            {
                msProjectDoc.Quit(PjSaveType.pjDoNotSave);

                Util.ReleaseObject(msProjectDoc);
            }

            return new ConversionResult { Success = true };
        }
    }
}
