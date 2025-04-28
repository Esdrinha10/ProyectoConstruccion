using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
  public  class GestionRiesgoMocks
    {

        public static tbGestionRiesgos CrearMockGestionRiesgos()
        {
            return new tbGestionRiesgos
            {
                geri_Descripcion = "Prueba",
                geri_Impacto = "Prueba",
                geri_Probabilidad = 10,
                geri_Mitigacion = "Prueba",
                proy_Id = 30,
                usua_Creacion = 3,
                geri_FechaCreacion = DateTime.Now,
              
            };

        }

        public static tbGestionRiesgos EditarMockGestionRiesgos()
        {
            return new tbGestionRiesgos
            {
                geri_Id = 1,
                geri_Descripcion = "Prueba",
                geri_Impacto = "Prueba",
                geri_Probabilidad = 10,
                geri_Mitigacion = "Prueba",
                proy_Id = 30,
                usua_Modificacion = 3,
                geri_FechaModificacion = DateTime.Now,

            };

        }
    }
}
