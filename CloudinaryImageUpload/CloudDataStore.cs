using CloudinaryDotNet.Actions;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CloudinaryImageUpload
{
    public class CloudDataStore : ICloudDataStore
    {
        private readonly Database _database;

        public CloudDataStore(Database database)
        {
            _database = database;
        }

        public DataSet GetEmployeeData()
        {
            const string sql = 
                "select pkEmployee as 'Id', LastName, FirstName, Title, Department, City, pkImage as 'ImageId', publicId as 'Picture' " +
                "from employee " +
                "left outer join [Image] on [Image].pkImage = employee.fkPicture " +
                "order by lastname";

            return _database.ExecuteDataSet(new SqlCommand(sql));
        }

        public void UpdateImage(long pkImage, ImageUploadResult result)
        {
            var sql = string.Format(
                "UPDATE [Image] " +
                "SET [publicId] = '{0}', [version] = {1}, [signature] = '{2}', [width] = {3}, [height] = {4}, [format] = '{5}', " +
                "[bytes] = {6}, [url] = '{7}', [secureUrl] = '{8}', [fkSecUserModifiedBy] = 6235890, [dateModified] = GETUTCDATE() " +
                "WHERE [pkImage] = {9}",
                result.PublicId, result.Version, result.Signature, result.Width, result.Height,
                result.Format, result.Length, result.Uri, result.SecureUri, pkImage);

            _database.ExecuteNonQuery(new SqlCommand(sql));
        }

        public void InsertImage(long pkEmployee, ImageUploadResult result)
        {
            // Insert new image record, tie back to original employee
            using (var conn = _database.CreateConnection())
            {
                conn.Open();
                var uow = conn.BeginTransaction();

                try
                {
                    var sql = string.Format(
                            "INSERT INTO [Image] ([publicId], [version], [signature], [width], [height], [format], [bytes], [url], [secureUrl], " +
                            "[fkSecUserCreatedBy], [fkSecUserModifiedBy], [dateCreated], [dateModified]) " +
                            "VALUES('{0}', {1}, '{2}', {3}, {4}, '{5}', {6}, '{7}', '{8}', 6235890, 6235890, GETUTCDate(), GETUTCDATE())",
                            result.PublicId, result.Version, result.Signature, result.Width, result.Height,
                            result.Format, result.Length, result.Uri, result.SecureUri);

                    _database.ExecuteNonQuery(new SqlCommand(sql), uow);

                    var ds = _database.ExecuteDataSet(new SqlCommand("select @@IDENTITY as 'pkImage'"), uow);
                    var pkImage = Convert.ToInt64(ds.Tables[0].Rows[0]["pkImage"]);

                    sql = string.Format("UPDATE [Employee] SET fkPicture = {0} WHERE pkEmployee = {1}", pkImage, pkEmployee);
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

        public void DeleteImage(long pkImage)
        {
            using (var conn = _database.CreateConnection())
            {
                conn.Open();
                var uow = conn.BeginTransaction();

                try
                {
                    // Update employee record
                    var sql = string.Format("UPDATE [Employee] SET fkPicture = NULL WHERE fkPicture = {0}", pkImage);
                    _database.ExecuteNonQuery(new SqlCommand(sql), uow);

                    // Delete image record
                    sql = string.Format("DELETE FROM [Image] WHERE pkImage = {0}", pkImage);
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
    }
}
