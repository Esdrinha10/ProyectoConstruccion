using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class EstadosCivilesMocks
    {
        public static tbEstadosCiviles CrearMockEstadosCiviles()
        {
            return new tbEstadosCiviles
            {
                civi_Descripcion = "Prueba",
                usua_Creacion = 3,
                civi_FechaCreacion = DateTime.Now,
            };

        }

        public static tbEstadosCiviles EditarMockEstadosCiviles()
        {
            return new tbEstadosCiviles
            {
                civi_Id = 1,
                civi_Descripcion = "Prueba",
                usua_Modificacion = 3,
                civi_FechaModificacion = DateTime.Now,
            };

        }
    }
}
