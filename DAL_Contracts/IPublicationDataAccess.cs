using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.Entities;

namespace BookSaver.DataContracts
{
    public interface IPublicationDataAccess
    {
        IEnumerable<Publication> GetAllPublications();
    }
}
