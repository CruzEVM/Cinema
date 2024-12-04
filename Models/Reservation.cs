using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Models
{
	public class Reservation
	{
        public int ID { get; set; } // ID único
        public int MovieID { get; set; } // ID de la película
        public int RoomID { get; set; } // ID de la sala
        public DateTime ReservationDate { get; set; } // Fecha y hora de la reserva
        public string UserName { get; set; } // Nombre del usuario que reserva
    }
}

