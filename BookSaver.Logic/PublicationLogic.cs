using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IEnumerable<Author> GetPublicationAuthors(Publication publication)
        {
            throw new NotImplementedException();
        }

        public Magazine GetPublicationMagazine(Publication publication)
        {
            throw new NotImplementedException();
        }
    }
}
