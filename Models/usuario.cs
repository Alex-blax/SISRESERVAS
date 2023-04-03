﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISRESERVAS.Models
{
    public class usuario
    {
        public usuario()
        {
            Reservas = new HashSet<reserva>();
        }
        [Key]

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }



        public ISet<reserva> Reservas { get; set; }

        [NotMapped]
        public bool MantenerActivo { get; set; }

    }
}
