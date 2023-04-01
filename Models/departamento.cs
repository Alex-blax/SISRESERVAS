using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISRESERVAS.Models
{
    public class departamento
    {
        //aqui va la info de cada departamento para viajar de bolivia
        [Key]
        public int departamentoid { get; set; }
        public string nombredep { get; set; }
        public int precio { get; set; }



        public ICollection<reserva> reserva { get; set; }

    }
}