using BookSaver.DataContracts;
using BookSaver.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BookSaver.DatabaseBookData
{
    public class DataBaseAuthorDao : IAuthorDataAccess
    {
        private readonly string connectionString;

        public DataBaseAuthorDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private Author ConstructAuthorFromSelection(SqlDataReader reader)
        {
            int id = (int)reader["ID_Author"];
            string name = reader["Name"] as string;
            string surname = reader["Surname"] as string;
            return new Author(id,name,surname);
        }

        private List<Author> ConstructAuthorsListFromSelection(SqlCommand command)
        {
            List<Author> authors = new List<Author>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    authors.Add(ConstructAuthorFromSelection(reader));
                }
            }

            return authors;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Select_All_Authors", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    return ConstructAuthorsListFromSelection(command);
                }
            }
        }

        public Author GetAuthorByID(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Select_Author_By_Id", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Author_ID", System.Data.SqlDbType.Int)
                    {
                        Value = id
                    });
                    con.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return ConstructAuthorFromSelection(reader);
                        }
                        else return null;
                    }
                }
            }
        }

        public IEnumerable<Author> GetAuthorsByBookId(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
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

        public void AddAuthor(Author author)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Author_Insert", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Author_Name", System.Data.SqlDbType.VarChar)
                    {
                        Value = author.Name
                    });
                    command.Parameters.Add(new SqlParameter("@Author_Surname", System.Data.SqlDbType.VarChar)
                    {
                        Value = author.Surname
                    });
                    command.Parameters.Add(new SqlParameter("@Author_ID", System.Data.SqlDbType.Int)
                    {
                        Value = 0
                    });
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RemoveAuthorsWithoutAnyPublicationsOrBooks()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Remove_Authors_Without_Any_Publications_Or_Books", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
