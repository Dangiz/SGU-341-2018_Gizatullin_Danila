using System;
using System.Collections.Generic;
using System.Linq;
using BookSaver.DataContracts;
using BookSaver.Entities;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BookSaver.DatabaseBookData
{
    public class DatabaseBookDao : IBookDataAcces
    {
        private readonly string connectionString;

        public DatabaseBookDao()
        {
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
            //using (SqlConnection con = new SqlConnection(connectionString))
            //    using (SqlCommand command = new SqlCommand("dbo.Book_Insert", con))
            //    {
            //        command.CommandType = System.Data.CommandType.StoredProcedure;
            //        command.Parameters.Add(new SqlParameter("@Name", System.Data.SqlDbType.NVarChar)
            //        {
            //            Value = book.Name
            //        });
            //        command.Parameters.Add(new SqlParameter("@Author", System.Data.SqlDbType.NVarChar)
            //        {
            //            Value = book.Author
            //        });
            //        command.Parameters.Add(new SqlParameter("@Genre", System.Data.SqlDbType.NVarChar)
            //        {
            //            Value = book.Genre.Name,
            //        });
            //        command.Parameters.Add("@Book_ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            //        con.Open();
            //        int a = command.ExecuteNonQuery();
            //        book.Id = command.Parameters["@Book_ID"].Value as int? ?? default(int);
            //        return a>0;
            //    }
            throw new NotImplementedException();
        }
        public IEnumerable<Book> GetAllBooks()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Books_Select", con))
            {
                //command.CommandType = System.Data.CommandType.StoredProcedure;
                //List<Book> books = new List<Book>();
                //List<Genre> genres = (List<Genre>) _genreDao.GetAllGenres();
                //con.Open();
                //using (var reader = command.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        Genre genre = genres.First(g => g.Name.CompareTo(reader[4].ToString()) == 0);
                //        Book book = new Book(int.Parse(reader["ID"].ToString()), genre, reader["Name"].ToString(), reader["Author"].ToString());
                //        books.Add(book);
                //    }
                //}
                //return books;
                throw new NotImplementedException();
            }
        }

        public Book GetBookById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Select_Book_By_Id", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Book_ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                });
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ConstructBookBySelection(reader);
                    }
                    else return null;
                }

            }
        }

        public IEnumerable<Book> GetBooksByGenreID(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Select_Books_By_Genre", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Genre_ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                });
                con.Open();
                List<Book> books = new List<Book>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {                       
                        books.Add(ConstructBookBySelection(reader));
                    }

                    return books;
                }
            }
        }

        private Book ConstructBookBySelection(SqlDataReader reader)
        {
            int bookID = int.Parse(reader["ID_Book"].ToString());
            return new Book(bookID,
                            reader["Name"].ToString(),
                            int.Parse(reader["Publishing_Year"].ToString()));
        }
    }
}
