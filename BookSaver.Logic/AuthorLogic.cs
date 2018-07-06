using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.Entities;
using BookSaver.LogicContracts;
using BookSaver.DataContracts;

namespace BookSaver.Logic
{
    public class AuthorLogic : IAuthorLogic
    {

        private IBookDataAcces _bookDao;
        private IAuthorDataAccess _authorDao;

        public AuthorLogic(IBookDataAcces bookDao, IAuthorDataAccess authorDao)
        {
            _bookDao = bookDao;
            _authorDao = authorDao;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorDao.GetAllAuthors();
        }

        public IEnumerable<Publication> GetAuhtorPublications(Author author)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAuthorBooks(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
