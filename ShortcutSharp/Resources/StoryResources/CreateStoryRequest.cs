using Newtonsoft.Json;

namespace Sharpcut.Resources.StoryResources
{
    public class CreateStoryRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("story_type")]
        public string StoryType { get; set; }

        [JsonProperty("requested_by_id")]
        public Guid? RequestedId { get; set; }

        [JsonProperty("workflow_state_id")]
        public int WorkflowStateId { get; set; }

        public CreateStoryRequest()
        {
            Name = string.Empty;
        }
    }
}
