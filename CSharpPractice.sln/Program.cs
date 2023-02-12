using System;
using CSharpPractice.Classes;

namespace CSharpPractice
{
    internal class Program
    {
        static double numberTwo = 100;

        static void Main(string[] args)
        {


            double[] numbers = { 1, 2, 3, 43, 42154};
            double mathResult = SimpleMath.Add(numbers);

            BankAccount bankAccount = new BankAccount(1000);
            bankAccount.AddToBalance(numberTwo);

            Console.WriteLine(bankAccount.Balance);
            Console.WriteLine(mathResult);

            ChildBankAccount childBankAccount = new ChildBankAccount();

            childBankAccount.AddToBalance(numberTwo);
            Console.WriteLine(childBankAccount.Balance);

            Console.ReadLine();
        }
    }

    class SimpleMath
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

    }
}
