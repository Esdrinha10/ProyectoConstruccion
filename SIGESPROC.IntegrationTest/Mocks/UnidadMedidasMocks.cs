using SIGESPROC.Entities.Entities;
using System;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public static class UnidadMedidasMocks
    {

        public static tbUnidadesMedida CrearMockUnidadMedidas()
        {
            return new tbUnidadesMedida
            {
                unme_Nombre = "Centimetro",
                unme_Nomenclatura = "CM",
                usua_Creacion = 3,
                unme_FechaCreacion = DateTime.Now

            };
        }


        public static tbUnidadesMedida EditarMockUnidadMedidas()
        {
            return new tbUnidadesMedida
            {
                unme_Id = 5,
                unme_Nombre = "Centimetro",
                unme_Nomenclatura = "CM",
                usua_Modificacion = 3,
                unme_FechaModificacion = DateTime.Now
            };
        }

    }
}
