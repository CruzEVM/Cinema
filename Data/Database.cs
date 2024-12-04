using MySql.Data.MySqlClient;

namespace Cinema.Data
{
    public class Database
    {
        // Cadena de conexión a la base de datos
        private const string ConnectionString = "server=localhost;port=3306;database=CinemaDB;user id=root;password=Admin159753*;";

        // Método para obtener una nueva conexión
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

    }
}
