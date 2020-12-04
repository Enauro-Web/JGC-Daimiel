using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daimiel.Models
{
    public class JsonOrdenesRoot
    {
        public JsonOrdenes d { get; set; }
    }
    public class JsonOrdenes
    {
        public IEnumerable<JsonOrden> results { get; set; }
    }
    public class JsonOrden
    {
        public Metadata __metadata { get; set; }
        public string NumeroOrden { get; set; }
        public string Semielaborado { get; set; }
        public string Lote { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionSemielaborado { get; set; }
        public string Fecha { get; set; }
        public string Cantidad { get; set; }

    }

    public class Metadata
    {
        public string id { get; set; }
        public string uri { get; set; }
        public string type { get; set; }

    }
}
