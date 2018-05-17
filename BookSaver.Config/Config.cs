using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using BookSaver.Logic;
using BookSaver.LogicContracts;
using BookSaver.DataContracts;
using BookSaver.MemoryBookData;
using BookSaver.DatabaseBookData;
using System.Configuration;

namespace BookSaver.Config
{
    public static class Config
    {
        public static String connectionString;
        public static void RegisterServices(IKernel kernel)
        {
            kernel
                .Bind<IBookLogic>()
                .To<BookLogic>();

            string daoType = ConfigurationManager.AppSettings["DaoType"];
            switch (daoType)
            {
                case "Memory":
                    kernel
                        .Bind<IBookDataAcces>()
                        .To<MemoryBookDao>();
                    break;
                case "DataBase":
                    {
                        kernel
                            .Bind<IBookDataAcces>()
                            .To<DatabaseBookDao>();
                        break;
                    }
                default:
                    throw new ArgumentException("Wrong DAO type in config file");
            }

            //kernel
            //    .Bind<INoteDao>()
            //    .To<FileNoteDao>();
        }
    }
}
