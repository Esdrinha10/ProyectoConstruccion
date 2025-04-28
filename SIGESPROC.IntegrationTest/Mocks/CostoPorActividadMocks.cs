using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public class CostoPorActividadMocks
    {
        public static tbCostoPorActividad CrearMockCostoPorActividad()
        {
            return new tbCostoPorActividad
            {
                unme_Id = 5,
                acti_Id = 15,
                copc_Valor = 500,
                usua_Creacion = 3,
                copc_FechaCreacion = DateTime.Now
            };
        }

        public static tbCostoPorActividad ActualizarMockCostoPorActividad()
        {
            return new tbCostoPorActividad
            {
                copc_Id = 20,
                unme_Id = 5,
                acti_Id = 15,
                copc_Valor = 500,
                usua_Creacion = 3,
                copc_FechaCreacion = DateTime.Now
            };
        }
    }
}
