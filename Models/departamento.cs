using System.ComponentModel.DataAnnotations;

namespace SISRESERVAS.Models
{
    public class departamento
    {
        //aqui va la info de cada departamento para viajar de bolivia
        [Key]
        private int id;
        private string nombredep;
/*        private int estado;
*/
        public int Id { get => id; set => id = value; }
        public string Nombredep { get => nombredep; set => nombredep = value; }
/*        public int Estado { get => estado; set => estado = value; }
*/
    }
}