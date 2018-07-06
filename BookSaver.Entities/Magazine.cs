using System;
using System.Collections.Generic;

namespace BookSaver.Entities
{
    public class Magazine
    {
        private Func<IEnumerable<Publication>> getPublications;

        public Magazine(Func<IEnumerable<Publication>> getPublications, int id, string name)
        {
            this.getPublications = getPublications;
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }


        
    }
}
