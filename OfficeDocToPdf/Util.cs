using System;

namespace OfficeDocToPdf
{
    public class Util
    {
        public static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch (Exception exReleaseObject)
            {
                Console.WriteLine("Release of COM Object Fail:" + exReleaseObject);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
