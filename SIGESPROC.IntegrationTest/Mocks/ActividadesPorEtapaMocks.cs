using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class ActividadesPorEtapaMocks
    {
        public static tbActividadesPorEtapas CrearMockActividadesPorEtapa()
        {
            return new tbActividadesPorEtapas
            {
                acet_Observacion = "prueba",
                acet_Cantidad = 10,
                empl_Id = 3,
                acet_FechaInicio = DateTime.Now,
                acet_FechaFin = DateTime.Now,
                acet_PrecioManoObraEstimado = 3000,
                acet_PrecioManoObraFinal = 2900,
                acti_Id = 5,
                unme_Id = 3,
                etpr_Id = 200,
                usua_Creacion = 3,
                acet_FechaCreacion = DateTime.Now,
                acet_Estado = true
            };
        }

        public static tbActividadesPorEtapas EditarMockActividadesPorEtapa()
        {
            return new tbActividadesPorEtapas
            {
                acet_Observacion = "prueba",
                acet_Cantidad = 10,
                empl_Id = 3,
                acet_FechaInicio = DateTime.Now,
                acet_FechaFin = DateTime.Now,
                acet_PrecioManoObraEstimado = 3000,
                acet_PrecioManoObraFinal = 2900,
                acti_Id = 5,
                unme_Id = 3,
                etpr_Id = 210,
                usua_Creacion = 3,
                acet_FechaCreacion = DateTime.Now,
                acet_Estado = true
            };
        }
    }
}
