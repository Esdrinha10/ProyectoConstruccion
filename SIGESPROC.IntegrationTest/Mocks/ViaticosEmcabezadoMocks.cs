using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class ViaticosEmcabezadoMocks
    {
        public static tbViaticosEncabezados CrearMoskViaticoEmcabezado()
        {
            return new tbViaticosEncabezados
            {
                vien_MontoEstimado = 240,
                vien_TotalGastado = 150.50M,
                vien_TotalReconocido = 50,
                vien_FechaEmicion = DateTime.Now,
                empl_Id = 30,
                Proy_Id = 4,
                usua_Creacion = 3,
                vien_FechaCreacion = DateTime.Now
            };
        }

        public static tbViaticosEncabezados EditarMoskViaticoEmcabezado()
        {
            return new tbViaticosEncabezados
            {
                vien_Id = 15,
                vien_MontoEstimado = 240,

                vien_TotalGastado = 150.50M,
                vien_TotalReconocido = 50,

                vien_FechaEmicion = DateTime.Now,
                empl_Id = 30,
                Proy_Id = 4,
                usua_Modificacion = 3,
                vien_FechaModificacion = DateTime.Now
            };
        }
    }
}
