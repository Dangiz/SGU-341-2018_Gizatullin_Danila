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

        public BookLogic(IBookDataAcces bookDao, IGenreDataAcces genreDao)
        {
            _bookDao = bookDao;
            _genreDao = genreDao;
        }

        public Book AddBook(string name, string Author, string genre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookDao.GetAllBooks();
        }

        public IEnumerable<Author> GetBookAuthors(Book book)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetBookGenres(Book book)
        {
            return _genreDao.GetGenresByBookId(book.Id);
        }
    }
}
