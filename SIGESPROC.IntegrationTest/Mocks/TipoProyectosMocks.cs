using SIGESPROC.Entities.Entities;
using System;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public static class TipoProyectosMocks
    {

        public static tbTiposProyecto CrearMockTipoProyectos()
        {
            return new tbTiposProyecto
            {
                tipr_Descripcion = "Remodelación",
                usua_Creacion = 3,
                tipr_FechaCreacion = DateTime.Now

            };
        }


        public static tbTiposProyecto EditarMockTipoProyectos()
        {
            return new tbTiposProyecto
            {
                tipr_Id = 5,
                tipr_Descripcion = "Remodelación",
                usua_Modificacion = 3,
                tipr_FechaModificacion = DateTime.Now
            };
        }

    }
}
