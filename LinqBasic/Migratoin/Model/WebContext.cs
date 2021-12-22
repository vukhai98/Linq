using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migratoin.Model
{
    public class WebContext : DbContext
    {
        public DbSet<Article> Articles { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        private const string connectingString = @"Server=ADMIN;
                                                  Database=WebData;
                                                  Trusted_Connection=True;";
        // tạo log kiểm soát chương trình ghi lại các câu lệnh và các lỗi có thể khi cần 
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
            builder.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Warning)
                   .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Debug)
                   .AddConsole();
        });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectingString);
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ArticleTag>(entity => {
                entity.HasIndex(articleTag => new { articleTag.ArticleId, articleTag.TagId })
                      .IsUnique();
            });


        }

    }
}
