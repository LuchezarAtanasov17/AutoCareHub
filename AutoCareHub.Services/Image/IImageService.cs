using AutoCareHub.Data.Models;
using Microsoft.AspNetCore.Http;

namespace AutoCareHub.Services.Image
{
    public interface IImageService
    {
        Task<string> UploadImage(IFormFile imageFile, string nameFolder, Service studio);
    }
}
