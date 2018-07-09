using BookSaver.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaver.DataContracts
{
    public interface IGenreDataAcces
    {
        void AddGenre(Genre genre);
        IEnumerable<Genre> GetAllGenres();
        IEnumerable<Genre> GetGenresByBookId(int id);
        IEnumerable<Genre> GetGenreByName(string name);
        Genre GetGenreById(int id);

    }
}
