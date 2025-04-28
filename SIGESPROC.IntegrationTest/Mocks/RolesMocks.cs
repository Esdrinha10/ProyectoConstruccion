using SIGESPROC.Common.Models.ModelsAcceso;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class RolesMocks
    {
        public static tbRoles CrearMockRoles()
        {
            return new tbRoles
            {
                role_Id = 1,
                role_Descripcion = "Administrador",
                usua_Creacion = 3
            };
        }

        public static RolViewModel CrearMockRolViewModel()
        {
            return new RolViewModel
            {
                role_Id = 1,
                role_Descripcion = "Administrador",
                usua_Creacion = 3,
                pantallasSeleccionadas = new List<int> { 1, 2, 3 }
            };
        }

        public static RolViewModel EditarMocKRoles()
        {
            return new RolViewModel
            {
                role_Id = 1,
                role_Descripcion = "Administrador Modificado",
                usua_Modificacion = 3,
                pantallasSeleccionadas = new List<int> { 1, 2 }
            };
        }
    }
}