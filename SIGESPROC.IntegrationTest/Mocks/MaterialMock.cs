using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class MaterialMock
    {
        public static tbMateriales CrearMoskMaterial()
        {
            return new tbMateriales
            {
                mate_Descripcion = "Prueba",
                usua_Creacion = 3,
                mate_FechaCreacion = DateTime.Now
            };

        }

        public static tbMateriales EditarMoskMaterial()
        {
            return new tbMateriales
            {
                mate_Id = 71,
                mate_Descripcion = "Prueba",
                usua_Modificacion = 3,
                mate_FechaModificacion = DateTime.Now
            };

        }
    }
}
