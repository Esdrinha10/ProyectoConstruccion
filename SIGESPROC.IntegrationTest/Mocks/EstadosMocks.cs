using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class EstadosMocks
    {
        public static tbEstados CrearMockEstados()
        {
            return new tbEstados
            {
                esta_Codigo = "0101",
                esta_Nombre = "Prueba",
                pais_Id = 1,
                usua_Creacion = 3,
                esta_FechaCreacion = DateTime.Now,
            };
        }

        public static tbEstados EditarMockEstados()
        {
            return new tbEstados
            {
                esta_Id = 1,
                esta_Codigo = "11",
                esta_Nombre = "Prueba",
                pais_Id = 1,
                usua_Modificacion = 3,
                esta_FechaModificacion = DateTime.Now,
            };
        }
    }
}
