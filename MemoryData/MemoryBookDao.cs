using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.DataContracts;
using BookSaver.Entities;

namespace BookSaver.MemoryBookData
{
    public class MemoryBookDao : IBookDataAcces
    {
        private IGenreDataAcces _genreDao;
        private readonly HashSet<Book> books;

        private int maxBookId;

        public MemoryBookDao(IGenreDataAcces genreDao)
        {
            books = new HashSet<Book>();
            _genreDao = genreDao;
            maxBookId = 0;
            
        }

        public bool AddBook(Book book)
        {
            book.Id = ++maxBookId;
            books.Add(book);
            _genreDao.AddGenre(book.Genre);
            return true;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return books.Select(n => n);
        }


        public Book GetBookById(int id)
        {
            return books.FirstOrDefault(n => n.Id == id);
        }
    }
}
