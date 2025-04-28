using SIGESPROC.Common.Models.ModelsGeneral;
using SIGESPROC.Entities.Entities;
using System;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public static class MonedasMocks
    {

        public static MonedaViewModel CrearMockMonedas()
        {
            return new MonedaViewModel
            {
                mone_Nombre = "Bitcoin",
                mone_Abreviatura = "BTC",
                pais_Id = 24,
                usua_Creacion = 3,
                mone_FechaCreacion = DateTime.Now

            };
        }


        public static MonedaViewModel EditarMockMonedas()
        {
            return new MonedaViewModel
            {
                mone_Id = 21,
                mone_Nombre = "Bitcoin",
                mone_Abreviatura = "BTC",
                pais_Id = 24,
                usua_Modificacion = 3
            };
        }

    }
}
