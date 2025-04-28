using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
  public  class ImagenesporIncidenteMocks
    {
        public static tbImagenesPorIncidencias CrearMockImagenesPorIncidencias()
        {
            return new tbImagenesPorIncidencias
            {
                imin_Imagen ="Prueba",
                inci_Id = 26,
                usua_Creacion = 3,
                imin_FechaCreacion = DateTime.Now
            };

        }

        public static tbImagenesPorIncidencias EditarMockImagenesPorIncidencias()
        {
            return new tbImagenesPorIncidencias
            {
                imin_Id = 27,
                imin_Imagen = "Prueba",
                inci_Id = 26,
                usua_Modificacion = 3,
                imin_FechaModificacion = DateTime.Now,
              
            };

        }

    }
}
