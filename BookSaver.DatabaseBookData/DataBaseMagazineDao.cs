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
            return new Magazine((int)reader["ID_Magazine"], reader["Name"].ToString());
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
            using (SqlCommand command = new SqlCommand("dbo.Select_All_Magazines", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                return ConstructMagazinesListBySelection(command);
            }
        }

        public Magazine GetMagazineById(int id)
        {
            throw new NotImplementedException();
        }

        public Magazine GetMagazineByPublicationId()
        {
            throw new NotImplementedException();
        }
    }
}
