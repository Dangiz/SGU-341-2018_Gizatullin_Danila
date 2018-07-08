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
    public class DataBaseAuthorDao : IAuthorDataAccess
    {
        private readonly string connectionString;

        public DataBaseAuthorDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private Author ConstructAuthorBySelection(SqlDataReader reader)
        {
            return new Author((int)reader["ID_Author"],
                            reader["Name"].ToString(),
                            reader["Surname"].ToString());
        }

        private List<Author> ConstructAuthorsListFromSelection(SqlCommand command)
        {
            List<Author> authors = new List<Author>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    authors.Add(ConstructAuthorBySelection(reader));
                }
            }

            return authors;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Select_All_Authors", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;              
                con.Open();
                return ConstructAuthorsListFromSelection(command);
            }
        }

        public Author GetAuthorByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetAuthorsByBookId(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Select_Authors_By_Book_Id", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Book_ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                });
                con.Open();
                return ConstructAuthorsListFromSelection(command);
            }
        }

       
    }
}
