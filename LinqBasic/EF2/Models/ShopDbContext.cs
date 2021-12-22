using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF2
{
    public class ShopDbContext : DbContext
    {
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            //builder.AddConsole()
        });


        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<CategoryDetails> CategoryDetailes { get; set; }
      
        private const string connectingString = @"Server=ADMIN;
                                                  Database=ShopData;
                                                  Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectingString);
            //optionsBuilder.UseLazyLoadingProxies();

            Console.WriteLine("OnConfiguring");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Console.WriteLine("OnModelCreating");
            // Fluent API 
            // Cach 1:
            //var entity = modelBuilder.Entity(typeof(Product));
            // Entity => Fulent API -> Products
            //Cach 2:
            //var entity = modelBuilder.Entity<Product>();
            // Cách 3:
            var entity = modelBuilder.Entity<Product>(entity =>
            {
                // Table Maping
                entity.ToTable("Products");
                // PK 
                entity.HasKey(p => p.ProductId);

                entity.Property(x => x.Name).HasMaxLength(50).IsRequired();
                // Index
                entity.HasIndex(p => p.Price).HasName("Index-Products-Price");

                //entity.Property(x => x.CategoryId).HasMaxLength(50).IsRequired();
                // Relative
                entity.HasOne(p => p.Category)
                                    .WithMany() // Category khong có sản phẩm nào 
                                    .HasForeignKey(p => p.CategoryId)  // Đặt tên Fk
                                    .OnDelete(DeleteBehavior.Cascade); // xóa 1 ko ảnh hưởng nhiều 
                entity.HasOne(p => p.Category2)
                                    .WithMany(c => c.Products) // Collect Navigation
                                    .HasForeignKey(p => p.CategoryId2)
                                    .OnDelete(DeleteBehavior.NoAction);
                entity.Property(p => p.Name)
                      .HasColumnName("ProductName")
                      .HasColumnType("ntext")
                      .HasMaxLength(100)
                      .IsRequired(true)
                      .HasDefaultValue("Product Default");  


            });
            // quan hệ 1 - 1
            modelBuilder.Entity<CategoryDetails>(entity =>
            {
                // tạo khóa chính
                entity.HasKey(x => x.CategoryDetailID);

                entity.HasOne(x => x.Category)
                      .WithOne(c => c.CategoryDetails)
                      .HasForeignKey<CategoryDetails>(c => c.CategoryDetailID)
                      .OnDelete(DeleteBehavior.Cascade);

            });
            //modelBuilder.Entity<Category>().HasMany<Product>(g => g.Products)
            //        .WithOne(s => s.Category)
            //        .HasForeignKey(s => s.CategoryId)
            //        .OnDelete(DeleteBehavior.Cascade);

        }


    }
}
