using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Extras.Models.Request
{
    public class tipoidentificacionRequest
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public byte estado { get; set; }
        public int CreatedAt { get; set; }
        public DateTime CreatedAtdate { get; set; }
        public int updatedAt { get; set; }
        public DateTime updatedAtdate { get; set; }
    }
}
