using System;
using System.Collections.Generic;

namespace BookSaver.Entities
{
    public class Genre
    {

        public Genre(int id, string name)
        {         
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; set; }
        
    }
}
