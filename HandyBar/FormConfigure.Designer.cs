namespace HandyBar
{
	partial class FormConfigure
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
			this.dataGridViewShortcuts = new System.Windows.Forms.DataGridView();
			this.Filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Arguments = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Tooltip = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonMoveDown = new System.Windows.Forms.Button();
			this.buttonMoveUp = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewShortcuts)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridViewShortcuts
			// 
			this.dataGridViewShortcuts.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridViewShortcuts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewShortcuts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Filename,
            this.Arguments,
            this.Tooltip});
			this.dataGridViewShortcuts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewShortcuts.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewShortcuts.Name = "dataGridViewShortcuts";
			this.dataGridViewShortcuts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewShortcuts.Size = new System.Drawing.Size(665, 336);
			this.dataGridViewShortcuts.TabIndex = 0;
			this.dataGridViewShortcuts.SelectionChanged += new System.EventHandler(this.dataGridViewShortcuts_SelectionChanged);
			// 
			// Filename
			// 
			this.Filename.HeaderText = "Filename";
			this.Filename.Name = "Filename";
			this.Filename.Width = 300;
			// 
			// Arguments
			// 
			this.Arguments.HeaderText = "Arguments";
			this.Arguments.Name = "Arguments";
			this.Arguments.Width = 150;
			// 
			// Tooltip
			// 
			this.Tooltip.HeaderText = "Tooltip";
			this.Tooltip.Name = "Tooltip";
			this.Tooltip.Width = 150;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonCancel);
			this.panel1.Controls.Add(this.buttonOK);
			this.panel1.Controls.Add(this.buttonMoveDown);
			this.panel1.Controls.Add(this.buttonMoveUp);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 352);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(689, 36);
			this.panel1.TabIndex = 1;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(470, 7);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(361, 7);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonMoveDown
			// 
			this.buttonMoveDown.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonMoveDown.Location = new System.Drawing.Point(252, 7);
			this.buttonMoveDown.Name = "buttonMoveDown";
			this.buttonMoveDown.Size = new System.Drawing.Size(75, 23);
			this.buttonMoveDown.TabIndex = 1;
			this.buttonMoveDown.Text = "Move Down";
			this.buttonMoveDown.UseVisualStyleBackColor = true;
			this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
			// 
			// buttonMoveUp
			// 
			this.buttonMoveUp.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonMoveUp.Location = new System.Drawing.Point(143, 7);
			this.buttonMoveUp.Name = "buttonMoveUp";
			this.buttonMoveUp.Size = new System.Drawing.Size(75, 23);
			this.buttonMoveUp.TabIndex = 0;
			this.buttonMoveUp.Text = "Move Up";
			this.buttonMoveUp.UseVisualStyleBackColor = true;
			this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(10, 10, 10, 2);
			this.panel2.Size = new System.Drawing.Size(689, 352);
			this.panel2.TabIndex = 2;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.dataGridViewShortcuts);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(10, 10);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(669, 340);
			this.panel3.TabIndex = 1;
			// 
			// FormConfigure
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(689, 388);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormConfigure";
			this.Text = "Configure Shortcuts";
			this.Load += new System.EventHandler(this.FormConfigure_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewShortcuts)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewShortcuts;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonMoveDown;
		private System.Windows.Forms.Button buttonMoveUp;
		private System.Windows.Forms.DataGridViewTextBoxColumn Filename;
		private System.Windows.Forms.DataGridViewTextBoxColumn Arguments;
		private System.Windows.Forms.DataGridViewTextBoxColumn Tooltip;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
	}
}