using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace LettersAndNumbers
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private enum Mode
		{
			Random,
			Explicit
		}

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdoRandom;
		private System.Windows.Forms.CheckBox chkNumbers;
		private System.Windows.Forms.RichTextBox txtDisplay;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton rdoExplicit;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private string m_ValidChars = null;
		private bool m_IncludeNums = false;
		private Mode m_Mode = Mode.Random;
		private string m_Font = "Tahoma";
		private Color m_TextColor = Color.Red;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.rdoExplicit = new System.Windows.Forms.RadioButton();
			this.rdoRandom = new System.Windows.Forms.RadioButton();
			this.chkNumbers = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtDisplay = new System.Windows.Forms.RichTextBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(560, 55);
			this.panel1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.rdoExplicit);
			this.groupBox1.Controls.Add(this.rdoRandom);
			this.groupBox1.Controls.Add(this.chkNumbers);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(560, 48);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Options";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.Location = new System.Drawing.Point(304, 17);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 19);
			this.button1.TabIndex = 2;
			this.button1.Text = "Set Font Style";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// rdoExplicit
			// 
			this.rdoExplicit.Location = new System.Drawing.Point(96, 20);
			this.rdoExplicit.Name = "rdoExplicit";
			this.rdoExplicit.Size = new System.Drawing.Size(64, 16);
			this.rdoExplicit.TabIndex = 1;
			this.rdoExplicit.Text = "Explicit";
			// 
			// rdoRandom
			// 
			this.rdoRandom.Checked = true;
			this.rdoRandom.Location = new System.Drawing.Point(16, 20);
			this.rdoRandom.Name = "rdoRandom";
			this.rdoRandom.Size = new System.Drawing.Size(72, 16);
			this.rdoRandom.TabIndex = 0;
			this.rdoRandom.TabStop = true;
			this.rdoRandom.Text = "Random";
			this.rdoRandom.CheckedChanged += new System.EventHandler(this.ModeChanged);
			// 
			// chkNumbers
			// 
			this.chkNumbers.Location = new System.Drawing.Point(176, 20);
			this.chkNumbers.Name = "chkNumbers";
			this.chkNumbers.Size = new System.Drawing.Size(120, 16);
			this.chkNumbers.TabIndex = 1;
			this.chkNumbers.Text = "Include Numbers?";
			this.chkNumbers.CheckedChanged += new System.EventHandler(this.chkNumbers_CheckedChanged);
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(560, 5);
			this.panel2.TabIndex = 2;
			// 
			// txtDisplay
			// 
			this.txtDisplay.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDisplay.Location = new System.Drawing.Point(0, 55);
			this.txtDisplay.Name = "txtDisplay";
			this.txtDisplay.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.txtDisplay.Size = new System.Drawing.Size(560, 362);
			this.txtDisplay.TabIndex = 1;
			this.txtDisplay.Text = "";
			this.txtDisplay.WordWrap = false;
			this.txtDisplay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDisplay_KeyPress);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																											 this.menuItem1,
																											 this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																											 this.menuItem2});
			this.menuItem1.Text = "&File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "&Exit";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																											 this.menuItem4,
																											 this.menuItem5});
			this.menuItem3.Text = "&Help";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 0;
			this.menuItem4.Text = "&Overview";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 1;
			this.menuItem5.Text = "About";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// fontDialog1
			// 
			this.fontDialog1.Color = System.Drawing.Color.Red;
			this.fontDialog1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.fontDialog1.ShowColor = true;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(560, 417);
			this.Controls.Add(this.txtDisplay);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Letters and Numbers!";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
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

		private void ModeChanged(object sender, System.EventArgs e)
		{
			if (rdoExplicit.Checked)
				m_Mode = Mode.Explicit;
			else
				m_Mode = Mode.Random;

			chkNumbers.Enabled = (m_Mode == Mode.Random);
		}

		private void chkNumbers_CheckedChanged(object sender, System.EventArgs e)
		{
			m_IncludeNums = chkNumbers.Checked;
			BuildValidChars();
		}

		private void BuildValidChars()
		{
			int idx = 0;
			int howmany = 26;
			m_ValidChars = "";

			if (m_IncludeNums)
				howmany += 9;

			byte[] bytes = new byte[howmany];

			ASCIIEncoding a = new ASCIIEncoding();
         
			for (int i=65; i <= 90; i++,idx++)
				bytes[idx] = Convert.ToByte(i);
//			for (int i=97; i <= 122; i++,idx++)
//				bytes[idx] = Convert.ToByte(i);

			if (m_IncludeNums)
				for (int i=49; i <= 57; i++,idx++)
					bytes[idx] = Convert.ToByte(i);

			m_ValidChars = a.GetString(bytes);
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			BuildValidChars();
		}

		private void txtDisplay_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			char CharToDisplay;
			float fontsize = txtDisplay.Height * .75f;

			if (m_Mode == Mode.Explicit)
				CharToDisplay = e.KeyChar;
			else
			{
				int i = 0;
				Random r = new Random();
				i = r.Next(m_ValidChars.Length-1);
				CharToDisplay = m_ValidChars[i];
			}

			txtDisplay.Text = "";
			txtDisplay.SelectionColor = m_TextColor;
			txtDisplay.SelectionFont = new Font(m_Font, fontsize, FontStyle.Bold, GraphicsUnit.Pixel);
			txtDisplay.SelectionAlignment = HorizontalAlignment.Center;
			txtDisplay.AppendText(CharToDisplay.ToString());
			e.Handled = true;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (fontDialog1.ShowDialog() == DialogResult.OK)
			{
				m_Font = fontDialog1.Font.Name;
				m_TextColor = fontDialog1.Color;
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			Overview o = new Overview();
			o.ShowDialog(this);
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			About a = new About();
			a.ShowDialog(this);
		}
	}
}
