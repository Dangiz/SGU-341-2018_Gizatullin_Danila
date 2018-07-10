using BookSaver.Entities;
using System.Collections.Generic;

namespace BookSaver.DataContracts
{
    public interface IGenreDataAcces
    {
        void AddGenre(Genre genre);
        IEnumerable<Genre> GetAllGenres();
        IEnumerable<Genre> GetGenresByBookId(int id);
        IEnumerable<Genre> GetGenreByName(string name);
        Genre GetGenreById(int id);
        bool IsGenreUnique(Genre genre);

    }
}
