using SIGESPROC.Common.Models.ModelsAcceso;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class PantallaPorRolMocks
    {
        public static tbPantallasPorRoles CrearMockPantallasPorRoles()
        {

            return new tbPantallasPorRoles
            {
                role_Id = 1,
                pant_Id = 2,
                usua_Creacion = 3
            };
        }
        public static PantallaPorRolViewModel EditarMockPantallasPorRoles()
        {

            return new PantallaPorRolViewModel
            {
                role_Id = 1,
                pant_Id = 2,
                usua_Creacion = 3
            };
        }
    }
}
