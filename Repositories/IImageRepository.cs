using CZTrails.Models.Domain;

namespace CZTrails.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
