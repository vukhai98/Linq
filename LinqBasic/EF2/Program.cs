using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF2
{
    class Program
    {
        static void CreatedDatabase()
        {
            using var dbContext = new ShopDbContext();
            {
                string dbName = dbContext.Database.GetDbConnection().Database;
                var result = dbContext.Database.EnsureCreated();
                if (result)
                {
                    Console.WriteLine($"Created {dbName} is success.");
                }
                else
                {
                    Console.WriteLine($"Created {dbName} isn't success.");
                }
            }
        }
        static void DropDatabase()
        {
            using var dbContext = new ShopDbContext();
            {
                string dbName = dbContext.Database.GetDbConnection().Database;
                var result = dbContext.Database.EnsureDeleted();
                if (result)
                {
                    Console.WriteLine($"Deleted {dbName} is success.");
                }
                else
                {
                    Console.WriteLine($"Deleted {dbName} isn't success.");
                }
            }
        }
        static void InsertDatabase()
        {
            using var dbContext = new ShopDbContext();
           
                dbContext.categories.AddRange(new List<Category>()
                {
                    new Category() {Name= "Phone", Discription= "Types Of Phones"},
                    new Category() {Name = "Drinks ",Discription= "Types Of Drinks"}

                });
                dbContext.products.AddRange(new List<Product>()
                {
                    new Product() {Name= "Iphone8",Price=1000, CategoryId=1 },
                    new Product() {Name= "Samsung",Price=900, CategoryId=1 },
                    new Product() {Name= "Wine",Price=500, CategoryId=2 },
                    new Product() {Name= "Nokia",Price=600, CategoryId=1 },
                    new Product() {Name= "Cafe",Price=100, CategoryId=2 },


                });
                 dbContext.SaveChanges();
            
        }
        static void Main(string[] args)
        {
            //DropDatabase();
            //CreatedDatabase();
            //DropDatabase();
            //InsertDatabase();
            using var dbContext = new ShopDbContext();
            //var category = (from c in dbContext.categories
            //                where c.CategoryId == 2
            //                select c).FirstOrDefault();
            //Console.WriteLine($"{category.CategoryId} + {category.Name}");
            //var e = dbContext.Entry(category);
            //e.Collection(c => c.Products).Load();
            //if (category.Products != null)
            //{
            //    Console.WriteLine($"So san pham: {category.Products.Count()}");
            //    foreach (var p in category.Products)
            //    {
            //        p.PrinInfo();
            //    }
            //}
            //Console.ReadLine();
            //var products = from p in dbContext.products
            //               where p.Name.Contains("i")
            //               orderby p.Price descending
            //               select p;
            //foreach (var p in products.Take(2).ToList())
            //{
            //    p.PrinInfo();
            //}
            //Console.ReadKey();

            var result = dbContext.products.
                Join(dbContext.categories, p => p.CategoryId, c => c.CategoryId,
                (p, c) => new
                {
                    Name = p.Name,
                    Menu = c.Name,
                    Price = p.Price

                });
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name}+{item.Menu}+{item.Price}");
            }
            Console.ReadLine();
               
            

        }
    }
}
