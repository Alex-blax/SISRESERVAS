using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SISRESERVAS.Models
{
    public class reserva
    {
        [Key]

        public int IdRes { get; set; }
        public DateTime FechaReserva { get; set; }



        public int ViajeId { get; set; }
        public virtual viaje Viaje { get; set; }
        public int UsuarioId { get; set; }
        public virtual usuario Usuario { get; set; }


    }
}