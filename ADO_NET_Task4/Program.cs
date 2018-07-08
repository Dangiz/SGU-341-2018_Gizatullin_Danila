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
        private static IAuthorLogic authorLogic;
        private static IBookLogic bookLogic;
        //private static IGenreLogic genreLogic;

        private static IBookDataAcces bookData;


        static Program()
        {

            IKernel ninjectKernel = new StandardKernel();
            Config.RegisterServices(ninjectKernel);
            bookData = ninjectKernel.Get<IBookDataAcces>();
            bookLogic = ninjectKernel.Get<IBookLogic>();
            authorLogic = ninjectKernel.Get<IAuthorLogic>();
            //genreLogic = ninjectKernel.Get<IGenreLogic>();
        }


   
        static void Main(string[] args)
        {
            foreach(Book book in bookLogic.GetAllBooks())
            {
                ShowBook(book);
                Console.WriteLine("Authors:");
                foreach (Author author in bookLogic.GetBookAuthors(book))
                    ShowAuthor(author);
                Console.WriteLine("Genres:");
                foreach (Genre genre in bookLogic.GetBookGenres(book))
                    ShowGenre(genre);
                Console.WriteLine();               
            }
            bookLogic.AddBook("The Demon-Haunted World", 2013, null, null, null);

        }

        private static void ShowBook(Book book)
        {
            Console.WriteLine($"{book.Id} {book.Name} {book.Year}");
        }
        private static void ShowGenre(Genre genre)
        {
            Console.WriteLine($"{genre.Id} {genre.Name}");
        }
        private static void ShowAuthor(Author author)
        {
            Console.WriteLine($"{author.Id} {author.Name} {author.Surname}");
        }

    }
}
