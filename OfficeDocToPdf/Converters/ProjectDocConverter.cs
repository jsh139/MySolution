using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Office.Interop.MSProject;
using Exception = Microsoft.Office.Interop.MSProject.Exception;

namespace OfficeDocToPdf.Converters
{
    public class ProjectDocConverter : DocConverter, IDocConverter
    {
        protected override string ExtensionList { get; } = "ProjectExtensionList";

        public ConversionResult Convert(object inputFile, object outputFile)
        {
            //Start application
//            var msProjectDoc = new Application { Visible = false };
            var msProjectDoc = new Application();

            try
            {
                try
                {
                    Thread.Sleep(1000);
                    msProjectDoc.FileOpen(inputFile, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, true);
                }
                catch (COMException)
                {
                    Thread.Sleep(1000);
                    msProjectDoc.FileOpen(inputFile, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, true);
                }

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
