using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.Entities;

namespace BookSaver.DataContracts
{
    public interface IAuthorDataAccess
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorByID(int id);
        IEnumerable<Author> GetAuthorsByBookId(int id);
        void AddAuthor(Author author);
        void RemoveAllLazyAuthors();
    }
}
