using BookSaver.Entities;
using System.Collections.Generic;

namespace BookSaver.DataContracts
{
    public interface IMagazineDataAccess
    {
        Magazine GetMagazineById(int id);
        IEnumerable<Magazine> GetAllMagazines();
        Magazine GetMagazineByPublicationId();
    }
}
