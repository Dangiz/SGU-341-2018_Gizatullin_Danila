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
        private readonly HashSet<Book> books;
        private readonly HashSet<Genre> genres;
        private int maxBookId;
        private int maxGenreId;

        public MemoryBookDao()
        {
            books = new HashSet<Book>();
            genres = new HashSet<Genre>();
            maxBookId = 0;
            maxGenreId = 0;
        }

        public bool AddBook(Book book)
        {
            book.Id = ++maxBookId;
            books.Add(book);
            AddGenre(book.Genre);
            return true;
        }

        public bool AddGenre(Genre genre)
        {
            if (!genres.Any(g => g.Name.CompareTo(genre.Name) == 0))
            {
                genre.Id = ++maxGenreId;
                genres.Add(genre);           
            }
            else
            {
                genre.Id = genres.First(g => g.Name.CompareTo(genre.Name) == 0).Id;
            }
            return true;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return genres;
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
