using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF2
{
    class Program
    {
        static void CreateDatabase()
        {
            using var dbcontext = new ProductDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            //Console.WriteLine(dbname);
            var result = dbcontext.Database.EnsureCreated();
            if (result)
            {
                Console.WriteLine($"Create database {dbname} is success.");
            }
            else
            {
                Console.WriteLine($"Create database{dbname} isn't success.");
            }
            Console.ReadLine();
        }
        static void DropDatabase()
        {
            using var dbcontext = new ProductDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            //Console.WriteLine(dbname);
            var result = dbcontext.Database.EnsureDeleted();
            if (result)
            {
                Console.WriteLine($"Deleted database {dbname} is success.");
            }
            else
            {
                Console.WriteLine($"Deleted database{dbname} isn't success.");
            }
            Console.ReadLine();
        }
        static void InsertProduct()
        {
            using var dbContext = new ProductDbContext();
            /*
             * Model(Product)
             * Add,AddAsyc
             * SaveChange
             */
            dbContext.AddRange(new List<Product>(){
                new Product() { ProductName = "Product 2",Provider="Company 2" },
                new Product() { ProductName = "Product 3",Provider="Company 3" },
                new Product() { ProductName = "Product 4",Provider="Company 4" },
                new Product() { ProductName = "Product 5",Provider="Company 5" },
            });
            int number_rows = dbContext.SaveChanges();
            Console.WriteLine($"Added {number_rows} rows.");
            Console.ReadKey();

        }
        static void ReadProduct()
        {
            using var dbContext = new ProductDbContext();
            var result = dbContext.products.Select(s => s).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item.ProductId + item.ProductName + item.Provider);
            }
            Console.ReadKey();
        }
        //static void RenameProduct(int id, string newName)
        //{
        //    using var dbContext = new ProductDbContext();
        //    Product product = (from p in dbContext.products
        //                       where p.ProductId == id
        //                       select p).FirstOrDefault();
        //    if (product != null)
        //    {
        //        product.ProductName = newName;
        //        int numberRows = dbContext.SaveChanges();
        //        Console.WriteLine($"Updete name:{numberRows} product");

        //    }
        //}
        static void DeleteProduct(int id)
        {
            using var dbContext = new ProductDbContext();
            Product product = (from p in dbContext.products
                               where p.ProductId == id
                               select p).FirstOrDefault();
            if (product != null)
            {
                dbContext.Remove(product);
                int numberRows = dbContext.SaveChanges();
                Console.WriteLine($"Delete {numberRows} product");

            }
            
        }
        static void Main(string[] args)
        {
            // Entity -> Database, Table
            // Database - SQL Sever : data01 : DbContext
            // --product
            //CreateDatabase();
            //DropDatabase();
            //InsertProduct();
            //ReadProduct();
            //RenameProduct(1,"Iphone");
            DeleteProduct(5);
        }
    }
}
