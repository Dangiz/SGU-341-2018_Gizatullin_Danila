using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaver.Entities
{
    public class Genre
    {
        public Genre(string name)
        {
            Name = name;
        }

        public Genre(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public String Name { get; set; }
    }
}
