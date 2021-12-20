using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace WorkingWithJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = "{   \"id\":\"1103556660738 \",   \"picture\":{      \"data\":{         \"url\":\"https//fbcdn-profile-a.akamaihd.net/hprofile-ak-prn2/1027805_12033339550_4857557559_n.jpq\",         \"is_silhouette\":false      }   }}";
            //dynamic obj = JObject.Parse(json);
            //Console.WriteLine((string)obj.picture.data.url);
            JObject obj = JObject.Parse(json);
            var url = obj.Descendants().OfType<JProperty>()
                .FirstOrDefault(p => p.Name == "url")?.Value?.ToString();
            if (string.IsNullOrWhiteSpace(url)) // Check xem giá trị trả gia có null không.
            {
                Console.WriteLine("It is  Null");
            }
            else
            {
                Console.WriteLine(url);
            }
            Console.ReadKey();

        }
    }
}
