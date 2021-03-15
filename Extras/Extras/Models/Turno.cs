using System;
using System.Collections.Generic;

#nullable disable

namespace Extras.Models
{
    public partial class Turno
    {
        public Turno()
        {
            Transacciones = new HashSet<Transaccione>();
        }

        public int Id { get; set; }
        public int Codigoth { get; set; }
        public int Dia { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime HoraIniDescanso { get; set; }
        public DateTime HoraFinDescanso { get; set; }
        public string Observaciones { get; set; }
        public bool? Estado { get; set; }
        public int? CreatedAt { get; set; }
        public DateTime CreatedAtdate { get; set; }
        public int? UpdatedAt { get; set; }
        public DateTime? UpdatedAtdate { get; set; }

        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
