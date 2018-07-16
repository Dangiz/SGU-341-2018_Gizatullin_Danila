using BookSaver.Entities;
using System.Collections.Generic;

namespace BookSaver.LogicContracts
{
    public interface IPublisherLogic
    {
        Publisher GetPublisherByBookId(int bookId);
        IEnumerable<Publisher> GetAllPublishers();
    }
}
