using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Extras.Models.Request
{
    public class rangosRequest
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string rango { get; set; }
        public DateTime inicio { get; set; }
        public DateTime fin { get; set; }
        public byte estado { get; set; }
        public int createdAt { get; set; }
        public DateTime createdAtdate { get; set; }
        public int updatedAt { get; set; }
        public DateTime uptadedAtdate { get; set; }
    }
}
