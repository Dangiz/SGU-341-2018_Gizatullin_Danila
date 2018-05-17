using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.Entities;

namespace BookSaver.LogicContracts
{
    public interface IBookLogic
    {
        Book AddBook(String Name,String Author,String Genre);
        Genre AddGenre(String Name);
        Book[] GetAllBooks();
        Genre[] GetAllGenres();
        IEnumerable<Book> GetBookBySubstr();
    }
}
