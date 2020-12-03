using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daimiel.Models
{
    public class TblLlenadoras
    {
        public int id { get; set; }
        public int formulacion_id { get; set; }
        public int semielaborado { get; set; }
        public string unidad { get; set; }
        public string puesto { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public DateTime inicio_vaciado_alsafe { get; set; }
        public float cantidad { get; set; }
        public int duracion { get; set; }
        public string estado { get; set; }
        public int orden { get; set; }


    }
}
