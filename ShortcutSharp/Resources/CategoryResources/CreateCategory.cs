using Newtonsoft.Json;

namespace Sharpcut.Resources.CategoryResources
{
    public class CreateCategory
    {
        /// <summary>
        /// The name of the new Category.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The hex color to be displayed with the Category (for example, “#ff0000”).
        /// </summary>
        [JsonProperty("color")]
        public string? Color { get; set; }

        /// <summary>
        /// This field can be set to another unique ID. In the case that the Category has been imported from another tool, the ID in the other tool can be indicated here.
        /// </summary>
        [JsonProperty("external_id")]
        public string? ExternalId { get; set; }

        /// <summary>
        /// The type of entity this Category is associated with; currently Milestone is the only type of Category.
        /// </summary>
        /// <value>
        /// milestone
        /// </value>
        [JsonProperty("type")]
        public string Type { get; set; }

        public CreateCategory()
        {
            Name = string.Empty;
            Type = "milestone";
        }
    }
}
