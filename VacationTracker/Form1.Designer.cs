namespace VacationTracker
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tabCalendar = new System.Windows.Forms.TableLayoutPanel();
			this.cboMonth = new System.Windows.Forms.ComboBox();
			this.btnAdvanceMonth = new System.Windows.Forms.Button();
			this.btnDecreaseMonth = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnDecreaseMonth);
			this.panel1.Controls.Add(this.btnAdvanceMonth);
			this.panel1.Controls.Add(this.cboMonth);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(808, 48);
			this.panel1.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 497);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(808, 69);
			this.panel2.TabIndex = 2;
			// 
			// tabCalendar
			// 
			this.tabCalendar.BackColor = System.Drawing.SystemColors.Window;
			this.tabCalendar.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tabCalendar.ColumnCount = 7;
			this.tabCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tabCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tabCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tabCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tabCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tabCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tabCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tabCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabCalendar.Location = new System.Drawing.Point(0, 48);
			this.tabCalendar.Name = "tabCalendar";
			this.tabCalendar.RowCount = 7;
			this.tabCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tabCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tabCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tabCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tabCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tabCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tabCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tabCalendar.Size = new System.Drawing.Size(808, 449);
			this.tabCalendar.TabIndex = 3;
			this.tabCalendar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabCalendar_MouseClick);
			// 
			// cboMonth
			// 
			this.cboMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cboMonth.FormattingEnabled = true;
			this.cboMonth.Location = new System.Drawing.Point(341, 12);
			this.cboMonth.Name = "cboMonth";
			this.cboMonth.Size = new System.Drawing.Size(121, 21);
			this.cboMonth.TabIndex = 0;
			this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.cboMonth_SelectedIndexChanged);
			// 
			// btnAdvanceMonth
			// 
			this.btnAdvanceMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnAdvanceMonth.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdvanceMonth.Location = new System.Drawing.Point(494, 12);
			this.btnAdvanceMonth.Name = "btnAdvanceMonth";
			this.btnAdvanceMonth.Size = new System.Drawing.Size(75, 23);
			this.btnAdvanceMonth.TabIndex = 1;
			this.btnAdvanceMonth.Text = "----->";
			this.btnAdvanceMonth.UseVisualStyleBackColor = true;
			this.btnAdvanceMonth.Click += new System.EventHandler(this.btnAdvanceMonth_Click);
			// 
			// btnDecreaseMonth
			// 
			this.btnDecreaseMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnDecreaseMonth.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDecreaseMonth.Location = new System.Drawing.Point(234, 12);
			this.btnDecreaseMonth.Name = "btnDecreaseMonth";
			this.btnDecreaseMonth.Size = new System.Drawing.Size(75, 23);
			this.btnDecreaseMonth.TabIndex = 2;
			this.btnDecreaseMonth.Text = "<-----";
			this.btnDecreaseMonth.UseVisualStyleBackColor = true;
			this.btnDecreaseMonth.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(808, 566);
			this.Controls.Add(this.tabCalendar);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TableLayoutPanel tabCalendar;
		private System.Windows.Forms.ComboBox cboMonth;
		private System.Windows.Forms.Button btnAdvanceMonth;
		private System.Windows.Forms.Button btnDecreaseMonth;
	}
}

