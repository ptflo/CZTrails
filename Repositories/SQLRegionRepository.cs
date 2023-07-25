using CZTrails.Data;
using CZTrails.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CZTrails.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly CZTrailsDbContext dbContext;

        public SQLRegionRepository(CZTrailsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public CZTrailsDbContext DbContext { get; }
        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }
        public async Task<Region?> GetAsync(Guid id)
        {
            return await dbContext.Regions.FindAsync(id);
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await dbContext.Regions.FindAsync(id);
            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Spz = region.Spz;

            await dbContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await dbContext.Regions.FindAsync(id);
            if (existingRegion == null)
            {
                return null;
            }
            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
