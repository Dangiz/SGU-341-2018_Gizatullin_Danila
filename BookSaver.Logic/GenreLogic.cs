using BookSaver.DataContracts;
using BookSaver.Entities;
using BookSaver.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaver.Logic
{
    public class GenreLogic:IGenreLogic
    {
        private IGenreDataAcces _genreDao;

        public GenreLogic(IGenreDataAcces genreDao)
        {
            _genreDao = genreDao;
        }

        public Genre AddGenre(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Genre Name is whitespace or null");
            }
            Genre genre = new Genre(name);
            if (_genreDao.AddGenre(genre))
            {
                return genre;
            }
            else
            {
                throw new InvalidOperationException("Error by saving new Genre");
            }
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _genreDao.GetAllGenres().ToArray();
        }
    }
}
