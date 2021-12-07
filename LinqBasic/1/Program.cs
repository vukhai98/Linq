using System;

namespace TestExtensions
{
    class Program
    {

        public static void Main()
        {

            string s = "100";
            int i = s.ToInt32();
            i++;
            Console.WriteLine(i);
            Console.ReadKey();
        }
    }

    public static class Y2Extensions
    {
        public static int ToInt32(this object obj)
        {
            return Int32.Parse(obj.ToString());
        }
    }
}
