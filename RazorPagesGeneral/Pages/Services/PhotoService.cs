using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using RazorPagesGeneral.Core;
using RazorPagesGeneral.Pages.Services.Interfaces;

namespace RazorPagesGeneral.Pages.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary cloudinary;
        public PhotoService(IOptions<CloudinarySettings> options)
        {
            var account = new Account(
                options.Value.CloudName,
                options.Value.ApiKey,
                options.Value.ApiSecret
                );

            cloudinary = new Cloudinary(account);
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if(file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var imageUploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500)
                };

                uploadResult = await cloudinary.UploadAsync(imageUploadParams);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicUrl)
        {
            var publicId = publicUrl.Split('/').Last().Split('.')[0];
            var deleteParams = new DeletionParams(publicId);
            return await cloudinary.DestroyAsync(deleteParams);
        }
    }
}
