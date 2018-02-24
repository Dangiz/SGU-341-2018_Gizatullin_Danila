using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            User Ivan = new User("Иван", "Иванов", "Иванович", new DateTime(1990, 01, 01));
            Console.WriteLine(Ivan.ToString() + "Of age:" + Ivan.Age);
        }
    }
}
