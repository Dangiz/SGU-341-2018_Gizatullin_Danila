using System;
using System.Collections.Generic;
using BookSaver.DataContracts;
using BookSaver.Entities;
using BookSaver.LogicContracts;

namespace BookSaver.Logic
{
    public class PublicationLogic : IPublicationLogic
    {
        IPublicationDataAccess _publicationDao;
        IAuthorDataAccess _authorDao;

        public PublicationLogic(IPublicationDataAccess publicationDao, IAuthorDataAccess authorDao)
        {
            _publicationDao = publicationDao;
            _authorDao = authorDao;
        }

        public IEnumerable<Publication> GetAllPublications()
        {
            return _publicationDao.GetAllPublications();
        }

        public IEnumerable<Publication> GetPublicationsByAuthorId(int authorId)
        {
            if (_authorDao.GetAuthorByID(authorId) != null)
            {
                return _publicationDao.GetPublicationByAuthorId(authorId);
            }
            else
            {
                throw new ArgumentException("No Author with such id");
            }
        }

        public IEnumerable<Publication> GetPublicationsByMagazineId(int magazineId)
        {
            return _publicationDao.GetPublicationsByMagazineId(magazineId);
        }
    }
}
