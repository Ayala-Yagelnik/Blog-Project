using Blog.Core.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Blog.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Tag>? Tags { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SSNMLFD;database=blogs;trusted_connection=true");
        }
    }
}
