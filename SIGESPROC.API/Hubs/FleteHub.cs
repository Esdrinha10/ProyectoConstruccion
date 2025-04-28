using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGESPROC.API.Hubs
{
    public class FleteHub : Hub
    {
        // Diccionario para almacenar las coordenadas de las polylines por cada empleado
        private static Dictionary<int, Dictionary<int, List<(double lat, double lng)>>> polylines
      = new Dictionary<int, Dictionary<int, List<(double, double)>>>();

        public async Task ActualizarPolyline(int emplId, int flenId, List<double> latitudes, List<double> longitudes)
        {
            // Validar que las listas de latitudes y longitudes tengan el mismo tamaño
            if (latitudes.Count != longitudes.Count)
            {
                throw new ArgumentException("Las listas de latitudes y longitudes deben tener el mismo tamaño.");
            }

            // Combinar las listas de latitudes y longitudes en una lista de tuplas (lat, lng)
            var coordenadas = latitudes.Zip(longitudes, (lat, lng) => (lat, lng)).ToList();

            // Asegurarse de que exista el empleado en el diccionario
            if (!polylines.ContainsKey(emplId))
            {
                polylines[emplId] = new Dictionary<int, List<(double, double)>>();
            }

            polylines[emplId][flenId] = coordenadas;

            // Notificar a los otros clientes conectados sobre la nueva polyline
            await Clients.Others.SendAsync("RecibirPolyline", emplId, flenId, latitudes, longitudes);
        }

        public async Task<List<Dictionary<string, double>>> ObtenerPolyline(int emplId, int flenId)
        {
            if (polylines.ContainsKey(emplId) && polylines[emplId].ContainsKey(flenId))
            {
                var polyline = polylines[emplId][flenId];
                return polyline.Select(p => new Dictionary<string, double>
        {
            { "lat", p.lat },
            { "lng", p.lng }
        }).ToList();
            }

            return new List<Dictionary<string, double>>();
        }
        // Método para actualizar la ubicación actual de un empleado
        public async Task ActualizarUbicacion(int emplId, int flenId, double lat, double lng)
        {
            // Enviar la nueva ubicación a todos los clientes conectados
            await Clients.All.SendAsync("RecibirUbicacion", emplId, flenId, lat, lng);
        }
    }
}