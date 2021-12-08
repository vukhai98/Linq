using System;

namespace ActionVsFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> myAction = new Action<int>(DoSomeThing);
            myAction(obj: 123);
            Func<int, double> myFunc = new Func<int, double>(CalculateSomething);
            Console.WriteLine( myFunc(arg: 5));

            Console.ReadKey();
        }
        static void DoSomeThing(int i)
        {
            Console.WriteLine(i);
        }
        static double CalculateSomething(int i)
        {
            return (double)i / 2;
        }
    }
}
