using BookSaver.Entities;
using System.Collections.Generic;

namespace BookSaver.LogicContracts
{
    public interface IPublisherLogic
    {
        IEnumerable<Magazine> GetPublisherMagazines(int publisherId);
        IEnumerable<Book> GetPublisherBooks(int publisherId);
        IEnumerable<Publisher> GetAllPublishers();
    }
}
