using AUWalksAPI.Models.Domain;
using AUWalksAPI.Models.DTO;
using AUWalksAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AUWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                // Convert Dto to Domain model
                var image = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription
                };

                // Use repository to upload image
                image = await _imageRepository.Upload(image);
                return Ok(image);
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10MB, please upload a smaller file.");
            }
        }
    }
}