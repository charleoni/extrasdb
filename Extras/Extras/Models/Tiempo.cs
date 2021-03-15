using System;
using System.Collections.Generic;

#nullable disable

namespace Extras.Models
{
    public partial class Tiempo
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
        public string MesNombre { get; set; }
        public string DiaNombre { get; set; }
        public int DiaAño { get; set; }
        public int SemanaAño { get; set; }
        public int Semestre { get; set; }
        public int Trimestre { get; set; }
        public int Cuatrimestre { get; set; }
        public bool DiaHabil { get; set; }
    }
}
