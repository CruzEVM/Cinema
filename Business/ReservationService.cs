using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Cinema.Models;
using Cinema.Data;

namespace Cinema.Business
{
    public class ReservationService
    {
        private readonly Database db = new Database();

        // Agregar reserva
        public void AddReservation(Reservation reservation)
        {
            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Reservations (MovieID, RoomID, ReservationDate, UserName) VALUES (@MovieID, @RoomID, @ReservationDate, @UserName)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MovieID", reservation.MovieID);
                        command.Parameters.AddWithValue("@RoomID", reservation.RoomID);
                        command.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate);
                        command.Parameters.AddWithValue("@UserName", reservation.UserName);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar la reserva: {ex.Message}");
            }
        }

        // Obtener todas las reservas
        public List<object> GetAllReservations()
        {
            var reservations = new List<object>();

            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT r.ID, m.Title AS Movie, ro.Name AS Room, r.ReservationDate, r.UserName
                        FROM Reservations r
                        JOIN Movies m ON r.MovieID = m.ID
                        JOIN Rooms ro ON r.RoomID = ro.ID";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservations.Add(new
                            {
                                ID = reader.GetInt32("ID"),
                                Movie = reader.GetString("Movie"),
                                Room = reader.GetString("Room"),
                                ReservationDate = reader.GetDateTime("ReservationDate"),
                                UserName = reader.GetString("UserName")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener reservas: {ex.Message}");
            }

            return reservations;
        }

        // Obtener sala aleatoria
        public Room GetRandomRoom()
        {
            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Rooms";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        var rooms = new List<Room>();
                        while (reader.Read())
                        {
                            rooms.Add(new Room
                            {
                                ID = reader.GetInt32("ID"),
                                Name = reader.GetString("Name")
                            });
                        }

                        if (rooms.Count > 0)
                        {
                            var random = new Random();
                            int index = random.Next(rooms.Count);
                            return rooms[index];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener una sala aleatoria: {ex.Message}");
            }

            return null; // Si no hay salas disponibles
        }
    }
}
