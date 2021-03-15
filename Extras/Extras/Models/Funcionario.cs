using System;
using System.Collections.Generic;

#nullable disable

namespace Extras.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Novedades = new HashSet<Novedade>();
            Transacciones = new HashSet<Transaccione>();
        }

        public int Id { get; set; }
        public int TipoIdentificacion { get; set; }
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public bool? Estado { get; set; }
        public int? CreatedAt { get; set; }
        public DateTime CreatedAtdate { get; set; }
        public int? UpdatedAt { get; set; }
        public DateTime? UpdatedAtdate { get; set; }

        public virtual TipoIdentificacion TipoIdentificacionNavigation { get; set; }
        public virtual ICollection<Novedade> Novedades { get; set; }
        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
