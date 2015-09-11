using System.IO;
using System.Net;
using NReco.PdfGenerator;

namespace PdfGenerator.Generators
{
    public class NRecoPdfGenerator : IPdfGenerator
    {
        // Top and bottom margins currently set to 1/2 inch
        private const float VerticalMargins = 12.7f;

        // Left and right Margins currently set to 1 inch
        private const float HorizontalMargins = 25.4f;

        public byte[] GeneratePdf(PdfRequest request)
        {
            var pdfConverter = GetPdfConverter();

            var pageOrientation = request.Orientation == PdfOrientation.Portrait ? PageOrientation.Portrait : PageOrientation.Landscape;

            SetReportOptions(pdfConverter, pageOrientation);

            SetupHeader(pdfConverter);
            SetupFooter(pdfConverter);

            var baseUrl = request.BaseUrl;

            var html = HtmlTools.GetHtml(request.ConversionUrl);

            return pdfConverter.GeneratePdf(html);
        }

        private HtmlToPdfConverter GetPdfConverter()
        {
            return new HtmlToPdfConverter();
        }

        private void SetReportOptions(HtmlToPdfConverter converter, PageOrientation pageOrientation)
        {
            converter.Orientation = pageOrientation;
            converter.Size = PageSize.Letter;

            converter.Margins = new PageMargins
            {
                Top = VerticalMargins,
                Bottom = VerticalMargins,
                Left = HorizontalMargins,
                Right = HorizontalMargins,
            };
        }

        private void SetupHeader(HtmlToPdfConverter converter)
        {
        }

        private void SetupFooter(HtmlToPdfConverter converter)
        {
            const string html = "<div style=\"width: 100%; font-size: 16px; font-family: Arial,Helvetica,sans-serif; color: #3e4652;\"><span style=\"float:right;\">Page &p; of &P;</span></div>";

            converter.PageFooterHtml = html;
        }
    }
}
