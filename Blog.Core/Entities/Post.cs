namespace Blog.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Tag> Tags { get; set; }
        public int ViewsAmount { get; set; }
        public byte[] Image { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime LastViewedAt { get; set; }
    }
}
