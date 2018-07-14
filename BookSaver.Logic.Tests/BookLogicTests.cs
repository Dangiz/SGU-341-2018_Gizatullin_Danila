using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;
using BookSaver.DataContracts;
using BookSaver.Entities;

namespace BookSaver.Logic.Tests
{
    [TestClass()]
    public class BookLogicTests
    {
        public TestContext TestContext { get; set; }

        BookLogic AddBookLogicTestConfiguration(TestContext testContext)
        {
            var bookDaoMock = new Mock<IBookDataAcces>();
            var authorDaoMock = new Mock<IAuthorDataAccess>();
            var genreDaoMock = new Mock<IGenreDataAccess>();
            var publisherDaoMock = new Mock<IPublisherDataAccess>();

            bookDaoMock.Setup(item => item.AddBook(It.IsAny<Book>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(1);

            bookDaoMock.Setup(item => item.IsBookUnique(It.IsAny<Book>(), It.IsAny<int>())).Returns(Convert.ToBoolean(testContext.DataRow["isBookUnique"]));

            if (Convert.ToBoolean(testContext.DataRow["authorFound"]))
            {
                authorDaoMock.Setup(item => item.GetAuthorByID(It.IsAny<int>())).Returns(new Author());
            }
            else
            {
                authorDaoMock.Setup(item => item.GetAuthorByID(It.IsAny<int>())).Returns((Author)null);
            }

            if (Convert.ToBoolean(testContext.DataRow["genreFound"]))
            {
                genreDaoMock.Setup(item => item.GetGenreById(It.IsAny<int>())).Returns(new Genre());
            }
            else
            {
                genreDaoMock.Setup(item => item.GetGenreById(It.IsAny<int>())).Returns((Genre)null);
            }

            if (Convert.ToBoolean(testContext.DataRow["publisherFound"]))
            {
                publisherDaoMock.Setup(item => item.GetPublisherById(It.IsAny<int>())).Returns(new Publisher());
            }
            else
            {
                publisherDaoMock.Setup(item => item.GetPublisherById(It.IsAny<int>())).Returns((Publisher)null);
            }

             return new BookLogic(bookDaoMock.Object, genreDaoMock.Object, authorDaoMock.Object, publisherDaoMock.Object);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "bookTestData.xml", "bookDataElement", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void AddBookTest()
        {
            var bookLogic = AddBookLogicTestConfiguration(TestContext);
            string name = Convert.ToString(TestContext.DataRow["name"]);
            int year = Convert.ToInt32(TestContext.DataRow["year"]);
            int authorId = Convert.ToInt32(TestContext.DataRow["authorId"]);
            int genreId = Convert.ToInt32(TestContext.DataRow["genreId"]);
            int publisherId = Convert.ToInt32(TestContext.DataRow["publisherId"]);
            Action bookAdd = (() => bookLogic.AddBook(name, year, authorId, genreId, publisherId));
            switch (Convert.ToString(TestContext.DataRow["expectedResult"]))
            {
                case "AuthorArgumentException":
                    Assert.ThrowsException<ArgumentException>(bookAdd, "Author with this Id does not exist");
                    break;
                case "GenreArgumentException":
                    Assert.ThrowsException<ArgumentException>(bookAdd, "Genre with this Id does not exist");
                    break;
                case "PublisherArgumentException":
                    Assert.ThrowsException<ArgumentException>(bookAdd, "Publisher with this Id does not exist");
                    break;
                case "NameFormatArgumentException":
                    Assert.ThrowsException<ArgumentException>(bookAdd, "Wrong book name format");
                    break;
                case "YearFormatArgumentException":
                    Assert.ThrowsException<ArgumentException>(bookAdd, "Wrong Year format");
                    break;
                case "BookUniqueArgumentException":
                    Assert.ThrowsException<ArgumentException>(bookAdd, "Book with this data already exist");
                    break;
                case "Complete":
                    Assert.AreEqual(1, bookLogic.AddBook(name, year, authorId, genreId, publisherId));
                    break;
                default:
                    Assert.Fail("No Such Expected result param");
                    break;
            }
        }
        [TestMethod()]
        public void GetAllBooksTest()
        {
            var bookDaoMock = new Mock<IBookDataAcces>();
            var books = new List<Book>();
            var book = new Book(0, "Name", 2000);
            books.Add(book);
            bookDaoMock.Setup(item => item.GetAllBooks()).Returns(books);
       
            var bookLogic=new BookLogic(bookDaoMock.Object, null, null, null);

            Assert.AreEqual(books, bookLogic.GetAllBooks());
        }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "bookTestData.xml", "removeBookIdElement", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void RemoveBookByIdTest()
        {
            var bookDaoMock = new Mock<IBookDataAcces>();
            if (Convert.ToBoolean(TestContext.DataRow["bookFound"]))
            {
                bookDaoMock.Setup(item => item.GetBookById(It.IsAny<int>())).Returns(new Book());
            }
            else
            {
                bookDaoMock.Setup(item => item.GetBookById(It.IsAny<int>())).Returns((Book)null);
            }
            var authorDaoMock = new Mock<IAuthorDataAccess>();
            var bookLogic = new BookLogic(bookDaoMock.Object, null, authorDaoMock.Object, null);

            int id = Convert.ToInt32(TestContext.DataRow["id"]);

            switch (Convert.ToString(TestContext.DataRow["expectedResult"]))
            {
                case "BookIdArgumentException":
                    Assert.ThrowsException<ArgumentException>(()=>bookLogic.RemoveBookAtId(id), "No book with this Id");
                    break;
                case "Complete":
                    bookLogic.RemoveBookAtId(id);
                    break;
                default:
                    Assert.Fail("No Such Expected result param");
                    break;
            }


        }
    }
}