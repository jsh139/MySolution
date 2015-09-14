using System;
using WebSupergoo.ABCpdf10;

namespace PdfGenerator.Generators
{
    public class AbcPdfGenerator : IPdfGenerator
    {
        private const float HeaderHeight = 60;
        private const float HeaderSpacing = 3;

        private const float FooterHeight = 60;
        private const float FooterSpacing = 3;

        // Top and bottom margins currently set to 1/2 inch
        private const float VerticalMargins = 36f;

        // Left and right Margins currently set to 1 inch
        private const float HorizontalMargins = 72f;

        private const float HtmlViewerWidthInches = 8.5F;

        private const float PortraitMultiplier = 73.4F;
        private const float LandscapeMultiplier = 101.5F;

        private const float PortraitLetterWidth = 612f;
        private const float PortraitLetterHeight = 792f;

        public byte[] GeneratePdf(PdfRequest request)
        {
            var pdfConverter = GetPdfConverter();

            var pageOrientation = request.Orientation;

            SetReportOptions(pdfConverter, pageOrientation);

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

                SetupHeader(pdfConverter, pageOrientation);
                SetupFooter(pdfConverter, pageOrientation, i, pdfConverter.PageCount);

                pdfConverter.Flatten();
            }

            if (pageOrientation == PdfOrientation.Landscape)
            {
                id = pdfConverter.GetInfoInt(pdfConverter.Root, "Pages");
                pdfConverter.SetInfo(id, "/Rotate", "90");
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
            converter.HtmlOptions.Engine = EngineType.Gecko;
            converter.HtmlOptions.UseScript = false;
            converter.HtmlOptions.BrowserWidth = GetHtmlViewerWidth(pageOrientation);
            converter.HtmlOptions.Paged = true;
            converter.HtmlOptions.ImprovePageBreakAvoid = true;
            converter.HtmlOptions.ImprovePageBreakInTable = true;
            
            if (pageOrientation == PdfOrientation.Landscape)
            {
                converter.Transform.Rotate(90, converter.MediaBox.Left, converter.MediaBox.Bottom);
                converter.Transform.Translate(converter.MediaBox.Width, 0);

                // rotate our rectangle
                converter.Rect.Width = converter.MediaBox.Height;
                converter.Rect.Height = converter.MediaBox.Width;
            }

            converter.Rect.Inset(HorizontalMargins, VerticalMargins);
            converter.Rect.Top -= HeaderHeight + HeaderSpacing;
            converter.Rect.Bottom += FooterHeight + FooterSpacing;
        }

        private int GetHtmlViewerWidth(PdfOrientation pageOrientation)
        {
            float multiplier = pageOrientation == PdfOrientation.Landscape ? LandscapeMultiplier : PortraitMultiplier;
            return Convert.ToInt32(HtmlViewerWidthInches * multiplier);
        }

        private void SetupHeader(Doc converter, PdfOrientation pageOrientation)
        {
            const string html = "<p><font face=\"Arial,Helvetica,sans-serif\" size=\"4\" color=\"#3e4652\">This is my header<br>Line 2<br>Line 3<br>Line 4<br>Line 5</font></p>";
            var width = PortraitLetterWidth;
            var height = PortraitLetterHeight;

            if (pageOrientation == PdfOrientation.Landscape)
            {
                width = PortraitLetterHeight;
                height = PortraitLetterWidth;
            }

            converter.Rect.Left = HorizontalMargins;
            converter.Rect.Bottom = height - (VerticalMargins + HeaderHeight);
            converter.Rect.Right = width - HorizontalMargins;
            converter.Rect.Top = height - VerticalMargins;

            converter.AddHtml(html);
            converter.FrameRect();
        }

        private void SetupFooter(Doc converter, PdfOrientation pageOrientation, int currentPage, int pageCount)
        {
            const string html = "<p align=\"right\"><font face=\"Arial,Helvetica,sans-serif\" size=\"4\" color=\"#3e4652\">Page &p; of &P;<br>Line 2<br>Line 3<br>Line 4<br>Line 5</font></p>";
            var width = PortraitLetterWidth;

            if (pageOrientation == PdfOrientation.Landscape)
            {
                width = PortraitLetterHeight;
            }

            converter.Rect.Left = HorizontalMargins;
            converter.Rect.Bottom = VerticalMargins;
            converter.Rect.Right = width - HorizontalMargins;
            converter.Rect.Top = VerticalMargins + FooterHeight;

            converter.AddHtml(html.Replace("&p;", currentPage.ToString()).Replace("&P;", pageCount.ToString()));
            converter.FrameRect();
        }
    }
}
