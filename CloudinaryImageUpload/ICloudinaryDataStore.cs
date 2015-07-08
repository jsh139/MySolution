using CloudinaryDotNet.Actions;
using System.Drawing;

namespace CloudinaryImageUpload
{
    public interface ICloudinaryDataStore
    {
        Image GetImage(string publicId);

        ImageUploadResult UploadImage(string fileName);

        void DeleteImage(string publicId);
    }
}
