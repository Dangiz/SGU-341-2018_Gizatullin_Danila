using System.Collections.Generic;
using BookSaver.Entities;

namespace BookSaver.LogicContracts
{
    public interface IBookLogic
    {

        Book AddBook(string name, string Author, string genre);
        IEnumerable<Book> GetAllBooks();
    }
}
