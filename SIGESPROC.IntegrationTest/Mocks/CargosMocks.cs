using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class CargosMocks
    {
        public static tbCargos CrearMockCargos()
        {
            return new tbCargos
            {
                carg_Descripcion = "Prueba",
                usua_Creacion = 3,
                carg_FechaCreacion = DateTime.Now
            };

        }

        public static tbCargos EditarMockCargos()
        {
            return new tbCargos
            {
                carg_Id = 27,
                carg_Descripcion = "Prueba",
                usua_Modificacion = 3,
                carg_FechaModificacion = DateTime.Now,
            };
        }
    }
}
