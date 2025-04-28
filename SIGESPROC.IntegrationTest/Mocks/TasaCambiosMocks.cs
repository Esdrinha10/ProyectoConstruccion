using SIGESPROC.Entities.Entities;
using System;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public static class TasaCambiosMocks
    {

        public static tbTasasCambio CrearMockTasaCambios()
        {
            return new tbTasasCambio
            {
                mone_A = 1,
                mone_B = 10,
                taca_ValorA = 10,
                taca_ValorB = 15,
                usua_Creacion = 3,
                taca_FechaCreacion = DateTime.Now

            };
        }


        public static tbTasasCambio EditarMockTasaCambios()
        {
            return new tbTasasCambio
            {
                taca_Id = 5,
                mone_A = 1,
                mone_B = 10,
                taca_ValorA = 10,
                taca_ValorB = 15,
                usua_Modificacion = 3,
                taca_FechaModificacion = DateTime.Now
            };
        }

    }
}
