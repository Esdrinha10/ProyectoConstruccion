using SIGESPROC.Entities.Entities;
using System;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public static class PaisesMocks
    {

        public static tbPaises CrearMockPaises()
        {
            return new tbPaises
            {
                pais_Nombre = "Honduras",
                pais_Codigo = "HN",
                pais_Prefijo = "504",
                usua_Creacion = 3,
                pais_FechaCreacion = DateTime.Now

            };
        }


        public static tbPaises EditarMockPaises()
        {
            return new tbPaises
            {
                pais_Id = 2,
                pais_Nombre = "Honduras",
                pais_Codigo = "HN",
                pais_Prefijo = "504",
                usua_Modificacion = 3,
                pais_FechaModificacion = DateTime.Now
            };
        }

    }
}
