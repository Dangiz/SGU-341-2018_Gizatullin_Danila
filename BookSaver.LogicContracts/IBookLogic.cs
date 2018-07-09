using System.Collections.Generic;
using BookSaver.Entities;

namespace BookSaver.LogicContracts
{
    public interface IBookLogic
    {
        void AddBook(string name, int year, int authorId, int genreId, int publisherId);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Genre> GetBookGenres(Book book);
        IEnumerable<Author> GetBookAuthors(Book book);
        void RemoveBookAtId(int id);
    }
}
