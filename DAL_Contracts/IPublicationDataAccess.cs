using BookSaver.Entities;
using System.Collections.Generic;

namespace BookSaver.DataContracts
{
    public interface IPublicationDataAccess
    {
        IEnumerable<Publication> GetAllPublications();
        IEnumerable<Publication> GetPublicationByAuthorId(int id);
    }
}
