﻿using CZTrails.Data;
using CZTrails.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CZTrails.Repositories
{
    public class SQLTrailRepository : ITrailRepository
    {
        private readonly CZTrailsDbContext dbContext;

        public SQLTrailRepository(CZTrailsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Trail> CreateAsync(Trail trail)
        {
            await dbContext.Trails.AddAsync(trail);
            await dbContext.SaveChangesAsync();
            return trail;
        }
        public async Task<List<Trail>> GetAllAsync()
        {
            return await dbContext.Trails.Include("TrailDifficulty").Include(x => x.Region).ToListAsync(); //include - naviguje na obtiznost a region pomoci Guid - pri metode GetAllTrails se diky include zobrazi v kolonce difficulty misto GUID "Těžká". Metoda se stringem i s akci ma stejny vysledek
        }

        public async Task<Trail?> GetAsync(Guid id)
        {
            return await dbContext.Trails
                .Include("TrailDifficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Trail?> UpdateAsync(Guid id, Trail trail)
        {
            var existingTrail = await dbContext.Trails.FindAsync(id);
            if (existingTrail == null)
            {
                return null;
            }
            existingTrail.Name = trail.Name;
            existingTrail.Description = trail.Description;
            existingTrail.Length = trail.Length;
            existingTrail.TrailImageUrl = trail.TrailImageUrl;
            existingTrail.RegionID = trail.RegionID;
            existingTrail.TrailDifficultyID = trail.TrailDifficultyID;

            await dbContext.SaveChangesAsync();
            return existingTrail;

        }
        public async Task<Trail?> DeleteAsync(Guid id)
        {
            var existingTrail = await dbContext.Trails.FindAsync(id);
            if (existingTrail == null)
            {
                return null;
            }
            dbContext.Trails.Remove(existingTrail);
            await dbContext.SaveChangesAsync();
            return existingTrail;
        }
    }
}
