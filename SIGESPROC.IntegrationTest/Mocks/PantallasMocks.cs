using SIGESPROC.Common.Models.ModelsAcceso;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class PantallasMocks
    {
        public static tbPantallas CrearMockPantallas()
        {

            return new tbPantallas
            {
                pant_Id = 1,
                pant_Descripcion = "Pantalla Actualizada",
                usua_Creacion = 3
            };
        }
        public static PantallaViewModel EditarMockPantallas()
        {

            return new PantallaViewModel
            {
                pant_Id = 1,
                pant_Descripcion = "Pantalla Actualizada",
                usua_Modificacion = 3
            };
        }
    }
}
