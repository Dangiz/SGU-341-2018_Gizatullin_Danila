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
        private IGenreDataAcces _genreDao;
        private IAuthorDataAccess _authorDao;
        private IPublisherDataAccess _publisherDao;

        public BookLogic(IBookDataAcces bookDao, IGenreDataAcces genreDao, IAuthorDataAccess authorDao, IPublisherDataAccess publisherDao)
        {
            _bookDao = bookDao;
            _genreDao = genreDao;
            _authorDao = authorDao;
            _publisherDao = publisherDao;
        }

        public void AddBook(string name, int year, int authorId, int genreId, int publisherId)
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
            if (String.IsNullOrEmpty(name) || name.Length > 150 || Regex.Match(name,@"\A[a-zA-Z0-9 ]+\Z").Length!=name.Length)
            {
                throw new ArgumentException();
            }

            if (year / 1000 != 2 & year / 1000 != 1)
            {
                throw new ArgumentException();
            }

            Book book = new Book() { Name = name, Year = year };

            if(!_bookDao.IsBookUnique(book,publisherId))
            {
                throw new ArgumentException();
            }

            _bookDao.AddBook(book, authorId, genreId, publisherId);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookDao.GetAllBooks();
        }

        public IEnumerable<Author> GetBookAuthors(int bookId)
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

        public IEnumerable<Genre> GetBookGenres(int bookId)
        {
            if (_bookDao.GetBookById(bookId) != null)
            {
                return _genreDao.GetGenresByBookId(bookId);
            }
            else
            {
                throw new ArgumentException("No book with such id");
            }
        }

        public void RemoveBookAtId(int id)
        {
            if (_bookDao.GetBookById(id) != null)
            {
                _bookDao.RemoveBookById(id);
                _authorDao.RemoveAllLazyAuthors();
            }
            else
            {
                throw new ArgumentException("No book with this Id");
            }
        }

    }
}
