using Cinema.Data;
using Cinema.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            // Crear instancia de la clase Database
            Database db = new Database();

            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open(); // Abre la conexión
                    MessageBox.Show("¡Conexión exitosa a la base de datos!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGestionarPeliculas_Click(object sender, EventArgs e)
        {
            FormMovies formMovies = new FormMovies();
            formMovies.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenRooms_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario FormRooms
            FormRooms formRooms = new FormRooms();

            // Muestra el formulario
            formRooms.ShowDialog();
        }

        private void btnOpenReservations_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FormReservations
            FormReseravtions formReservations = new FormReseravtions();

            // Mostrar el formulario
            formReservations.ShowDialog();
        }
    }
}
