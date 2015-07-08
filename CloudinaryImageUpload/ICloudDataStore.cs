using System.Data;
using CloudinaryDotNet.Actions;

namespace CloudinaryImageUpload
{
    public interface ICloudDataStore
    {
        DataSet GetEmployeeData();

        void UpdateImage(long pkImage, ImageUploadResult result);

        void InsertImage(long pkEmployee, ImageUploadResult result);

        void DeleteImage(long pkImage);
    }
}
