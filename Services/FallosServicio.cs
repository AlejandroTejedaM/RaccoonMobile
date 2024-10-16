using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RaccoonMobile.Models;

namespace RaccoonMobile.Services
{
    public class FalloServicio : IFalloServicio
    {
        private List<Fallo> fallos;
        public FalloServicio()
        {
            this.fallos = new List<Fallo>();
            
        }
        public bool ActualizarFallo(Fallo fallo)
        {
            Fallo? falloActual = fallos.FirstOrDefault(f => f.id == fallo.id);
            if (falloActual != null)
            {
                falloActual = fallo;
                fallos.Remove(falloActual);
                fallos.Add(fallo);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarFallo(int id)
        {
            Fallo? fallo = fallos.FirstOrDefault(f => f.id == id);
            if (fallo != null)
            {
                fallos.Remove(fallo);
                return true;
            }
            return false;
        }

        public Fallo? ObtenerFallo(int id)
        {
            if (fallos.Count > 0)
            {
                return fallos.FirstOrDefault(f => f.id == id);
            }
            else
            {
                return null;
            }
        }

        public List<Fallo> ObtenerFallos()
        {
            return fallos;
        }

        public List<Fallo> ObtenerFallosPorUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Fallo ReportarFallo(Fallo fallo)
        {
            if (fallo == null)
            {
                throw new ArgumentNullException(nameof(fallo));
            }
            fallos.Add(fallo);
            return fallo;
        }
    }

}