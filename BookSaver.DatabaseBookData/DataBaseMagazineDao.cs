using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaver.DataContracts;
using BookSaver.Entities;
using System.Data.SqlClient;

namespace BookSaver.DatabaseBookData
{
    public class DataBaseMagazineDao : IMagazineDataAccess
    {
        private readonly string connectionString;

        public DataBaseMagazineDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private Magazine ConsctructMagazineFromSelection(SqlDataReader reader)
        {
            int id = (int)reader["ID_Magazine"];
            string name = reader["Name"] as string;
            return new Magazine(id,name );
        }

        private List<Magazine> ConstructMagazinesListBySelection(SqlCommand command)
        {
            List<Magazine> magazines = new List<Magazine>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    magazines.Add(ConsctructMagazineFromSelection(reader));
                }
            }

            return magazines;
        }

        public IEnumerable<Magazine> GetAllMagazines()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Select_All_Magazines", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    return ConstructMagazinesListBySelection(command);
                }
            }
        }

        public IEnumerable<Magazine> GetMagazinesByPublisherId(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Select_Magazines_By_Publisher_ID", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Publisher_ID", id));
                    con.Open();
                    return ConstructMagazinesListBySelection(command);
                }
            }
        }

        public Magazine GetMagazineById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Select_Magazine_By_Id", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    using(var reader=command.ExecuteReader())
                    {
                        return ConsctructMagazineFromSelection(reader);
                    }
                }
            }
        }

        public Magazine GetMagazineByPublicationId(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Select_Magazine_By_Publication_ID", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Publication_ID", id));
                    con.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        return ConsctructMagazineFromSelection(reader);
                    }
                }
            }
        }
    }
}
