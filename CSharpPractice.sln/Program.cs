using System;
using CSharpPractice.Classes;
using CSharpPractice.Interface;
using Microsoft.VisualBasic;

namespace CSharpPractice
{
    internal class Program
    {
        static double numberTwo = 100;

        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount(1000);
            bankAccount.AddToBalance(numberTwo);

            SimpleMath simpleMath = new SimpleMath();

            Console.WriteLine(Information(bankAccount));
            Console.WriteLine(Information(simpleMath));


            Console.ReadLine();
        }

        private static string Information(IInformation information)
        {
            return information.GetInformation();
        }
    }

    class SimpleMath: IInformation
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Add(double[] numbers)
        {
            double result = 0;
            foreach(double d in numbers)
            {
                result += d;
            }
            return result;
        }

        public string GetInformation()
        {
            return "Class that solves simple math.";
        }
    }
}
