using System;
using System.IO;
using System.Net;
using WebSupergoo.ABCpdf10;

namespace PdfGenerator.Generators
{
    public class AbcPdfGenerator : IPdfGenerator
    {
        private const float HeaderHeight = 61F;
        private const float HeaderSpacing = 2F;

        private const float FooterHeight = 60F;
        private const float FooterSpacing = 3F;
        
        // Top and bottom margins currently set to 1/2 inch
        private const float VerticalMargins = 36F;

        // Left and right Margins currently set to 1 inch
        private const float HorizontalMargins = 72F;

        private const float HtmlViewerWidthInches = 8.5F;

        // Magic numbers used to set the browser width (in pixels) for portrait and landscape.
        private const float PortraitMultiplier = 73.4F;
        private const float LandscapeMultiplier = 101.5F;

        private const float PortraitLetterWidth = 612F;
        private const float PortraitLetterHeight = 792F;

        // One hour
        private const int PageTimeout = 3600000;

        public byte[] GeneratePdf(PdfRequest request)
        {
            var pdfConverter = GetPdfConverter();
            var pageOrientation = request.Orientation;

            var header = GetHeader(pageOrientation);
            var footer = GetFooter(pageOrientation);
            var includeHeader = !string.IsNullOrWhiteSpace(header.Html);

            SetReportOptions(pdfConverter, pageOrientation, includeHeader, true);

            var html = GetHtml(request.ConversionUrl);

            return AssemblePages(pdfConverter, html, false, includeHeader ? header : null, footer);
        }

        private byte[] GetPdfBytes(Doc pdfDocument)
        {
            byte[] pdfBytes;

            try
            {
                pdfBytes = pdfDocument.GetData();
            }
            finally
            {
                // close the Document to release all the resources
                pdfDocument.Clear();
            }

            return pdfBytes;
        }

        private byte[] AssemblePages(Doc pdfConverter, string html, bool forExport, HeaderFooterContext header = null, HeaderFooterContext footer = null)
        {
            pdfConverter.AddPage();
            var id = pdfConverter.AddImageHtml(html);

            while (pdfConverter.Chainable(id))
            {
                pdfConverter.Page = pdfConverter.AddPage();
                id = pdfConverter.AddImageToChain(id);
            }

            // Get the page count now before the document is consumed below
            var count = pdfConverter.PageCount;

            for (var i = 1; i <= count; i++)
            {
                pdfConverter.PageNumber = i;

                if (header != null)
                {
                    AddHeaderToPage(pdfConverter, header);
                }

                if (footer != null)
                {
                    AddFooterToPage(pdfConverter, footer, i, count, forExport);
                }

                pdfConverter.Flatten();
            }

            return GetPdfBytes(pdfConverter);
        }

        private Doc GetPdfConverter()
        {
            return new Doc();
        }

        private void SetReportOptions(Doc converter, PdfOrientation pageOrientation, bool includeHeader, bool includeFooter)
        {
            converter.HtmlOptions.Engine = EngineType.Gecko;
            converter.HtmlOptions.BrowserWidth = GetHtmlViewerWidth(pageOrientation);
            converter.HtmlOptions.ImprovePageBreakAvoid = true;
            converter.HtmlOptions.Timeout = PageTimeout;
            converter.HtmlOptions.AddLinks = true;

            if (pageOrientation == PdfOrientation.Landscape)
            {
                // Swap width/height
                converter.MediaBox.SetRect(0, 0, PortraitLetterHeight, PortraitLetterWidth);
                converter.Rect.SetRect(0, 0, PortraitLetterHeight, PortraitLetterWidth);
            }

            converter.Rect.Inset(HorizontalMargins, VerticalMargins);
            converter.Rect.Bottom += FooterHeight + FooterSpacing;

            if (includeHeader)
            {
                converter.Rect.Top -= HeaderHeight + HeaderSpacing;
            }

            if (includeFooter)
            {
                converter.Rect.Bottom += FooterHeight + FooterSpacing;
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
            var width = pageOrientation == PdfOrientation.Portrait ? PortraitLetterWidth : PortraitLetterHeight;
            var height = pageOrientation == PdfOrientation.Portrait ? PortraitLetterHeight : PortraitLetterWidth;

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

            if (header.UseCopy)
            {
                // Copy the header from the first page
                converter.AddImageDoc(converter, 1, converter.Rect);
            }
            else
            {
                converter.AddImageHtml(header.Html, true, converter.HtmlOptions.BrowserWidth, true);
                header.UseCopy = true;
            }
        }

        private HeaderFooterContext GetFooter(PdfOrientation pageOrientation)
        {
            var width = pageOrientation == PdfOrientation.Portrait ? PortraitLetterWidth : PortraitLetterHeight;

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
//                PageNumberHtml = GetHtml("DataViz/Viewer", "PageNumber"),
                PageNumberHtml = "<p align=\"right\" spacebefore=\"0\" spaceafter=\"0\"><font face=\"Arial,Helvetica,sans-serif\" size=\"2\" color=\"#3e4652\">Page {0} of {1}</font></p>",
            };
        }

        private void AddFooterToPage(Doc converter, HeaderFooterContext footer, int currentPage, int pageCount, bool forExport)
        {
            converter.Rect.Left = footer.Left;
            converter.Rect.Bottom = footer.Bottom;
            converter.Rect.Right = footer.Right * .80;  // Leave some room for the page #
            converter.Rect.Top = footer.Top;

            if (footer.UseCopy)
            {
                // Copy the footer from the first page
                converter.AddImageDoc(converter, 1, converter.Rect);
            }
            else
            {
                converter.AddImageHtml(footer.Html, true, Convert.ToInt32(converter.HtmlOptions.BrowserWidth * .80), true);
                footer.UseCopy = true;
            }

            if (!forExport)
            {
                // Add the page number
                var pageHtml = string.Format(footer.PageNumberHtml, currentPage, pageCount);
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
            public bool UseCopy { get; set; }
            public double Left { get; set; }
            public double Bottom { get; set; }
            public double Right { get; set; }
            public double Top { get; set; }
            public string Html { get; set; }
            public string PageNumberHtml { get; set; }
        }
    }
}
