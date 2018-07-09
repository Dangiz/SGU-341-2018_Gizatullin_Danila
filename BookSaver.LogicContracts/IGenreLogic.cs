using BookSaver.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaver.LogicContracts
{
    public interface IGenreLogic
    {
        void AddGenre(string name);
        IEnumerable<Genre> GetAllGenres();
        IEnumerable<Book> GetGenreBooks(Genre genre);
    }
}
