using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.Entities;
using BookSaver.LogicContracts;

namespace BookSaver.Logic
{
    public class MagazineLogic : IMagazineLogic
    {
        public IEnumerable<Publication> GetMagazinePublications(int magazineId)
        {
            throw new NotImplementedException();
        }

        public Publisher GetMagazinePublisher(int publisherId)
        {
            throw new NotImplementedException();
        }
    }
}
