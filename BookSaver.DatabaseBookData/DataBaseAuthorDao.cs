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
            return new Author(int.Parse(reader["ID_Author"].ToString()),
                            reader["Name"].ToString(),
                            reader["Surname"].ToString());
        }


        public IEnumerable<Author> GetAllAuthors()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Select_All_Authors", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                List<Author> authors = new List<Author>();
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        authors.Add(ConstructAuthorBySelection(reader));
                    }
                }
                return authors;
            }
        }

        public Author GetAuthorByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
