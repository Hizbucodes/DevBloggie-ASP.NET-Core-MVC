using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DevBloggie.Web.Settings;
using Microsoft.Extensions.Options;

namespace DevBloggie.Web.Repositories
{
    public class CloudinaryImageRepository : IImageRepository
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryImageRepository(IOptions<CloudinarySettings> options)
        {
            var settings = options.Value;

         
            if (string.IsNullOrWhiteSpace(settings.CloudName) ||
                string.IsNullOrWhiteSpace(settings.ApiKey) ||
                string.IsNullOrWhiteSpace(settings.ApiSecret))
            {
                throw new InvalidOperationException("Cloudinary settings are missing");
            }

            var account = new Account(
                settings.CloudName,
                settings.ApiKey,
                settings.ApiSecret
            );

            _cloudinary = new Cloudinary(account)
            {
                Api = { Secure = true }
            };
        }

        public async Task<string?> UploadAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            await using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = "devbloggie",
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = true
            };



            var uploadResult = await _cloudinary.UploadAsync(uploadParams);


            return uploadResult.StatusCode == System.Net.HttpStatusCode.OK
                ? uploadResult.SecureUrl?.ToString()
                : null;
        }
    }
}
