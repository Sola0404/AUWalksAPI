using AUWalksAPI.Models.Domain;

namespace AUWalksAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
    }
}