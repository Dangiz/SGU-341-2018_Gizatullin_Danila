using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaver.Entities
{
    public class Author
    {

        public Author(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
