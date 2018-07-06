using System.Collections.Generic;
using BookSaver.Entities;

namespace BookSaver.LogicContracts
{
    public interface IBookLogic
    {
        Book AddBook(string name, string Author, string genre);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Genre> GetBookGenres(Book book);
        IEnumerable<Author> GetBookAuthors(Book book);
    }
}
