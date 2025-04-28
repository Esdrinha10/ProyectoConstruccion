using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class CiudadesMocks
    {
        public static tbCiudades CrearMockCiudades()
        {
            return new tbCiudades
            {
                ciud_Codigo = "0021",
                ciud_Descripcion = "Prueba",
                esta_Id = 18,
                usua_Creacion = 3,
                ciud_FechaCreacion = DateTime.Now,
            };
        }

        public static tbCiudades EditarMockCiudades()
        {
            return new tbCiudades
            {
                ciud_Id = 1,
                ciud_Codigo = "2020",
                ciud_Descripcion = "Prueba2",
                esta_Id = 1,
                usua_Modificacion = 3,
                ciud_FechaModificiacion = DateTime.Now,
            };
        }
    }
}
