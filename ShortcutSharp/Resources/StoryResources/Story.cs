namespace Sharpcut.Resources.StoryResources
{
    public class Story
    {
        public string AppUrl { get; set; }
        public bool IsArchived { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsBlocking { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? CompletedAtOverride { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CycleTime { get; set; }
        public DateTime? Deadline { get; set; }
        public string Description { get; set; }
        public string EntityType { get; set; }
        public int? EpicId { get; set; }
        public int? Estimate { get; set; }
        public string? ExternalId { get; set; }
        public string[] ExternalLinks { get; set; }
        public Guid[] FollowerIds { get; set; }
        public Guid? GroupId { get; set; }
        public Guid[] GroupMentionIds { get; set; }
        public int Id { get; set; }
        public int? IterationId { get; set; }
        public int[] LabelIds { get; set; }
        public int LeadTime { get; set; }

        public Story()
        {
            ExternalLinks = Array.Empty<string>();
            FollowerIds = Array.Empty<Guid>();
            GroupMentionIds = Array.Empty<Guid>();
            LabelIds = Array.Empty<int>();
        }
    }
}
