using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Cinema.Models;

namespace Cinema.Services
{
    public class RoomService
    {
        private readonly string connectionString;

        public RoomService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Room> GetAllRooms()
        {
            var rooms = new List<Room>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Rooms";

                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rooms.Add(new Room
                        {
                            ID = reader.GetInt32("ID"),
                            Name = reader.GetString("Name"),
                            Capacity = reader.GetInt32("Capacity")
                        });
                    }
                }
            }

            return rooms;
        }

        public void AddRoom(Room room)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Rooms (Name, Capacity) VALUES (@Name, @Capacity)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", room.Name);
                    command.Parameters.AddWithValue("@Capacity", room.Capacity);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRoom(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Rooms WHERE ID = @ID";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
