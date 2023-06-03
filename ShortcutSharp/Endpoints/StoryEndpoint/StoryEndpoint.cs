using Sharpcut.Resources.StoryResources;

namespace Sharpcut.Endpoints.StoryEndpoint
{
    public class StoryEndpoint : EndpointBase
    {
        private const string BasePath = "/api/v3/stories";

        public StoryEndpoint(HttpClient httpClient)
            : base(httpClient)
        {                
        }

        public async Task<Story> Create(CreateStoryRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentNullException(nameof(request.Name));
            }

            return await PostAsync<CreateStoryRequest, Story>(BasePath, request);
        }
    }
}
