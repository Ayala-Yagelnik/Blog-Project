using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Blog.Core.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentID { get; set; }
        public string Description { get; set; }
    }
}