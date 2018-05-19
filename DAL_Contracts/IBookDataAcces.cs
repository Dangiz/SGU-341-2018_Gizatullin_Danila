using System.Collections.Generic;
using BookSaver.Entities;

namespace BookSaver.DataContracts
{
    public interface IBookDataAcces
    {
        bool AddBook(Book book);
      
        IEnumerable<Book> GetAllBooks();
        
    }
}
