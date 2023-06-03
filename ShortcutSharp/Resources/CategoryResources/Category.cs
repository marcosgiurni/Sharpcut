using Newtonsoft.Json;

namespace Sharpcut.Resources.CategoryResources
{
    public class Category
    {
        /// <summary>
        /// The unique ID of the Category.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the Category.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A true/false boolean indicating if the Category has been archived.
        /// </summary>
        [JsonProperty("archived")]
        public bool IsArchived { get; set; }

        /// <summary>
        /// The hex color to be displayed with the Category (for example, “#ff0000”).
        /// </summary>
        [JsonProperty("color")]
        public string? Color { get; set; }

        /// <summary>
        /// The time/date that the Category was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// A string description of this resource.
        /// </summary>
        [JsonProperty("entity_type")]
        public string EntityType { get; set; }

        /// <summary>
        /// This field can be set to another unique ID. In the case that the Category has been imported from another tool, the ID in the other tool can be indicated here.
        /// </summary>
        [JsonProperty("external_id")]
        public string? ExternalId { get; set; }

        /// <summary>
        /// The type of entity this Category is associated with; currently Milestone is the only type of Category.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The time/date that the Category was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public Category()
        {
            Name = string.Empty;
            EntityType = string.Empty;
            Type = string.Empty;
        }
    }
}
