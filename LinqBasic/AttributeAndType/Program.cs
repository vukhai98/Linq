using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AttributeAndType
{
    class Program
    {
        // Type -> class, struct,...int,bool...
        // Attribute
        //  Reflection :thong tin kieu du lieu, thoi diem thuc thi 
        /*
         * Mota
         * - thong tin chi tiet 
         */
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)] // Mota duoc su dung  dau
        public class MotaAttribute : Attribute
        {
            public string Thongtinchitiet { set; get; }
            public MotaAttribute(string _thongtinchitiet)
            {
                Thongtinchitiet = _thongtinchitiet;
            }
            static void Main(string[] args)
            {
                #region Type
                //    Console.OutputEncoding = Encoding.UTF8;
                //    //int a = 1;
                //    //var t = a.GetType();
                //    //Console.WriteLine(t.FullName);
                //    int[] a = { 1, 2, 4 };
                //    Type t = a.GetType(); //typeof(Array)
                //    Console.WriteLine(t.FullName);

                //    Console.WriteLine("Các thuộc tính :");
                //    // lấy ra các thuộc tính 
                //    t.GetProperties().ToList().ForEach(
                //        (PropertyInfo o) => { Console.WriteLine(o.Name); }
                //        );
                //    // lấy ra các phương thức
                //    Console.WriteLine("Các phương thức:");
                //    t.GetMethods().ToList().ForEach(
                //       (MethodInfo m) =>{
                //           Console.WriteLine(m.Name);
                //       });
                //}
                #endregion
                User user = new User()
                {
                    Name = null,
                    Age = 15,
                    PhoneNumber = "0934635346",
                    Email = "vukhai27091998.com "
                };
                //var properties = user.GetType().GetProperties();
                ////foreach (PropertyInfo property in properties)
                ////{
                ////    string name = property.Name;
                ////    var value = property.GetValue(user);
                ////    Console.WriteLine($"{name,15}: {value,25}");
                ////}
                //foreach (PropertyInfo property in properties)
                //{
                //    foreach (var attr in property.GetCustomAttributes(false))
                //    {
                //        MotaAttribute mota = attr as MotaAttribute;
                //        if (mota != null)
                //        {
                //            var value = property.GetValue(user);
                //            var name = property.Name;
                //            Console.WriteLine($"({name,15})-{mota.Thongtinchitiet,25}:{value}");

                //        }
                //    }   


                ValidationContext context = new ValidationContext(user);
                var result = new List<ValidationResult>();
                bool kq = Validator.TryValidateObject(user, context, result, true);
                if (kq == false)
                {
                    result.ToList().ForEach(er =>
                    {
                        Console.WriteLine(er.MemberNames.First());
                        Console.WriteLine(er.ErrorMessage);
                    });
                }
                Console.ReadLine();


             


            }
        }
    }
}
