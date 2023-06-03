using Sharpcut.Endpoints.CategoryEndpoint;
using Sharpcut.Endpoints.EpicEndpoint;
using Sharpcut.Endpoints.Interfaces;

namespace Sharpcut
{
    public class ShortcutApi
    {
        public ICategoryEndpoint Categories { get; set; }
        public IEpicEndpoint Epics { get; set; }

        public ShortcutApi(string apiToken)
            : this(apiToken, new HttpClient())
        {
        }

        public ShortcutApi(string apiToken, HttpClient httpClient)
        {
            if (string.IsNullOrWhiteSpace(apiToken))
            {
                throw new ArgumentNullException(nameof(apiToken));
            }

            httpClient.BaseAddress = new Uri("https://api.app.shortcut.com");
            httpClient.DefaultRequestHeaders.Add("Shortcut-Token", apiToken);

            Categories = new CategoryEndpoint(httpClient);
            Epics = new EpicEndpoint(httpClient);
        }
    }
}