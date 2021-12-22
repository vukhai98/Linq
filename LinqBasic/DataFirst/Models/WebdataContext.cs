using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataFirst.Models
{
    public partial class WebdataContext : DbContext
    {
        public WebdataContext()
        {
        }

        public WebdataContext(DbContextOptions<WebdataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleTags> ArticleTags { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ADMIN;Database=Webdata;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.ArticleContent).HasColumnType("ntext");

                entity.Property(e => e.ArticleName).HasMaxLength(100);
            });

            modelBuilder.Entity<ArticleTags>(entity =>
            {
                entity.HasKey(e => e.ArticleTagId);

                entity.HasIndex(e => e.TagId);

                entity.HasIndex(e => new { e.ArticleId, e.TagId })
                    .IsUnique();

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleTags)
                    .HasForeignKey(d => d.ArticleId);

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ArticleTags)
                    .HasForeignKey(d => d.TagId);
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasKey(e => e.TagId);

                entity.Property(e => e.Content).HasColumnType("ntext");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
