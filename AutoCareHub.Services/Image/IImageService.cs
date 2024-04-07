using AutoCareHub.Data.Models;
using Microsoft.AspNetCore.Http;

namespace AutoCareHub.Services.Image
{
    /// <summary>
    /// Provides access to images.
    /// </summary>
    public interface IImageService
    {
        /// <summary>
        /// Uploads an image.
        /// </summary>
        /// <param name="imageFile">the image file</param>
        /// <param name="nameFolder">the folder name</param>
        /// <param name="studio">the service</param>
        /// <returns>a URL as string</returns>
        Task<string> UploadImage(IFormFile imageFile, string nameFolder, Service service);
    }
}
