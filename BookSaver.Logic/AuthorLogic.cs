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

        public void AddAuthor(string name, string surname)
        {
            if(String.IsNullOrEmpty(name) || name.Length>150 || Regex.Match(name, @"\A[a-zA-Z]+\Z").Length!=name.Length)
            {
                throw new ArgumentException("Author name has wrong format");
            }
            if (String.IsNullOrEmpty(surname) || surname.Length > 150 || Regex.Match(surname, @"\A[a-zA-Z]+\Z").Length != surname.Length)
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

        public IEnumerable<Publication> GetAuhtorPublications(Author author)
        {
            if (_authorDao.GetAuthorByID(author.Id)!=null)
            {
                return _publicationDao.GetPublicationByAuthorId(author.Id);
            }
            else
            {
                throw new ArgumentException("No Author with such id");
            }
        }

        public IEnumerable<Book> GetAuthorBooks(int authorId)
        {
            if(_authorDao.GetAuthorByID(authorId)!=null)
            {
                return _bookDao.GetBooksByAuthorID(authorId);
            }
            else
            {
                throw new ArgumentException("No Author with such id");
            }
        }
    }
}
