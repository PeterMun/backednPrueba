using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backendPruebaNexti.Models
{
    public class EventoModel
    {
        [Key]
        public int IdEvento{ get; set; }
        public string? DescripcionEvento { get; set; }
        public string? LugarEvento { get; set; }
        public decimal? PrecioEvento { get; set; }
        public DateOnly? FechaEvento { get; set; }
        public bool? Estado { get; set; }
    }
}