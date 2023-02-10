using System;

namespace CSharpPractice.sln
{
    internal class Program
    {
        static double numberTwo = 12.34;

        static void Main(string[] args)
        {

            if(numberTwo == 1)
            {
                var numberThree = 12f;
            }
            int numberOne = 23;
            Console.WriteLine($"{numberOne}");
            Console.WriteLine($"{numberTwo}");
            var message = Console.ReadLine();
            Console.WriteLine(SimpleMath.Add(numberOne, numberTwo));
            Console.ReadLine();
        }
    }

    class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
    }
}
