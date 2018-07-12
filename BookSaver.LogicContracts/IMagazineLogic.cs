using BookSaver.Entities;
using System.Collections.Generic;

namespace BookSaver.LogicContracts
{
    public interface IMagazineLogic
    {
        Magazine GetMagazineByPublicationId(int publicationId);
        IEnumerable<Magazine> GetMagazinesByPublisherId(int publisherId);
    }
}
