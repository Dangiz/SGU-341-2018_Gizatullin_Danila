using BookSaver.Entities;
using System.Collections.Generic;

namespace BookSaver.DataContracts
{
    public interface IAuthorDataAccess
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorByID(int id);
        IEnumerable<Author> GetAuthorsByBookId(int id);
        void AddAuthor(Author author);
        void RemoveAuthorsWithoutAnyPublicationsOrBooks();
        IEnumerable<Author> GetAuthorsByPublicationId(int id);
    }
}
