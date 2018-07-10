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

        public PublicationLogic(IPublicationDataAccess publicationDao)
        {
            _publicationDao = publicationDao;
        }

        public IEnumerable<Publication> GetAllPublications()
        {
            return _publicationDao.GetAllPublications();
        }

        public IEnumerable<Author> GetPublicationAuthors(int publicationId)
        {
            throw new NotImplementedException();
        }

        public Magazine GetPublicationMagazine(int publicationId)
        {
            throw new NotImplementedException();
        }
    }
}
