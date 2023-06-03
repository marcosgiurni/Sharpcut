using Sharpcut.Endpoints.Interfaces;
using Sharpcut.Resources.EpicResources;

namespace Sharpcut.Endpoints.EpicEndpoint
{
    public class EpicEndpoint : EndpointBase, IEpicEndpoint
    {
        private const string EpicsPath = "/api/v3/epics";

        public EpicEndpoint(HttpClient httpClient)
            : base(httpClient)
        {
        }

        public async Task<IList<Epic>?> GetAllAsync()
        {
            return await GetAsync<List<Epic>>(EpicsPath);
        }

        public async Task<Epic> CreateAsync(CreateEpicRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentNullException(nameof(request.Name));
            }

            return await PostAsync<CreateEpicRequest, Epic>(EpicsPath, request);
        }
    }
}
