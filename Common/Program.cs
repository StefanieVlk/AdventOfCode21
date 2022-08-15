using System;
using AoCDay01;
using AoCDay02;

namespace Common
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Day 01 ===");
            Day01 day01 = new Day01();
            Console.WriteLine("Result Task 1: "+ day01.ExecuteFirstTask());
            Console.WriteLine("Result Task 2: "+ day01.ExecuteSecondTask());

            Console.WriteLine("=== Day 02 ===");
            Day02 day02 = new Day02();
            Console.WriteLine("Result Task 1: "+ day02.ExecuteFirstTask());
        }
    }
}
