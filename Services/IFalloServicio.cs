using System.Collections.Generic;
using RaccoonMobile.Models;

namespace RaccoonMobile.Services
{
    public interface IFalloServicio
    {
        List<Fallo> ObtenerFallos();
        Fallo? ObtenerFallo(int id);
        Fallo ReportarFallo(Fallo fallo);
        bool ActualizarFallo(Fallo fallo);
        bool EliminarFallo(int id);

        // Métodos agregados para estadísticas
        Dictionary<string, int> ObtenerFallosPorEstado();
        Dictionary<string, int> ObtenerFallosPorDia();
        double CalcularTiempoPromedioRespuesta();
    }
}