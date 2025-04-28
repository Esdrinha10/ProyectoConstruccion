using SIGESPROC.Entities.Entities;
using System;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class IncidentePorActividadMock
    {
        public static tbIncidenciasPorActividades InsertarIncidentePorActividadMock()
        {
            return new tbIncidenciasPorActividades
            {
                inac_Id=0,
                acet_Id=1,
                inci_Id=1,
                usua_Creacion=3,
                inac_FechaCreacion=DateTime.Now,
                usua_Modificacion=3,
                inac_FechaModificacion=DateTime.Now,
                inac_Estado=true
            };
        }

        public static tbIncidenciasPorActividades ActualizarIncidentePorActividadMock()
        {
            return new tbIncidenciasPorActividades
            {
                inac_Id = 3,
                acet_Id = 1,
                inci_Id = 1,
                usua_Creacion = 3,
                inac_FechaCreacion = DateTime.Now,
                usua_Modificacion = 3,
                inac_FechaModificacion = DateTime.Now,
                inac_Estado = true
            };
        }
    }
}
