using System;
using CSharpPractice.Classes;

namespace CSharpPractice
{
    internal class Program
    {
        static double numberTwo = 100;

        static void Main(string[] args)
        {

            BankAccount bankAccount = new BankAccount();
            bankAccount.AddToBalance(numberTwo);

            Console.WriteLine(bankAccount.Balance);

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
    }
}
