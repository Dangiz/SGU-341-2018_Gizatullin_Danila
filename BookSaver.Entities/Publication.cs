using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaver.Entities
{
    public class Publication
    {
        public Publication()
        {
        }

        public Publication(int id, string name, int year)
        {
            Id = id;
            Name = name;
            Year = year;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
   
    }
}
