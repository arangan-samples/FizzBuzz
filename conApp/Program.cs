using System;
using FizzBuzzLib;

namespace conApp
{
    class Program
    {
        // Unit test for this..... 
        // 1. case never breaks when divisible by 3 and 5
        // any other cases.... that we will need.
        // customer specify, any cases..... 3 and 5 and any combination
        // extra credit --- build script that will run and test
        static void Main(string[] args)
        {
            FizzBuzz fizzBuzz = new FizzBuzz(100, 3,5, "fizz","buzz");

            string val = string.Empty;

            while((val = fizzBuzz.GetNext()) != null)
            {
                Console.WriteLine(val);
            }
        }
    }
}
