using BookSaver.DataContracts;
using BookSaver.Entities;
using BookSaver.LogicContracts;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            Genre genre=new Genre() { Name = name };
            if(!_genreDao.IsGenreUnique(genre))
            {
                throw new ArgumentException("Genre with this name already exist");
            }
            _genreDao.AddGenre(genre);
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _genreDao.GetAllGenres();
        }

        public IEnumerable<Book> GetGenreBooks(int genreId)
        {
            if (_genreDao.GetGenreById(genreId) != null)
            {
                return _bookDao.GetBooksByGenreID(genreId);
            }
            else throw new ArgumentException("No Genre with such id");
        }
    }
}
