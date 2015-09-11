
namespace PdfGenerator
{
    public class PdfRequest
    {
        public string ConversionUrl { get; set; }
        public string BaseUrl { get; set; }
        public string OutputFile { get; set; }
        public ReportFormat Format { get; set; }
        public PdfOrientation Orientation { get; set; }
    }

    public enum ReportFormat
    {
        Tabular,
        SideBySide,
    }

    public enum PdfOrientation
    {
        Portrait,
        Landscape,
    }
}
