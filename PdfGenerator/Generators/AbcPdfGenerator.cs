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

            var header = SetupHeader(pdfConverter, pageOrientation);
            var footer = SetupFooter(pdfConverter, pageOrientation);
            var includeHeader = !string.IsNullOrWhiteSpace(header.Html);

            SetReportOptions(pdfConverter, pageOrientation, includeHeader);

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

                if (includeHeader)
                {
                    AddHeaderToPage(pdfConverter, header);
                }

                AddFooterToPage(pdfConverter, footer, i, pdfConverter.PageCount);

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

        private void SetReportOptions(Doc converter, PdfOrientation pageOrientation, bool includeHeader)
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
            converter.Rect.Bottom += FooterHeight + FooterSpacing;

            if (includeHeader)
            {
                converter.Rect.Top -= HeaderHeight + HeaderSpacing;
            }
        }

        private int GetHtmlViewerWidth(PdfOrientation pageOrientation)
        {
            float multiplier = pageOrientation == PdfOrientation.Landscape ? LandscapeMultiplier : PortraitMultiplier;
            return Convert.ToInt32(HtmlViewerWidthInches * multiplier);
        }

        private HeaderFooterContext SetupHeader(Doc converter, PdfOrientation pageOrientation)
        {
            const string html = "<p><font face=\"Arial,Helvetica,sans-serif\" size=\"4\" color=\"#3e4652\">This is my header<br>Line 2<br>Line 3<br>Line 4<br>Line 5</font></p>";
            var width = PortraitLetterWidth;
            var height = PortraitLetterHeight;

            if (pageOrientation == PdfOrientation.Landscape)
            {
                width = PortraitLetterHeight;
                height = PortraitLetterWidth;
            }

            return new HeaderFooterContext
            {
                Left = HorizontalMargins,
                Bottom = height - (VerticalMargins + HeaderHeight),
                Right = width - HorizontalMargins,
                Top = height - VerticalMargins,
                Html = html,
            };
        }

        private void AddHeaderToPage(Doc converter, HeaderFooterContext header)
        {
            converter.Rect.Left = header.Left;
            converter.Rect.Bottom = header.Bottom;
            converter.Rect.Right = header.Right;
            converter.Rect.Top = header.Top;

            converter.AddHtml(header.Html);
            converter.FrameRect();
        }

        private HeaderFooterContext SetupFooter(Doc converter, PdfOrientation pageOrientation)
        {
            const string html = "<p align=\"right\"><font face=\"Arial,Helvetica,sans-serif\" size=\"4\" color=\"#3e4652\">Page &p; of &P;<br>Line 2<br>Line 3<br>Line 4<br>Line 5</font></p>";
            var width = PortraitLetterWidth;

            if (pageOrientation == PdfOrientation.Landscape)
            {
                width = PortraitLetterHeight;
            }

            return new HeaderFooterContext
            {
                Left = HorizontalMargins,
                Bottom = VerticalMargins,
                Right = width - HorizontalMargins,
                Top = VerticalMargins + FooterHeight,
                Html = html,
            };
        }

        private void AddFooterToPage(Doc converter, HeaderFooterContext footer, int currentPage, int pageCount)
        {
            converter.Rect.Left = footer.Left;
            converter.Rect.Bottom = footer.Bottom;
            converter.Rect.Right = footer.Right;
            converter.Rect.Top = footer.Top;

            converter.AddHtml(footer.Html.Replace("&p;", currentPage.ToString()).Replace("&P;", pageCount.ToString()));
            converter.FrameRect();
        }

        internal class HeaderFooterContext
        {
            public double Left { get; set; }
            public double Bottom { get; set; }
            public double Right { get; set; }
            public double Top { get; set; }
            public string Html { get; set; }
        }
    }
}
