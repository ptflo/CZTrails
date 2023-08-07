using CZTrails.Models.Domain;
using System.Runtime.InteropServices;

namespace CZTrails.Repositories
{
    public interface ITrailRepository
    {
        Task<Trail> CreateAsync(Trail trail);
        Task<List<Trail>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int page = 1, int pageSize = 25);
        Task<Trail?> GetAsync(Guid id);
        Task<Trail?> UpdateAsync(Guid id, Trail trail);
        Task<Trail?> DeleteAsync(Guid id);
    }
}
