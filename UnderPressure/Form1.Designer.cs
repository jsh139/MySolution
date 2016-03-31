namespace UnderPressure
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
            this.btnDoIt = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labDatabase = new System.Windows.Forms.ToolStripStatusLabel();
            this.labMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDatabase = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEvent = new System.Windows.Forms.ComboBox();
            this.txtIterations = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkDatabase = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDoIt
            // 
            this.btnDoIt.Enabled = false;
            this.btnDoIt.Location = new System.Drawing.Point(15, 173);
            this.btnDoIt.Name = "btnDoIt";
            this.btnDoIt.Size = new System.Drawing.Size(75, 33);
            this.btnDoIt.TabIndex = 0;
            this.btnDoIt.Text = "Do it";
            this.btnDoIt.UseVisualStyleBackColor = true;
            this.btnDoIt.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labDatabase,
            this.labMessage,
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 453);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(582, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labDatabase
            // 
            this.labDatabase.Name = "labDatabase";
            this.labDatabase.Size = new System.Drawing.Size(232, 20);
            this.labDatabase.Spring = true;
            this.labDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labMessage
            // 
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(232, 20);
            this.labMessage.Spring = true;
            this.labMessage.Text = "Select Database";
            this.labMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 19);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Database:";
            // 
            // cboDatabase
            // 
            this.cboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Location = new System.Drawing.Point(91, 39);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Size = new System.Drawing.Size(150, 24);
            this.cboDatabase.TabIndex = 3;
            this.cboDatabase.SelectedIndexChanged += new System.EventHandler(this.cboDatabase_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Event:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Iterations:";
            // 
            // cboEvent
            // 
            this.cboEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEvent.FormattingEnabled = true;
            this.cboEvent.Location = new System.Drawing.Point(91, 83);
            this.cboEvent.Name = "cboEvent";
            this.cboEvent.Size = new System.Drawing.Size(254, 24);
            this.cboEvent.TabIndex = 6;
            // 
            // txtIterations
            // 
            this.txtIterations.Location = new System.Drawing.Point(91, 127);
            this.txtIterations.Name = "txtIterations";
            this.txtIterations.Size = new System.Drawing.Size(73, 22);
            this.txtIterations.TabIndex = 7;
            this.txtIterations.Text = "1000";
            // 
            // txtLog
            // 
            this.txtLog.ContextMenuStrip = this.contextMenuStrip1;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 220);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(582, 233);
            this.txtLog.TabIndex = 8;
            this.txtLog.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkDatabase);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 220);
            this.panel1.TabIndex = 9;
            // 
            // chkDatabase
            // 
            this.chkDatabase.AutoSize = true;
            this.chkDatabase.Location = new System.Drawing.Point(199, 129);
            this.chkDatabase.Name = "chkDatabase";
            this.chkDatabase.Size = new System.Drawing.Size(120, 21);
            this.chkDatabase.TabIndex = 0;
            this.chkDatabase.Text = "Use Database";
            this.chkDatabase.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 28);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.clearToolStripMenuItem.Text = "&Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 478);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtIterations);
            this.Controls.Add(this.cboEvent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboDatabase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnDoIt);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(600, 523);
            this.Name = "Form1";
            this.Text = "Under Pressure";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDoIt;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labDatabase;
        private System.Windows.Forms.ToolStripStatusLabel labMessage;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEvent;
        private System.Windows.Forms.TextBox txtIterations;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkDatabase;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    }
}

