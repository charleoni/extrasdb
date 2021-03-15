using System;
using System.Collections.Generic;

#nullable disable

namespace Extras.Models
{
    public partial class Rango
    {
        public Rango()
        {
            Novedades = new HashSet<Novedade>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Rango1 { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public bool? Estado { get; set; }
        public int? CreatedAt { get; set; }
        public DateTime CreatedAtdate { get; set; }
        public int? UpdatedAt { get; set; }
        public DateTime? UpdatedAtdate { get; set; }

        public virtual ICollection<Novedade> Novedades { get; set; }
    }
}
