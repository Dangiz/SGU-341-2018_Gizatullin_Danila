using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.LogicContracts;
using BookSaver.Entities;
using BookSaver.DataContracts;

namespace BookSaver.Logic
{
    public class PublisherLogic : IPublisherLogic
    {
        IPublisherDataAccess _publisherDao;

        public PublisherLogic(IPublisherDataAccess publisherDao)
        {
            _publisherDao = publisherDao;
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            return _publisherDao.GetAllPublishers();
        }

        public Publisher GetPublisherByBookId(int bookId)
        {
            return _publisherDao.GetPublisherByBookId(bookId);
        }
    }
}
