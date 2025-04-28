using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
  public  class ControldeCalidadporActividadMocks
    {
        public static tbControlDeCalidadesPorActividades CrearMockControlDeCalidadesPorActividades()
        {
            return new tbControlDeCalidadesPorActividades
            {
                acet_Id = 1,
                coca_Id = 12,
        
            
            };

        }

        public static tbControlDeCalidadesPorActividades EditarMockControlDeCalidadesPorActividades()
        {
            return new tbControlDeCalidadesPorActividades
            {
                coac_Id = 12,
                acet_Id = 1,
                coca_Id = 12,
            };

        }



    }
}
