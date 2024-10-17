using System;
using System.Collections.Generic;
using System.Linq;
using RaccoonMobile.Models;

namespace RaccoonMobile.Services
{
    public class FalloServicio : IFalloServicio
    {
        private List<Fallo> fallos;

        public FalloServicio()
        {
            this.fallos = new List<Fallo>();
            fallos.Add(new Fallo
            {
                id = 1,
                usuario = "Juan Pérez",
                descripcion = "Problema con la conexión a internet",
                dispositivo = "Laptop",
                tipoRed = "4G",
                PosicionLatitud = 19.4326,
                PosicionLongitud = -99.1332,
                estado = Estado.Pendiente,
                fechaReporte = DateTime.Now
            });
            fallos.Add(new Fallo
            {
                id = 2,
                usuario = "María López",
                descripcion = "Problema con la impresora",
                dispositivo = "Impresora",
                tipoRed = "5G",
                PosicionLatitud = 19.4326,
                PosicionLongitud = -99.1332,
                estado = Estado.Atendida,
                fechaReporte = DateTime.Now.AddDays(-1),
                fechaResolucion = DateTime.Now
            });
            fallos.Add(new Fallo
            {
                id = 3,
                usuario = "Pedro Ramírez",
                descripcion = "Problema con el servidor",
                dispositivo = "Servidor",
                tipoRed = "3G",
                PosicionLatitud = 19.4326,
                PosicionLongitud = -99.1332,
                estado = Estado.Cancelada,
                fechaReporte = DateTime.Now.AddDays(-2),
                fechaResolucion = DateTime.Now
            });
        }

        public List<Fallo> ObtenerFallos()
        {
            return fallos;
        }

        public Fallo ObtenerFallo(int id)
        {
            return fallos.FirstOrDefault(f => f.id == id);
        }

        public Fallo ReportarFallo(Fallo fallo)
        {
            if (fallo == null) throw new ArgumentNullException(nameof(fallo));
            
            fallo.id = fallos.Count > 0 ? fallos.Max(f => f.id) + 1 : 1;
            fallos.Add(fallo);
            return fallo;
        }

        public bool ActualizarFallo(Fallo fallo)
        {
            var existente = fallos.FirstOrDefault(f => f.id == fallo.id);
            if (existente != null)
            {
                existente.usuario = fallo.usuario;
                existente.descripcion = fallo.descripcion;
                existente.dispositivo = fallo.dispositivo;
                existente.tipoRed = fallo.tipoRed;
                existente.PosicionLatitud = fallo.PosicionLatitud;
                existente.PosicionLongitud = fallo.PosicionLongitud;
                existente.estado = fallo.estado;
                existente.fechaReporte = fallo.fechaReporte;
                existente.fechaResolucion = fallo.fechaResolucion;   
                return true;
            }
            return false;
        }

        public bool EliminarFallo(int id)
        {
            var fallo = fallos.FirstOrDefault(f => f.id == id);
            if (fallo != null)
            {
                fallos.Remove(fallo);
                return true;
            }
            return false;
        }

        // Método para obtener estadísticas por estado
        public Dictionary<string, int> ObtenerFallosPorEstado()
        {
            return fallos
                .GroupBy(f => f.estado)
                .ToDictionary(
                    g => g.Key switch 
                    {
                        Estado.Pendiente => "Pendiente",
                        Estado.Atendida => "Atendida",
                        Estado.Cancelada => "Cancelada",
                        _ => "Desconocido"
                    },
                    g => g.Count()
                );
        }

        // Método para obtener fallos agrupados por día
        public Dictionary<string, int> ObtenerFallosPorDia()
        {
            return fallos
                .GroupBy(f => f.fechaReporte.Date.ToString("yyyy-MM-dd"))
                .ToDictionary(g => g.Key, g => g.Count());
        }

        // Método para calcular el tiempo de respuesta promedio en horas
        public double CalcularTiempoPromedioRespuesta()
        {
            var tiempos = fallos
                .Where(f => f.fechaResolucion != DateTime.MinValue)
                .Select(f => (f.fechaResolucion - f.fechaReporte).TotalHours)
                .ToList();

            return tiempos.Any() ? tiempos.Average() : 0;
        }
    }
}
