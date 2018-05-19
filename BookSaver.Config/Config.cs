using System;
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
            kernel
                .Bind<IGenreLogic>()
                .To<GenreLogic>();

            string daoType = ConfigurationManager.AppSettings["DaoType"];
            switch (daoType)
            {
                case "Memory":
                    kernel
                        .Bind<IBookDataAcces>()
                        .To<MemoryBookDao>().InSingletonScope();
                    kernel
                        .Bind<IGenreDataAcces>()
                        .To<MemoryGenreDao>().InSingletonScope();
                    break;
                case "DataBase":
                    {
                        kernel
                            .Bind<IBookDataAcces>()
                            .To<DatabaseBookDao>().InSingletonScope();
                        kernel
                            .Bind<IGenreDataAcces>()
                            .To<DataBaseGenreDao>().InSingletonScope();
                        break;
                    }
                default:
                    throw new ArgumentException("Wrong DAO type in config file");
            }
        }
    }
}
