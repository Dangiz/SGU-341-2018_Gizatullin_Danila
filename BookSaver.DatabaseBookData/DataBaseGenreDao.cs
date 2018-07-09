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

        public DataBaseGenreDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private Genre ConsctructGenreFromSelection(SqlDataReader reader)
        {
            return new Genre((int)reader["ID_Genre"], reader["Name"].ToString());
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            throw new NotImplementedException();
        }

        public void AddGenre(Genre genre)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Genre_Insert", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Name", System.Data.SqlDbType.VarChar)
                {
                    Value = genre.Name
                });
                command.Parameters.Add(new SqlParameter("@Genre_ID", System.Data.SqlDbType.Int)
                {
                    Value = 0,
                    Direction=ParameterDirection.Output
                });
                con.Open();
                command.ExecuteNonQuery();
            }
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

        public IEnumerable<Genre> GetGenreByName(string name)
        {
            throw new NotImplementedException();
        }

        public Genre GetGenreById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.Select_Genre_By_Id", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Genre_ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                });
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ConsctructGenreFromSelection(reader);
                    }
                    else return null;
                }

            }
        }
    }
}
