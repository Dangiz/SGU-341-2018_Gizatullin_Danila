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
            return new Book(int.Parse(reader["ID_Book"].ToString()),
                            reader["Name"].ToString(),
                            int.Parse(reader["Publishing_Year"].ToString()));
        }

        public bool AddBook(Book book)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Book> GetAllBooks()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Select_All_Books", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                List<Book> books = new List<Book>();
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(ConstructBookBySelection(reader));
                    }
                }
                return books;
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

        
    }
}
