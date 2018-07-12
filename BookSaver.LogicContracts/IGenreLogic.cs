using BookSaver.Entities;
using System.Collections.Generic;

namespace BookSaver.LogicContracts
{
    public interface IGenreLogic
    {
        void AddGenre(string name);
        IEnumerable<Genre> GetAllGenres();
        IEnumerable<Genre> GetGenresByBookId(int bookId);
        
    }
}
