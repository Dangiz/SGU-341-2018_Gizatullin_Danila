using BookSaver.Entities;
using System.Collections.Generic;

namespace BookSaver.DataContracts
{
    public interface IGenreDataAccess
    {
        void AddGenre(Genre genre);
        IEnumerable<Genre> GetAllGenres();
        IEnumerable<Genre> GetGenresByBookId(int id);
        Genre GetGenreById(int id);
        bool IsGenreUnique(Genre genre);

    }
}
