using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public class ImagenporGestionAdicionalMocks
    {

        public static tbImagenesPorGestionesAdicionales CrearMockImagenporGestionAdicional()
        {
            return new tbImagenesPorGestionesAdicionales
            {
                Imge_Imagen = "Prueba",
                adic_Id = 30,
                usua_Creacion = 3,
                Imge_FechaCreacion = DateTime.Now
            };

        }

        public static tbImagenesPorGestionesAdicionales EditarMockImagenporGestionAdicional()
        {
            return new tbImagenesPorGestionesAdicionales
            {
                Imge_Id = 27,
                Imge_Imagen = "Prueba",
                adic_Id = 30,
                usua_Modificacion = 3,
                Imge_FechaModificacion = DateTime.Now,
          
            };

        }

    }

}
