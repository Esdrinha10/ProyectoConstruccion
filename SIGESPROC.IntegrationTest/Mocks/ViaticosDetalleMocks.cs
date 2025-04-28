using SIGESPROC.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Mocks
{
    public static class ViaticosDetalleMocks
    {

        public static tbViaticosDetalles CrearMoskViaticoDetalle()
        {
            return new tbViaticosDetalles
            {
                vide_Descripcion = "Prueba",
                vide_ImagenFactura = "Imagen.jpg",
                vide_MontoGastado = 30,
                vien_Id = 10,
                cavi_Id = 10,
                vide_MontoReconocido = 500,
                usua_Creacion = 3,
                vide_FechaCreacion = DateTime.Now
            };

        }

        public static tbViaticosDetalles EditarMoskViaticoDetalle()
        {
            return new tbViaticosDetalles
            {
                vide_Id = 20,
                vide_Descripcion = "Prueba",
                vide_ImagenFactura = "Imagen.jpg",
                vide_MontoGastado = 30,
                vien_Id = 10,
                cavi_Id = 10,
                vide_MontoReconocido = 500,
                usua_Creacion = 3,
                vide_FechaCreacion = DateTime.Now
            };

        }

    }
}
