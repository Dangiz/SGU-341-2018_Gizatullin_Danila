using BookSaver.Entities;
using System.Collections.Generic;

namespace BookSaver.LogicContracts
{
    public interface IPublicationLogic
    {
        IEnumerable<Publication> GetAllPublications();
        IEnumerable<Publication> GetPublicationsByAuthorId(int authorId);
        IEnumerable<Publication> GetPublicationsByMagazineId(int magazineId);
    }
}
