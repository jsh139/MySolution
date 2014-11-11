namespace DependencyInjection
{
	partial class Form1
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
			this.txtLog = new System.Windows.Forms.RichTextBox();
			this.btnLog = new System.Windows.Forms.Button();
			this.btnSMS = new System.Windows.Forms.Button();
			this.btnEmail = new System.Windows.Forms.Button();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtLog
			// 
			this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.txtLog.Location = new System.Drawing.Point(0, 132);
			this.txtLog.Name = "txtLog";
			this.txtLog.Size = new System.Drawing.Size(487, 190);
			this.txtLog.TabIndex = 0;
			this.txtLog.Text = "";
			// 
			// btnLog
			// 
			this.btnLog.Location = new System.Drawing.Point(39, 44);
			this.btnLog.Name = "btnLog";
			this.btnLog.Size = new System.Drawing.Size(75, 23);
			this.btnLog.TabIndex = 1;
			this.btnLog.Text = "Log To File";
			this.btnLog.UseVisualStyleBackColor = true;
			this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
			// 
			// btnSMS
			// 
			this.btnSMS.Location = new System.Drawing.Point(160, 44);
			this.btnSMS.Name = "btnSMS";
			this.btnSMS.Size = new System.Drawing.Size(75, 23);
			this.btnSMS.TabIndex = 2;
			this.btnSMS.Text = "Send SMS";
			this.btnSMS.UseVisualStyleBackColor = true;
			this.btnSMS.Click += new System.EventHandler(this.btnSMS_Click);
			// 
			// btnEmail
			// 
			this.btnEmail.Location = new System.Drawing.Point(288, 44);
			this.btnEmail.Name = "btnEmail";
			this.btnEmail.Size = new System.Drawing.Size(75, 23);
			this.btnEmail.TabIndex = 3;
			this.btnEmail.Text = "Send Email";
			this.btnEmail.UseVisualStyleBackColor = true;
			this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
			// 
			// txtMessage
			// 
			this.txtMessage.Location = new System.Drawing.Point(39, 90);
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(324, 20);
			this.txtMessage.TabIndex = 4;
			this.txtMessage.Text = "Sample text";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(487, 322);
			this.Controls.Add(this.txtMessage);
			this.Controls.Add(this.btnEmail);
			this.Controls.Add(this.btnSMS);
			this.Controls.Add(this.btnLog);
			this.Controls.Add(this.txtLog);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox txtLog;
		private System.Windows.Forms.Button btnLog;
		private System.Windows.Forms.Button btnSMS;
		private System.Windows.Forms.Button btnEmail;
		private System.Windows.Forms.TextBox txtMessage;
	}
}

