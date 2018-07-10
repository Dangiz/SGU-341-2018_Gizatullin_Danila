
using System.Collections.Generic;
using BookSaver.Entities;

namespace BookSaver.LogicContracts
{
    public interface IAuthorLogic
    {
        IEnumerable<Author> GetAllAuthors();
        IEnumerable<Publication> GetAuhtorPublications(int authorId);
        IEnumerable<Book> GetAuthorBooks(int authorId);
        void AddAuthor(string name, string surname);
    }
}
