using System;
using System.Collections.Generic;
using BookSaver.Entities;
using BookSaver.LogicContracts;
using BookSaver.DataContracts;
using System.Text.RegularExpressions;

namespace BookSaver.Logic
{
    public class BookLogic : IBookLogic
    {
        private IBookDataAcces _bookDao;
        private IGenreDataAccess _genreDao;
        private IAuthorDataAccess _authorDao;
        private IPublisherDataAccess _publisherDao;

        public BookLogic(IBookDataAcces bookDao, IGenreDataAccess genreDao, IAuthorDataAccess authorDao, IPublisherDataAccess publisherDao)
        {
            _bookDao = bookDao;
            _genreDao = genreDao;
            _authorDao = authorDao;
            _publisherDao = publisherDao;
        }

        public IEnumerable<Book> GetBooksByPublisherId(int publisherId)
        {
            return _bookDao.GetBooksByPublisherID(publisherId);
        }

        public int AddBook(string name, int year, int authorId, int genreId, int publisherId)
        { 

            if(_authorDao.GetAuthorByID(authorId)==null)
            {
                throw new ArgumentException("Author with this Id does not exist");
            }
            if (_genreDao.GetGenreById(genreId)== null)
            {
                throw new ArgumentException("Genre with this Id does not exist");
            }
            if (_publisherDao.GetPublisherById(publisherId) == null)
            {
                throw new ArgumentException("Publisher with this Id does not exist");
            }
            if (!ValidationHelper.StringAlphaNumericValidation(name,150))
            {
                throw new ArgumentException("Wrong book name format");
            }

            if (!ValidationHelper.YearValidation(year))
            {
                throw new ArgumentException("Wrong Year format");
            }

            Book book = new Book() { Name = name, Year = year };

            if(!_bookDao.IsBookUnique(book,publisherId))
            {
                throw new ArgumentException("Book with this data already exist");
            }

            return _bookDao.AddBook(book, authorId, genreId, publisherId);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookDao.GetAllBooks();
        }

        public IEnumerable<Book> GetBooksByAuthorId(int authorId)
        {
            if (_authorDao.GetAuthorByID(authorId) != null)
            {
                return _bookDao.GetBooksByAuthorID(authorId);
            }
            else
            {
                throw new ArgumentException("No Author with such id");
            }
        }

        public IEnumerable<Book> GetBooksByGenreId(int genreId)
        {
            if (_genreDao.GetGenreById(genreId) != null)
            {
                return _bookDao.GetBooksByGenreID(genreId);
            }
            else throw new ArgumentException("No Genre with such id");
        }

        public void RemoveBookAtId(int id)
        {
            if (_bookDao.GetBookById(id) != null)
            {
                _bookDao.RemoveBookById(id);
                _authorDao.RemoveAuthorsWithoutAnyPublicationsOrBooks();
            }
            else
            {
                throw new ArgumentException("No book with this Id");
            }
        }

    }
}
