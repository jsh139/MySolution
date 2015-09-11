using System;
using HiQPdf;

namespace PdfGenerator.Generators
{
    public class HiQPdfGenerator : IPdfGenerator
    {
        private const float HeaderHeight = 56;
        private const float HeaderSpacing = 5;

        private const float FooterHeight = 56;
        private const float FooterSpacing = 5;

        // Top and bottom margins currently set to 1/2 inch
        private const float VerticalMargins = 36;

        // Left and right Margins currently set to 1 inch
        private const float HorizontalMargins = 72;

        private const float HtmlViewerWidthInches = 8.5F;

        private const int PortraitPageWidth = 800;

        private const int LandscapePageWidth = 1122;

        private const float PortraitMultiplier = 73.4F;
        private const float LandscapeMultiplier = 101.5F;

        public byte[] GeneratePdf(PdfRequest request)
        {
            var pdfConverter = GetPdfConverter();

            var pageOrientation = request.Orientation == PdfOrientation.Portrait ? PdfPageOrientation.Portrait : PdfPageOrientation.Landscape;

            SetReportOptions(pdfConverter, pageOrientation);

            SetupHeader(pdfConverter, pageOrientation);
            SetupFooter(pdfConverter, pageOrientation);

            var baseUrl = request.BaseUrl;

            var html = HtmlTools.GetHtml(request.ConversionUrl);

            // This method will convert the html to pdf and build a EvoPdf.Document object
            var pdfBytes = pdfConverter.ConvertHtmlToMemory(html, baseUrl);

            return pdfBytes;
        }

        private HtmlToPdf GetPdfConverter()
        {
            return new HtmlToPdf();
        }

        private void SetReportOptions(HtmlToPdf converter, PdfPageOrientation pageOrientation)
        {
            converter.Document.PageOrientation = pageOrientation;
            converter.Document.PageSize = PdfPageSize.Letter;

            // We are doing this according to EvoPdf's suggestion. This tells the converter to not
            // scale the content, but instead to work within the specified viewer width.
            converter.Document.FitPageWidth = false;
            converter.Document.ResizePageWidth = false;
            converter.BrowserWidth = GetHtmlViewerWidth(pageOrientation);
            converter.TrimToBrowserWidth = true;

            // We are using a TriggeringMode of 'Auto' here because we don't have any asynchronous script operations 
            // that would execute later. If we did, the converter would not wait for those operations to finish.
            // This is kind of important so that we won't have a conversion delay time.
            converter.TriggerMode = ConversionTriggerMode.Auto;

            converter.Document.Margins = new PdfMargins(HorizontalMargins, HorizontalMargins, 
                VerticalMargins, VerticalMargins);

            converter.HtmlLoadedTimeout = 3600;
        }

        private int GetHtmlViewerWidth(PdfPageOrientation pageOrientation)
        {
            float multiplier = pageOrientation == PdfPageOrientation.Landscape ? LandscapeMultiplier : PortraitMultiplier;
            return Convert.ToInt32(HtmlViewerWidthInches * multiplier);
        }

        private void SetupHeader(HtmlToPdf pdfConverter, PdfPageOrientation pageOrientation)
        {
            var html = string.Empty;

            if (string.IsNullOrWhiteSpace(html)) return;

            //pdfConverter.PdfDocumentOptions.ShowHeader = true;
            //pdfConverter.PdfDocumentOptions.TopSpacing = HeaderSpacing;
            //pdfConverter.PdfHeaderOptions.HeaderHeight = HeaderHeight;

            //var pageWidth = pageOrientation == PdfPageOrientation.Portrait ? PortraitPageWidth : LandscapePageWidth;

            //var headerHtml = new HtmlToPdfVariableElement(0, 0, html, null)
            //{
            //    HtmlViewerWidth = pageWidth
            //};

            //pdfConverter.PdfHeaderOptions.AddElement(headerHtml);
        }

        private void SetupFooter(HtmlToPdf pdfConverter, PdfPageOrientation pageOrientation)
        {
            //const string html = "<div style=\"width: 100%; font-size: 16px; font-family: Arial,Helvetica,sans-serif; color: #3e4652;\"><span style=\"float:right;\">Page &p; of &P;</span></div>";

            //pdfConverter.PdfDocumentOptions.ShowFooter = true;
            //pdfConverter.PdfDocumentOptions.BottomSpacing = FooterSpacing;
            //pdfConverter.PdfFooterOptions.FooterHeight = FooterHeight;

            //var pageWidth = pageOrientation == PdfPageOrientation.Portrait ? PortraitPageWidth : LandscapePageWidth;

            //var footerHtmlWithPageNumbers = new HtmlToPdfVariableElement(0, 0, html, null)
            //{
            //    HtmlViewerWidth = pageWidth
            //};

            //pdfConverter.PdfFooterOptions.AddElement(footerHtmlWithPageNumbers);
        }
    }
}
