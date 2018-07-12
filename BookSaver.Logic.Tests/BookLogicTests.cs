using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSaver.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Moq;
using BookSaver.DataContracts;
using BookSaver.Entities;

namespace BookSaver.Logic.Tests
{
    [TestClass()]
    public class BookLogicTests
    {
        BookLogic bookLogic;
        [TestInitialize]
        public void TestInitialize()
        {
            var bookDaoMock = new Mock<IBookDataAcces>();
            var authorDaoMock = new Mock<IAuthorDataAccess>();
            var genreDaoMock = new Mock<IGenreDataAccess>();
            var publisherDaoMock = new Mock<IPublisherDataAccess>();

            bookDaoMock.Setup(item => item.AddBook(It.IsAny<Book>(),It.IsAny<int>(),It.IsAny<int>(),It.IsAny<int>())).Returns(100);

            bookDaoMock.Setup(item => item.IsBookUnique(It.IsAny<Book>(), It.IsAny<int>())).Returns(true);
            
            authorDaoMock.Setup(item => item.GetAuthorByID(It.IsAny<int>())).Returns(new Author());

            genreDaoMock.Setup(item=>item.GetGenreById(It.IsAny<int>())).Returns(new Genre());

            publisherDaoMock.Setup(item => item.GetPublisherById(It.IsAny<int>())).Returns(new Publisher());

            bookLogic = new BookLogic(bookDaoMock.Object,genreDaoMock.Object,authorDaoMock.Object,publisherDaoMock.Object);
            
        }

        [TestMethod()]
        public void AddBookTest()
        {
            string name = "Name";
            int year = 2010;
            int authorId = 2;
            int genreId = 1;
            int publisherId = 1;
            var actual=bookLogic.AddBook(name, year, authorId, genreId, publisherId);
            Assert.AreEqual(actual,100);
        }
    }
}