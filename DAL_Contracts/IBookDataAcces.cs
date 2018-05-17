using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.Entities;

namespace BookSaver.DataContracts
{
    public interface IBookDataAcces
    {
        bool AddBook(Book book);
        bool AddGenre(Genre genre);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Genre> GetAllGenres();
    }
}
