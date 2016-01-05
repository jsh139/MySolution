using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PdfGenerator.Generators;

namespace PdfGenerator
{
    public partial class FrmPdfGenerator : Form
    {
        private const string PdfViewer = @"C:\Program Files (x86)\Nuance\Power PDF\bin\NuancePDF.exe";
        private Dictionary<RadioButton, IPdfGenerator> _pdfGeneratorMap; 

        public FrmPdfGenerator()
        {
            InitializeComponent();
            MapPdfGenerators();
        }

        private void MapPdfGenerators()
        {
            _pdfGeneratorMap = grpPdfEngine.Controls.OfType<RadioButton>()
                .ToDictionary(c => c, c => CreatePdfGenerator(c.Name));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            btnConvert.Enabled = false;

            var request = new PdfRequest
            {
                BaseUrl = txtBaseUrl.Text,
                ConversionUrl = txtReportUrl.Text,
                Format = rdoTabular.Checked ? ReportFormat.Tabular : ReportFormat.SideBySide,
                Orientation = rdoPortrait.Checked ? PdfOrientation.Portrait : PdfOrientation.Landscape,
                OutputFile = txtOutput.Text,
            };

            var gen = GetPdfGenerator();
            var pdfBytes = gen.GeneratePdf(request);

            File.WriteAllBytes(request.OutputFile, pdfBytes);

            Cursor.Current = Cursors.Default;
            btnConvert.Enabled = true;

            if (chkOpenResult.Checked && File.Exists(PdfViewer))
            {
                Process.Start(PdfViewer, request.OutputFile);
            }
        }

        private IPdfGenerator CreatePdfGenerator(string name)
        {
            IPdfGenerator gen = null;

            switch (name)
            {
                case "rdoEvo":
                    gen = new EvoPdfGenerator();
                    break;
                case "rdoNReco":
                    gen = new NRecoPdfGenerator();
                    break;
                case "rdoDynamicPdf":
                    gen = new DynamicPdfGenerator();
                    break;
                case "rdoAbc":
                    gen = new AbcPdfGenerator();
                    break;
                case "rdoExpert":
                    gen = new ExpertPdfGenerator();
                    break;
                case "rdoHiQ":
                    gen = new HiQPdfGenerator();
                    break;
            }

            return gen;
        }

        private IPdfGenerator GetPdfGenerator()
        {
            return grpPdfEngine.Controls.OfType<RadioButton>()
                .Where(c => c.Checked)
                .Select(c => _pdfGeneratorMap[c])
                .FirstOrDefault();
        }
    }
}
