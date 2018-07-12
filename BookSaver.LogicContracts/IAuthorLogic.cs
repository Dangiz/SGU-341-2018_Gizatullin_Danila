
using System.Collections.Generic;
using BookSaver.Entities;

namespace BookSaver.LogicContracts
{
    public interface IAuthorLogic
    {
        IEnumerable<Author> GetAllAuthors();
        IEnumerable<Author> GetAuthorsByBookId(int bookId);
        IEnumerable<Author> GetAuthorsByPublicationId(int publicationId);
        void AddAuthor(string name, string surname);
    }
}
