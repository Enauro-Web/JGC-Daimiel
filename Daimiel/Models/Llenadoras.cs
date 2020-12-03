using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daimiel.Models
{
    public class Llenadoras
    {
        public int id { get; set; }
        public int formulacion_id { get; set; }
        public int semielaborado { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }        
        public float cantidad { get; set; }
        public int duracion { get; set; }
        public int orden { get; set; }
        public string fecha_inicio { get; set; }
        public string fecha_fin { get; set; }


    }
}
