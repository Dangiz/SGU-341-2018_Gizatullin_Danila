using System;
using System.Collections.Generic;
using System.Linq;
using BookSaver.Entities;
using BookSaver.LogicContracts;
using BookSaver.DataContracts;

namespace BookSaver.Logic
{
    //public class BookLogic : IBookLogic
    //{
    //    private IBookDataAcces _bookDao;
    //    private IGenreLogic _genreLogic;

    //    public BookLogic(IBookDataAcces bookDao,IGenreLogic genreLogic)
    //    {
    //        _bookDao = bookDao;
    //        _genreLogic = genreLogic;
    //    }

    //    public Book AddBook(string name, string author, string genre)
    //    {
    //        if (string.IsNullOrWhiteSpace(name) || 
    //            string.IsNullOrWhiteSpace(author) || 
    //            string.IsNullOrWhiteSpace(genre))
    //        {
    //            throw new ArgumentException("One of inserted Book parametres are not available");
    //        }
    //        Book book = new Book(_genreLogic.AddGenre(genre), name, author);
            
    //        if(_bookDao.AddBook(book))
    //        {
    //            return book;
    //        }
    //        else
    //        {
    //            throw new InvalidOperationException("Error by saving new book");
    //        }
    //    }

    //    public IEnumerable<Book> GetAllBooks()
    //    {
    //        return _bookDao.GetAllBooks();
    //    }

    //}
}
