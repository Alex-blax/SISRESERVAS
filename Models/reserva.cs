using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SISRESERVAS.Models
{
    public class reserva
    {
       

        [Key]
        public int Id { get; set; }
/*        public DateTime Fecha { get; set; }
*/        public int Cantidad { get; set; }


        public departamentoviaje departamentoviaje { get; set; }




        public usuario usuario { get; set; }

    }
}