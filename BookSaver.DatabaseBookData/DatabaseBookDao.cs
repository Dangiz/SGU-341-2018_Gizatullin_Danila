using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.DataContracts;
using BookSaver.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace BookSaver.DatabaseBookData
{
    public class DatabaseBookDao : IBookDataAcces
    {
        private String connectionString;

        public DatabaseBookDao()
        {
            connectionString = SetDataBaseConnection();
        }

        private string SetDataBaseConnection()
        {
            switch (ConfigurationManager.AppSettings["DataBaseAccesType"])
            {
                case "Remote":
                    return ConfigurationManager.ConnectionStrings["Remote"].ConnectionString;
                case "Local":
                    return ConfigurationManager.ConnectionStrings["Local"].ConnectionString;
                default:
                    throw new ArgumentException("Wrong DataBase connection type in config file");
            }
        }

        public bool AddBook(Book book)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = con.CreateCommand();
            command.CommandText = $"execute LibrarySystem.dbo.Book_Insert@Name='{book.Name}',@Author='{book.Author}',@Genre='{book.Genre.Name}'";
            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool AddGenre(Genre genre)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = con.CreateCommand();
            command.CommandText = command.CommandText = $"DECLARE @ID_Genre INTEGER; EXECUTE dbo.Genre_Insert @NewGenre='{genre.Name}', @Genre_ID=@ID_Genre OUTPUT;";
            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }

            finally
            {
                con.Close();
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = con.CreateCommand();
            command.CommandText = "EXECUTE dbo.Books_Select";
            try
            {
                List<Book> books = new List<Book>();
                List<Genre> genres = (List<Genre>) GetAllGenres();
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Genre genre = genres.First(g=>g.Name.CompareTo(reader[4].ToString())==0);
                    Book book = new Book(int.Parse(reader[0].ToString()),genre,reader[1].ToString(), reader[2].ToString());
                    books.Add(book);
                }
                return books;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = con.CreateCommand();
            command.CommandText = "EXECUTE dbo.Genre_Select";
            try
            {
                List<Genre> genres = new List<Genre>();
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Genre genre = new Genre(int.Parse(reader[0].ToString()),reader[1].ToString());
                    genres.Add(genre);
                }
                return genres;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
