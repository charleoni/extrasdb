using System;
using System.Collections.Generic;

#nullable disable

namespace Extras.Models
{
    public partial class Transaccione
    {
        public int Id { get; set; }
        public int? IdFuncionario { get; set; }
        public DateTime Fecha { get; set; }
        public string Identificacion { get; set; }
        public int Codigoth { get; set; }
        public DateTime Horaentrada { get; set; }
        public DateTime Horasalida { get; set; }
        public DateTime Horainidescanso { get; set; }
        public DateTime Horafindescanso { get; set; }
        public bool? Estado { get; set; }
        public int? CreatedAt { get; set; }
        public DateTime CreatedAtdate { get; set; }
        public int? UpdatedAt { get; set; }
        public DateTime? UpdatedAtdate { get; set; }

        public virtual Turno CodigothNavigation { get; set; }
        public virtual Funcionario IdFuncionarioNavigation { get; set; }
    }
}
