using System;
using System.Collections.Generic;
using System.Linq;
using BookSaver.Entities;
using BookSaver.LogicContracts;
using BookSaver.DataContracts;

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


        public void AddBook(string name, int year, Author author, Genre genre,Publisher publisher)
        {
            _bookDao.AddBook(new Book() { Name = name, Year = year }, author.Id, genre.Id, publisher.Id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookDao.GetAllBooks();
        }

        public IEnumerable<Author> GetBookAuthors(Book book)
        {
            return _authorDao.GetAuthorsByBookId(book.Id);
        }

        public IEnumerable<Genre> GetBookGenres(Book book)
        {
            return _genreDao.GetGenresByBookId(book.Id);
        }
    }
}
