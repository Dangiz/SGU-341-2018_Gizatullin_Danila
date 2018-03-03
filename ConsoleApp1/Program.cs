using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RingClass;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ring r = new Ring(0, 0, 5, 6);
            r.SetRads(12, 12);
            Console.WriteLine(r.Area);
        }
    }
}
