using AUWalksAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AUWalksAPI.Data
{
    public class AUWalksDbContext : DbContext
    {
        // Using base(dbContextOptions) to pass the dbContextOptions parameter received by AUWalksDbContext
        // to the constructor of the DbContext base class.
        // DbContextOptions contain configuration information, like connection strings, model configurations, etc.
        public AUWalksDbContext(DbContextOptions<AUWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        // DbSet<T> is a collection of entities in the context or can be queried from the database of a given type.
        // Entity Framework uses DbSet<T> to map C# classes to database tables. Each entity type corresponds to a table, 
        // and the properties of the entity correspond to columns in the table.
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for difficulties
            // Easy, Medium, Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty() { Id = Guid.Parse("883d7b93-a0a1-48ef-bdba-e52f5ce4febe"), Name = "Easy" },
                new Difficulty() { Id = Guid.Parse("cc5fbb9d-5277-4f21-a84f-18276f71e593"), Name = "Medium" },
                new Difficulty() { Id = Guid.Parse("5cad5a8d-5696-4333-9ece-b998a1997934"), Name = "Hard" }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for regions
            var regions = new List<Region>
            {
                new Region()
                {
                    Id = Guid.Parse("9eb79079-fe2e-464d-a061-e391a9ca603b"),
                    Name = "Canberra",
                    Code = "CBR",
                    RegionImageUrl = "https://www.australia.com/content/australia/en_ca/places/canberra-and-surrounds/guide-to-canberra/_jcr_content/hero/desktop.adapt.1920.high.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("a8720e10-e420-450b-a636-2da229378f90"),
                    Name = "Sydney",
                    Code = "SYD",
                    RegionImageUrl = "https://www.australia.com/content/australia/en_ca/places/sydney-and-surrounds/guide-to-sydney/_jcr_content/hero/desktop.adapt.1920.high.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("f1b3b3b4-1b3b-4b3b-8b3b-3b3b3b3b3b3b"),
                    Name = "Melbourne",
                    Code = "MEL",
                    RegionImageUrl = "https://www.australia.com/content/australia/en_ca/places/melbourne-and-surrounds/guide-to-melbourne/_jcr_content/hero/desktop.adapt.1920.high.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"),
                    Name = "Brisbane",
                    Code = "BNE",
                    RegionImageUrl = "https://www.australia.com/content/australia/en_ca/places/brisbane-and-surrounds/guide-to-brisbane/_jcr_content/hero/desktop.adapt.1920.high.jpg"
                }
            };
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}