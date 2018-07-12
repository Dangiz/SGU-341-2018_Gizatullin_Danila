using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.LogicContracts;
using BookSaver.Entities;

namespace BookSaver.Logic
{
    public class PublisherLogic : IPublisherLogic
    {
        public IEnumerable<Publisher> GetAllPublishers()
        {
            throw new NotImplementedException();
        }

        public Publisher GetPublisherByMagazineId(int publisherId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Magazine> GetPublisherMagazines(int publisherId)
        {
            throw new NotImplementedException();
        }
    }
}
