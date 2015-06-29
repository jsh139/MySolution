namespace CloudinaryImageUpload
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
            this.dataEmployee = new System.Windows.Forms.DataGridView();
            this.btnGet = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // dataEmployee
            // 
            this.dataEmployee.AllowUserToAddRows = false;
            this.dataEmployee.AllowUserToDeleteRows = false;
            this.dataEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataEmployee.Location = new System.Drawing.Point(0, 0);
            this.dataEmployee.Name = "dataEmployee";
            this.dataEmployee.RowTemplate.Height = 24;
            this.dataEmployee.Size = new System.Drawing.Size(1010, 530);
            this.dataEmployee.TabIndex = 0;
            this.dataEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataEmployee_CellContentClick);
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGet.Location = new System.Drawing.Point(12, 546);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(118, 27);
            this.btnGet.TabIndex = 1;
            this.btnGet.Text = "Get Employees";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // openFile
            // 
            this.openFile.Filter = "Image files|*.jpg;*.png;*.gif|All files|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 585);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.dataEmployee);
            this.MinimumSize = new System.Drawing.Size(1028, 630);
            this.Name = "Form1";
            this.Text = "Picture Adder";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataEmployee;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.OpenFileDialog openFile;
    }
}

