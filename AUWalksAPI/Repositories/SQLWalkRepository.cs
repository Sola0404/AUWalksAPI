using AUWalksAPI.Data;
using AUWalksAPI.Models.Domain;

namespace AUWalksAPI.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly AUWalksDbContext _dbContext;
        public SQLWalkRepository(AUWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }
    }
}