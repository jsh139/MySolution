using System;
using System.IO;
using System.Net;
using WebSupergoo.ABCpdf10;

namespace PdfGenerator.Generators
{
    public class AbcPdfGenerator : IPdfGenerator
    {
        private const float HeaderHeight = 61;
        private const float HeaderSpacing = 2;

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

        // One hour
        private const int PageTimeout = 3600000;

        public byte[] GeneratePdf(PdfRequest request)
        {
            var now = DateTime.Now;

            var pdfConverter = GetPdfConverter();

            var pageOrientation = request.Orientation;

            var header = GetHeader(pageOrientation);
            var footer = GetFooter(pageOrientation);

            var includeHeader = !string.IsNullOrWhiteSpace(header.Html);

            SetReportOptions(pdfConverter, pageOrientation, includeHeader);

            var html = GetHtml(request.ConversionUrl);

            pdfConverter.AddPage();
            var id = pdfConverter.AddImageHtml(html);

            while (pdfConverter.Chainable(id))
            {
                pdfConverter.Page = pdfConverter.AddPage();
                id = pdfConverter.AddImageToChain(id);
            }

            // Get the page count now before the document is consumed below
            int count = pdfConverter.PageCount;

            for (int i = 1; i <= count; i++)
            {
                pdfConverter.PageNumber = i;

                if (includeHeader)
                {
                    AddHeaderToPage(pdfConverter, header);
                }

                AddFooterToPage(pdfConverter, footer, i, count, false);

                pdfConverter.Flatten();
            }

            if (pageOrientation == PdfOrientation.Landscape)
            {
                id = pdfConverter.GetInfoInt(pdfConverter.Root, "Pages");
                pdfConverter.SetInfo(id, "/Rotate", "90");
            }

            var time = DateTime.Now - now;
            return pdfConverter.GetData();
        }

        private Doc GetPdfConverter()
        {
            return new Doc();
        }

