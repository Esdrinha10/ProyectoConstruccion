using SIGESPROC.Entities.Entities;
using System;
using SIGESPROC.Common.Models.ModelsGeneral;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public static class NivelesMocks
    {

        public static NivelViewModel CrearMockNiveles()
        {
            return new NivelViewModel
            {
                nive_Descripcion = "Medio",
                usua_Creacion = 3,
                nive_FechaCreacion = DateTime.Now

            };
        }


        public static NivelViewModel EditarMockNiveles()
        {
            return new NivelViewModel
            {
                nive_Id = 1,
                nive_Descripcion = "Medio",
                usua_Modificacion = 3,
                nive_FechaModificacion = DateTime.Now
            };
        }

    }
}
