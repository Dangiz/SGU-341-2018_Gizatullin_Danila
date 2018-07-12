using BookSaver.Config;
using BookSaver.Entities;
using BookSaver.LogicContracts;
using Ninject;
using System;

namespace ADO_NET_Task4
{
    class Program
    {
        private static IAuthorLogic _authorLogic;
        private static IBookLogic _bookLogic;
        private static IGenreLogic _genreLogic;
        private static IPublicationLogic _publicationLogic;
        private static IMagazineLogic _magazineLogic;
        private static IPublisherLogic _publisherLogic;

        static Program()
        {
            IKernel ninjectKernel = new StandardKernel();
            Config.RegisterServices(ninjectKernel);
            _bookLogic = ninjectKernel.Get<IBookLogic>();
            _authorLogic = ninjectKernel.Get<IAuthorLogic>();
            _genreLogic = ninjectKernel.Get<IGenreLogic>();
            _publicationLogic = ninjectKernel.Get<IPublicationLogic>();
            _magazineLogic = ninjectKernel.Get<IMagazineLogic>();
            _publisherLogic = ninjectKernel.Get<IPublisherLogic>();
        }


   
        static void Main(string[] args)
        {
                foreach (Book book in _bookLogic.GetAllBooks())
                {
                    ShowBook(book);
                    Console.WriteLine("Authors:");
                    foreach (Author author in _authorLogic.GetAuthorsByBookId(book.Id))
                        ShowAuthor(author);
                    Console.WriteLine("Genres:");
                    foreach (Genre genre in _genreLogic.GetGenresByBookId(book.Id))
                        ShowGenre(genre);
                    Console.WriteLine();
                }

                foreach(Publication publication in _publicationLogic.GetPublicationsByAuthorId(2))
                {
                    ShowPublication(publication);
                }

            _genreLogic.AddGenre("History");
        }

        private static void ShowBook(Book book)
        {
            Console.WriteLine($"{book.Id} {book.Name} {book.Year}");
        }
        private static void ShowPublication(Publication publication)
        {
            Console.WriteLine($"{publication.Id} {publication.Name} {publication.Year}");
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
