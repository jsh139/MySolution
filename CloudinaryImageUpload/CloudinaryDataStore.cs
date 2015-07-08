using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Drawing;
using System.IO;
using System.Net;

namespace CloudinaryImageUpload
{
    public class CloudinaryDataStore : ICloudinaryDataStore
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryDataStore(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }

        public Image GetImage(string publicId)
        {
            var wc = new WebClient();
            var url = _cloudinary.Api.UrlImgUp.Secure().CSubDomain(true)
                .Transform(new Transformation().Width(58).Height(58).Crop("fill").Gravity("face").Border(1, "#B1B5BA"))
                .BuildUrl(publicId);

            var bytes = wc.DownloadData(url);
            var ms = new MemoryStream(bytes);

            return Image.FromStream(ms);
        }

        public ImageUploadResult UploadImage(string fileName)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName)
            };

            return _cloudinary.Upload(uploadParams);
        }

        public void DeleteImage(string publicId)
        {
            // Delete image from cloud
            _cloudinary.DeleteResources(publicId);
        }
    }
}
