using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class IncidentesMocks
    {

        public static tbIncidentes CrearMockIncidentes()
        {
            return new tbIncidentes
            {
                inci_Descripcion = "Prueba",
                inci_Fecha = DateTime.Now,
                inci_Costo = 30,
                acet_Id = 892,
                usua_Creacion = 3,
                inci_FechaCreacion = DateTime.Now,
                imin_Imagen = "imagen.jpg",
                imin_FechaCreacion = DateTime.Now
            };

        }

        public static tbIncidentes EditarMockIncidentes()
        {
            return new tbIncidentes
            {
                inci_Id = 27,
                inci_Descripcion = "Prueba",
                inci_Fecha = DateTime.Now,
                inci_Costo = 30,
                acet_Id = 892,
                usua_Modificacion = 3,
                inci_FechaModificacion = DateTime.Now,
                imin_Imagen = "imagen.jpg",
                imin_FechaModificacion = DateTime.Now
            };

        }

    }
}
