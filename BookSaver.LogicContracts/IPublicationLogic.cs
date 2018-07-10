using BookSaver.Entities;
using System.Collections.Generic;

namespace BookSaver.LogicContracts
{
    public interface IPublicationLogic
    {
        IEnumerable<Publication> GetAllPublications();
        IEnumerable<Author> GetPublicationAuthors(int publicationId);
        Magazine GetPublicationMagazine(int publicationId);
    }
}
