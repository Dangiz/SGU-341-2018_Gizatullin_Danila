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
        private IBookDataAcces _bookDao;

        public DataBaseGenreDao(IBookDataAcces bookData)
        {
            _bookDao = bookData;
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
            throw new NotImplementedException();
        }
        public bool AddGenre(Genre genre)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Genre> GetGenresByBookId(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Select_Genres_By_IDBook", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Book_ID", System.Data.SqlDbType.Int)
                {
                    Value =id
                });
                List<Genre> genres = new List<Genre>();
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        genres.Add(ConsctructGenreFromSelection(reader));
                    }
                }
                return genres;
            }
        }

        private Genre ConsctructGenreFromSelection(SqlDataReader reader)
        {
            int id = int.Parse(reader["ID_Genre"].ToString());
            return new Genre(id, reader["Name"].ToString(), ()=>_bookDao.GetBooksByGenreID(id));
        }
    }
}
