using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Blog.Core.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }      
        public string Country { get; set; }
        public byte[] Icon { get; set; }
        public string Bio { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<Category> Categories { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Post> Posts { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
