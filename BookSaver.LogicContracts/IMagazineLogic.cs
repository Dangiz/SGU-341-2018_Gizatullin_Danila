using BookSaver.Entities;
using System.Collections.Generic;

namespace BookSaver.LogicContracts
{
    public interface IMagazineLogic
    {
        IEnumerable<Publication> GetMagazinePublications(int magazineId);
        Publisher GetMagazinePublisher(int publisherId);
    }
}
