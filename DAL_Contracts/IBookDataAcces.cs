﻿using System.Collections.Generic;
using BookSaver.Entities;

namespace BookSaver.DataContracts
{
    public interface IBookDataAcces
    {
        void AddBook(Book book,int authorId,int genreId,int publisherId);
        Book GetBookById(int id);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksByGenreID(int id);
        IEnumerable<Book> GetBooksByAuthorID(int id);
        bool IsBookUnique(Book book,int publisherId);
        void RemoveBookById(int id);
    }
}
