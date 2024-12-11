using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Blog.Core.Entities
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
