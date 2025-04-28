using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public class DeduccionMocks
    {
        public static tbDeducciones CrearMockDeduccion()
        {
            return new tbDeducciones
            {
                dedu_Descripcion = "Nueva Deduccion",
                dedu_Porcentaje = 5,
                dedu_EsMontoFijo = false,
                usua_Creacion = 3,
                dedu_FechaCreacion = DateTime.Now
            };
        }

        public static tbDeducciones ActualizarMockDeduccion()
        {
            return new tbDeducciones
            {
                dedu_Id = 15,
                dedu_Descripcion = "Nueva Deduccion",
                dedu_Porcentaje = 5,
                dedu_EsMontoFijo = false,
                usua_Creacion = 3,
                dedu_FechaCreacion = DateTime.Now
            };
        }

    }
}
