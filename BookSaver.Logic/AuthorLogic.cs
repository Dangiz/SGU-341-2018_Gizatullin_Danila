using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BookSaver.Entities;
using BookSaver.LogicContracts;
using BookSaver.DataContracts;

namespace BookSaver.Logic
{
    public class AuthorLogic : IAuthorLogic
    {

        private IBookDataAcces _bookDao;
        private IAuthorDataAccess _authorDao;
        private IPublicationDataAccess _publicationDao;

        public AuthorLogic(IBookDataAcces bookDao, IAuthorDataAccess authorDao, IPublicationDataAccess publicationDao)
        {
            _bookDao = bookDao;
            _authorDao = authorDao;
            _publicationDao = publicationDao;
        }

        public IEnumerable<Author> GetAuthorsByBookId(int bookId)
        {
            if (_bookDao.GetBookById(bookId) != null)
            {
                return _authorDao.GetAuthorsByBookId(bookId);
            }
            else
            {
                throw new ArgumentException("No book with such id");
            }

        }

        public void AddAuthor(string name, string surname)
        {
            if(!ValidationHelper.StringAlphaValidation(name,150))
            {
                throw new ArgumentException("Author name has wrong format");
            }
            if (!ValidationHelper.StringAlphaValidation(surname, 150))
            {
                throw new ArgumentException("Author surname has wrong format");
            }
            Author author = new Author() { Name = name, Surname = surname };
            _authorDao.AddAuthor(author);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorDao.GetAllAuthors();
        }

        public IEnumerable<Author> GetAuthorsByPublicationId(int publicationId)
        {
            return _authorDao.GetAuthorsByPublicationId(publicationId);
        }
    }
}
