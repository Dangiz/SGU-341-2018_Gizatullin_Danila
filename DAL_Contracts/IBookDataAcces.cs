using BookSaver.Entities;
using System.Collections.Generic;

namespace BookSaver.DataContracts
{
    public interface IBookDataAcces
    {
        int AddBook(Book book,int authorId,int genreId,int publisherId);
        Book GetBookById(int id);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksByGenreID(int id);
        IEnumerable<Book> GetBooksByAuthorID(int id);
        IEnumerable<Book> GetBooksByPublisherID(int id);
        bool IsBookUnique(Book book,int publisherId);
        void RemoveBookById(int id);
    }
}
