using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ1
{
    // LINQ (Language Integrated Query): Ngon ngu truy van tich hop
    // SQL 
    // Nguon du lieu: IEnumerable,IEmumerabl<T>(Array,List,Stack,Queue.......)
    // XML, SQL, Objcect, Entity(EF Core), DataSet(ADO.Net)
    public class Product
    {
        public int ID { set; get; }
        public string Name { set; get; }         // tên
        public double Price { set; get; }        // giá
        public string[] Colors { set; get; }     // cá màu
        public int Brand { set; get; }           // ID Nhãn hiệu, hãng
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }
        // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
        override public string ToString()
           => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";

    }
    public class Brand
    {
        public string Name { set; get; }
        public int ID { set; get; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var brands = new List<Brand>() {
                new Brand{ID = 1, Name = "Công ty AAA"},
                new Brand{ID = 1, Name = "Công ty AAA"},
                new Brand{ID = 2, Name = "Công ty BBB"},
                new Brand{ID = 4, Name = "Công ty CCC"},
            };

            var products = new List<Product>()
            {
                new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };
            #region Select,Where,Join,GroupJoin
            // lấy ra sản phẩm giá 400
            //var result = from p in products
            //             where p.Price == 400
            //             select p;
            //foreach (var product in result)
            //{
            //    Console.WriteLine(product);
            //}

            // Selcet 
            //var result = products.Select(
            //    p =>
            //    {
            //        return new
            //        {
            //            Ten = p.Name,
            //            Gia = p.Price
            //        };
            //    });

            // Join
            //var result = products
            //             .Join(brands, p => p.Brand, b => b.ID, (p, b) => new
            //{
            //    NameProduct = p.Name,
            //    NameBrand = b.Name
            //});
            //foreach (var item in result)
            //{
            //    Console.OutputEncoding = Encoding.UTF8;
            //    Console.WriteLine($"{item.NameProduct,10} {item.NameBrand,10}");
            //}
            //Console.ReadKey();
            // GroupJoin
            //var result = brands.GroupJoin(products, b => b.ID, p => p.Brand,
            //    (b, p) => new
            //    {
            //        Thuonghieu = b.Name,
            //        Cacsanpham = p
            //    });

            //foreach (var gr in result)
            //{
            //    Console.OutputEncoding = Encoding.UTF8;
            //    Console.WriteLine(gr.Thuonghieu);
            //    foreach (var p in gr.Cacsanpham)
            //    {
            //        Console.OutputEncoding = Encoding.UTF8;
            //        Console.WriteLine(p);
            //    }
            //}


            #endregion

            // take
            //products.Take(4).ToList().ForEach(p => { Console.OutputEncoding = Encoding.UTF8; Console.WriteLine(p); });
            // skip
            //products.Skip(2).ToList().ForEach(p => { Console.OutputEncoding = Encoding.UTF8; Console.WriteLine(p); });
            //Orderby(tăng dần) / OrderbyDescending (giam dần)
            //Reverse
            //Group by

            //var result = products.GroupBy(p => p.Brand);
            //foreach (var group in result)
            //{
            //    Console.OutputEncoding = Encoding.UTF8;
            //    Console.WriteLine(group.Key);
            //    foreach (var p in group)
            //    {
            //        Console.OutputEncoding = Encoding.UTF8;
            //        Console.WriteLine(p);
            //    }
            //}
            // Distinct
            // Single SingleOrDefault
            //Any 
            //All
            //Count

            // In ra ten sam pham , ten thuong hieu , co gia (300-400)
            // gia giam dan 
            //var result = products.Where(p => p.Price >= 300 && p.Price <= 400)
            //                     .OrderByDescending(p => p.Price)
            //                     .Join(brands, p => p.Brand, b => b.ID, (p, b) => new
            //                     {
            //                         Tensanpham = p.Name,
            //                         Tenthuonghieu = b.Name,
            //                         Gia = p.Price

            //                     });
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.Tensanpham,15} {item.Tenthuonghieu,15} {item.Gia,10}");
            //}

            /*
             *  Query syntax LINQ
             *  1, xac dinh nguon : from tênphầntử in IEnumerables
             *  ...........where,oderby...
             *  2, lấy dữ liệu : seclec , gruop by
             */
            Console.OutputEncoding = Encoding.UTF8;

            //var result = from p in products
            //             from c in p.Colors
            //             where p.Price >= 400 && c == "Xanh"
            //             orderby p.Price descending
            //             select new
            //             {
            //                 Name = p.Name,
            //                 Prices = p.Price,
            //                 Color = p.Colors,
            //             };
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.Name,10} {item.Prices} {string.Join(",",item.Color)}");
            //}
            //var groupBy = from p in products
            //              group p by p.Price into gr
            //              orderby gr.Key
            //              select gr;
            //foreach (var group in groupBy)
            //{
            //    Console.WriteLine($" Price: {group.Key}");
            //    foreach (var p in group)
            //    {
            //        Console.WriteLine($"{p,30}");
            //    }
            //}
            //var result = from product in products
            //             group product by product.Price into gr
            //             orderby gr.Key
            //             let quantily = "Số lượng san phẩm:" + gr.Count()
            //             select new
            //             {
            //                 Gia = gr.Key,
            //                 Cacsanpham = gr.ToList(),
            //                 Soluong = quantily
            //             };
            //foreach (var gruop in result)
            //{
            //    Console.WriteLine($"Price:{gruop.Gia} quantily:{gruop.Soluong}");
            //    foreach (var item in gruop.Cacsanpham)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            var result_Join = from p in products
                              join b in brands
                              on p.Brand equals b.ID into t
                              from x in t.DefaultIfEmpty()
                              select new
                              {
                                  Ten = p.Name,
                                  gia = p.Price,
                                  Tenthuonghieu = (x != null)?x.Name:"NoBrand"
                              };
            foreach (var item in result_Join)
            {
                Console.WriteLine($"Brand:{item.Tenthuonghieu,10}  ProductName:{item.Ten,12}  Pirce:{item.gia,5}");
            }
        }
    }
}
 