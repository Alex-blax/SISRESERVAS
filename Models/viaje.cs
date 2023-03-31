using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SISRESERVAS.Models
{
    public class viaje
    {
        //en esta clase iran los distintos viajes disponibles por dia
        [Key]
        private int id;
        private DateTime hora;
        private int precio;
        private string bus;
        private int asientosdis;
        private string conductor;
        public int DepartamentoId { get; set; }

        [ForeignKey("DepartamentoId")]
        public virtual departamento departamento { get; set; }

        public int Id { get => id; set => id = value; }
        public DateTime Hora { get => hora; set => hora = value; }
        public int Precio { get => precio; set => precio = value; }
        public string Bus { get => bus; set => bus = value; }
        public int Asientosdis { get => asientosdis; set => asientosdis = value; }
        public string Conductor { get => conductor; set => conductor = value; }

    }
}
