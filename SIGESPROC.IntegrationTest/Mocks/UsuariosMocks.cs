using SIGESPROC.Common.Models.ModelsAcceso;
using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class UsuariosMocks
    {
        public static tbUsuarios CrearMockUsuarios()
        {

            return new tbUsuarios
            {
                usua_Id = 74,
                usua_Usuario = "usuarioActualizado",
                usua_Clave = "claveNueva",
                usua_EsAdministrador = true,
                empl_Id = 108,
                role_Id = 63,
                usua_Creacion = 3
            };
        }
        public static UsuarioViewModel EditarMockUsuarios()
        {

            return new UsuarioViewModel
            {
                usua_Id = 74,
                usua_Usuario = "admin",
                usua_Clave = "123",
                usua_EsAdministrador = true,
                empl_Id = 108,
                role_Id = 63,
                usua_Modificacion = 3
            };
        }
    }
}
