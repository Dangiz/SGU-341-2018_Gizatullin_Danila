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
        IGenreDataAccess _genreDao;
        IBookDataAcces _bookDao;

        public GenreLogic(IGenreDataAccess genreDao, IBookDataAcces bookDao)
        {
            _genreDao = genreDao;
            _bookDao = bookDao;
        }

        public void AddGenre(string name)
        {
            if (!ValidationHelper.StringAlphaValidation(name,70))
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


        public IEnumerable<Genre> GetGenresByBookId(int bookId)
        {
            if (_bookDao.GetBookById(bookId) != null)
            {
                return _genreDao.GetGenresByBookId(bookId);
            }
            else
            {
                throw new ArgumentException("No book with such id");
            }
        }
    }
}
