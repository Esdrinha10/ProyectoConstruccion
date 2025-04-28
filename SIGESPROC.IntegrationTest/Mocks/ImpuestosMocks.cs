using SIGESPROC.Entities.Entities;
using System;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public static class ImpuestosMocks
    {

        public static tbImpuestos CrearMockImpuestos()
        {
            return new tbImpuestos
            {
                impu_Porcentaje = 10,
                usua_Creacion = 3,
                impu_FechaCreacion = DateTime.Now

            };
        }



        public static tbImpuestos EditarMockImpuestos()
        {
            return new tbImpuestos
            {
                impu_Id = 1,
                impu_Porcentaje = 15,
                usua_Modificacion = 3,
                impu_FechaModificacion = DateTime.Now
            };
        }

    }
}
