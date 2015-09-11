using System.IO;
using System.Net;
using ceTe.DynamicPDF.Conversion;

namespace PdfGenerator.Generators
{
    public class DynamicPdfGenerator : IPdfGenerator
    {
        // Top and bottom margins currently set to 1/2 inch
        private const double VerticalMargins = 12.7;

        // Left and right Margins currently set to 1 inch
        private const double HorizontalMargins = 25.4;

        public byte[] GeneratePdf(PdfRequest request)
        {
            var pageOrientation = request.Orientation == PdfOrientation.Portrait ? PageOrientation.Portrait : PageOrientation.Landscape;

            var reportOptions = SetReportOptions(pageOrientation);

            SetupHeader();
            SetupFooter();

            var baseUrl = request.BaseUrl;

            var html = HtmlTools.GetHtml(request.ConversionUrl);

            return Converter.ConvertHtmlString(html, reportOptions);
        }

        private HtmlConversionOptions SetReportOptions(PageOrientation pageOrientation)
        {
            var options = new HtmlConversionOptions(PageSize.Letter, pageOrientation, HorizontalMargins, VerticalMargins, false);

            return options;
        }

        private void SetupHeader()
        {
        }

        private void SetupFooter()
        {
            const string html = "<div style=\"width: 100%; font-size: 16px; font-family: Arial,Helvetica,sans-serif; color: #3e4652;\"><span style=\"float:right;\">Page &p; of &P;</span></div>";

            //converter.PageFooterHtml = html;
        }
    }
}
