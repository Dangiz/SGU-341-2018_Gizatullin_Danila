using System;
using Ninject;
using BookSaver.LogicContracts;
using BookSaver.Config;
using BookSaver.DataContracts;
using BookSaver.Entities;

namespace ADO_NET_Task4
{
    class Program
    {
        //private static IBookLogic bookLogic;
        //private static IGenreLogic genreLogic;
        private static IBookDataAcces bookData;

        static Program()
        {

            IKernel ninjectKernel = new StandardKernel();
            Config.RegisterServices(ninjectKernel);
            bookData = ninjectKernel.Get<IBookDataAcces>();
            //bookLogic = ninjectKernel.Get<IBookLogic>();
            //genreLogic = ninjectKernel.Get<IGenreLogic>();
        }
   
        static void Main(string[] args)
        {
            Book book=bookData.GetBookById(6);
            Console.WriteLine($"{book.Id} {book.Name} {book.Year}");
            /*foreach (Genre genre in book.Genres)
            {
                Console.WriteLine($"{genre.Name}");
            }*/
        }
        
    }
}
