using Cinema.Models;
using Cinema.Services;
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
    public partial class FormRooms : Form
    {

        private readonly RoomService roomService;
        public FormRooms()
        {
            InitializeComponent();
            string connectionString = "server=localhost;port=3306;database=CinemaDB;user id=root;password=Admin159753*";
            roomService = new RoomService(connectionString);
        }

        private void FormRooms_Load(object sender, EventArgs e)
        {

        }
        private void btnListRooms_Click(object sender, EventArgs e)
        {
            try
            {
                var rooms = roomService.GetAllRooms();
                dataGridViewRooms.DataSource = rooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar salas: {ex.Message}");
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                var room = new Room
                {
                    Name = txtRoomName.Text,
                    Capacity = int.Parse(txtRoomCapacity.Text)
                };
                roomService.AddRoom(room);
                MessageBox.Show("Sala agregada correctamente");
                btnListRooms_Click(sender, e); // Refrescar la lista
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la sala: {ex.Message}");
            }
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtRoomID.Text);
                roomService.DeleteRoom(id);
                MessageBox.Show("Sala eliminada correctamente");
                btnListRooms_Click(sender, e); // Refrescar la lista
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la sala: {ex.Message}");
            }
        }

        private void dataGridViewRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewRooms.Rows[e.RowIndex];
                txtRoomID.Text = row.Cells["ID"].Value.ToString();
                txtRoomName.Text = row.Cells["Name"].Value.ToString();
                txtRoomCapacity.Text = row.Cells["Capacity"].Value.ToString();
            }
        }

        private void dataGridViewRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtRoomID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
