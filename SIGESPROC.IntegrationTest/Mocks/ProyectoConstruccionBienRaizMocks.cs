using SIGESPROC.Common.Models.ModelsBienRaiz;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;

namespace SIGESPROC.IntegrationTest.Mocks
{
   public class ProyectoConstruccionBienRaizMocks
    {
        public static ProyectoConstruccionBienRaizViewModel CrearMockProyectooConstruccionBienRaiz()
        {
            return new ProyectoConstruccionBienRaizViewModel
            {
                terr_Id = 2,
                proy_Id = 1,
                usua_Creacion = 3,
                pcon_FechaCreacion = DateTime.Now
            };
        }

        public static ProyectoConstruccionBienRaizViewModel EditarMockProyectoConstruccionBienRaiz()
        {
            return new ProyectoConstruccionBienRaizViewModel
            {
                pcon_Id = 2,
                terr_Id = 2,
                proy_Id = 1,
                usua_Creacion = 3,
                pcon_FechaCreacion = DateTime.Now
            };
        }
    }
}
