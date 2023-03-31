using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISRESERVAS.Models
{
    public class usuario
    {
        [Key]
        private int id;
        private string nombre;
        private string apellido;
        private int edad;
        private string correo;
        private string contraseña;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }

        [NotMapped]
        public bool MantenerActivo { get; set; }
    }
}
