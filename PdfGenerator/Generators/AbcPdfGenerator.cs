using System;
using System.IO;
using System.Net;
using WebSupergoo.ABCpdf10;

namespace PdfGenerator.Generators
{
    public class AbcPdfGenerator : IPdfGenerator
    {
        // Top and bottom margins currently set to 1/2 inch
        private const float VerticalMargins = 36f;

        // Left and right Margins currently set to 1 inch
        private const float HorizontalMargins = 72f;

        private const float HtmlViewerWidthInches = 8.5F;

        private const float PortraitMultiplier = 73.4F;
        private const float LandscapeMultiplier = 101.5F;

        public byte[] GeneratePdf(PdfRequest request)
        {
            var pdfConverter = GetPdfConverter();

            var pageOrientation = request.Orientation;

            SetReportOptions(pdfConverter, pageOrientation);

            SetupHeader(pdfConverter);
            SetupFooter(pdfConverter);

            var baseUrl = request.BaseUrl;

            var html = HtmlTools.GetHtml(request.ConversionUrl);

            pdfConverter.AddPage();
            var id = pdfConverter.AddImageHtml(html);

            while (pdfConverter.Chainable(id))
            {
                pdfConverter.Page = pdfConverter.AddPage();
                id = pdfConverter.AddImageToChain(id);
            }

            for (int i = 1; i <= pdfConverter.PageCount; i++)
            {
                pdfConverter.PageNumber = i;
                pdfConverter.Flatten();
            }

            var pdfBytes = pdfConverter.GetData();
            pdfConverter.Clear();
            
            return pdfBytes;
        }

        private Doc GetPdfConverter()
        {
            return new Doc();
        }

        private void SetReportOptions(Doc converter, PdfOrientation pageOrientation)
        {
            converter.Units = UnitType.Points;
            converter.Rect.Inset(HorizontalMargins, VerticalMargins);
            converter.HtmlOptions.Engine = EngineType.Gecko;
            converter.HtmlOptions.UseScript = false;
            converter.HtmlOptions.BrowserWidth = GetHtmlViewerWidth(pageOrientation);
            converter.HtmlOptions.Paged = true;
            converter.HtmlOptions.ImprovePageBreakAvoid = true;
            converter.HtmlOptions.ImprovePageBreakInTable = true;
            
        }

        private int GetHtmlViewerWidth(PdfOrientation pageOrientation)
        {
            float multiplier = pageOrientation == PdfOrientation.Landscape ? LandscapeMultiplier : PortraitMultiplier;
            return Convert.ToInt32(HtmlViewerWidthInches * multiplier);
        }

        private void SetupHeader(Doc converter)
        {
        }

        private void SetupFooter(Doc converter)
        {
            const string html =
                "<div style=\"width: 100%; font-size: 16px; font-family: Arial,Helvetica,sans-serif; color: #3e4652;\"><span style=\"float:right;\">Page &p; of &P;</span></div>";

            //converter.PageFooterHtml = html;
        }
    }
}
