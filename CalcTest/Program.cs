using System;
using CalcBasic;

namespace CalcTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello to Calc Test!");
            Console.WriteLine(string.Format("{0} + {1} = {2}", 20, 22, BasicMath.Sum(20, 22)));
            Console.WriteLine(string.Format("{0} - {1} = {2}", 50, 8, BasicMath.Difference(50, 8)));
            Console.WriteLine(string.Format("{0} * {1} = {2}", 7, 6, BasicMath.Multiplication(7, 6)));
            Console.WriteLine(string.Format("{0} / {1} = {2}", 420, 10, BasicMath.Division(420, 10)));
        }
    }
}
