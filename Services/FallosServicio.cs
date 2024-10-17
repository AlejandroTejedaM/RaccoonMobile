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
            var existingFallo = fallos.FirstOrDefault(f => f.id == fallo.id);
            if (existingFallo != null)
            {
                existingFallo.usuario = fallo.usuario;
                existingFallo.descripcion = fallo.descripcion;
                existingFallo.dispositivo = fallo.dispositivo;
                existingFallo.tipoRed = fallo.tipoRed;
                existingFallo.PosicionLatitud = fallo.PosicionLatitud;
                existingFallo.PosicionLongitud = fallo.PosicionLongitud;
                existingFallo.estado = fallo.estado;
                existingFallo.fechaReporte = fallo.fechaReporte;

                existingFallo.fechaResolucion = DateTime.Now;


                return true;
            }
            return false;
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

        public Fallo ObtenerFallo(int id)
        {
            return fallos.FirstOrDefault(f => f.id == id);
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
            Fallo ultimoFallo = ObtenerFallo(fallos.Count);
            if (ultimoFallo == null)
            {
                fallo.id = 1;
                fallos.Add(fallo);
            }
            else
            {
                fallo.id = ultimoFallo.id + 1;
                fallos.Add(fallo);
            }
            return fallo;
        }
    }

}