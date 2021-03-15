using System;
using System.Collections.Generic;

#nullable disable

namespace Extras.Models
{
    public partial class Tipohora
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public byte[] Rango { get; set; }
        public DateTime Horainicio { get; set; }
        public DateTime Horafinal { get; set; }
        public bool? Estado { get; set; }
        public int? CreatedAt { get; set; }
        public DateTime CreatedAtdate { get; set; }
        public int? UpdatedAt { get; set; }
        public DateTime? UpdatedAtdate { get; set; }
    }
}
