using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.Entities;

namespace BookSaver.LogicContracts
{
    public interface IAuthorLogic
    {
        IEnumerable<Author> GetAllAuthors();
        IEnumerable<Publication> GetAuhtorPublications(Author author);
        IEnumerable<Book> GetAuthorBooks(Author author);
        void AddAuthor(string name, string surname);
    }
}
