using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Extras.Models.Request
{
    public class turnosRequest
    {
        public int id { get; set; }
        public int dia { get; set; }
        public int codigoth { get; set; }
        public DateTime hora_entrada { get; set; }
        public DateTime hora_salida { get; set; }
        public DateTime hora_ini { get; set; }
        public DateTime hora_fin { get; set; }
        public string observaciones { get; set; }
        public byte estado { get; set; }
        public int createdAt { get; set; }
        public DateTime createdAtdate { get; set; }
        public int updatedAt { get; set; }
        public DateTime updatedAtdate { get; set; }
    }
}
