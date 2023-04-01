using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SISRESERVAS.Models
{
    public class reserva
    {
       

        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }


        [ForeignKey("DepartamentoId")]

        public int DepartamentoId { get; set; }
        public departamento departamento { get; set; }

        [ForeignKey("ViajeId")]
        public int ViajeId { get; set; }
        public viaje viaje { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public usuario usuario { get; set; }

    }
}