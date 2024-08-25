using AUWalksAPI.Data;
using AUWalksAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AUWalksAPI.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly AUWalksDbContext _dbContext;
        public SQLWalkRepository(AUWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await _dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }
    }
}