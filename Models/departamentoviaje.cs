using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISRESERVAS.Models
{
    public class departamentoviaje
    {
        [Key]
        public int Iddevia { get; set; }

     /*   [ForeignKey("ViajeId")]
        public int ViajeId { get; set; }*/
        public viaje viaje { get; set; }

   /*     [ForeignKey("DepartamentoId")]
        public int DepartamentoId { get; set; }*/
        public departamento departamento { get; set; }


        public ICollection<reserva> reserva { get; set; }


    }
}
