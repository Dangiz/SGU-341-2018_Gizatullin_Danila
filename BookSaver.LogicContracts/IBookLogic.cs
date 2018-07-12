using System.Collections.Generic;
using BookSaver.Entities;

namespace BookSaver.LogicContracts
{
    public interface IBookLogic
    {
        int AddBook(string name, int year, int authorId, int genreId, int publisherId);
        void RemoveBookAtId(int id);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksByGenreId(int genreId);
        IEnumerable<Book> GetBooksByAuthorId(int authorId);
        IEnumerable<Book> GetBooksByPublisherId(int publisherId);
    }
}
