using AUWalksAPI.Models.Domain;

namespace AUWalksAPI.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}