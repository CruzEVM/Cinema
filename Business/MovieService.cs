using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Cinema.Models;
using Cinema.Data;

namespace Cinema.Business
{
    public class MovieService
    {
        private readonly Database db = new Database();

        // Obtener todas las películas
        public List<Movie> GetAllMovies()
        {
            var movies = new List<Movie>();

            using (var connection = db.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Movies";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movies.Add(new Movie
                            {
                                ID = reader.GetInt32("ID"),
                                Title = reader.GetString("Title"),
                                Genre = reader.GetString("Genre"),
                                Duration = reader.GetInt32("Duration"),
                                Classification = reader.GetString("Classification")
                            });
                        }
                    }
                }
            }
            return movies;
        }

        // Agregar una nueva película
        public void AddMovie(Movie movie)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Movies (Title, Genre, Duration, Classification) VALUES (@Title, @Genre, @Duration, @Classification)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", movie.Title);
                    command.Parameters.AddWithValue("@Genre", movie.Genre);
                    command.Parameters.AddWithValue("@Duration", movie.Duration);
                    command.Parameters.AddWithValue("@Classification", movie.Classification);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Actualizar una película existente
        public void UpdateMovie(Movie movie)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Movies SET Title = @Title, Genre = @Genre, Duration = @Duration, Classification = @Classification WHERE ID = @ID";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", movie.ID);
                    command.Parameters.AddWithValue("@Title", movie.Title);
                    command.Parameters.AddWithValue("@Genre", movie.Genre);
                    command.Parameters.AddWithValue("@Duration", movie.Duration);
                    command.Parameters.AddWithValue("@Classification", movie.Classification);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Eliminar una película
        public void DeleteMovie(int id)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Movies WHERE ID = @ID";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
