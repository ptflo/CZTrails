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

    }
}
