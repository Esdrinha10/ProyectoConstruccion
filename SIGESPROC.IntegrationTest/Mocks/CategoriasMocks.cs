using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class CategoriasMocks
    {
        public static tbCategorias CrearMockCategorias()
        {
            return new tbCategorias
            {
                cate_Descripcion = "Prueba",
                usua_Creacion = 3,
                cate_FechaCreacion = DateTime.Now,
            };

        }

        public static tbCategorias EditarMockCategorias()
        {
            return new tbCategorias
            {
                cate_Id = 1,
                cate_Descripcion = "Prueba",
                usua_Modificacion = 3,
                cate_FechaModificacion = DateTime.Now,
            };

        }
    }
}
