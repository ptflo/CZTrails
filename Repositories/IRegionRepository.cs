using CZTrails.Models.Domain;

namespace CZTrails.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync(); //async function, returns list of all regions
        Task<Region?> GetAsync(Guid id);
        Task<Region> CreateAsync(Region region);
        Task<Region?> UpdateAsync(Guid id, Region region);
        Task<Region?> DeleteAsync(Guid id);
    }
}
