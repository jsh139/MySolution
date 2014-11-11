using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ShortcutBar
{
	/// <summary>
	/// Summary description for RestartJobs.
	/// </summary>
	public class Prompt : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label labPrompt;
		private System.Windows.Forms.TextBox txtPrompt;
		private System.Windows.Forms.Button btnOk;
		public string Result = null;

		public Prompt(string Prompt, string Title, string ButtonText, string InitialText)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			labPrompt.Text = Prompt;
			this.Text = Title;
			btnOk.Text = ButtonText;
			txtPrompt.Text = InitialText;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Prompt));
			this.labPrompt = new System.Windows.Forms.Label();
			this.txtPrompt = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labPrompt
			// 
			this.labPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labPrompt.Location = new System.Drawing.Point(25, 16);
			this.labPrompt.Name = "labPrompt";
			this.labPrompt.Size = new System.Drawing.Size(224, 16);
			this.labPrompt.TabIndex = 0;
			this.labPrompt.Text = "Label Text";
			// 
			// txtPrompt
			// 
			this.txtPrompt.Location = new System.Drawing.Point(25, 48);
			this.txtPrompt.Name = "txtPrompt";
			this.txtPrompt.Size = new System.Drawing.Size(224, 20);
			this.txtPrompt.TabIndex = 1;
			this.txtPrompt.Text = "";
			this.txtPrompt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrompt_KeyDown);
			this.txtPrompt.TextChanged += new System.EventHandler(this.txtPrompt_TextChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(154, 80);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(95, 24);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Enabled = false;
			this.btnOk.Location = new System.Drawing.Point(26, 80);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(95, 23);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "Button Text";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// Prompt
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(274, 111);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txtPrompt);
			this.Controls.Add(this.labPrompt);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Prompt";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Prompt Text";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			Result = txtPrompt.Text;
		}

		private void txtPrompt_TextChanged(object sender, System.EventArgs e)
		{
			btnOk.Enabled = (txtPrompt.Text.Trim() != "");
		}

		private void txtPrompt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && btnOk.Enabled)
			{
				btnOk_Click(btnOk, null);
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else if (e.KeyCode == Keys.Return && !btnOk.Enabled)
			{
				this.DialogResult = DialogResult.Cancel;
				this.Close();
			}
		}
	}
}
