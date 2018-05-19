using BookSaver.DataContracts;
using BookSaver.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BookSaver.DatabaseBookData
{
    public class DataBaseGenreDao:IGenreDataAcces
    {
        private readonly string connectionString;

        public DataBaseGenreDao()
        {
            connectionString = SetDataBaseConnection();
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
        public IEnumerable<Genre> GetAllGenres()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Genre_Select", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                List<Genre> genres = new List<Genre>();
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Genre genre = new Genre(int.Parse(reader["ID"].ToString()), reader["Name"].ToString());
                        genres.Add(genre);
                    }
                }
                return genres;

            }
        }
        public bool AddGenre(Genre genre)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Genre_Insert", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@NewGenre", System.Data.SqlDbType.NVarChar)
                {
                    Value = genre.Name
                });
                command.Parameters.Add("@Genre_ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                int a = command.ExecuteNonQuery();
                genre.Id = command.Parameters["@Genre_ID"].Value as int? ?? default(int);
                return a > 0;
            }
        }
    }
}
