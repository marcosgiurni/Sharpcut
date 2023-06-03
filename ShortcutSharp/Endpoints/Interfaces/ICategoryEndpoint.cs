using Sharpcut.Resources.CategoryResources;

namespace Sharpcut.Endpoints.Interfaces
{
    public interface ICategoryEndpoint
    {
        Task<Category> CreateAsync(CreateCategory category);
        Task<IList<Category>?> GetAllAsync();
    }
}