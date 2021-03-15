using System;
using System.Collections.Generic;

#nullable disable

namespace Extras.Models
{
    public partial class Novedade
    {
        public int Id { get; set; }
        public int Identificacion { get; set; }
        public DateTime Fecha { get; set; }
        public int Codigo { get; set; }
        public DateTime Inicio1 { get; set; }
        public DateTime Fin1 { get; set; }
        public DateTime? Inicio2 { get; set; }
        public DateTime? Fin2 { get; set; }
        public string Tipo { get; set; }
        public double Cantidad { get; set; }
        public bool? Estado { get; set; }
        public int? CreatedAt { get; set; }
        public DateTime CreatedAtdate { get; set; }
        public int? UpdatedAt { get; set; }
        public DateTime? UpdatedAtdate { get; set; }

        public virtual Rango CodigoNavigation { get; set; }
        public virtual Funcionario IdentificacionNavigation { get; set; }
    }
}
