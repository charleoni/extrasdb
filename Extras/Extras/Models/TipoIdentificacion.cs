using System;
using System.Collections.Generic;

#nullable disable

namespace Extras.Models
{
    public partial class TipoIdentificacion
    {
        public TipoIdentificacion()
        {
            Funcionarios = new HashSet<Funcionario>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public int? CreatedAt { get; set; }
        public DateTime CreatedAtdate { get; set; }
        public int? UpdatedAt { get; set; }
        public DateTime? UpdatedAtdate { get; set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
