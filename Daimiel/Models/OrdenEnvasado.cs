using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daimiel.Models
{
    public class OrdenEnvasado
    {
        public int Id { get; set; }
        public string Puesto { get; set; }
        public string Puesto_Denominacion { get; set; }
        public int Orden { get; set; }
        public int Material { get; set; }
        public string ProductoTerminado { get; set; }
        public string ProductoTerminado_Denominacion { get; set; }
        public int Semielaborado { get; set; }
        public string Semielaborado_Descr { get; set; }
        public float Grado_Brix_VALOR_TEO { get; set; }
        public float Temperatura_Pasteriz { get; set; }
        public float Temperatura_Llenado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
