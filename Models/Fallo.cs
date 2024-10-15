using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaccoonMobile.Models
{
    public class Fallo
    {
        public int id { get; set; }
        public Usuario usuario { get; set; }
        public DateTime fechaReporte { get; set; }
        public DateTime fechaResolucion { get; set; }
        public String descripcion { get; set; }
        public Estado estado { get; set; }
        public Double PosicionLatitud { get; set; }
        public Double PosicionLongitud { get; set; }

    }
}