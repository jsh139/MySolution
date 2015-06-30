using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

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
                    gridRow.Cells.Add(new DataGridViewImageCell { Value = GetImage(row["Picture"].ToString()), ToolTipText = "Click to change image" });
                }

                gridRow.Cells.Add(new DataGridViewTextBoxCell { Value = row["Picture"] });

                dataEmployee.Rows.Add(gridRow);
            }

            // Resize the DataGridView columns to fit the newly loaded content.
            dataEmployee.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            dataEmployee.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private Image GetImage(string picture)
        {
            var wc = new WebClient();
            var url = _cloudinary.Api.UrlImgUp.Secure().CSubDomain(true)
                .Transform(new Transformation().Width(58).Height(58).Crop("fill").Gravity("face").Border(1, "#B1B5BA"))
                .BuildUrl(picture);
            
            var bytes = wc.DownloadData(url);
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
                var pkEmployee = Convert.ToInt64(row.Cells["Id"].Value);
                var pkImage = row.Cells["ImageId"].Value == DBNull.Value ? (long?)null : Convert.ToInt64(row.Cells["ImageId"].Value);

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    var result = UploadImageToCloud(openFile.FileName);

                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        if (pkImage.HasValue)
                        {
                            UpdateImageInDb(pkImage.Value, result);
                            DeleteImageFromCloud(row.Cells["PublicId"].Value.ToString());
                        }
                        else
                        {
                            InsertImageInDb(pkEmployee, result);
                        }

                        btnGet_Click(sender, new EventArgs());
                    }
                }
            }
        }

        private void DeleteImageFromCloud(string publicId)
        {
            // Delete image from cloud
            _cloudinary.DeleteResources(publicId);
        }

        private void UpdateImageInDb(long pkImage, ImageUploadResult result)
        {
            // Update image record
            var sql = string.Format(
                "UPDATE [Image] " + 
                "SET [publicId] = '{0}', [version] = {1}, [signature] = '{2}', [width] = {3}, [height] = {4}, [format] = '{5}', " +
                "[bytes] = {6}, [url] = '{7}', [secureUrl] = '{8}', [fkSecUserModifiedBy] = 6235890, [dateModified] = GETUTCDATE() " +
                "WHERE [pkImage] = {9}",
                result.PublicId, result.Version, result.Signature, result.Width, result.Height,
                result.Format, result.Length, result.Uri, result.SecureUri, pkImage);

            _database.ExecuteNonQuery(new SqlCommand(sql));
        }

        private void InsertImageInDb(long pkEmployee, ImageUploadResult result)
        {
            // Insert new image record, tie back to original employee
            var sql = string.Format(
                    "INSERT INTO [Image] ([publicId], [version], [signature], [width], [height], [format], [bytes], [url], [secureUrl], " +
                    "[fkSecUserCreatedBy], [fkSecUserModifiedBy], [dateCreated], [dateModified]) " +
                    "VALUES('{0}', {1}, '{2}', {3}, {4}, '{5}', {6}, '{7}', '{8}', 6235890, 6235890, GETUTCDate(), GETUTCDATE())",
                    result.PublicId, result.Version, result.Signature, result.Width, result.Height, 
                    result.Format, result.Length, result.Uri, result.SecureUri);

            using (var conn = _database.CreateConnection())
            {
                conn.Open();
                var uow = conn.BeginTransaction();

                try
                {
                    _database.ExecuteNonQuery(new SqlCommand(sql), uow);

                    var ds = _database.ExecuteDataSet(new SqlCommand("select @@IDENTITY as 'pkImage'"), uow);
                    var pkImage = Convert.ToInt64(ds.Tables[0].Rows[0]["pkImage"]);

                    sql = string.Format("UPDATE [Employee] SET fkPicture = {0} WHERE pkEmployee = {1}", pkImage,
                        pkEmployee);
                    _database.ExecuteNonQuery(new SqlCommand(sql), uow);

                    uow.Commit();
                }
                catch (Exception)
                {
                    uow.Rollback();
                    throw;
                }
            }
        }

        private ImageUploadResult UploadImageToCloud(string fileName)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName)
            };

            return _cloudinary.Upload(uploadParams);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            dataEmployee.Height = Height - 100;
            dataEmployee.Width = Width - 18;
        }
    }
}
