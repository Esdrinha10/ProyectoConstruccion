using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public class EstadodeProyectoMocks
    {
        public static tbEstadosProyectos CrearMockEstadosProyectos()
        {
            return new tbEstadosProyectos
            {
                espr_Descripcion = "Prueba",
                usua_Creacion = 3,
                espr_FechaCreacion = DateTime.Now,
            
            };

        }

        public static tbEstadosProyectos EditarMockEstadosProyectos()
        {
            return new tbEstadosProyectos
            {
                espr_Id = 27,
                espr_Descripcion = "Prueba",
                usua_Modificacion = 3,
                espr_FechaModificacion = DateTime.Now,
            
            };

        }
    }
}
