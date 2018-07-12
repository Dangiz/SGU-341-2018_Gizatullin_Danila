using BookSaver.Entities;
using System.Collections.Generic;

namespace BookSaver.LogicContracts
{
    public interface IPublisherLogic
    {
        Publisher GetPublisherByMagazineId(int magazinerId);
        IEnumerable<Publisher> GetAllPublishers();
    }
}
