using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SISRESERVAS.Models
{
    public class viaje
    {
        //en esta clase iran los distintos viajes disponibles por dia
        [Key]
        public int viajeid {get;set;}
        public string bus {get;set;}
        public int asientosdis {get;set;}
        public string conductor { get; set; }

        public ICollection<reserva> reserva { get; set; }
    }




}
