namespace Blog.Core.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UsageAmount { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public bool IsActive { get; set; }
    }
}
