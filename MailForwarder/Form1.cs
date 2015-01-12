using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using Microsoft.Office.Interop.Outlook;

namespace MailForwarder
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RichTextBox txtMain;
		private System.Windows.Forms.Label label1;
		private System.Timers.Timer timer1;
		private System.Windows.Forms.Button btnForward;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private bool m_Forwarding = false;
		private System.Windows.Forms.TextBox txtEmailAddress;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private CheckBox chkForwardAll;
		private Hashtable m_Mails;
		private delegate void UpdateTxtDelegate(string Message);
		private delegate void UpdateStatusDelegate(string Message);

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.txtEmailAddress = new System.Windows.Forms.TextBox();
			this.btnForward = new System.Windows.Forms.Button();
			this.txtMain = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Timers.Timer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.chkForwardAll = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			this.SuspendLayout();
			// 
			// txtEmailAddress
			// 
			this.txtEmailAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtEmailAddress.Location = new System.Drawing.Point(118, 20);
			this.txtEmailAddress.Name = "txtEmailAddress";
			this.txtEmailAddress.Size = new System.Drawing.Size(192, 20);
			this.txtEmailAddress.TabIndex = 0;
			this.txtEmailAddress.Text = "jsh139@gmail.com";
			// 
			// btnForward
			// 
			this.btnForward.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnForward.Location = new System.Drawing.Point(118, 64);
			this.btnForward.Name = "btnForward";
			this.btnForward.Size = new System.Drawing.Size(104, 23);
			this.btnForward.TabIndex = 1;
			this.btnForward.Text = "&Begin Forwarding";
			this.btnForward.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtMain
			// 
			this.txtMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtMain.Location = new System.Drawing.Point(0, 96);
			this.txtMain.Name = "txtMain";
			this.txtMain.ReadOnly = true;
			this.txtMain.Size = new System.Drawing.Size(349, 159);
			this.txtMain.TabIndex = 2;
			this.txtMain.Text = "";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.Location = new System.Drawing.Point(30, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Email Address:";
			// 
			// timer1
			// 
			this.timer1.Interval = 60000;
			this.timer1.SynchronizingObject = this;
			this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.chkForwardAll);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(349, 96);
			this.panel1.TabIndex = 4;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 255);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(349, 22);
			this.statusBar1.TabIndex = 5;
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.statusBarPanel1.Name = "statusBarPanel1";
			this.statusBarPanel1.Text = "Idle";
			this.statusBarPanel1.Width = 32;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel2.Name = "statusBarPanel2";
			this.statusBarPanel2.Text = "Not Forwarding";
			this.statusBarPanel2.Width = 300;
			// 
			// chkForwardAll
			// 
			this.chkForwardAll.AutoSize = true;
			this.chkForwardAll.Location = new System.Drawing.Point(238, 68);
			this.chkForwardAll.Name = "chkForwardAll";
			this.chkForwardAll.Size = new System.Drawing.Size(83, 17);
			this.chkForwardAll.TabIndex = 0;
			this.chkForwardAll.Text = "Full Forward";
			this.chkForwardAll.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(349, 277);
			this.Controls.Add(this.txtMain);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnForward);
			this.Controls.Add(this.txtEmailAddress);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(328, 300);
			this.Name = "Form1";
			this.Text = "Mail Forwarder";
			((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (m_Forwarding)
			{
				m_Forwarding = false;
				m_Mails.Clear();
				btnForward.Text = "&Begin Forwarding";
				statusBarPanel1.Text = "Idle";
				statusBarPanel2.Text = "Not Forwarding";
				timer1.Enabled = false;
			}
			else
			{
				m_Forwarding = true;
				m_Mails = new Hashtable();
				btnForward.Text = "&End Forwarding";
				statusBarPanel1.Text = "Sleeping";
				statusBarPanel2.Text = "Forwarding";
				timer1.Enabled = true;
				timer1_Elapsed(sender, null);
			}
		}

		private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			timer1.Enabled = false;
			UpdateStatus("Checking mail...");

			Thread t = new Thread(new ThreadStart(CheckMail));			
			t.Name = "MailCheck";
			t.Start();

			while (t.IsAlive)
			{
				System.Windows.Forms.Application.DoEvents();
				Thread.Sleep(100);
			}

			t = null;
				
			UpdateStatus("Sleeping");
			timer1.Enabled = true;
			System.Windows.Forms.Application.DoEvents();
		}

		private void CheckMail()
		{
			ApplicationClass myOlApp = new ApplicationClass();
			NameSpace newNS = myOlApp.GetNamespace("MAPI");
			MAPIFolder mapi1 = newNS.GetDefaultFolder(OlDefaultFolders.olFolderInbox);

			foreach (System.Object o in mapi1.Items)
			{
				if (o is MailItem)
				{
					MailItem item = (MailItem)o;

					if (item.UnRead)
					{
						if (!m_Mails.ContainsKey(item.EntryID))
						{
							m_Mails.Add(item.EntryID, null);
							if (chkForwardAll.Checked)
								FullForward(item);
							else
								ForwardMail(item);

							string Message = String.Format("Forwarded {0} to {1} at {2}\r\n\r\n",
								ConstructSubject(item), txtEmailAddress.Text, DateTime.Now);

							txtMain.Invoke(new UpdateTxtDelegate(UpdateTxt), new Object[] {Message});
						}
					}
				}
			}
		}

		private string ConstructKey(MailItem item)
		{
			return String.Format("{0}:{1}:{2}",
				item.SenderName, item.Subject, item.ReceivedTime);
		}

		private string ConstructSubject(MailItem item)
		{
			return String.Format("From: {0}; Subject: {1}",
				item.SenderName, item.Subject);
		}

		private string ConstructMailMessage(MailItem item)
		{
			string MailMessage = String.Format(
				"-----Original Message-----\r\n" +
				"From: \"{0}\" <{1}>\r\n" +
				"Sent: {2}\r\n" +
				"To: {3}\r\n" +
				"Subject: {4}\r\n\r\n" +
				"{5}",
				item.SenderName, item.SenderEmailAddress, item.ReceivedTime,
				ListRecipients(item.Recipients), item.Subject, item.Body);

			return MailMessage;
		}

		private string ListRecipients(Recipients r)
		{
			string Recip = "";

			for (int i=1; i <= r.Count; i++)
				Recip += r[i].Name + "; ";

			Recip = Recip.Trim().TrimEnd(';');

			return Recip;
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			txtMain.Top = 98;
		}

		private void ForwardMail(MailItem item)
		{
            //CourtLinkMail mail = new CourtLinkMail();

            //try
            //{
            //    mail.AppendFooter = false;
            //    mail.EmailAddress = txtEmailAddress.Text;
            //    mail.EmailSubject = ConstructSubject(item);
            //    mail.EmailText = ConstructMailMessage(item);
            //    mail.EmailFrom = "Josh.Hoffman@LexisNexis.com";

            //    mail.Send();
            //}
            //catch (System.Exception e)
            //{
            //    MessageBox.Show(e.Message, "Error sending mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
		}

		private void FullForward(MailItem item)
		{
            //CourtLinkMail mail = new CourtLinkMail();

            //try
            //{
            //    mail.AppendFooter = false;
            //    mail.EmailAddress = txtEmailAddress.Text;
            //    mail.EmailSubject = item.Subject;
            //    mail.EmailText = item.Body;
            //    mail.EmailFrom = item.SenderEmailAddress;

            //    mail.Send();
            //}
            //catch (System.Exception e)
            //{
            //    MessageBox.Show(e.Message, "Error sending mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
		}

		private void UpdateTxt(string Message)
		{
			txtMain.AppendText(Message);
		}

		private void UpdateStatus(string Message)
		{
			statusBarPanel1.Text = Message;
		}
	}
}
