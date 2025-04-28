using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class MaquinariaPorProveedorMocks
    {
        public static tbMaquinariasPorProveedores CrearMoskMaquinariasPorProveedores()
        {
            return new tbMaquinariasPorProveedores
            {
                mapr_PrecioCompra = 1000,
                maqu_Id = 0,
                prov_Id = 5,
                usua_Creacion = 3,
                mapr_FechaCreacion = DateTime.Now,
                nive_Id = 5,
                mapr_DiaHora = 1,
            };

        }

        public static tbMaquinariasPorProveedores EditarMoskMaquinariasPorProveedores()
        {
            return new tbMaquinariasPorProveedores
            {
                mapr_Id = 32,
                mapr_PrecioCompra = 1000,
                maqu_Id = 0,
                prov_Id = 5,
                usua_Creacion = 3,
                mapr_FechaCreacion = DateTime.Now,
                nive_Id = 5,
                mapr_DiaHora = 1,
            };

        }
    }
}
