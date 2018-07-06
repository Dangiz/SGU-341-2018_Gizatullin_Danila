using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.Entities;

namespace BookSaver.LogicContracts
{
    interface IPublisherLogic
    {
        IEnumerable<Magazine> GetPublisherMagazines(Publisher publisher);
        IEnumerable<Book> GetPublisherBooks(Publisher publisher);
    }
}
