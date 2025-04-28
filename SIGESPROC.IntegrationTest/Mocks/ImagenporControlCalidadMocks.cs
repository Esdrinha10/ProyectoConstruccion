using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
  public  class ImagenporControlCalidadMocks
    {

        public static tbImagenesPorControlesDeCalidades CrearMockIncidentesImagenPorControlCalidad()
        {
            return new tbImagenesPorControlesDeCalidades
            {
                icca_Imagen = "Prueba",
                coca_Id = 30,
                usua_Creacion = 3,
                icca_FechaCreacion = DateTime.Now,
               
            };

        }

        public static tbImagenesPorControlesDeCalidades EditarMockImagenporControlCalidad()
        {
            return new tbImagenesPorControlesDeCalidades
            {
                icca_Id = 27,
                icca_Imagen = "Prueba",
                coca_Id = 30,
                usua_Modificacion = 3,
                icca_FechaModificacion = DateTime.Now,
            };

        }


    }
}
