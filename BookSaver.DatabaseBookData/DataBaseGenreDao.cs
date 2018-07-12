using BookSaver.DataContracts;
using BookSaver.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BookSaver.DatabaseBookData
{
    public class DataBaseGenreDao:IGenreDataAccess
    {
        private readonly string connectionString;

        public DataBaseGenreDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private Genre ConsctructGenreFromSelection(SqlDataReader reader)
        {

            int id = (int)reader["ID_Genre"];
            string name = reader["Name"] as string;
            return new Genre(id, name);
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Select_All_Genres", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
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
        }

        public void AddGenre(Genre genre)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
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
                        Direction = ParameterDirection.Output
                    });
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool IsGenreUnique(Genre genre)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Is_Genre_Unique", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Name", System.Data.SqlDbType.VarChar)
                    {
                        Value = genre.Name
                    });
                    var Result = new SqlParameter("@Result", System.Data.SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(Result);
                    con.Open();
                    command.ExecuteNonQuery();
                    return (bool)Result.Value;
                }
            }
        }

        public IEnumerable<Genre> GetGenresByBookId(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Select_Genres_By_IDBook", con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Book_ID", System.Data.SqlDbType.Int)
                    {
                        Value = id
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
        }

        public Genre GetGenreById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
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
}
