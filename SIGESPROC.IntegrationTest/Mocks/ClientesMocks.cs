using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class ClientesMocks
    {
        public static tbClientes CrearMockClientes()
        {
            return new tbClientes
            {
                clie_DNI = "1804200502571",
                clie_Nombre = "Astrid",
                clie_Apellido = "Martilla",
                clie_CorreoElectronico = "astridm@gmail.com",
                clie_Telefono = "54212153",
                clie_FechaNacimiento = DateTime.Now,
                clie_Sexo = "f",
                clie_DireccionExacta = "Barrio San Ben",
                ciud_Id = 1,
                civi_Id = 2,
                usua_Creacion = 3,
                clie_FechaCreacion = DateTime.Now,
                clie_Tipo = "b"
            };
            
        }

        public static tbClientes EditarMockClientes()
        {
            return new tbClientes
            {
                clie_Id = 5,
                clie_DNI = "1804200502571",
                clie_Nombre = "Astrid",
                clie_Apellido = "Martilla",
                clie_CorreoElectronico = "astridm@gmail.com",
                clie_Telefono = "54212153",
                clie_FechaNacimiento = DateTime.Now,
                clie_Sexo = "f",
                clie_DireccionExacta = "Barrio San Ben",
                ciud_Id = 1,
                civi_Id = 2,
                usua_Modificacion = 3,
                clie_FechaModificacion = DateTime.Now,
                clie_Tipo = "b"
            };
        }
    }
}
