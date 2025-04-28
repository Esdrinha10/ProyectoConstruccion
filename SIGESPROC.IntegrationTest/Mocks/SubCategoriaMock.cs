using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class SubCategoriaMock
    {
        public static tbSubcategorias CrearMoskSubCategoria()
        {
            return new tbSubcategorias
            {
                suca_Descripcion = "Prueba",
                cate_Id = 3,
                usua_Creacion = 3,
                suca_FechaCreacion = DateTime.Now
            };

        }

        public static tbSubcategorias EditarMoskSubCategoria()
        {
            return new tbSubcategorias
            {
                suca_Id = 71,
                suca_Descripcion = "Prueba",
                cate_Id = 3,
                usua_Creacion = 3,
                suca_FechaCreacion = DateTime.Now
            };

        }
    }
}
