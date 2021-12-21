using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF2
{
   public class ProductDbContext : DbContext
    {
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { 
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
             //builder.AddConsole()
            }); 


        public DbSet<Product> products { get; set; }
        private const string connectingString = @"Server=ADMIN;
                                                  Database=Data01;
                                                  Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectingString);
        }
    }
}
