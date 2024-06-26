﻿using AutoCareHub.Data;
using AutoCareHub.Data.Models;
using AutoCareHub.Services.Exceptions;
using AutoCareHub.Services.Image;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace AutoCareHub.Services.Impl.Image
{
    /// <summary>
    /// Represents a image service.
    /// </summary>
    public class ImageService : IImageService
    {
        private readonly AutoCareHubDbContext _context;
        private readonly Cloudinary _cloudinary;

        /// <summary>
        /// Initialize a new instance of the <see cref="ImageService"/> class.
        /// </summary>
        /// <param name="context">the context</param>
        /// <param name="cloudinary">the cloudinary</param>
        public ImageService(AutoCareHubDbContext context, Cloudinary cloudinary)
        {
            _context = context;
            _cloudinary = cloudinary;
        }

        /// <inheritdoc/>
        public async Task<string> UploadImage(IFormFile imageFile, string nameFolder, Service service)
        {
            try
            {
                using var stream = imageFile.OpenReadStream();

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(service.Id.ToString(), stream),
                    Folder = nameFolder,
                };

                var result = await this._cloudinary.UploadAsync(uploadParams);
                if (result.Error != null)
                {
                    throw new InvalidOperationException(result.Error.Message);
                }

                var imageUrls = new List<string>();

                if (service.ImageUrls == null)
                {
                    imageUrls.Add(result.Url.ToString());
                }
                else
                {
                    imageUrls = JsonSerializer.Deserialize<List<string>>(service.ImageUrls);
                    imageUrls.Add(result.Url.ToString());
                }

                service.ImageUrls = JsonSerializer.Serialize(imageUrls);

                this._context.Update(service);
                await this._context.SaveChangesAsync();

                return result.Url.ToString();
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while uploading an image.", ex);
            }
        }
    }
}
