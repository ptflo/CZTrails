using CZTrails.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CZTrails.Data
{
    public class CZTrailsDbContext : DbContext
    {
        public CZTrailsDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) //constructor
        {
            
        }
        //creating database entities
        public DbSet<TrailDifficulty> TrailDifficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Trail> Trails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed the data for difficulties
            //easy, medium, hard

            var difficulties = new List<TrailDifficulty>()
            {
                new TrailDifficulty()
                {
                    Id = Guid.Parse("76f6f7e4-de7d-4a91-91e0-6c996f4a3bfc"),
                    Name = "Lehká"
                },
                new TrailDifficulty()
                {
                    Id = Guid.Parse("f391738c-228e-45a0-938d-94f736cdbc96"),
                    Name = "Střední"
                },
                new TrailDifficulty()
                {
                    Id = Guid.Parse("f7bc4218-d58c-4d81-be87-6d0635f85c00"),
                    Name = "Těžká"
                }
            };

            //seed difficulties to the database
            modelBuilder.Entity<TrailDifficulty>().HasData(difficulties);


            //seed the data for regions

            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("6c79963a-414b-4211-8b17-80580786b447"),
                    Name = "Středočeský kraj",
                    Code = "STČ",
                    Spz = 'S'
                },
                new Region
                {
                    Id = Guid.Parse("063f3cfb-f233-4422-bf9b-af3586f33c7e"),
                    Name = "Hlavní město Praha",
                    Code = "PHA",
                    Spz = 'A'
                },
                new Region
                {
                    Id = Guid.Parse("13ec54c1-e829-4dda-93aa-f8bb014730f2"),
                    Name = "Jihočeský kraj",
                    Code = "JHČ",
                    Spz = 'C'
                },
                new Region
                {
                    Id = Guid.Parse("41872f28-4c69-427e-b726-754e929f2b86"),
                    Name = "Plzeňský kraj",
                    Code = "PLK",
                    Spz = 'P'
                },
                new Region
                {
                    Id = Guid.Parse("efc5a27a-e530-4d20-9f4b-448dac386eb6"),
                    Name = "Karlovarský kraj",
                    Code = "KVK",
                    Spz = 'K'
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);

        }
    }
}
