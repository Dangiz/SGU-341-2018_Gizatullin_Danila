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

        public DatabaseBookDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private Book ConstructBookBySelection(SqlDataReader reader)
        {
            return new Book((int)reader["ID_Book"],
                            reader["Name"].ToString(),
                            (int)reader["Publishing_Year"]);
        }

        private List<Book> ConstructBooksListBySelection(SqlCommand command)
        {
            List<Book> books = new List<Book>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    books.Add(ConstructBookBySelection(reader));
                }
            }

            return books;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Select_All_Books", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                return ConstructBooksListBySelection(command);
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
                return ConstructBooksListBySelection(command);
            }
        }

        public bool IsBookUnique(Book book,Publisher publisher)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Is_Book_Unique", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Name", System.Data.SqlDbType.VarChar)
                {
                    Value = book.Name
                });
                command.Parameters.Add(new SqlParameter("@Year", System.Data.SqlDbType.Int)
                {
                    Value = book.Year
                });
                command.Parameters.Add(new SqlParameter("@Publisher_ID", System.Data.SqlDbType.Int)
                {
                    Value = publisher.Id
                });
                var Result = new SqlParameter("@Publisher_ID", System.Data.SqlDbType.Int);
                command.Parameters.Add(Result);
                con.Open();
                command.ExecuteNonQuery();
                return (bool)Result.Value;
            }
        }

        public void AddBook(Book book, int authorId, int genreId, int publisherId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Book_Insert", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Name", System.Data.SqlDbType.VarChar)
                {
                    Value = book.Name
                });
                command.Parameters.Add(new SqlParameter("@Year", System.Data.SqlDbType.Int)
                {
                    Value = book.Year
                });
                command.Parameters.Add(new SqlParameter("@Publisher_ID", System.Data.SqlDbType.Int)
                {
                    Value = publisherId
                });
                command.Parameters.Add(new SqlParameter("@Genre_ID", System.Data.SqlDbType.Int)
                {
                    Value = genreId
                });
                if (authorId != 0)
                {
                    command.Parameters.Add(new SqlParameter("@Author_ID", System.Data.SqlDbType.Int)
                    {
                        Value = authorId
                    });
                }
                command.Parameters.Add(new SqlParameter("@Book_ID", System.Data.SqlDbType.Int)
                {
                    Value = 0
                });
                con.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
