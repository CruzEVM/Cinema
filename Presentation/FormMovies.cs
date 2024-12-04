using Cinema.Business;
using Cinema.Data;
using Cinema.Models;
using MySql.Data.MySqlClient;
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
    public partial class FormMovies : Form
    {
        private Database db = new Database();
        private MovieService movieService;


        public FormMovies()
        {
            InitializeComponent();
            movieService = new MovieService();
        }

        private void FormMovies_Load(object sender, EventArgs e)
        {

        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                var movies = movieService.GetAllMovies();
                dataGridViewMovies.DataSource = movies;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar películas: {ex.Message}");
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var movie = new Movie
                {
                    Title = txtTitle.Text,
                    Genre = txtGenre.Text,
                    Duration = int.Parse(txtDuration.Text),
                    Classification = txtClassification.Text
                };

                movieService.AddMovie(movie);
                MessageBox.Show("Película agregada correctamente.");
                btnListar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la película: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);

                movieService.DeleteMovie(id);
                MessageBox.Show("Película eliminada correctamente.");
                btnListar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la película: {ex.Message}");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                var movie = new Movie
                {
                    ID = int.Parse(txtID.Text),
                    Title = txtTitle.Text,
                    Genre = txtGenre.Text,
                    Duration = int.Parse(txtDuration.Text),
                    Classification = txtClassification.Text
                };

                movieService.UpdateMovie(movie);
                MessageBox.Show("Película actualizada correctamente.");
                btnListar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la película: {ex.Message}");
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDuration_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que la fila seleccionada no sea el encabezado
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewMovies.Rows[e.RowIndex];

                // Asigna los valores de la fila seleccionada a los campos de texto
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtGenre.Text = row.Cells["Genre"].Value.ToString();
                txtDuration.Text = row.Cells["Duration"].Value.ToString();
                txtClassification.Text = row.Cells["Classification"].Value.ToString();
                txtID.Text = row.Cells["ID"].Value.ToString();
            }
        }

        private void ClearTextBoxes()
        {
            txtID.Clear();
            txtTitle.Clear();
            txtGenre.Clear();
            txtDuration.Clear();
            txtClassification.Clear();
        }
            private void btnLimpiar_Click(object sender, EventArgs e)
            {
                ClearTextBoxes();
            }

    }
}
