using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.IO;
using System.Windows.Forms;
using WebSupergoo.ABCpdf10;
using WebSupergoo.ABCpdf10.Operations;

namespace PdfShrinker
{
    public partial class Form1 : Form
    {
        private const string ConnectionString =
            @"data source=PhPaQASQL14\QA01;initial catalog=QA01_UATNM;user id=sa;password=Admin!Admin;Asynchronous Processing=True;MultipleActiveResultSets=True;Connect Timeout=30;TrustServerCertificate=True";
        private readonly ReportPdfDataStore _reportPdfDataStore;

        public Form1()
        {
            var database = new SqlDatabase(ConnectionString);
            _reportPdfDataStore = new ReportPdfDataStore(database);

            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            //var pdfBytes = _reportPdfDataStore.GetPdfBytes(71);
            //File.WriteAllBytes(@"C:\Temp\OriginalReport.pdf", pdfBytes);
            var pdfBytes = File.ReadAllBytes(@"C:\Temp\R10 - PDF-SBS-Landscape-11fields_01Oct2015 (1).pdf");

            ShrinkPdf(pdfBytes);
        }

        private void ShrinkPdf(byte[] pdfBytes)
        {
            var pdfDoc = new Doc();

            var oldDoc = new Doc();
            oldDoc.Read(pdfBytes);

            var count = oldDoc.PageCount;
            
            for (var i = 1; i <= count; i++)
            {
                pdfDoc.AddPage();
                pdfDoc.PageNumber = i;
                pdfDoc.AddImageDoc(oldDoc, i, null);
                pdfDoc.Flatten();
            }

            pdfDoc.Save(@"C:\Temp\ShrunkenReport.pdf");
            pdfDoc.Clear();
        }
    }
}
