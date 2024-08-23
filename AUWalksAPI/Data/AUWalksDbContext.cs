using AUWalksAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AUWalksAPI.Data
{
    public class AUWalksDbContext : DbContext
    {
        // Using base(dbContextOptions) to pass the dbContextOptions parameter received by AUWalksDbContext
        // to the constructor of the DbContext base class.
        // DbContextOptions contain configuration information, like connection strings, model configurations, etc.
        public AUWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        // DbSet<T> is a collection of entities in the context or can be queried from the database of a given type.
        // Entity Framework uses DbSet<T> to map C# classes to database tables. Each entity type corresponds to a table, 
        // and the properties of the entity correspond to columns in the table.
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}