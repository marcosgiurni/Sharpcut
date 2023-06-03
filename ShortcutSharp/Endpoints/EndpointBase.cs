using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sharpcut.Exceptions;
using System.Net;
using System.Text;

namespace Sharpcut.Endpoints
{
    public abstract class EndpointBase
    {
        private readonly HttpClient _httpClient;

        public EndpointBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T?> GetAsync<T>(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var response = await _httpClient.GetAsync(path);

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(content))
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<U?> PostAsync<T, U>(string path, T data)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var requestBody = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(path, requestContent);            

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
            {
                dynamic errorData = JObject.Parse(responseContent);
                throw new UnprocessableEntityException(Convert.ToString(errorData.message));
            }

            if (string.IsNullOrWhiteSpace(responseContent))
            {
                throw new Exception("Error");
            }

            return JsonConvert.DeserializeObject<U>(responseContent);
        }
    }
}
