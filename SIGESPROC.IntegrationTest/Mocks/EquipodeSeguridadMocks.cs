using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
  public   class EquipodeSeguridadMocks
    {
        public static tbEquiposSeguridad CrearMockEquiposSeguridad()
        {
            return new tbEquiposSeguridad
            {
                equs_Nombre = "Prueba",
                equs_Descripcion = "Prueba",
                usua_Creacion = 3,
                equs_FechaCreacion = DateTime.Now
            };

        }

        public static tbEquiposSeguridad EditarMockEquiposSeguridad()
        {
            return new tbEquiposSeguridad
            {

                equs_Id = 3,
                equs_Nombre = "Prueba",
                equs_Descripcion = "Prueba",
                usua_Modificacion = 3,
                equs_FechaModificacion = DateTime.Now
            };

        }

    }
}
