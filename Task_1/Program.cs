using System;

namespace Task_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Round r=RoundLoader.LoadFromFile("Round.txt");
            Console.WriteLine(r.Space);
        }
    }
}