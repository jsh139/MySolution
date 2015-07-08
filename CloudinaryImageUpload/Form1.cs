using CloudinaryDotNet;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Net;
using System.Windows.Forms;

namespace CloudinaryImageUpload
{
    public partial class Form1 : Form
    {
        private const string ConnectionString =
                @"data source=.\SQL2012;initial catalog=LDRPS11;user id=sa;password=Ldrps10@;Asynchronous Processing=True;MultipleActiveResultSets=True;Connect Timeout=30;TrustServerCertificate=True";
        private readonly ICloudDataStore _cloudDataStore;
        private readonly ICloudinaryDataStore _cloudinaryDataStore;

        public Form1()
        {
            var database = new SqlDatabase(ConnectionString);
            _cloudDataStore = new CloudDataStore(database);
            
            var cloudinary = new Cloudinary(new Account("dwtoc6red", "924227612593437", "FOsAZuLhEDDZBgT6-B2pkHRgdTI"));
            _cloudinaryDataStore = new CloudinaryDataStore(cloudinary);

            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            AddColumns(_cloudDataStore.GetEmployeeData());
            
            Cursor.Current = Cursors.Default;
        }

        private void AddColumns(DataSet ds)
        {
            dataEmployee.Rows.Clear();
            dataEmployee.Columns.Clear();

            foreach (DataColumn col in ds.Tables[0].Columns)
            {
                dataEmployee.Columns.Add(col.ColumnName, col.ColumnName);
            }

            dataEmployee.Columns.Add(new DataGridViewColumn { Name = "PublicId", Visible = false });

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var gridRow = new DataGridViewRow();

                gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = row["Id"] });
                gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = row["LastName"] });
                gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = row["FirstName"] });
                gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = row["Title"] });
                gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = row["Department"] });
                gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = row["City"] });
                
                var pkImage = row["ImageId"];
                gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = pkImage });

                if (string.IsNullOrEmpty(pkImage.ToString()))
                {
                    gridRow.Cells.Add(new DataGridViewButtonCell { Value = "Add Image", ToolTipText = "Click to add an image" });
                }
                else
                {
                    var cell = new DataGridViewImageCell 
                    { 
                        Value = _cloudinaryDataStore.GetImage(row["Picture"].ToString()), 
                        ToolTipText = "Click to change image",
                        ContextMenuStrip = GetContextMenu(dataEmployee.Rows.Count),
                    };

                    gridRow.Cells.Add(cell);
                }

                gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = row["Picture"] });

                dataEmployee.Rows.Add(gridRow);
            }

            // Resize the DataGridView columns to fit the newly loaded content.
            dataEmployee.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dataEmployee.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void dataEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataEmployee.Rows[e.RowIndex];
            var column = dataEmployee.Columns[e.ColumnIndex];

            if (column.Name == "Picture")
            {
                var pkEmployee = Convert.ToInt64(row.Cells["Id"].Value);
                var pkImage = row.Cells["ImageId"].Value == DBNull.Value ? (long?)null : Convert.ToInt64(row.Cells["ImageId"].Value);

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var result = _cloudinaryDataStore.UploadImage(openFile.FileName);

                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        if (pkImage.HasValue)
                        {
                            _cloudDataStore.UpdateImage(pkImage.Value, result);
                            _cloudinaryDataStore.DeleteImage(row.Cells["PublicId"].Value.ToString());
                        }
                        else
                        {
                            _cloudDataStore.InsertImage(pkEmployee, result);
                        }

                        Cursor.Current = Cursors.Default;
                        btnGet_Click(sender, new EventArgs());
                    }
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            dataEmployee.Height = Height - 100;
            dataEmployee.Width = Width - 18;
        }

        private ContextMenuStrip GetContextMenu(int rowIndex)
        {
            var strip = new ContextMenuStrip();
            var item = new ToolStripMenuItem
            {
                Name = "toolDelete",
                Text = @"&Delete Image",
                Tag = rowIndex,
            };

            item.Click += ContextMenuClickDeleteImage;
            strip.Items.Add(item);

            return strip;
        }

        private void ContextMenuClickDeleteImage(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                var rowIndex = Convert.ToInt32((sender as ToolStripMenuItem).Tag);
                var pkImage = Convert.ToInt64(dataEmployee.Rows[rowIndex].Cells["ImageId"].Value);
                var publicId = dataEmployee.Rows[rowIndex].Cells["PublicId"].Value.ToString();

                _cloudDataStore.DeleteImage(pkImage);
                _cloudinaryDataStore.DeleteImage(publicId);

                btnGet_Click(sender, e);
            }
        }
    }

}
