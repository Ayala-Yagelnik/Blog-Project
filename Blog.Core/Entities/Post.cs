﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Blog.Core.Entities
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public User Author { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ViewsAmount { get; set; }
        public byte[] Image { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime LastViewedAt { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Tag> Tags { get; set; }

    }
}
