using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.Entities;

namespace BookSaver.LogicContracts
{
    public interface IMagazineLogic
    {
        IEnumerable<Publication> GetMagazinePublications(Magazine magazine);
        Publisher GetMagazinePublisher(Publisher publisher);
    }
}
