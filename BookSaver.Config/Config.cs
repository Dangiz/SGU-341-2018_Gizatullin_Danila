using BookSaver.DatabaseBookData;
using BookSaver.DataContracts;
using BookSaver.Logic;
using BookSaver.LogicContracts;
using Ninject;
using System;
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
                .Bind<IAuthorLogic>()
                .To<AuthorLogic>();
            kernel
                .Bind<IGenreLogic>()
                .To<GenreLogic>();
            kernel
                .Bind<IPublicationLogic>()
                .To<PublicationLogic>();
            kernel
                .Bind<IMagazineLogic>()
                .To<MagazineLogic>();
            kernel
                .Bind<IPublisherLogic>()
                .To<PublisherLogic>();


            switch (ConfigurationManager.AppSettings["DataBaseAccesType"])
            {
                case "Remote":
                    connectionString=ConfigurationManager.ConnectionStrings["Remote"].ConnectionString;
                    break;
                case "Local":
                    connectionString=ConfigurationManager.ConnectionStrings["Local"].ConnectionString;
                    break;
                default:
                    throw new ArgumentException("Wrong DataBase connection type in config file");
            }

            string daoType = ConfigurationManager.AppSettings["DaoType"];
            switch (daoType)
            {
                case "DataBase":
                    {
                        kernel
                            .Bind<IBookDataAcces>()
                            .To<DatabaseBookDao>().InSingletonScope().WithConstructorArgument("connectionString",connectionString);
                        kernel
                            .Bind<IGenreDataAccess>()
                            .To<DataBaseGenreDao>().InSingletonScope().WithConstructorArgument("connectionString", connectionString);
                        kernel
                            .Bind<IAuthorDataAccess>()
                            .To<DataBaseAuthorDao>().InSingletonScope().WithConstructorArgument("connectionString", connectionString);
                        kernel
                           .Bind<IPublisherDataAccess>()
                           .To<DataBasePublisherDao>().InSingletonScope().WithConstructorArgument("connectionString", connectionString);
                        kernel
                          .Bind<IPublicationDataAccess>()
                          .To<DataBasePublicationDao>().InSingletonScope().WithConstructorArgument("connectionString", connectionString);
                        kernel
                           .Bind<IMagazineDataAccess>()
                           .To<DataBaseMagazineDao>().InSingletonScope().WithConstructorArgument("connectionString", connectionString);
                        break;
                    }
                default:
                    throw new ArgumentException("Wrong DAO type in config file");
            }
        }
    }
}
