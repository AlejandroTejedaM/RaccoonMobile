using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RaccoonMobile.Models;

namespace RaccoonMobile.Services
{
    public interface IFalloServicio
    {
        public List<Fallo> ObtenerFallos();
        public Fallo? ObtenerFallo(int id);
        public Fallo ReportarFallo(Fallo fallo);
        public bool ActualizarFallo(Fallo fallo);
        public bool EliminarFallo(int id);
        public List<Fallo> ObtenerFallosPorUsuario(int id);
    }
}