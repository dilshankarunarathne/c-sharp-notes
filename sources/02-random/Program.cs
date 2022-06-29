using System;

namespace CSharpFundementals 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var number = random.Next(1, 100);
                Console.WriteLine(number);
            }
        }
    }
}