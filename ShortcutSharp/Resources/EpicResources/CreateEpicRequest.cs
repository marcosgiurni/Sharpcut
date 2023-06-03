using Newtonsoft.Json;

namespace Sharpcut.Resources.EpicResources
{
    public class CreateEpicRequest
    {
        public DateTime? CompletedAtOverride { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateOnly? Deadline { get; set; }
        public string? Description { get; set; }
        public int? StateId { get; set; }
        public string? ExternalId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }


        public CreateEpicRequest()
        {
            Name = string.Empty;
        }
    }
}