        private void SetReportOptions(Doc converter, PdfOrientation pageOrientation, bool includeHeader)
        {
            converter.HtmlOptions.Engine = EngineType.Gecko;
            converter.HtmlOptions.BrowserWidth = GetHtmlViewerWidth(pageOrientation);
            converter.HtmlOptions.ImprovePageBreakAvoid = true;
            converter.HtmlOptions.Timeout = PageTimeout;

            if (pageOrientation == PdfOrientation.Landscape)
            {
                converter.Transform.Rotate(90, converter.MediaBox.Left, converter.MediaBox.Bottom);
                converter.Transform.Translate(converter.MediaBox.Width, 0);

                // Rotate our rectangle
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

        private string GetBaseUrl()
        {
            // Use the universally recognized ip address that equates to "localhost"
            // This will cause the request to go to the current machine. 
            // This is needed so that the data will be found in cache.
            return "http://127.0.0.1";
        }

        private int GetHtmlViewerWidth(PdfOrientation pageOrientation)
        {
            float multiplier = pageOrientation == PdfOrientation.Landscape ? LandscapeMultiplier : PortraitMultiplier;
            return Convert.ToInt32(HtmlViewerWidthInches * multiplier);
        }

        private HeaderFooterContext GetHeader(PdfOrientation pageOrientation)
        {
            var width = PortraitLetterWidth;
            var height = PortraitLetterHeight;

            if (pageOrientation == PdfOrientation.Landscape)
            {
                // Flip-flop page dimensions
                width = PortraitLetterHeight;
                height = PortraitLetterWidth;
            }

            return new HeaderFooterContext
            {
                Left = HorizontalMargins,
                Bottom = height - (VerticalMargins + HeaderHeight),
                Right = width - HorizontalMargins,
                Top = height - VerticalMargins,
//                Html = GetHtml("DataViz/Viewer", "Header"),
                Html = "<style>body { margin: 0; padding: 0; }</style> " +
                    "<div style=\"width: 100%; font-size: 12px; font-family: Arial,Helvetica,sans-serif; color: #3e4652; \">" +
                    "Copyright 2015 Sungard Availability Services<br>All rights reserved<br>Line 3<br>Line 4<br>Line 5<br>Line 6</div>",
            };
        }

        private void AddHeaderToPage(Doc converter, HeaderFooterContext header)
        {
            converter.Rect.Left = header.Left;
            converter.Rect.Bottom = header.Bottom;
            converter.Rect.Right = header.Right;
            converter.Rect.Top = header.Top;

            if (header.Doc == null)
            {
                header.Doc = GetPdfConverter();
                SetReportOptions(header.Doc, PdfOrientation.Portrait, true);
                header.Doc.Rect.Rectangle = converter.Rect.Rectangle;
                header.Doc.AddPage();
                header.Doc.AddImageHtml(header.Html, true, converter.HtmlOptions.BrowserWidth, true);
            }

            // Copy the header from the first page
            converter.AddImageDoc(header.Doc, 1, header.Doc.Rect);
        }

        private HeaderFooterContext GetFooter(PdfOrientation pageOrientation)
        {
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
//                Html = GetHtml("DataViz/Viewer", "Footer"),
                Html = "<style>body { margin: 0; padding: 0; }</style> " +
                    "<div style=\"width: 100%; font-size: 12px; font-family: Arial,Helvetica,sans-serif; color: #3e4652; \">" +
                    "Copyright 2015 Sungard Availability Services<br>All rights reserved<br>Line 3<br>Line 4<br>Line 5<br>Line 6</div>",
            };
        }

        private void AddFooterToPage(Doc converter, HeaderFooterContext footer, int currentPage, int pageCount, bool forExport)
        {
            converter.Rect.Left = footer.Left;
            converter.Rect.Bottom = footer.Bottom;
            converter.Rect.Right = footer.Right * .80;  // Leave some room for the page #
            converter.Rect.Top = footer.Top;

            if (footer.Doc == null)
            {
                footer.Doc = GetPdfConverter();
                SetReportOptions(footer.Doc, PdfOrientation.Portrait, true);
                footer.Doc.Rect.Rectangle = converter.Rect.Rectangle;
                footer.Doc.AddPage();
                footer.Doc.AddImageHtml(footer.Html, true, Convert.ToInt32(converter.HtmlOptions.BrowserWidth *.80), true);
            }

            // Copy the footer from the first page
            converter.AddImageDoc(footer.Doc, 1, footer.Doc.Rect);

            if (!forExport)
            {
                // Add the page number
                var pageHtml = string.Format("<p align=\"right\"><font face=\"Arial,Helvetica,sans-serif\" size=\"2\" color=\"#3e4652\">Page {0} of {1}</font></p>",
                                             currentPage, pageCount);
                converter.Rect.Left = converter.Rect.Right;
                converter.Rect.Bottom = footer.Bottom;
                converter.Rect.Right = footer.Right;
                converter.Rect.Top = footer.Top;

                converter.AddHtml(pageHtml);
            }
        }

        private string GetHtml(string controller, string endpoint, string args = "")
        {
            var url = string.Format("{0}/{1}/{2}{3}", GetBaseUrl(), controller, endpoint, args);

            return GetHtml(url);
        }

        private string GetHtml(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;

            request.Method = WebRequestMethods.Http.Get;
            request.ContentLength = 0;
            request.Timeout = 600000;

            var html = string.Empty;

            var response = (HttpWebResponse)request.GetResponse();
            var responseStream = response.GetResponseStream();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var reader = new StreamReader(responseStream))
                {
                    string responseFromServer = reader.ReadToEnd();
                    html = responseFromServer;
                }
            }

            response.Close();

            return html;
        }

        internal class HeaderFooterContext
        {
            public Doc Doc { get; set; }
            public double Left { get; set; }
            public double Bottom { get; set; }
            public double Right { get; set; }
            public double Top { get; set; }
            public string Html { get; set; }
        }
    }
}
