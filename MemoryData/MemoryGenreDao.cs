using BookSaver.DataContracts;
using BookSaver.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaver.MemoryBookData
{
    public class MemoryGenreDao:IGenreDataAcces
    {

        private readonly HashSet<Genre> genres;
        private int maxGenreId;

        public MemoryGenreDao()
        {
            genres = new HashSet<Genre>();
            maxGenreId = 0;
        }

        public bool AddGenre(Genre genre)
        {
            if (!genres.Any(g => g.Name.CompareTo(genre.Name) == 0))
            {
                genre.Id = ++maxGenreId;
                genres.Add(genre);
            }
            else
            {
                genre.Id = genres.First(g => g.Name.CompareTo(genre.Name) == 0).Id;
            }
            return true;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return genres;
        }
    }
}
