using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.Entities;

namespace BookSaver.LogicContracts
{
    public interface IPublicationLogic
    {
        IEnumerable<Author> GetPublicationAuthors(Publication publication);
        Magazine GetPublicationMagazine(Publication publication);
    }
}
