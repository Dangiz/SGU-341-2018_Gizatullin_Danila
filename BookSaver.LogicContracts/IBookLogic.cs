using System.Collections.Generic;
using BookSaver.Entities;

namespace BookSaver.LogicContracts
{
    public interface IBookLogic
    {
        void AddBook(string name, int year, int authorId, int genreId, int publisherId);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Genre> GetBookGenres(int bookId);
        IEnumerable<Author> GetBookAuthors(int bookId);
        void RemoveBookAtId(int id);
    }
}
