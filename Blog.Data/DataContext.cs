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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Author)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict); // שינוי כאן

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // שינוי כאן

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Author)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict); // שינוי כאן

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict); // שינוי כאן

            modelBuilder.Entity<Tag>()
                .HasOne(t => t.Author)
                .WithMany(u => u.Tags)
                .HasForeignKey(t => t.AuthorId)
                .OnDelete(DeleteBehavior.Restrict); // שינוי כאן

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.posts)
                .WithMany(p => p.Tags); // קשר מMany-to-Many
        }
    }
}
