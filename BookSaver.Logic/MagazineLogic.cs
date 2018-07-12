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
        public Magazine GetMagazineByPublicationId(int publicationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Magazine> GetMagazinesByPublisherId(int publisherId)
        {
            throw new NotImplementedException();
        }
    }
}
