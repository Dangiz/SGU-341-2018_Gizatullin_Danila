using System;
using System.Collections.Generic;

namespace BookSaver.Entities
{
    public class Magazine
    {
        public Magazine()
        {
        }

        public Magazine(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }


        
    }
}
