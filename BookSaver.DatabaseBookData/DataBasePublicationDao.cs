
using System.Collections.Generic;
using BookSaver.DataContracts;
using BookSaver.Entities;
using System.Data.SqlClient;
using System.Data;
using System;

namespace BookSaver.DatabaseBookData
{
    public class DataBasePublicationDao : IPublicationDataAccess
    {
        private readonly string connectionString;

        public DataBasePublicationDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private Publication ConstructPublicationBySelection(SqlDataReader reader)
        {
            return new Publication((int)reader["ID_Publication"], (string) reader["Name"], (int)reader["Publishing_Year"]);
        }

        private List<Publication> ConstructBooksListBySelection(SqlCommand command)
        {
            List<Publication> publications = new List<Publication>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    publications.Add(ConstructPublicationBySelection(reader));
                }
            }

            return publications;
        }

        public IEnumerable<Publication> GetAllPublications()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Select_All_Publications", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                return ConstructBooksListBySelection(command);
            }
        }

        public IEnumerable<Publication> GetPublicationByAuthorId(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Select_Publications_By_Author_ID", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Author_ID", SqlDbType.Int)
                {
                    Value = id
                });
                con.Open();
                return ConstructBooksListBySelection(command);
            }
        }
    }
}
