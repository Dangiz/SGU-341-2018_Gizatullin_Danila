using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.Entities;
using BookSaver.LogicContracts;
using BookSaver.DataContracts;

namespace BookSaver.Logic
{
    public class MagazineLogic : IMagazineLogic
    {
        IMagazineDataAccess _magazineDao;

        public MagazineLogic(IMagazineDataAccess magazineDao)
        {
            _magazineDao = magazineDao;
        }

        public Magazine GetMagazineByPublicationId(int publicationId)
        {
            return _magazineDao.GetMagazineByPublicationId(publicationId);
        }

        public IEnumerable<Magazine> GetMagazinesByPublisherId(int publisherId)
        {
            return _magazineDao.GetMagazinesByPublisherId(publisherId);
        }
    }
}
