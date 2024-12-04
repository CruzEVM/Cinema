using Cinema.Business;
using Cinema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.Presentation
{
    public partial class FormReseravtions : Form
    {
        private readonly ReservationService reservationService = new ReservationService();
        private readonly MovieService movieService = new MovieService(); // Servicio de películas
        public FormReseravtions()
        {
            InitializeComponent();
            LoadMovies(); // Cargar las películas al iniciar el formulario
            LoadReservations(); // Cargar las reservas existentes
        }

        private void FormReseravtions_Load(object sender, EventArgs e)
        {
           
        }
        // Cargar películas en el ComboBox
        private void LoadMovies()
        {
            try
            {
                var movies = movieService.GetAllMovies(); // Obtener todas las películas
                cmbMovie.DataSource = movies; // Asignar al ComboBox
                cmbMovie.DisplayMember = "Title"; // Mostrar el título de la película
                cmbMovie.ValueMember = "ID"; // Usar el ID como valor
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las películas: {ex.Message}");
            }
        }  
        private void LoadReservations()
        {
            try
            {
                var reservations = reservationService.GetAllReservations();
                dataGridViewReservations.DataSource = reservations;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar reservas: {ex.Message}");
            }
        }

        // Guardar una nueva reserva
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar selección de película y horario
                if (cmbMovie.SelectedItem == null || dtpReservationDate.Value == null)
                {
                    MessageBox.Show("Por favor, selecciona una película y un horario.");
                    return;
                }

                // Obtener sala aleatoria
                var room = reservationService.GetRandomRoom();
                if (room == null)
                {
                    MessageBox.Show("No hay salas disponibles. Por favor, verifica la base de datos.");
                    return;
                }

                // Crear nueva reserva
                var reservation = new Reservation
                {
                    MovieID = ((Movie)cmbMovie.SelectedItem).ID, // Corregido
                    RoomID = room.ID,
                    ReservationDate = dtpReservationDate.Value,
                    UserName = txtUserName.Text
                };

                reservationService.AddReservation(reservation);
                MessageBox.Show($"Reserva guardada correctamente.\nSala asignada: {room.Name}");

                // Actualizar lista
                LoadReservations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la reserva: {ex.Message}");
            }
        }
    }
}
