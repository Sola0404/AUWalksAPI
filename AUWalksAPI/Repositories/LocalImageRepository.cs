using AUWalksAPI.Data;
using AUWalksAPI.Models.Domain;

namespace AUWalksAPI.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AUWalksDbContext _dbContext;
        public LocalImageRepository(IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            AUWalksDbContext dbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }

        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images",
                $"{image.FileName}{image.FileExtension}");

            // Upload image to loca path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            // http://localhost:5062/images/{filename}.{extension}
            var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;

            await _dbContext.Images.AddAsync(image);
            await _dbContext.SaveChangesAsync();

            return image;
        }
    }
}