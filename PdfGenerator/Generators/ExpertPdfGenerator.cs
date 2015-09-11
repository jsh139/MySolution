#region Copyright © SunGard Availability Services

// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is 
// prohibited without the prior written consent of the copyright owner.

#endregion

using System;
using System.IO;
using System.Net;
using ExpertPdf.HtmlToPdf;

namespace PdfGenerator.Generators
{
    public class ExpertPdfGenerator : IPdfGenerator
    {
        private const float HeaderHeight = 56;
        private const float FooterHeight = 56;

        // Top and bottom margins currently set to 1/2 inch
        private const int VerticalMargins = 36;

        // Left and right Margins currently set to 1 inch
        private const int HorizontalMargins = 72;

        private const float HtmlViewerWidthInches = 8.5F;

        private const int PortraitPageWidth = 800;

        private const int LandscapePageWidth = 1122;

        private const float PortraitMultiplier = 73.4F;
        private const float LandscapeMultiplier = 101.5F;

        public byte[] GeneratePdf(PdfRequest request)
        {
            var pdfConverter = GetPdfConverter();

            var pageOrientation = request.Orientation == PdfOrientation.Portrait ? PDFPageOrientation.Portrait : PDFPageOrientation.Landscape;
            var baseUrl = request.BaseUrl;

            SetReportOptions(pdfConverter, pageOrientation);

            //SetupHeader(pdfConverter, pageOrientation);
            //SetupFooter(pdfConverter, pageOrientation, baseUrl);

            var html = HtmlTools.GetHtml(request.ConversionUrl);

            // This method will convert the html to pdf and build an ExperPdf.Document object
            var document = pdfConverter.GetPdfDocumentObjectFromHtmlString(html, baseUrl);

            var conversionSummary = pdfConverter.ConversionSummary;

            var pdfBytes = document.Save();
            document.Close();

            return pdfBytes;
        }

        private PdfConverter GetPdfConverter()
        {
            return new PdfConverter();
        }

        private void SetReportOptions(PdfConverter converter, PDFPageOrientation pageOrientation)
        {
            converter.PdfDocumentOptions.PdfPageOrientation = pageOrientation;
            converter.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;

            // This tells the converter to not scale the content, but instead to work within the specified viewer width.
            converter.PdfDocumentOptions.FitWidth = false;
            converter.PdfDocumentOptions.AutoSizePdfPage = false;
            converter.PageWidth = GetHtmlViewerWidth(pageOrientation);
            converter.ClipHtmlView = true;
            converter.ConversionDelay = 0;
            
            converter.PdfDocumentOptions.LeftMargin = HorizontalMargins;
            converter.PdfDocumentOptions.RightMargin = HorizontalMargins;
            converter.PdfDocumentOptions.TopMargin = VerticalMargins;
            converter.PdfDocumentOptions.BottomMargin = VerticalMargins;

            converter.NavigationTimeout = 3600;
        }

        private int GetHtmlViewerWidth(PDFPageOrientation pageOrientation)
        {
            float multiplier = pageOrientation == PDFPageOrientation.Landscape ? LandscapeMultiplier : PortraitMultiplier;
            return Convert.ToInt32(HtmlViewerWidthInches * multiplier);
        }

        private void SetupHeader(PdfConverter pdfConverter, PDFPageOrientation pageOrientation)
        {
            var html = string.Empty;

            if (string.IsNullOrWhiteSpace(html)) return;

            pdfConverter.PdfDocumentOptions.ShowHeader = true;
            pdfConverter.PdfHeaderOptions.HeaderHeight = HeaderHeight;

            var pageWidth = pageOrientation == PDFPageOrientation.Portrait ? PortraitPageWidth : LandscapePageWidth;
        }

        private void SetupFooter(PdfConverter pdfConverter, PDFPageOrientation pageOrientation, string baseUrl)
        {
            pdfConverter.PdfDocumentOptions.ShowFooter = true;
            pdfConverter.PdfFooterOptions.FooterHeight = FooterHeight;
            pdfConverter.PdfFooterOptions.DrawFooterLine = false;
        }
    }
}
