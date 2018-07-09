using BookSaver.DataContracts;
using BookSaver.Entities;
using BookSaver.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookSaver.Logic
{
    public class GenreLogic : IGenreLogic
    {
        IGenreDataAcces _genreDao;
        IBookDataAcces _bookDao;

        public GenreLogic(IGenreDataAcces genreDao, IBookDataAcces bookDao)
        {
            _genreDao = genreDao;
            _bookDao = bookDao;
        }

        public void AddGenre(string name)
        {
            if (String.IsNullOrEmpty(name) || name.Length > 70 || Regex.Match(name, @"\A[a-zA-Z]+\Z").Length != name.Length)
            {
                throw new ArgumentException("Wrong Genre name format");
            }
            _genreDao.AddGenre(new Genre() { Name = name });
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _genreDao.GetAllGenres();
        }

        public IEnumerable<Book> GetGenreBooks(Genre genre)
        {
            if (_genreDao.GetGenreById(genre.Id) != null)
            {
                return _bookDao.GetBooksByGenreID(genre.Id);
            }
            else throw new ArgumentException("No Genre with such id");
        }
    }
}
