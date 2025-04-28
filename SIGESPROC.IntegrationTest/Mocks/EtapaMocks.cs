using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
  public  class EtapaMocks
    {

        public static tbEtapas CrearMockEtapas()
        {
            return new tbEtapas
            {
                etap_Descripcion = "Prueba",
                usua_Creacion = 3,
                etap_FechaCreacion = DateTime.Now,
          
            };

        }

        public static tbEtapas EditarMockEtapas()
        {
            return new tbEtapas
            {
                etap_Id = 27,
                etap_Descripcion = "Prueba",
                usua_Modificacion = 3,
                etap_FechaModificacion = DateTime.Now,
            };

        }
    }
}
