using System.IO;
using System.Net;
using CloudinaryDotNet;
using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace CloudinaryImageUpload
{
    public partial class Form1 : Form
    {
        private const string ConnectionString =
                @"data source=.\SQL2012;initial catalog=LDRPS11;user id=sa;password=Ldrps10@;Asynchronous Processing=True;MultipleActiveResultSets=True;Connect Timeout=30;TrustServerCertificate=True";
        private readonly Cloudinary _cloudinary;
        private readonly Database _database;

        public Form1()
        {
            _database = new SqlDatabase(ConnectionString);
            _cloudinary = new Cloudinary(new Account("dwtoc6red", "924227612593437", "FOsAZuLhEDDZBgT6-B2pkHRgdTI"));

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            const string sql = "select pkEmployee as 'Id', LastName, FirstName, Title, Department, City, pkImage as 'ImageId', publicId as 'Picture' " +
                               "from employee " +
                               "left outer join [Image] on [Image].pkImage = employee.fkPicture " +
                               "order by lastname";
            AddColumns(GetData(sql));
        }

        private void AddColumns(DataSet ds)
        {
            dataEmployee.Rows.Clear();

            foreach (DataColumn col in ds.Tables[0].Columns)
            {
                dataEmployee.Columns.Add(col.ColumnName, col.ColumnName);
            }

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
                    gridRow.Cells.Add(new DataGridViewImageCell { Value = GetImage(row["Picture"].ToString()), ToolTipText = "Click to change image" });
                }

                dataEmployee.Rows.Add(gridRow);
            }

            // Resize the DataGridView columns to fit the newly loaded content.
            dataEmployee.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dataEmployee.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private Image GetImage(string picture)
        {
            var wc = new WebClient();
            var bytes = wc.DownloadData(string.Format("https://res.cloudinary.com/dwtoc6red/image/upload/w_58,h_58,c_fill,g_face/v1435241075/{0}.jpg", picture));
            var ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
        }

        private DataSet GetData(string selectCommand)
        {
            return _database.ExecuteDataSet(new SqlCommand(selectCommand));
        }

        private void dataEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataEmployee.Rows[e.RowIndex];
            var column = dataEmployee.Columns[e.ColumnIndex];

            if (column.Name == "Picture")
            {
                var cell = row.Cells["Picture"];

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    UploadImage(openFile.FileName);
                }
            }
        }

        private void UploadImage(string fileName)
        {
//            throw new NotImplementedException();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            dataEmployee.Height = Height - 100;
            dataEmployee.Width = Width - 18;
        }
    }
}
