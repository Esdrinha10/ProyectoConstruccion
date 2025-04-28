using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public class EtapaporProyectoMocks
    {
        public static tbEtapasPorProyectos CrearMockEtapaporProyecto()
        {
            return new tbEtapasPorProyectos
            {
                etap_Id = 1,
                empl_Id = 1,
                proy_Id = 1,
                usua_Creacion = 3,
                etpr_FechaCreacion = DateTime.Now,
                etpr_Estado = true,
              
            };

        }

        public static tbEtapasPorProyectos EditarMockEtapaporProyecto()
        {
            return new tbEtapasPorProyectos
            {
                etpr_Id = 1,
                etap_Id = 1,
                empl_Id = 1,
                proy_Id = 1,
                usua_Modificacion = 3,
                etpr_FechaModificacion = DateTime.Now,

            };

        }
    }
}
