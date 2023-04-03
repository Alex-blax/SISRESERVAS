using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SISRESERVAS.Models
{
    public class viaje
    {
        public viaje()
        {
            Reservas = new HashSet<reserva>();
        }

        [Key]
        public int IdViaje { get; set; }
        public string Bus { get; set; }
        public string Conductor { get; set; }
        public DateTime Fecha { get; set; }
        public int AsientosDisponibles { get; set; }


        public ISet<reserva> Reservas { get; set; }

        public int DepartamentoId { get; set; }
        public virtual departamento Departamento { get; set; }
    }




}
