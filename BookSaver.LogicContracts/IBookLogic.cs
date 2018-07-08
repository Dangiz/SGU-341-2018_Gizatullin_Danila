using System.Collections.Generic;
using BookSaver.Entities;

namespace BookSaver.LogicContracts
{
    public interface IBookLogic
    {
        void AddBook(string name, int year, Author author, Genre genre, Publisher publisher);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Genre> GetBookGenres(Book book);
        IEnumerable<Author> GetBookAuthors(Book book);
    }
}
