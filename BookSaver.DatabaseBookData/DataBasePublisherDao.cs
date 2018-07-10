using BookSaver.DataContracts;
using BookSaver.Entities;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BookSaver.DatabaseBookData
{
    public class DataBasePublisherDao:IPublisherDataAccess
    {
        private readonly string connectionString;

        public DataBasePublisherDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private Publisher ConsctructPublisherFromSelection(SqlDataReader reader)
        {
            return new Publisher((int)reader["ID_Publisher"], reader["Name"].ToString(), reader["City"].ToString(), reader["Street"].ToString(), (int)reader["House_Number"]);
        }

        private List<Publisher> ConstructPublishersListBySelection(SqlCommand command)
        {
            List<Publisher> publishers = new List<Publisher>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    publishers.Add(ConsctructPublisherFromSelection(reader));
                }
            }

            return publishers;
        }

        public Publisher GetPublisherByBookId(int id)
        {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("dbo.Select_Publisher_By_IDBook", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID_Book", System.Data.SqlDbType.Int)
                    {
                        Value = id
                    });
                    con.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return ConsctructPublisherFromSelection(reader);
                        }
                        else
                        {
                            throw new ArgumentException();
                        }
                    }
            }
        }

        public Publisher GetPublisherById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Select_Publisher_By_Id", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Publisher_ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                });
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ConsctructPublisherFromSelection(reader);
                    }
                    else return null;
                }
            }
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Select_All_Publishers", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                return ConstructPublishersListBySelection(command);
            }
        }
    }
}
