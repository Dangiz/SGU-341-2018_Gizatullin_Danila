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
    public class BookLogic : IBookLogic
    {
        private IBookDataAcces _bookDao;

        public BookLogic(IBookDataAcces noteDao)
        {
            _bookDao = noteDao;
            //_noteDao = DaoProvider.NoteDao;
        }

        public Book AddBook(string Name, string Author, string Genre)
        {
            if(string.IsNullOrWhiteSpace(Name)|| string.IsNullOrWhiteSpace(Author)|| string.IsNullOrWhiteSpace(Genre))
            {
                throw new ArgumentException("One of inserted Book parametres are not available");
            }
            Book book = new Book(AddGenre(Genre), Name, Author);
            
            if(_bookDao.AddBook(book))
            {
                return book;
            }
            else
            {
                throw new InvalidOperationException("Error by saving new book");
            }
        }
        public Genre AddGenre(string Name)
        {
            if(string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("Genre Name is whitespace or null");
            }
            Genre genre = new Genre(Name);
            if (_bookDao.AddGenre(genre))
            {
                return genre;
            }
            else
            {
                throw new InvalidOperationException("Error by saving new Genre");
            }
        }
        public Genre[] GetAllGenres()
        {
            return _bookDao.GetAllGenres().ToArray();
        }
        public Book[] GetAllBooks()
        {
            return _bookDao.GetAllBooks().ToArray();
        }

        public IEnumerable<Book> GetBookBySubstr()
        {
            throw new NotImplementedException();
        }
    }
}
