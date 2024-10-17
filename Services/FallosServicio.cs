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
            var random = new Random();
            var estados = new[] { Estado.Pendiente, Estado.Atendida, Estado.Cancelada };
            var dispositivos = new[] { "Laptop", "Impresora", "Servidor", "Router", "Smartphone" };
            var tiposRed = new[] { "3G", "4G", "5G", "WiFi" };

            for (int i = 0; i < 20; i++)
            {
                var fechaReporte = DateTime.Now.AddDays(-random.Next(0, 365));
                var fechaResolucion = fechaReporte.AddHours(random.Next(1, 72));
                var estado = estados[random.Next(estados.Length)];

                fallos.Add(new Fallo
                {
                    id = i + 1,
                    usuario = $"Usuario {i + 1}",
                    descripcion = $"Problema {i + 1}",
                    dispositivo = dispositivos[random.Next(dispositivos.Length)],
                    tipoRed = tiposRed[random.Next(tiposRed.Length)],
                    PosicionLatitud = 19.4326 + random.NextDouble() * 0.1,
                    PosicionLongitud = -99.1332 + random.NextDouble() * 0.1,
                    estado = estado,
                    fechaReporte = fechaReporte,
                    fechaResolucion = estado == Estado.Pendiente ? DateTime.MinValue : fechaResolucion
                });
            }
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
        public Dictionary<string, double> CalcularTiempoPromedioRespuestaPorDia()
        {
            var tiemposPorDia = fallos
                .Where(f => f.fechaResolucion != DateTime.MinValue)
                .GroupBy(f => f.fechaReporte.Date)
                .ToDictionary(
                    g => g.Key.ToString("yyyy-MM-dd"),
                    g => g.Average(f => (f.fechaResolucion - f.fechaReporte).TotalMinutes)
                );

            return tiemposPorDia;
        }
    }
}
