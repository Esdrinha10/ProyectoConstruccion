using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class ActividadesMocks
    {
        public static tbActividades CrearMockActividad()
        {
            return new tbActividades
            {
                acti_Descripcion = "prueba",
                usua_Creacion = 3,
                acti_FechaCreacion = DateTime.Now
            };
        }

        public static tbActividades EditarMockActividad()
        {
            return new tbActividades
            {
                acti_Id = 6,
                acti_Descripcion = "prueba",
                usua_Modificacion = 3,
                acti_FechaModificacion = DateTime.Now
            };
        }
    }
}
