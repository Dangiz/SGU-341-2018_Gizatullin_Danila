using System.Collections.Generic;
using BookSaver.Entities;

namespace BookSaver.DataContracts
{
    public interface IBookDataAcces
    {
        bool AddBook(Book book);
        Book GetBookById(int id);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksByGenreID(int id);
    }
}
