using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SISRESERVAS.Models
{
    public class reserva
    {
        //aqui la info de las reservas de buses de tabla departamento usuario 
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }

        public int ViajeId { get; set; }
        public int UsuarioId { get; set; }
        /*        public int DepartamentoId { get; set; }
        */
        [ForeignKey("ViajeId")]
        public virtual viaje viaje { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual usuario usuario { get; set; }

        /*  [ForeignKey("DepartamentoId")]
          public virtual departamento departamento { get; set; }*/

    }
}