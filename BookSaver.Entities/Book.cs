using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaver.Entities
{
    public class Book
    {
        public Book(Genre genre, string name, string author)
        {
            Genre = genre;
            Name = name;
            Author = author;
        }

        public Book(int id, Genre genre, string name, string author)
        {
            Id = id;
            Genre = genre;
            Name = name;
            Author = author;
        }

        public int Id { get; set; }
        public Genre Genre { get; set; }
        public String Name { get; set; }
        public String Author { get; set; }
    }
}
