namespace Sharpcut.Resources.EpicResources
{
    public class Epic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AppUrl { get; set; }

        public Epic()
        {
            Name = string.Empty;
        }
    }
}
