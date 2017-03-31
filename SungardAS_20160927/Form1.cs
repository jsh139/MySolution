using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

using WebSupergoo.ABCpdf10;

namespace testapp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Render HTML";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(127, 50);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e) {
		
			string theBase = Directory.GetCurrentDirectory();
			string theRez = Directory.GetParent(theBase).Parent.FullName + "\\";

			RenderFileUrls(theRez, Directory.GetFiles(theRez, "*.html"));
			RenderFileUrls(theRez, Directory.GetFiles(theRez, "*.htm"));
			RenderFileUrls(theRez, Directory.GetFiles(theRez, "*.svg"));
		}

		private void RenderFileUrls(string theRez, string[] theFiles) {
			foreach (string theFile in theFiles) {
				using (Doc theDoc = new Doc()) {
                    
                    // JH
                    theDoc.Rect.Inset(72F, 36F);
                    theDoc.Rect.Bottom += 63;
                    // JH

					theDoc.HtmlOptions.Engine = EngineType.Gecko;
					theDoc.HtmlOptions.ImprovePageBreakAvoid = true;
					theDoc.HtmlOptions.AddLinks = true;

					int theID = theDoc.AddImageUrl("file://" + theFile);

					while (true) {
						if (!theDoc.Chainable(theID)) break;
						theDoc.Page = theDoc.AddPage();
						theID = theDoc.AddImageToChain(theID);
					}

				    var footerDoc = GetFooter();

					for (int i = 1; i <= theDoc.PageCount; i++) {
						theDoc.PageNumber = i;

                        // JH
                        AddFooter(theDoc, footerDoc);
                        // JH

                        theDoc.Flatten();
					}

					theDoc.Save(theRez + Path.GetFileNameWithoutExtension(theFile) + "_" + XSettings.Version.ToString() + ".pdf");
				}
			}
		}

        private void AddFooter(Doc converter, Doc footerDoc)
        {
            converter.Rect.Left = 72F;
            converter.Rect.Bottom = 36F;
            converter.Rect.Right = 540F;
            converter.Rect.Top = 96F;

            converter.AddImageDoc(footerDoc, 1, footerDoc.Rect);
	    }

        private Doc GetFooter()
        {
            var footerDoc = new Doc();

            var footerHtml =
                "\r\n<style>\r\n    body {\r\n        margin: 0;\r\n        padding: 0;\r\n    }\r\n</style>\r\n\r\n<div style=\"width: 100%; font-size: 12px; font-family: Arial,Helvetica,sans-serif; color: #3e4652; \">\r\n  This is some footer text.  \r\n</div>\r\n\r\n";

            footerDoc.HtmlOptions.Engine = EngineType.Gecko;
            footerDoc.HtmlOptions.ImprovePageBreakAvoid = true;
            footerDoc.HtmlOptions.AddLinks = true;

            footerDoc.Rect.Left = 72F;
            footerDoc.Rect.Bottom = 36F;
            footerDoc.Rect.Right = 540F;
            footerDoc.Rect.Top = 96F;

            footerDoc.AddImageHtml(footerHtml, true, footerDoc.HtmlOptions.BrowserWidth, true);

            return footerDoc;
        }
	}
}
