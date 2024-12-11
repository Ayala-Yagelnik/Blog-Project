﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Blog.Core.Entities
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public int UsageAmount { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public bool IsActive { get; set; }
    }
}
