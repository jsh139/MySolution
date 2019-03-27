namespace HandyBar
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addShortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeShortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLocationStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFullPathStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.topMostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripLabelDateTime = new System.Windows.Forms.ToolStripLabel();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.pictureBoxInsertionBar = new System.Windows.Forms.PictureBox();
			this.pictureBoxInsertionBarSerif1 = new System.Windows.Forms.PictureBox();
			this.pictureBoxInsertionBarSerif2 = new System.Windows.Forms.PictureBox();
			this.pictureBoxInsertionBarSerif3 = new System.Windows.Forms.PictureBox();
			this.pictureBoxInsertionBarSerif4 = new System.Windows.Forms.PictureBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStrip.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInsertionBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInsertionBarSerif1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInsertionBarSerif2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInsertionBarSerif3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInsertionBarSerif4)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.AllowDrop = true;
			this.toolStrip.ContextMenuStrip = this.contextMenuStrip;
			this.toolStrip.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelDateTime});
			this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
			this.toolStrip.Size = new System.Drawing.Size(296, 25);
			this.toolStrip.TabIndex = 6;
			this.toolStrip.Text = "toolStrip1";
			this.toolStrip.DragLeave += new System.EventHandler(this.toolStrip_DragLeave);
			this.toolStrip.DragOver += new System.Windows.Forms.DragEventHandler(this.toolStrip_DragOver);
			this.toolStrip.MouseEnter += new System.EventHandler(this.toolStrip_MouseEnter);
			this.toolStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStrip_MouseDown);
			this.toolStrip.DragEnter += new System.Windows.Forms.DragEventHandler(this.toolStrip_DragEnter);
			this.toolStrip.DragDrop += new System.Windows.Forms.DragEventHandler(this.toolStrip_DragDrop);
			this.toolStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStrip_MouseMove);
			this.toolStrip.MouseLeave += new System.EventHandler(this.toolStrip_MouseLeave);
			this.toolStrip.Click += new System.EventHandler(this.toolStrip_Click);
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addShortcutToolStripMenuItem,
            this.removeShortcutToolStripMenuItem,
            this.configureToolStripMenuItem,
            this.toolStripSeparator3,
            this.copyFullPathStripMenuItem,
            this.openLocationStripMenuItem,
            this.toolStripSeparator1,
            this.topMostToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeToolStripMenuItem});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(166, 126);
			this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
			// 
			// addShortcutToolStripMenuItem
			// 
			this.addShortcutToolStripMenuItem.Name = "addShortcutToolStripMenuItem";
			this.addShortcutToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.addShortcutToolStripMenuItem.Text = "Add Shortcut ...";
			this.addShortcutToolStripMenuItem.Click += new System.EventHandler(this.addShortcutToolStripMenuItem_Click);
			// 
			// removeShortcutToolStripMenuItem
			// 
			this.removeShortcutToolStripMenuItem.Name = "removeShortcutToolStripMenuItem";
			this.removeShortcutToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.removeShortcutToolStripMenuItem.Text = "Remove Shortcut";
			this.removeShortcutToolStripMenuItem.Click += new System.EventHandler(this.removeShortcutToolStripMenuItem_Click);
			// 
			// configureToolStripMenuItem
			// 
			this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
			this.configureToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.configureToolStripMenuItem.Text = "Configure ...";
			this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
			// 
            // openLocationStripMenuItem
            // 
            this.openLocationStripMenuItem.Name = "openLocationStripMenuItem";
            this.openLocationStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.openLocationStripMenuItem.Text = "Open Containing Folder";
            this.openLocationStripMenuItem.Click += new System.EventHandler(this.openLocationStripMenuItem_Click);
            // 
            // copyFullPathStripMenuItem
            // 
            this.copyFullPathStripMenuItem.Name = "copyFullPathStripMenuItem";
            this.copyFullPathStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.copyFullPathStripMenuItem.Text = "Copy Full Path";
            this.copyFullPathStripMenuItem.Click += new System.EventHandler(this.copyFullPathStripMenuItem_Click);
            // 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
			// 
			// topMostToolStripMenuItem
			// 
			this.topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
			this.topMostToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.topMostToolStripMenuItem.Text = "Top Most";
			this.topMostToolStripMenuItem.Click += new System.EventHandler(this.topMostToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// toolStripLabelDateTime
			// 
			this.toolStripLabelDateTime.AutoSize = false;
			this.toolStripLabelDateTime.Font = new System.Drawing.Font("Tahoma", 10.75F, System.Drawing.FontStyle.Bold);
			this.toolStripLabelDateTime.Margin = new System.Windows.Forms.Padding(0);
			this.toolStripLabelDateTime.Name = "toolStripLabelDateTime";
			this.toolStripLabelDateTime.Size = new System.Drawing.Size(100, 22);
			this.toolStripLabelDateTime.Text = "Sample Text";
			this.toolStripLabelDateTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.toolStripLabelDateTime.MouseEnter += new System.EventHandler(this.toolStripLabelDateTime_MouseEnter);
			this.toolStripLabelDateTime.MouseLeave += new System.EventHandler(this.toolStripLabelDateTime_MouseLeave);
			this.toolStripLabelDateTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripLabelDateTime_MouseMove);
			this.toolStripLabelDateTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripLabelDateTime_MouseDown);
			// 
			// toolTip
			// 
			this.toolTip.ShowAlways = true;
			// 
			// pictureBoxInsertionBar
			// 
			this.pictureBoxInsertionBar.BackColor = System.Drawing.Color.FloralWhite;
			this.pictureBoxInsertionBar.Enabled = false;
			this.pictureBoxInsertionBar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxInsertionBar.Image")));
			this.pictureBoxInsertionBar.Location = new System.Drawing.Point(29, 78);
			this.pictureBoxInsertionBar.Name = "pictureBoxInsertionBar";
			this.pictureBoxInsertionBar.Size = new System.Drawing.Size(10, 20);
			this.pictureBoxInsertionBar.TabIndex = 7;
			this.pictureBoxInsertionBar.TabStop = false;
			// 
			// pictureBoxInsertionBarSerif1
			// 
			this.pictureBoxInsertionBarSerif1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxInsertionBarSerif1.Image")));
			this.pictureBoxInsertionBarSerif1.Location = new System.Drawing.Point(58, 78);
			this.pictureBoxInsertionBarSerif1.Name = "pictureBoxInsertionBarSerif1";
			this.pictureBoxInsertionBarSerif1.Size = new System.Drawing.Size(10, 10);
			this.pictureBoxInsertionBarSerif1.TabIndex = 8;
			this.pictureBoxInsertionBarSerif1.TabStop = false;
			// 
			// pictureBoxInsertionBarSerif2
			// 
			this.pictureBoxInsertionBarSerif2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxInsertionBarSerif2.Image")));
			this.pictureBoxInsertionBarSerif2.Location = new System.Drawing.Point(85, 92);
			this.pictureBoxInsertionBarSerif2.Name = "pictureBoxInsertionBarSerif2";
			this.pictureBoxInsertionBarSerif2.Size = new System.Drawing.Size(10, 10);
			this.pictureBoxInsertionBarSerif2.TabIndex = 9;
			this.pictureBoxInsertionBarSerif2.TabStop = false;
			// 
			// pictureBoxInsertionBarSerif3
			// 
			this.pictureBoxInsertionBarSerif3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxInsertionBarSerif3.Image")));
			this.pictureBoxInsertionBarSerif3.Location = new System.Drawing.Point(106, 116);
			this.pictureBoxInsertionBarSerif3.Name = "pictureBoxInsertionBarSerif3";
			this.pictureBoxInsertionBarSerif3.Size = new System.Drawing.Size(10, 10);
			this.pictureBoxInsertionBarSerif3.TabIndex = 10;
			this.pictureBoxInsertionBarSerif3.TabStop = false;
			// 
			// pictureBoxInsertionBarSerif4
			// 
			this.pictureBoxInsertionBarSerif4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxInsertionBarSerif4.Image")));
			this.pictureBoxInsertionBarSerif4.Location = new System.Drawing.Point(121, 134);
			this.pictureBoxInsertionBarSerif4.Name = "pictureBoxInsertionBarSerif4";
			this.pictureBoxInsertionBarSerif4.Size = new System.Drawing.Size(10, 10);
			this.pictureBoxInsertionBarSerif4.TabIndex = 11;
			this.pictureBoxInsertionBarSerif4.TabStop = false;
			// 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(162, 6);
            // 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(296, 25);
			this.ContextMenuStrip = this.contextMenuStrip;
			this.ControlBox = false;
			this.Controls.Add(this.pictureBoxInsertionBarSerif4);
			this.Controls.Add(this.pictureBoxInsertionBarSerif3);
			this.Controls.Add(this.pictureBoxInsertionBarSerif2);
			this.Controls.Add(this.pictureBoxInsertionBar);
			this.Controls.Add(this.pictureBoxInsertionBarSerif1);
			this.Controls.Add(this.toolStrip);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.Maroon;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.Black;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
			this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
			this.Activated += new System.EventHandler(this.Form1_Activated);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
			this.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Form1_GiveFeedback);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.contextMenuStrip.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInsertionBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInsertionBarSerif1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInsertionBarSerif2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInsertionBarSerif3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInsertionBarSerif4)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripLabel toolStripLabelDateTime;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem topMostToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeShortcutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addShortcutToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.PictureBox pictureBoxInsertionBar;
		private System.Windows.Forms.PictureBox pictureBoxInsertionBarSerif1;
		private System.Windows.Forms.PictureBox pictureBoxInsertionBarSerif2;
		private System.Windows.Forms.PictureBox pictureBoxInsertionBarSerif3;
		private System.Windows.Forms.PictureBox pictureBoxInsertionBarSerif4;
        private System.Windows.Forms.ToolStripMenuItem openLocationStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFullPathStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
	}
}

