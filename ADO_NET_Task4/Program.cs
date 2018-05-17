using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using BookSaver.Logic;
using BookSaver.LogicContracts;
using BookSaver.Config;
using BookSaver.Entities;

namespace ADO_NET_Task4
{
    class Program
    {
        private static IBookLogic bookLogic;

        static Program()
        {
            IKernel ninjectKernel = new StandardKernel();
            Config.RegisterServices(ninjectKernel);
            bookLogic = ninjectKernel.Get<IBookLogic>();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                try
                {
                    Console.WriteLine("1. Add book.");
                    Console.WriteLine("2. Show books.");
                    Console.WriteLine("3. Add genre.");
                    Console.WriteLine("4. Show genres.");
                    Console.WriteLine("0. Exit.");

                    ConsoleKeyInfo entry = Console.ReadKey(intercept: true);
                    switch (entry.Key)
                    {
                        case ConsoleKey.D1:
                            AddBook();
                            break;
                        case ConsoleKey.D2:
                            ShowBooks();
                            break;
                        case ConsoleKey.D3:
                            AddGenre();
                            break;
                        case ConsoleKey.D4:
                            ShowGenres();
                            break;
                        case ConsoleKey.D0:
                            return;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    Console.ReadLine();
                }


            }
        }

        private static void ShowBooks()
        {
            Book[] books = bookLogic.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id}. {book.Name} {book.Author} ({book.Genre.Name})");
            }
            Console.ReadLine();
        }

        private static void ShowGenres()
        {
            Genre[] genres = bookLogic.GetAllGenres();
            foreach (var genre in genres)
            {
                Console.WriteLine($"{genre.Id} {genre.Name}");
            }
            Console.ReadLine();
        }

        private static void AddBook()
        {
            Console.WriteLine("Enter the book name: ");
            string bookName = Console.ReadLine();
            Console.WriteLine("Enter the book Author: ");
            string bookAuthor = Console.ReadLine();
            Console.WriteLine("Enter the book genre: ");
            string genreName = Console.ReadLine();
            bookLogic.AddBook(bookName, bookAuthor, genreName);


            Console.ReadLine();
        }

        private static void AddGenre()
        {
            Console.WriteLine("Enter the genre name: ");
            string genreName = Console.ReadLine();
            bookLogic.AddGenre(genreName);
        
            Console.ReadLine();
        }
    }
}
