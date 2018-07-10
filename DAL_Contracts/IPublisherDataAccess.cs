using BookSaver.Entities;
using System.Collections.Generic;

namespace BookSaver.DataContracts
{
    public interface IPublisherDataAccess
    {
        Publisher GetPublisherByBookId(int id);
        Publisher GetPublisherById(int id);
        IEnumerable<Publisher> GetAllPublishers();
    }
}
