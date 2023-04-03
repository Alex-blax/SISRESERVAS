﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISRESERVAS.Models
{
    public class departamento
    {
        public departamento()
        {
            Viajes = new HashSet<viaje>();
        }

        [Key]
        public int IdDep { get; set; }
        public string NombreDep { get; set; }
        public int Precio { get; set; }


        public ISet<viaje> Viajes { get; set; }
    }
}
