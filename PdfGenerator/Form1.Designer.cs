namespace PdfGenerator
{
    partial class FrmPdfGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtReportUrl = new System.Windows.Forms.TextBox();
            this.txtBaseUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.chkOpenResult = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoLandscape = new System.Windows.Forms.RadioButton();
            this.rdoPortrait = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoSideBySide = new System.Windows.Forms.RadioButton();
            this.rdoTabular = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.grpPdfEngine = new System.Windows.Forms.GroupBox();
            this.rdoHiQ = new System.Windows.Forms.RadioButton();
            this.rdoExpert = new System.Windows.Forms.RadioButton();
            this.rdoAbc = new System.Windows.Forms.RadioButton();
            this.rdoDynamicPdf = new System.Windows.Forms.RadioButton();
            this.rdoNReco = new System.Windows.Forms.RadioButton();
            this.rdoEvo = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpPdfEngine.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtReportUrl
            // 
            this.txtReportUrl.Location = new System.Drawing.Point(133, 36);
            this.txtReportUrl.Name = "txtReportUrl";
            this.txtReportUrl.Size = new System.Drawing.Size(448, 22);
            this.txtReportUrl.TabIndex = 0;
            this.txtReportUrl.Text = "http://localhost:8082/Test/TabularReport-BrokenHeadings.html";
            // 
            // txtBaseUrl
            // 
            this.txtBaseUrl.Location = new System.Drawing.Point(133, 83);
            this.txtBaseUrl.Name = "txtBaseUrl";
            this.txtBaseUrl.Size = new System.Drawing.Size(448, 22);
            this.txtBaseUrl.TabIndex = 1;
            this.txtBaseUrl.Text = "http://localhost:8082/Test/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Url To Convert:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Base Url:";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(506, 382);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 27);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkOpenResult
            // 
            this.chkOpenResult.AutoSize = true;
            this.chkOpenResult.Checked = true;
            this.chkOpenResult.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenResult.Location = new System.Drawing.Point(133, 308);
            this.chkOpenResult.Name = "chkOpenResult";
            this.chkOpenResult.Size = new System.Drawing.Size(154, 21);
            this.chkOpenResult.TabIndex = 5;
            this.chkOpenResult.Text = "Open Resultant Pdf";
            this.chkOpenResult.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoLandscape);
            this.groupBox1.Controls.Add(this.rdoPortrait);
            this.groupBox1.Location = new System.Drawing.Point(133, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 51);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orientation";
            // 
            // rdoLandscape
            // 
            this.rdoLandscape.AutoSize = true;
            this.rdoLandscape.Location = new System.Drawing.Point(112, 22);
            this.rdoLandscape.Name = "rdoLandscape";
            this.rdoLandscape.Size = new System.Drawing.Size(99, 21);
            this.rdoLandscape.TabIndex = 1;
            this.rdoLandscape.Text = "Landscape";
            this.rdoLandscape.UseVisualStyleBackColor = true;
            // 
            // rdoPortrait
            // 
            this.rdoPortrait.AutoSize = true;
            this.rdoPortrait.Checked = true;
            this.rdoPortrait.Location = new System.Drawing.Point(6, 21);
            this.rdoPortrait.Name = "rdoPortrait";
            this.rdoPortrait.Size = new System.Drawing.Size(75, 21);
            this.rdoPortrait.TabIndex = 0;
            this.rdoPortrait.TabStop = true;
            this.rdoPortrait.Text = "Portrait";
            this.rdoPortrait.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoSideBySide);
            this.groupBox2.Controls.Add(this.rdoTabular);
            this.groupBox2.Location = new System.Drawing.Point(133, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 54);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report Format";
            // 
            // rdoSideBySide
            // 
            this.rdoSideBySide.AutoSize = true;
            this.rdoSideBySide.Location = new System.Drawing.Point(112, 22);
            this.rdoSideBySide.Name = "rdoSideBySide";
            this.rdoSideBySide.Size = new System.Drawing.Size(108, 21);
            this.rdoSideBySide.TabIndex = 1;
            this.rdoSideBySide.Text = "Side by Side";
            this.rdoSideBySide.UseVisualStyleBackColor = true;
            // 
            // rdoTabular
            // 
            this.rdoTabular.AutoSize = true;
            this.rdoTabular.Checked = true;
            this.rdoTabular.Location = new System.Drawing.Point(7, 22);
            this.rdoTabular.Name = "rdoTabular";
            this.rdoTabular.Size = new System.Drawing.Size(78, 21);
            this.rdoTabular.TabIndex = 0;
            this.rdoTabular.TabStop = true;
            this.rdoTabular.Text = "Tabular";
            this.rdoTabular.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Pdf Output:";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(133, 131);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(448, 22);
            this.txtOutput.TabIndex = 9;
            this.txtOutput.Text = "C:\\Temp\\Report.pdf";
            // 
            // grpPdfEngine
            // 
            this.grpPdfEngine.Controls.Add(this.rdoHiQ);
            this.grpPdfEngine.Controls.Add(this.rdoExpert);
            this.grpPdfEngine.Controls.Add(this.rdoAbc);
            this.grpPdfEngine.Controls.Add(this.rdoDynamicPdf);
            this.grpPdfEngine.Controls.Add(this.rdoNReco);
            this.grpPdfEngine.Controls.Add(this.rdoEvo);
            this.grpPdfEngine.Location = new System.Drawing.Point(381, 180);
            this.grpPdfEngine.Name = "grpPdfEngine";
            this.grpPdfEngine.Size = new System.Drawing.Size(200, 186);
            this.grpPdfEngine.TabIndex = 11;
            this.grpPdfEngine.TabStop = false;
            this.grpPdfEngine.Text = "Conversion Engine";
            // 
            // rdoHiQ
            // 
            this.rdoHiQ.AutoSize = true;
            this.rdoHiQ.Location = new System.Drawing.Point(7, 157);
            this.rdoHiQ.Name = "rdoHiQ";
            this.rdoHiQ.Size = new System.Drawing.Size(78, 21);
            this.rdoHiQ.TabIndex = 5;
            this.rdoHiQ.Text = "HiQ Pdf";
            this.rdoHiQ.UseVisualStyleBackColor = true;
            // 
            // rdoExpert
            // 
            this.rdoExpert.AutoSize = true;
            this.rdoExpert.Location = new System.Drawing.Point(7, 130);
            this.rdoExpert.Name = "rdoExpert";
            this.rdoExpert.Size = new System.Drawing.Size(94, 21);
            this.rdoExpert.TabIndex = 4;
            this.rdoExpert.Text = "Expert Pdf";
            this.rdoExpert.UseVisualStyleBackColor = true;
            // 
            // rdoAbc
            // 
            this.rdoAbc.AutoSize = true;
            this.rdoAbc.Checked = true;
            this.rdoAbc.Location = new System.Drawing.Point(7, 103);
            this.rdoAbc.Name = "rdoAbc";
            this.rdoAbc.Size = new System.Drawing.Size(78, 21);
            this.rdoAbc.TabIndex = 3;
            this.rdoAbc.TabStop = true;
            this.rdoAbc.Text = "Abc Pdf";
            this.rdoAbc.UseVisualStyleBackColor = true;
            // 
            // rdoDynamicPdf
            // 
            this.rdoDynamicPdf.AutoSize = true;
            this.rdoDynamicPdf.Location = new System.Drawing.Point(7, 76);
            this.rdoDynamicPdf.Name = "rdoDynamicPdf";
            this.rdoDynamicPdf.Size = new System.Drawing.Size(108, 21);
            this.rdoDynamicPdf.TabIndex = 2;
            this.rdoDynamicPdf.Text = "Dynamic Pdf";
            this.rdoDynamicPdf.UseVisualStyleBackColor = true;
            // 
            // rdoNReco
            // 
            this.rdoNReco.AutoSize = true;
            this.rdoNReco.Location = new System.Drawing.Point(7, 49);
            this.rdoNReco.Name = "rdoNReco";
            this.rdoNReco.Size = new System.Drawing.Size(72, 21);
            this.rdoNReco.TabIndex = 1;
            this.rdoNReco.Text = "NReco";
            this.rdoNReco.UseVisualStyleBackColor = true;
            // 
            // rdoEvo
            // 
            this.rdoEvo.AutoSize = true;
            this.rdoEvo.Location = new System.Drawing.Point(7, 22);
            this.rdoEvo.Name = "rdoEvo";
            this.rdoEvo.Size = new System.Drawing.Size(53, 21);
            this.rdoEvo.TabIndex = 0;
            this.rdoEvo.Text = "Evo";
            this.rdoEvo.UseVisualStyleBackColor = true;
            // 
            // FrmPdfGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 421);
            this.Controls.Add(this.grpPdfEngine);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkOpenResult);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBaseUrl);
            this.Controls.Add(this.txtReportUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(620, 406);
            this.Name = "FrmPdfGenerator";
            this.Text = "PDF Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpPdfEngine.ResumeLayout(false);
            this.grpPdfEngine.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReportUrl;
        private System.Windows.Forms.TextBox txtBaseUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.CheckBox chkOpenResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoLandscape;
        private System.Windows.Forms.RadioButton rdoPortrait;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoSideBySide;
        private System.Windows.Forms.RadioButton rdoTabular;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.GroupBox grpPdfEngine;
        private System.Windows.Forms.RadioButton rdoAbc;
        private System.Windows.Forms.RadioButton rdoDynamicPdf;
        private System.Windows.Forms.RadioButton rdoNReco;
        private System.Windows.Forms.RadioButton rdoEvo;
        private System.Windows.Forms.RadioButton rdoExpert;
        private System.Windows.Forms.RadioButton rdoHiQ;
    }
}

