using Sharpcut.Resources.EpicResources;

namespace Sharpcut.Endpoints.Interfaces
{
    public interface IEpicEndpoint
    {
        Task<Epic> CreateAsync(CreateEpicRequest epic);
        Task<IList<Epic>?> GetAllAsync();
    }
}