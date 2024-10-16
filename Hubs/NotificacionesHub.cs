using Microsoft.AspNetCore.SignalR;
using RaccoonMobile.Models;

namespace RaccoonMobile.Hubs
{
    public class NotificacionesHub : Hub
    {
        public async Task EnviarMensaje(string mensaje)
        {
            await Clients.All.SendAsync("RecibirMensaje", mensaje);
        }

        public async Task NuevoFalloReportado(Fallo fallo)
        {
            await Clients.All.SendAsync("NuevoFalloReportado", fallo);
        }
        
        public async Task FalloActualizado(Fallo fallo)
        {
            await Clients.All.SendAsync("FalloActualizado", fallo);
        }
    }
}
