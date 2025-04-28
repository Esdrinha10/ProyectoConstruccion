using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public class CategoriaViaticoMocks
    {
        public static tbCategoriasViaticos CrearMockCategoriaViatico()
        {
            return new tbCategoriasViaticos
            {
                cavi_Descripcion = "Nueva Categoria",
                usua_Creacion = 3,
                cavi_FechaCreacion = DateTime.Now
            };
        }

        public static tbCategoriasViaticos ActualizarMockCategoriaViatico()
        {
            return new tbCategoriasViaticos
            {
                cavi_Id = 8,
                cavi_Descripcion = "Nueva Categoria",
                usua_Creacion = 3,
                cavi_FechaCreacion = DateTime.Now
            };
        }
    }
}
