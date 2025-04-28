using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGESPROC.Entities.Entities;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class BancosMocks
    {
        public static tbBancos CrearMockBancos()
        {
            return new tbBancos
            {
                banc_Descripcion = "Prueba Banco Mock",
                usua_Creacion = 3,
                banc_FechaCreacion = DateTime.Now
            };

        }

        public static tbBancos EditarMockBancos()
        {
            return new tbBancos
            {
                banc_Id = 1,
                banc_Descripcion = "Prueba Banco Mock 2",
                usua_Modificacion = 3,
                banc_FechaModificacion = DateTime.Now
            };

        }
    }
}
